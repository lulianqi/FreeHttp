using FreeHttp.FiddlerHelper;
using FreeHttp.MyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class RuleReportService
    {
        HttpClient httpClient;
        public RuleReportService()
        {
            httpClient = new HttpClient();
        }

        public async Task UploadRulesAsync<T1, T2>(List<T1> requestRules, List<T2> responseRules) where T1 : IFiddlerHttpTamper where T2: IFiddlerHttpTamper
        {
            MultipartFormDataContent multipartFormData = new MultipartFormDataContent();
            if(requestRules!=null)
            {
                foreach(var request in requestRules)
                {
                    multipartFormData.Add(new StringContent(MyJsonHelper.JsonDataContractJsonSerializer.ObjectToJsonStr(request)), "requestRule");
                }
            }
            if (responseRules != null)
            {
                foreach (var response in responseRules)
                {
                    multipartFormData.Add(new StringContent(MyJsonHelper.JsonDataContractJsonSerializer.ObjectToJsonStr(response)), "responseRule");
                }
            }

            try
            {
                await httpClient.PostAsync(string.Format(@"{0}freehttp/RuleDetails?user={1}", ConfigurationData.BaseUrl, WebService.UserComputerInfo.GetComputerMac()), multipartFormData);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                
            }
        }
    }
}
