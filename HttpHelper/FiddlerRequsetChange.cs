using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public class FiddlerRequsetChange
    {
        public FiddlerUriMatch UriMatch { get; set; }
        public HttpRequest HttpRawRequest { get; set; }

        public ContentModific UriModific { get; set; }

        public List<KeyValuePair<string, string>> HeadAddList { get; set; }

        public List<string> HeadDelList { get; set; }

        public ContentModific BodyModific { get; set; }
    }
}
