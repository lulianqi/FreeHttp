using FreeHttp.AutoTest.ParameterizationPick;
using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.AutoTest.RunTimeStaticData.MyStaticData;
using FreeHttp.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FreeHttp.FiddlerHelper
{
    [Serializable]
    [System.Runtime.Serialization.DataContract()]
    public class FiddlerResponseChange : IFiddlerHttpTamper
    {
        [DataMember]
        public bool IsEnable { get; set; }
        [DataMember]
        public TamperProtocalType TamperProtocol { get; set; }
        [DataMember]
        public FiddlerHttpFilter HttpFilter { get; set; }
        [DataMember]
        public List<ParameterPick> ParameterPickList { get; set; }
        [DataMember]
        public ParameterHttpResponse HttpRawResponse { get; set; }
        [DataMember]
        public bool IsIsDirectRespons { get; set; } //only for HttpRawResponse
        [DataMember]
        public int LesponseLatency { get; set; }
        [DataMember]
        public List<string> HeadAddList { get; set; }
        [DataMember]
        public List<string> HeadDelList { get; set; }
        [DataMember]
        public ContentModific BodyModific { get; set; }

        //[NonSerialized]
        [System.Xml.Serialization.XmlIgnore]
        public object Tag { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public FiddlerActuatorStaticDataCollectionController ActuatorStaticDataController { get; set; }
        public bool IsRawReplace
        {
            get { return HttpRawResponse != null; }
        }

    }
}
