using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class ConfigurationData
    {
        private static readonly String url_dev = "http://localhost:5000/";
        private static readonly String url_pro = "https://api.lulianqi.com/";
        private static readonly String rule_version = "2.0";

        public static string BaseUrl
        {
            get { return url_pro; }
        }

        public static string RuleVersion
        {
            get { return rule_version; }
        }
    }
}
