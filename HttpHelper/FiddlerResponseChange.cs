using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    public class FiddlerResponseChange : IFiddlerHttpTamper
    {
        public bool IsEnable { get; set; }
        public FiddlerUriMatch UriMatch { get; set; }
        public FiddlerHttpFilter HttpFilter { get; set; }
        public HttpResponse HttpRawResponse { get; set; }

        public bool IsIsDirectRespons { get; set; } //only for HttpRawResponse

        public int LesponseLatency { get; set; }

        public List<string> HeadAddList { get; set; }

        public List<string> HeadDelList { get; set; }

        public ContentModific BodyModific { get; set; }

        //[NonSerialized]
        [System.Xml.Serialization.XmlIgnore]
        public object Tag { get; set; }
        public bool IsRawReplace
        {
            get { return HttpRawResponse != null; }
        }

    }
}
