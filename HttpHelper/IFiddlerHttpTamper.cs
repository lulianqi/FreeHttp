using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    public interface IFiddlerHttpTamper
    {
        bool IsEnable { get; set; }
        //FiddlerUriMatch UriMatch { get; set; }
        FiddlerHttpFilter HttpFilter { get; set; }
        bool IsRawReplace { get; }
    }
}
