using FreeHttp.AutoTest.RunTimeStaticData;
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

        public async Task UploadRulesAsync<T1, T2>(List<T1> requestRules, List<T2> responseRules , ActuatorStaticDataCollection staticDataCollection =null) where T1 : IFiddlerHttpTamper where T2: IFiddlerHttpTamper
        {
            MultipartFormDataContent multipartFormData = new MultipartFormDataContent();
            if(staticDataCollection!=null)
            {
                multipartFormData.Add(new StringContent(MyJsonHelper.JsonDataContractJsonSerializer.ObjectToJsonStr(staticDataCollection)), "staticData");
            }
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
                await httpClient.PostAsync(string.Format(@"{0}freehttp/RuleDetails?ruleversion={1}&{2}", ConfigurationData.BaseUrl, UserComputerInfo.GetRuleVersion(), WebService.UserComputerInfo.GetFreeHttpUser()), multipartFormData);
            }
            catch(Exception ex)
            {
                await RemoteLogService.ReportLogAsync(ex.ToString(), RemoteLogService.RemoteLogOperation.RuleUpload, RemoteLogService.RemoteLogType.Error);
            }
            finally
            {
                
            }
        }
    }
}
