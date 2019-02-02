using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.ParameterizationPick
{
    
    [Serializable]
    public enum ParameterPickType
    {
        Str,
        Xml,
        Regex
    }


     [Serializable]
    public enum ParameterPickRange
    {
        Line,
        Heads,
        Entity
    }
}
