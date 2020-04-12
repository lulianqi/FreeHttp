using FreeHttp.AutoTest.ParameterizationContent;
using FreeHttp.AutoTest.RunTimeStaticData;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    [DataContract]
    public class ParameterHttpRequest : HttpRequest
    {
        [DataMember]
        public CaseParameterizationContent ParameterizationContent{ get; set; }

        [NonSerialized] 
        private ActuatorStaticDataCollection actuatorStaticDataCollection;

        public ParameterHttpRequest()
        {
            actuatorStaticDataCollection = null;
        }
        public ParameterHttpRequest(string yourRequest, bool isParameter)
        {
            ParameterizationContent = new CaseParameterizationContent(yourRequest, isParameter);
            ParameterizationContent.encodetype = ParameterizationContentEncodingType.encode_default;
            base.OriginSting = yourRequest;
        }

        private ParameterHttpRequest(HttpRequest httpRequest)
        {
            RequestLine = httpRequest.RequestLine;
            RequestHeads = httpRequest.RequestHeads;
            RequestEntity = httpRequest.RequestEntity;
            OriginSting = httpRequest.OriginSting;
        }

        public void SetActuatorStaticDataCollection(ActuatorStaticDataCollection yourStaticDataCollection)
        {
            actuatorStaticDataCollection = yourStaticDataCollection;
        }

        public new byte[] GetRawHttpRequest()
        {
            return base.GetRawHttpRequest();
        }

        public byte[] GetRawHttpRequest(out string errorMes, out NameValueCollection nameValueCollection)
        {
            nameValueCollection = null;
            errorMes = null;
            if(ParameterizationContent.hasParameter)
            {
                nameValueCollection = new NameValueCollection();
                string newOriginSting = ParameterizationContent.GetTargetContentData(actuatorStaticDataCollection, nameValueCollection, out errorMes);
                HttpRequest tempHttpRequest = HttpRequest.GetHttpRequest(newOriginSting);
                //tempHttpRequest.SetAutoContentLength();
                return tempHttpRequest.GetRawHttpRequest();
            }
            return base.GetRawHttpRequest();
        }

        public HttpRequest UpdateHttpRequest(out string errorMes, out NameValueCollection nameValueCollection)
        {
            nameValueCollection = null;
            errorMes = null;
            if (ParameterizationContent.hasParameter)
            {
                nameValueCollection = new NameValueCollection();
                string newOriginSting = ParameterizationContent.GetTargetContentData(actuatorStaticDataCollection, nameValueCollection, out errorMes);
                HttpRequest tempHttpRequest = HttpRequest.GetHttpRequest(newOriginSting);  // it may throw exception
                tempHttpRequest.SetAutoContentLength(); // if hasParameter SetAutoContentLength
                return tempHttpRequest;
            }
            return this;
        }

        public static ParameterHttpRequest GetHttpRequest(string yourRequest, bool isParameter)
        {
            ParameterHttpRequest returnPrameterHttpRequest;
            returnPrameterHttpRequest = new ParameterHttpRequest(HttpRequest.GetHttpRequest(yourRequest));
            returnPrameterHttpRequest.ParameterizationContent = new CaseParameterizationContent(yourRequest, isParameter);
            return returnPrameterHttpRequest;
        }

        public static ParameterHttpRequest GetHttpRequest(string yourRequest, bool isParameter, ActuatorStaticDataCollection yourActuatorStaticDataCollection)
        {
            ParameterHttpRequest returnPrameterHttpRequest = GetHttpRequest(yourRequest, isParameter);
            //returnPrameterHttpRequest.actuatorStaticDataCollection = yourActuatorStaticDataCollection;
            returnPrameterHttpRequest.SetActuatorStaticDataCollection(yourActuatorStaticDataCollection);
            return returnPrameterHttpRequest;
        }
        
    }
}
