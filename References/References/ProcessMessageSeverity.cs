using System.Runtime.Serialization;

namespace DataContracts
{
    /// <summary>
    /// Represents the severity of a process message.
    /// </summary> 
    public enum ProcessMessageSeverity
    {
        /// <summary>Indicates an error message.</summary>
        [EnumMember()]
        Error = 0,

        /// <summary>Indicates a partial message.</summary>
        [EnumMember()]
        Partial = 1,        

        /// <summary>Indicates a warning message.</summary>
        [EnumMember()]
        Warning = 2,

        /// <summary>Indicates an information message.</summary>
        [EnumMember()]
        Information = 3,

        /// <summary>Indicates an Progressive message.</summary>
        [EnumMember()]
        Progressive = 4                
    }

}
