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

        /// <summary>
        /// is skip when the session is hide
        /// </summary>
        public bool IsSkipUiHide { get; set; }

        /// <summary>
        /// is enable request rule when the application load
        /// </summary>
        public bool IsEnableRequestRule { get; set; }

        /// <summary>
        /// is enable response rule when the application load
        /// </summary>
        public bool IsEnableResponseRule { get; set; }



        public FiddlerModificSettingInfo():this(true, false ,true,true)
        {
            
        }
        public FiddlerModificSettingInfo( bool isSkipTlsHandshake, bool isOnlyMatchFistTamperRule ,bool isSyncTamperRule, bool isSkipUiHide, bool isEnableRequestRule = false, bool isEnableResponseRule = false)
        {
            IsSkipConnectTunnels = isSkipTlsHandshake;
            IsOnlyMatchFistTamperRule = isOnlyMatchFistTamperRule;
            IsSyncTamperRule = isSyncTamperRule ;
            IsSkipUiHide = isSkipUiHide;
            IsEnableRequestRule = isEnableRequestRule;
            IsEnableResponseRule = isEnableResponseRule;
        }
    }
}
