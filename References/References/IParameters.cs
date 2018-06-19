
namespace DocumentInterfaces
{
    /// <summary>
    /// A Process Message is used to send back contextual information for a business transaction.  This can
    /// include messages that indicate successful processing, informational messages and validation
    /// messages (for errors and warnings).
    /// </summary>
    public interface IParameters
    {
        /// <summary>
        /// Identifies what the the parameter relates to.
         string getIdentifier ();

        /// <summary>
        /// The value of the parameter
        /// </summary>
         string getText();

    }
}
