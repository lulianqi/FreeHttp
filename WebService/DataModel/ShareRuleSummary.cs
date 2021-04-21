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

            public string ShowTag
            {
                get
                {
                    return $"...{Token.Substring(Token.Length > 22 ? 22 : 0)} [{Remark}]";
                }
            }
        }

        public List<RuleToken> ShareRuleList { get; set; }
        public List<RuleToken> PrivateRuleList { get; set; }
    }
}
