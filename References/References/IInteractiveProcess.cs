using  DataContracts;
using  DocumentInterfaces;
using System.Collections.Generic;

namespace Ato.EN.IntegrationServices.Core.DocumentInterfaces
{
    /// <summary>
    /// In the interactive process messages from the various backends need to be added to process messages
    /// these messages will be mapped into the process message process 
    /// messages (for errors and warnings).
    /// </summary>
    public interface IInteractiveProcess : IProcessMessage
    {


        /// <summary>
        /// The severity of the process message indicates whether the message has been sent for information
        /// purposes or to indicate success, failure or warnings appropriate for a business transaction.
        /// </summary>
        ProcessMessageSeverity Severity
        {
            get;
            set;
        }
        /// <summary>
        /// The severity of the process message indicates whether the message has been sent for information
        /// purposes or to indicate success, failure or warnings appropriate for a business transaction.
        /// </summary>
        List<IParameters> Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the error Code
        /// </summary>
        string getErrorCode();

        /// <summary>
        /// Determins if messages should be suppressed
        /// </summary>
        bool suppress { get; set; }


    }
}
