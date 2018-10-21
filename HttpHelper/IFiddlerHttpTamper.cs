using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    
    public interface IFiddlerHttpTamper
    {
        FiddlerUriMatch UriMatch { get; set; }

        bool IsRawReplace { get; }
    }
}
