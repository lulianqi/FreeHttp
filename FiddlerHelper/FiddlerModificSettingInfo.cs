using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.FiddlerHelper
{
    [Serializable]
    public class FiddlerModificSettingInfo
    {
        /// <summary>
        /// is the rule will enable when the application load
        /// </summary>
        public bool IsDefaultEnableRule { get; set; }

        /// <summary>
        /// the rule will skip tls handshake when it is true
        /// </summary>
        public bool IsSkipConnectTunnels { get; set; }

        /// <summary>
        /// if it is true the FiddlerFreeHttp will only match the fist request or response rule 
        /// </summary>
        public bool IsOnlyMatchFistTamperRule { get; set; }

        /// <summary>
        /// if it is sync TamperRule in server
        /// </summary>
        public bool IsSyncTamperRule { get; set; }

        public FiddlerModificSettingInfo():this(false,true, false ,true)
        {
            
        }
        public FiddlerModificSettingInfo(bool isDefaultEnableRule, bool isSkipTlsHandshake, bool isOnlyMatchFistTamperRule ,bool isSyncTamperRule)
        {
            IsDefaultEnableRule = isDefaultEnableRule;
            IsSkipConnectTunnels = isSkipTlsHandshake;
            IsOnlyMatchFistTamperRule = isOnlyMatchFistTamperRule;
            IsSyncTamperRule = isSyncTamperRule ;
        }
    }
}
