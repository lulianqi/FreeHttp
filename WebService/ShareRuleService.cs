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
    public class ShareRuleService: RemoteRuleService
    {
        public ShareRuleSummary NowShareRuleSummary { get;private set; }
        public RuleDetails NowSaveRuleDetails { get; set; }
        public RuleDetails NowShowRuleDetails { get; set; }

        private string _userInfoStr;

        public ShareRuleService(string personalUserInfoStr)
        {
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

        public async Task<KeyValuePair<string, string>> SaveShareRulesAsync(string remark=null,bool isUploadStaticData=false)
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
            string response = await RemoteRuleService.UploadRulesAsync<FiddlerRequestChange, FiddlerResponseChange>(
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

        public async Task<bool> UpdateShareRulesAsync(string shareToken, bool isUploadStaticData = false)
        {
            string tempExecuteUrl = null;
            if (string.IsNullOrEmpty(shareToken))
            {
                return false;
            }
            tempExecuteUrl = $"{{0}}freehttp/sharerule/update?sharetoken={shareToken}&ruleversion={{1}}&{{2}}";
            if (NowSaveRuleDetails == null || NowSaveRuleDetails.ModificHttpRuleCollection == null)
            {
                _ = RemoteLogService.ReportLogAsync("SaveShareRules fail in ShareRuleService that NowSaveRuleDetails is null", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                return default;
            }
            string response = await RemoteRuleService.UploadRulesAsync<FiddlerRequestChange, FiddlerResponseChange>(
                NowSaveRuleDetails.ModificHttpRuleCollection?.RequestRuleList,
                NowSaveRuleDetails.ModificHttpRuleCollection?.ResponseRuleList,
                isUploadStaticData ? NowSaveRuleDetails.StaticDataCollection : null,
                tempExecuteUrl);
            BaseResultModel<string> httpResult = MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<BaseResultModel<string>>(response);
            if (httpResult == null)
            {
                _ = RemoteLogService.ReportLogAsync($"SaveShareRules fail in ShareRuleService that JsonDataContractJsonSerializer fial [{response}]", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
            }
            else
            {
                if(httpResult.Status== ReturnStatus.Success)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<RuleDetails> GetShareRuleDetailAsync(string token)
        {
            if(string.IsNullOrEmpty(token))
            {
                return null;
            }
            NowShowRuleDetails = await RemoteRuleService.GetRemoteRuleAsync(token, "{0}freehttp/ShareRule/get?shareToken={1}");
            return NowShowRuleDetails;
        }

        public async Task<bool> DeleteShareRuleDetailAsync(string token)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.DeleteAsync($"{ConfigurationData.BaseUrl}freehttp/sharerule?sharetoken={token}&{_userInfoStr}");

                if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMes =await responseMessage.Content.ReadAsStringAsync();
                    MyHelper.MyGlobalHelper.PutGlobalMessage(null,new MyGlobalHelper.GlobalMessageEventArgs(true, $"remove share token fial that :{errorMes}"));
                    await RemoteLogService.ReportLogAsync($"DeleteShareRuleDetailAsync fail : {errorMes}", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                }
                else
                {
                    if (MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<BaseResultModel<string>>(await responseMessage.Content.ReadAsStringAsync()) == null)
                    {
                        await RemoteLogService.ReportLogAsync($"JsonStringToObject fail in【DeleteShareRuleDetailAsync】 that {await responseMessage.Content.ReadAsStringAsync()}", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                await RemoteLogService.ReportLogAsync(ex.ToString(), RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
            }
            return false;
        }
    }
}
