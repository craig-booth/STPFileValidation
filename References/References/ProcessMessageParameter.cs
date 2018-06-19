using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using  DocumentInterfaces;

namespace DataContracts
{
    /// <summary>
    /// Parameters are used within ProcessMessageDocuments to pass contextual information.
    /// </summary>
    [DebuggerDisplay("Name = {Name}, Value = {Value}")]
   
    public class ProcessMessageParameter : IParameters
    {
        /// <summary>
        /// Gets or sets the message code.
        /// </summary>
        [XmlElement("Name")]
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the process message.
        /// </summary>
        [XmlElement("Value")]
        [DataMember(Name = "Value")]
        public string Value { get; set; }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageParameter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public ProcessMessageParameter(string name, string value) 
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessMessageParameter"/> class.
        /// </summary>
        public ProcessMessageParameter() 
        {
        }

        #endregion

        public string getIdentifier()
        {
           return this.Name;
        }

        public string getText()
        {
           return this.Value;
        }
    }
}
