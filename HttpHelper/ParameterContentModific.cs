using FreeHttp.AutoTest.ParameterizationContent;
using FreeHttp.AutoTest.RunTimeStaticData;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    class ParameterContentModific: ContentModific
    {
        public new CaseParameterizationContent TargetKey { get; set; }
        public new CaseParameterizationContent ReplaceContent { get; set; }

        private ActuatorStaticDataCollection actuatorStaticDataCollection;

        public new string GetFinalContent(string sourceContent)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();
            base.TargetKey = TargetKey.GetTargetContentData(actuatorStaticDataCollection, nameValueCollection, out string errorMes);
            if (errorMes != null)
            {
                base.ReplaceContent = ReplaceContent.GetTargetContentData(actuatorStaticDataCollection, nameValueCollection, out errorMes);
            }
            else
            {
                base.ReplaceContent = ReplaceContent.GetTargetContentData();
            }
            return base.GetFinalContent(sourceContent);
        }
    }
}
