using FreeHttp.AutoTest.ParameterizationPick;
using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.AutoTest.RunTimeStaticData.MyStaticData;
using FreeHttp.HttpHelper;
using FreeHttp.MyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FreeHttp.FiddlerHelper
{
    [Serializable]
    [System.Runtime.Serialization.DataContract()]
    public class FiddlerRequestChange : IFiddlerHttpTamper
    {
        private string _uid;

        /// <summary>
        /// get rule uid (not set this vaule in your business code) 
        /// </summary>
        [DataMember]
        public string RuleUid
        {
            get
            {
                if(_uid==null)
                {
                    _uid = Guid.NewGuid().ToString("D");
                }
                return _uid;
            }
            set
            {
                _uid = value;
            }
        }

        [DataMember]
        public bool IsEnable { get; set; }

        [DataMember]
        public bool IsHasParameter { get ; set; }

        [DataMember]
        public TamperProtocalType TamperProtocol { get ; set ; }
        [DataMember]
        public FiddlerHttpFilter HttpFilter{ get; set; }
        [DataMember]
        public List<ParameterPick> ParameterPickList { get; set; }
        [DataMember]
        public ParameterHttpRequest HttpRawRequest { get; set; }
        [DataMember]
        public ParameterContentModific UriModific { get; set; }

        [DataMember]
        public List<string> HeadAddList { get; set; }
        [DataMember]
        public List<string> HeadDelList { get; set; }
        [DataMember]
        public ParameterContentModific BodyModific { get; set; }

        //[NonSerialized]
        [System.Xml.Serialization.XmlIgnore]
        public object Tag { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public FiddlerActuatorStaticDataCollectionController ActuatorStaticDataController { get; set; }
        public bool IsRawReplace
        {
            get { return HttpRawRequest != null; }
        }
       
        public void SetHasParameter(bool hasParameter , ActuatorStaticDataCollection staticDataController = null)
        {
            if(staticDataController!=null)
            {
                ActuatorStaticDataController = new FiddlerActuatorStaticDataCollectionController(staticDataController);
            }
            IsHasParameter = hasParameter;

            if(IsRawReplace)
            {
                if(HttpRawRequest!=null)
                {
                    HttpRawRequest.SetUseParameterInfo(IsHasParameter, ActuatorStaticDataController.actuatorStaticDataCollection);
                }
            }
            else
            {
                if (UriModific != null && UriModific.ModificMode != ContentModificMode.NoChange)
                {
                    UriModific.SetUseParameterInfo(IsHasParameter, ActuatorStaticDataController.actuatorStaticDataCollection);
                }
                if (BodyModific != null && BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    BodyModific.SetUseParameterInfo(IsHasParameter, ActuatorStaticDataController.actuatorStaticDataCollection);
                }
            }
        }

        public object Clone()
        {
            FiddlerRequestChange cloneFiddlerRequestChange = this.MyDeepClone();
            cloneFiddlerRequestChange?.SetHasParameter(IsHasParameter, ActuatorStaticDataController?.actuatorStaticDataCollection);
            return cloneFiddlerRequestChange;
        }

    }
}
