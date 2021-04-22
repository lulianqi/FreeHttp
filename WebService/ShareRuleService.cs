using FreeHttp.FiddlerHelper;
using FreeHttp.MyHelper;
using FreeHttp.WebService.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class ShareRuleService: RuleReportService
    {
        public ShareRuleSummary NowShareRuleSummary { get;private set; }
        public RuleDetails NowSaveRuleDetails { get; set; }

        private string _userInfoStr;

        public ShareRuleService(string personalUserInfoStr)
        {
            base.UploadRuleUrl = @"{0}freehttp/sharerule/create?ruleversion={1}&{2}";
            NowShareRuleSummary = new ShareRuleSummary();
            _userInfoStr = personalUserInfoStr;
        }

        public async Task<ShareRuleSummary> GetShareRuleSummaryAsync()
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync($"{ConfigurationData.BaseUrl}freehttp/sharerule/sharerulesummary?{_userInfoStr}");

                if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    await RemoteLogService.ReportLogAsync("GetPersonalShareRulesAsync fail", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                }
                else
                {
                    NowShareRuleSummary = MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<ShareRuleSummary>(await responseMessage.Content.ReadAsStringAsync());
                    if (NowShareRuleSummary == null)
                    {
                        await RemoteLogService.ReportLogAsync($"JsonStringToObject fail in【GetPersonalShareRulesAsync】 that {await responseMessage.Content.ReadAsStringAsync()}", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                    }
                    else
                    {
                        return NowShareRuleSummary;
                    }
                }
            }
            catch (Exception ex)
            {
                await RemoteLogService.ReportLogAsync(ex.ToString(), RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
            }

            return default;
        }


        public async Task<KeyValuePair<string, string>> SaveShareRules(string remark=null,bool isUploadStaticData=false)
        {
            string tempExecuteUrl = null;
            if (!string.IsNullOrEmpty(remark))
            {
                tempExecuteUrl = $"{{0}}freehttp/sharerule/create?remark={remark}&ruleversion={{1}}&{{2}}";
            }
            if(NowSaveRuleDetails==null || NowSaveRuleDetails.ModificHttpRuleCollection==null)
            {
                _ = RemoteLogService.ReportLogAsync("SaveShareRules fail in ShareRuleService that NowSaveRuleDetails is null", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                return default;
            }
            string response = await base.UploadRulesAsync<FiddlerRequestChange, FiddlerResponseChange>(
                NowSaveRuleDetails.ModificHttpRuleCollection?.RequestRuleList,
                NowSaveRuleDetails.ModificHttpRuleCollection?.ResponseRuleList, 
                isUploadStaticData? NowSaveRuleDetails.StaticDataCollection:null,
                tempExecuteUrl);
            BaseResultModel<string> httpResult = MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<BaseResultModel<string>>(response);
            if(httpResult==null)
            {
                _ = RemoteLogService.ReportLogAsync($"SaveShareRules fail in ShareRuleService that JsonDataContractJsonSerializer fial [{response}]", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
            }
            else
            {
                return new KeyValuePair<string, string>(httpResult.Result, remark);
            }
            return default;
        }

    }
}
