using FreeHttp.AutoTest.ParameterizationContent;
using FreeHttp.AutoTest.RunTimeStaticData;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    public class ParameterHttpResponse : HttpResponse
    {
        public CaseParameterizationContent ParameterizationContent{ get; set; }

        [NonSerialized] 
        private ActuatorStaticDataCollection actuatorStaticDataCollection;
        public ParameterHttpResponse(string yourResponse, bool isParameter)
        {
            ParameterizationContent = new CaseParameterizationContent(yourResponse, isParameter);
            ParameterizationContent.encodetype = ParameterizationContentEncodingType.encode_default;
            base.OriginSting = yourResponse;
        }

        public ParameterHttpResponse()
        {
            actuatorStaticDataCollection = null;
        }

        private ParameterHttpResponse(HttpResponse httpResponse)
        {
            ResponseLine = httpResponse.ResponseLine;
            ResponseHeads = httpResponse.ResponseHeads;
            ResponseEntity = httpResponse.ResponseEntity;
            OriginSting = httpResponse.OriginSting;
        }

        public void SetActuatorStaticDataCollection(ActuatorStaticDataCollection yourStaticDataCollection)
        {
            actuatorStaticDataCollection = yourStaticDataCollection;
        }

        public new byte[] GetRawHttpResponse()
        {
            return base.GetRawHttpResponse();
        }

        public byte[] GetRawHttpResponse(out string errorMes, out NameValueCollection nameValueCollection)
        {
            nameValueCollection = null;
            errorMes = null;
            if(ParameterizationContent.hasParameter)
            {
                nameValueCollection = new NameValueCollection();
                string newOriginSting = ParameterizationContent.GetTargetContentData(actuatorStaticDataCollection, nameValueCollection, out errorMes);
                HttpResponse tempHttpResponse = HttpResponse.GetHttpResponse(newOriginSting);
                //tempHttpResponse.SetAutoContentLength();
                return tempHttpResponse.GetRawHttpResponse();
            }
            return base.GetRawHttpResponse();
        }

        public void UpdateHttpResponse(out string errorMes, out NameValueCollection nameValueCollection)
        {
            nameValueCollection = null;
            errorMes = null;
            if (ParameterizationContent.hasParameter)
            {
                nameValueCollection = new NameValueCollection();
                string newOriginSting = ParameterizationContent.GetTargetContentData(actuatorStaticDataCollection, nameValueCollection, out errorMes);
                HttpResponse tempHttpResponse = HttpResponse.GetHttpResponse(newOriginSting);
                ResponseLine = tempHttpResponse.ResponseLine;
                ResponseHeads = tempHttpResponse.ResponseHeads;
                ResponseEntity = tempHttpResponse.ResponseEntity;
            }
        }

        public static ParameterHttpResponse GetHttpResponse(string yourResponse, bool isParameter)
        {
            ParameterHttpResponse returnPrameterHttpResponse;
            returnPrameterHttpResponse = new ParameterHttpResponse(HttpResponse.GetHttpResponse(yourResponse));
            returnPrameterHttpResponse.ParameterizationContent = new CaseParameterizationContent(yourResponse, isParameter);
            return returnPrameterHttpResponse;
        }

        public static ParameterHttpResponse GetHttpResponse(string yourResponse, bool isParameter, ActuatorStaticDataCollection yourActuatorStaticDataCollection)
        {
            ParameterHttpResponse returnPrameterHttpResponse = GetHttpResponse(yourResponse, isParameter);
            //returnPrameterHttpResponse.actuatorStaticDataCollection = yourActuatorStaticDataCollection;
            returnPrameterHttpResponse.SetActuatorStaticDataCollection(yourActuatorStaticDataCollection);
            return returnPrameterHttpResponse;
        }
        
    }
}
