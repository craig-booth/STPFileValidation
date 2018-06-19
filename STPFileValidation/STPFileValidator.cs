using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;


using Ato.EN.IntegrationServices.Core;
using Ato.EN.IntegrationServices.CodeGenerationPAYEVNT;
using Ato.EN.IntegrationServices.CodeGenerationPAYEVNTEMP;

namespace STPFileValidation
{
    class STPFileValidator 
    {
        public IEnumerable<ValidationError> Validate(string fileName)
        {
            var errors = new List<ValidationError>();


            var payEvntConsumer = new PAYEVNT2018XmlConsumer();
            var payEvntEmpConsumer = new PAYEVNTEMP2018XmlConsumer();


            var stpFile = new STPFile(fileName);

            Stream stpStream;
            while ((stpStream = stpFile.GetChildDocument()) != null)
            {
                if (stpFile.DocumentType == "PAYEVNT")
                {
                    var payEvnt = payEvntConsumer.Consume(stpStream, true);
                    errors.AddRange(ValidatePAYEVNT(payEvnt, stpFile.DocumentId));
                }
                else if (stpFile.DocumentType == "PAYEVNTEMP")
                {
                    var payEvntEmp = payEvntEmpConsumer.Consume(stpStream, true);
                    errors.AddRange(ValidatePAYEVNTEMP(payEvntEmp, stpFile.DocumentId));
                }

                stpStream.Close();
            }

            stpFile.Close();


            if (errors.Count == 0)
            {
                errors.Add(new ValidationError()
                {
                    ErrorCode = "CMN.ATO.GEN.OK",
                    Severity = Severity.Success
                });
            }

            return errors;
        }

        public IEnumerable<ValidationError> ValidatePAYEVNT(PAYEVNT2018 payEvent, string documentId)
        {
            var validator = new PAYEVNT2018ValidatorSubmit();

            var result = validator.ValidateReport(payEvent, DateTime.Now);

            foreach (var message in result)
            {
                var error = new ValidationError()
                {
                    DocumentId = documentId,
                    DocumentType = "PAYEVNT_2018",
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

                yield return error;
            } 
        }

        public IEnumerable<ValidationError> ValidatePAYEVNTEMP(PAYEVNTEMP2018 payEventEmp, string documentId)
        {
            var validator = new PAYEVNTEMP2018ValidatorSubmit();
            var result = validator.ValidateReport(payEventEmp);

            foreach (var message in result)
            {
                var error = new ValidationError()
                {
                    DocumentId = documentId,
                    DocumentType = "PAYEVNTEMP_2018",
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

                yield return error;
            }
        }
    }

    public enum Severity { Error, Warning, Information, Success }
    public class ValidationError
    {
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public Severity Severity { get; set; }
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Location { get; set; }
    }
}
