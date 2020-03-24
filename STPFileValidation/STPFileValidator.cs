﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.IO;


using Ato.EN.IntegrationServices.Core;
using Ato.EN.IntegrationServices.CodeGenerationPAYEVNT;
using Ato.EN.IntegrationServices.CodeGenerationPAYEVNTEMP;

namespace STPFileValidation
{
    class STPFileValidator 
    {
        private STPFile _STPFile;
        private bool _XSDError;
        private string _NodeName;
        private string _PayrollId;

        private List<ValidationError> _Errors = new List<ValidationError>();
        public IEnumerable<ValidationError> Errors
        {
            get { return _Errors; }
        }

        public bool Validate(string fileName)
        {
            _Errors.Clear();

            _STPFile = new STPFile(fileName);
  
            Stream stpStream;
            while ((stpStream = _STPFile.GetChildDocument()) != null)
            {
                var memoryStream = new MemoryStream();
                stpStream.CopyTo(memoryStream);

                if (_STPFile.DocumentType == "PAYEVNT")
                    ValidatePAYEVNT(memoryStream);
                else if (_STPFile.DocumentType == "PAYEVNTEMP")
                    ValidatePAYEVNTEMP(memoryStream);

                stpStream.Close();
            }

            _STPFile.Close();


            if (_Errors.Count == 0)
            {
                _Errors.Add(new ValidationError()
                {
                    ErrorCode = "CMN.ATO.GEN.OK",
                    Severity = Severity.Success
                });

                return true;
            }
            else
                return false;
        }

        public bool ValidatePAYEVNT(Stream stream)
        {
            var successfull = true;

            try
            {
                stream.Position = 0;
                successfull &= ValidatePAYEVNTStructure(stream);

                stream.Position = 0;
                successfull &= ValidatePAYEVNTRules(stream);
            }
            catch
            {
                return false;
            }

            return successfull;
        }

        private bool ValidatePAYEVNTRules(Stream stream)
        {
            var successfull = true;

            var payEvntConsumer = new PAYEVNT2018XmlConsumer();
            var payEvnt = payEvntConsumer.Consume(stream, true);

            var validator = new PAYEVNT2018ValidatorSubmit();

            var result = validator.ValidateReport(payEvnt, DateTime.Now);

            foreach (var message in result)
            {
                var error = new ValidationError()
                {
                    DocumentId = _STPFile.DocumentId,
                    DocumentType = _STPFile.DocumentType,
                    ErrorCode = message.Code,
                    Description = message.Description,
                    LongDescription = message.LongDescription,
                    Location = message.Location
                };
                if (message.Severity == DataContracts.ProcessMessageSeverity.Warning)
                    error.Severity = Severity.Warning;
                else if (message.Severity == DataContracts.ProcessMessageSeverity.Information)
                    error.Severity = Severity.Information;
                else
                    error.Severity = Severity.Error;

                _Errors.Add(error);
                successfull = false;
            }

            return successfull;
        }

       private bool ValidatePAYEVNTEMP(Stream stream)
        {
            var successfull = true;

            try
            {
                stream.Position = 0;
                successfull &= ValidatePAYEVNTEMPStructure(stream);

                stream.Position = 0;
                successfull &= ValidatePAYEVNTEMPRules(stream);
            }
            catch
            {
                return false;
            }

            return successfull;
        }

        private bool ValidatePAYEVNTEMPRules(Stream stream)
        {
            var successfull = true;

            var payEvntEmpConsumer = new PAYEVNTEMP2018XmlConsumer();
            var payEvntEmp = payEvntEmpConsumer.Consume(stream, true);

            var validator = new PAYEVNTEMP2018ValidatorSubmit();
            var result = validator.ValidateReport(payEvntEmp);

            foreach (var message in result)
            {
                var error = new ValidationError()
                {
                    DocumentId = _STPFile.DocumentId,
                    DocumentType = _STPFile.DocumentType,
                    IdNumber = "",
                    TransferNumber = "",
                    ErrorCode = message.Code,
                    Description = message.Description,
                    LongDescription = message.LongDescription,
                    Location = message.Location
                };
                if (message.Severity == DataContracts.ProcessMessageSeverity.Warning)
                    error.Severity = Severity.Warning;
                else if (message.Severity == DataContracts.ProcessMessageSeverity.Information)
                    error.Severity = Severity.Information;
                else
                    error.Severity = Severity.Error;

                if (_PayrollId != "")
                {
                    error.IdNumber = _PayrollId.Substring(1, _PayrollId.Length - 1);
                    error.TransferNumber = _PayrollId.Substring(_PayrollId.Length, 1);
                }

                _Errors.Add(error);
                successfull = false;
            }

            return successfull;
        }

        private bool ValidatePAYEVNTStructure(Stream stream)
        {
            return ValidateAgainstXSD(stream, "http://www.sbr.gov.au/ato/payevnt", "ato.payevnt.0003.2018.01.00.xsd");
        }

        private bool ValidatePAYEVNTEMPStructure(Stream stream)
        {
            return ValidateAgainstXSD(stream, "http://www.sbr.gov.au/ato/payevntemp", "ato.payevntemp.0003.2018.01.00.xsd");
        }

        private bool ValidateAgainstXSD(Stream stream, string nameSpace, string xsdFile)
        {
            _XSDError = false;
            _NodeName = "";
            _PayrollId = "";

            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(nameSpace, xsdFile);
            settings.ValidationEventHandler += ValidationEventHandler;

            var xmlReader = XmlReader.Create(stream, settings);

            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        _NodeName = xmlReader.LocalName;
                    }
                    else if (xmlReader.NodeType == XmlNodeType.Text)
                    {
                        if (_NodeName == "EmploymentPayrollNumberId")
                        {
                            _PayrollId = xmlReader.Value;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                var error = new ValidationError()
                {
                    DocumentId = _STPFile.DocumentId,
                    DocumentType = _STPFile.DocumentType,
                    ErrorCode = "Invalid XML Document",
                    Description = e.Message,
                    LongDescription = "",
                    Location = _NodeName,
                    Severity = Severity.Error
                };
                if (_PayrollId != "")
                {
                    error.IdNumber = _PayrollId.Substring(0, _PayrollId.Length - 1);
                    error.TransferNumber = _PayrollId.Substring(_PayrollId.Length - 1, 1);
                }
                else
                {
                    error.IdNumber = "";
                    error.TransferNumber = "";
                }

                _Errors.Add(error);

                throw new XmlException();
            }

            return !_XSDError;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            var error = new ValidationError()
            {
                DocumentId = _STPFile.DocumentId,
                DocumentType = _STPFile.DocumentType,
                ErrorCode = "XSD Validation Error",
                Description = e.Message,
                LongDescription = "",
                Location = "",
                Severity = Severity.Error
            };

            if (_PayrollId != "")
            {
                error.IdNumber = _PayrollId.Substring(0, _PayrollId.Length - 1);
                error.TransferNumber = _PayrollId.Substring(_PayrollId.Length - 1, 1);
            }
            else
            {
                error.IdNumber = "";
                error.TransferNumber = "";
            }

            _Errors.Add(error);
            _XSDError = true;
        }
    }

    public enum Severity { Error, Warning, Information, Success }
    public class ValidationError
    {
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }  
        public string IdNumber { get; set; }
        public string TransferNumber { get; set; }
        public Severity Severity { get; set; }
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Location { get; set; }

        public string ErrorLocation
        {
            get
            {
                if (DocumentType == "PAYEVNTEMP")
                    return "Employee " + IdNumber + ", Transfer " + TransferNumber + " (Document " + DocumentId + ") : " + Location;
                else
                    return "Employer Information (Document " + DocumentId + ") : " + Location;
            }
        }
    }
}
