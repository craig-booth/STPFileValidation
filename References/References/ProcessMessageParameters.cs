using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using  DocumentInterfaces;

namespace DataContracts
{
    /// <summary>
    /// Represents a collection of <see cref="ProcessMessageDocument"/> objects.
    /// </summary>
    [DebuggerDisplay("Count = {Count}, Item[0] = {DebugItemZero}")]
  
    public class ProcessMessageParameters : List<IParameters> 
    {
    }
}
