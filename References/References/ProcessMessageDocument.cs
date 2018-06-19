
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using  DocumentInterfaces; 
using System.Collections.Generic;

namespace DataContracts
{

    /// <summary>
    /// A process messages document used for passing messages within an interaction.
    /// </summary>
    [XmlInclude(typeof(ProcessMessageDocument))]
    [DebuggerDisplay("Severity = {Severity}, Code = {Code}, Message = {Description}")]
   
    public class ProcessMessageDocument : IProcessMessage
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageDocument"/> class.
        /// </summary>
        public ProcessMessageDocument() 
        {
            this.Severity = ProcessMessageSeverity.Information;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageDocument"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public ProcessMessageDocument(string code) : this()
        {
            this.Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageDocument"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="severity">The severity.</param>
        public ProcessMessageDocument(string code, ProcessMessageSeverity severity) : this(code)
        {
            this.Severity = severity;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the message code.
        /// </summary>
        [XmlElement("Code")]
        [DataMember(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ProcessMessageSeverity"/>.
        /// </summary>
        /// <remarks>The default value is <see cref="ProcessMessageSeverity.Information"/>.</remarks>
        [XmlElement("Severity")]
        [DataMember(Name = "Severity")]
        public ProcessMessageSeverity Severity { get; set; }

        /// <summary>
        /// The severity of the process message indicates whether the message has been sent for information
        /// purposes or to indicate success, failure or warnings appropriate for a business transaction.
        /// </summary>
        [XmlIgnore()]
        public string SeverityAsString
        {
            get { return Severity.ToString(); }
            set
            {
                this.Severity = (ProcessMessageSeverity)Enum.Parse(typeof(ProcessMessageSeverity), value);
            }
        }

        /// <summary>
        /// Gets or sets the location of the process message
        /// </summary>
        [XmlElement("Location")]
        [DataMember(Name = "Location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the process message category.
        /// </summary>
        [XmlElement("CategoryCode")]
        [DataMember(Name = "CategoryCode")]
        public string CategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the property name relevent to the process message.
        /// </summary>
        [XmlElement("PropertyName")]
        [DataMember(Name = "PropertyName")]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the process message description.
        /// </summary>
        [XmlElement("Description")]
        [DataMember(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the process message long description.
        /// </summary>
        [XmlElement("LongDescription")]
        [DataMember(Name = "LongDescription")]
        public string LongDescription { get; set; }

        /// <summary>
        /// Used to determine what business document this error refers to
        /// </summary>
        [XmlElement("DocumentSequence")]
        [DataMember(Name = "DocumentSequence", IsRequired=false, EmitDefaultValue=false)]
        public string DocumentSequence { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        [XmlElement("Parameters")]
        [DataMember(Name = "Parameters", IsRequired = false, EmitDefaultValue = false)]
        public ProcessMessageParameters Parameters { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            string response = null;

            response = "Code: " + this.Code + Environment.NewLine +
                  "Description: " + this.Description + Environment.NewLine +
                  "Location: " + this.Location + Environment.NewLine +
                  "Long Description: " + this.LongDescription + Environment.NewLine +
                  "Severity: " + this.SeverityAsString;
            return response;

        }
        #endregion

         /// <summary>
        /// Code is already in the correct format
        /// </summary>
        /// <returns>The error code for the message</returns>
        public String getErrorCode()
        {
            return this.Code;
        }



        //List<IParameters> IInteractiveProcess.Parameters
        //{
        //    get
        //    {
        //        List<IParameters> response = new List<IParameters>();
        //        if (this.Parameters == null)
        //            response.AddRange(this.Parameters);
        //        return response;
        //    }
        //    set
        //    {
        //        this.Parameters = new ProcessMessageParameters();
        //        foreach (IParameters param in value)
        //        {
        //            this.Parameters.Add(new ProcessMessageParameter(param.getIdentifier(),param.getText()));
        //        }
        //    }
        //}

        public bool suppress { get; set; }
    }

}
