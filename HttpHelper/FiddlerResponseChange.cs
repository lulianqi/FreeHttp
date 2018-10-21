using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    class FiddlerResponseChange : IFiddlerHttpTamper
    {
        public FiddlerUriMatch UriMatch { get; set; }
        public HttpResponse HttpRawResponse { get; set; }

        public bool IsIsDirectRespons { get; set; } //only for HttpRawResponse

        public List<string> HeadAddList { get; set; }

        public List<string> HeadDelList { get; set; }

        public ContentModific BodyModific { get; set; }


        public bool IsRawReplace
        {
            get { return HttpRawResponse != null; }
        }
    }
}
