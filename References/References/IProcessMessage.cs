
namespace  DocumentInterfaces
{
    /// <summary>
    /// A Process Message is used to send back contextual information for a business transaction.  This can
    /// include messages that indicate successful processing, informational messages and validation
    /// messages (for errors and warnings).
    /// </summary>
    public interface IProcessMessage
    {
        /// <summary>
        /// A unique code for the process message.  This code will be unique to at least the current business
        /// transaction and preferably should be unique over all business transactions.  
        /// It is envisaged that 3rd party software providers will use the message code for their own message 
        /// file.  
        /// For example software providers will need to change a web service message to one that makes sense
        /// for their own user interface.
        /// </summary>
        string Code
        {
            get;
            set;
        }

        /// <summary>
        /// The severity of the process message indicates whether the message has been sent for information
        /// purposes or to indicate success, failure or warnings appropriate for a business transaction.
        /// </summary>
        string SeverityAsString
        {
            get;
            set;
        }

        /// <summary>
        /// Allows for categorizing of messages - this can be dependant upon the particular business
        /// transaction that is being processed.
        /// </summary>
        string CategoryCode
        {
            get;
            set;
        }

        /// <summary>
        /// Used to determine what business document this error refers to
        /// </summary>
        /// <remarks>Largely created to support the SBR program a string rather than a number has been used in order to keep this more general and reduce the risk of SBR changing this to some other type </remarks>
        string DocumentSequence { get; set; }

        /// <summary>
        /// Where appropriate this is used to indicate the location within the incoming business transaction
        /// message that the message pertains to.  
        /// </summary>
        string Location
        {
            get;
            set;
        }

        /// <summary>
        /// Where appropriate this is used to indicate the property within the incoming business transaction
        /// message that the message pertains to.
        /// </summary>
        string PropertyName
        {
            get;
            set;
        }

        /// <summary>
        /// Contains the text for the message.  3rd party software providers should not depend upon the text
        /// for this message rather they should use the Code value.
        /// </summary>
        string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Can optionally contain a more detailed description of the error message.
        /// </summary>
        string LongDescription
        {
            get;
            set;
        } 
    }
}
