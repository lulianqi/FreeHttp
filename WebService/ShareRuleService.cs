using FreeHttp.FiddlerHelper;
using FreeHttp.WebService.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class ShareRuleService: RuleReportService
    {
        public Dictionary<string, string> PersonalShareRules { get; private set; }
        public RuleDetails NowSaveRuleDetails { get; set; }

        private string _userInfoStr;

        public ShareRuleService(string personalUserInfoStr)
        {
            base.UploadRuleUrl = @"{0}freehttp/sharerule/create?ruleversion={1}&{2}";
            PersonalShareRules = new Dictionary<string, string>();
            _userInfoStr = personalUserInfoStr;
        }

        public async Task<Dictionary<string, string>> GetPersonalShareRulesAsync()
        {
            return PersonalShareRules;
        }


        public async Task<KeyValuePair<string, string>> SaveShareRules()
        {
            if(NowSaveRuleDetails==null || NowSaveRuleDetails.ModificHttpRuleCollection==null)
            {
                _ = RemoteLogService.ReportLogAsync("SaveShareRules fail in ShareRuleService that NowSaveRuleDetails is null", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                return default;
            }
            await base.UploadRulesAsync<FiddlerRequestChange, FiddlerResponseChange>(null, null);
            return default;
        }

    }
}
