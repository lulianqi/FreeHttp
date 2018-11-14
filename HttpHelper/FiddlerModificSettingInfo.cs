using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    public class FiddlerModificSettingInfo
    {
        public bool IsDefaultEnableRule { get; set; }
        public bool IsSkipTlsHandshake { get; set; }
        public bool IsOnlyMatchFistTamperRule { get; set; }

        public FiddlerModificSettingInfo(bool isDefaultEnableRule, bool isSkipTlsHandshake, bool isOnlyMatchFistTamperRule)
        {
            IsDefaultEnableRule = isDefaultEnableRule;
            IsSkipTlsHandshake = isSkipTlsHandshake;
            IsOnlyMatchFistTamperRule = isOnlyMatchFistTamperRule;
        }
    }
}
