using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService.DataModel
{
    public class ShareRuleSummary
    {
        public class RuleToken
        {
            public string Token { get; set; }
            public string Remark { get; set; }
        }

        public List<RuleToken> ShareRuleList { get; set; }
        public List<RuleToken> PrivateRuleList { get; set; }
    }
}
