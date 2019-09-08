using FreeHttp.AutoTest.ParameterizationPick;
using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.AutoTest.RunTimeStaticData.MyStaticData;
using FreeHttp.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.FiddlerHelper
{
    [Serializable]
    public class FiddlerRequestChange : IFiddlerHttpTamper
    {
        public bool IsEnable { get; set; }
        //public FiddlerUriMatch UriMatch { get; set; }
        public FiddlerHttpFilter HttpFilter{ get; set; }

        public List<ParameterPick> ParameterPickList { get; set; }

        public ParameterHttpRequest HttpRawRequest { get; set; }

        public ContentModific UriModific { get; set; }

        //public List<KeyValuePair<string, string>> HeadAddList { get; set; }
        public List<string> HeadAddList { get; set; }

        public List<string> HeadDelList { get; set; }

        public ContentModific BodyModific { get; set; }

        //[NonSerialized]
        [System.Xml.Serialization.XmlIgnore]
        public object Tag { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public FiddlerActuatorStaticDataCollectionController ActuatorStaticDataController { get; set; }
        public bool IsRawReplace
        {
            get { return HttpRawRequest != null; }
        }

       
    }
}
