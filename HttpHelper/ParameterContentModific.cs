using FreeHttp.AutoTest.ParameterizationContent;
using FreeHttp.AutoTest.RunTimeStaticData;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    [DataContract]
    public class ParameterContentModific: ContentModific
    {
        [DataMember]
        [System.Xml.Serialization.XmlAttribute("ParameterTargetKey")]
        public new CaseParameterizationContent TargetKey { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlAttribute("ParameterReplaceContent")]
        public new CaseParameterizationContent ReplaceContent { get; set; }

        //IsUseParameter will disable encodetype in CaseParameterizationContent ,if your need encodetype ability just remove it
        [DataMember]
        public bool IsUseParameter { get; set; }

        public void SetUseParameterInfo(bool isUseParameter , ActuatorStaticDataCollection staticDataCollection =null )
        {
            IsUseParameter = isUseParameter;
            if (IsUseParameter && staticDataCollection != null)
            {
                actuatorStaticDataCollection = staticDataCollection;
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        private ActuatorStaticDataCollection actuatorStaticDataCollection;

        public ParameterContentModific(string targetKey, string replaceContent , ActuatorStaticDataCollection dataCollection , bool useParameter): base(targetKey, replaceContent)
        {
            TargetKey = new CaseParameterizationContent(targetKey, useParameter);
            ReplaceContent = new CaseParameterizationContent(replaceContent, useParameter);
            actuatorStaticDataCollection = dataCollection;
            IsUseParameter = useParameter;
        }

        public ParameterContentModific() : this(null, null, null, false)
        {

        }

        public ParameterContentModific(string targetKey, string replaceContent):this(targetKey, replaceContent,null,false)
        {
            
        }

        public string GetFinalContent(string sourceContent, NameValueCollection yourDataResultCollection, out string errorMessage)
        {
            errorMessage = null;
            if (IsUseParameter)
            {
                base.TargetKey = TargetKey.GetTargetContentData(actuatorStaticDataCollection, yourDataResultCollection, out string errorMes);
                if (errorMes != null)
                {
                    base.ReplaceContent = ReplaceContent.GetTargetContentData(actuatorStaticDataCollection, yourDataResultCollection, out errorMes);
                }
                else
                {
                    base.ReplaceContent = ReplaceContent.GetTargetContentData();
                }
            }
            else
            {
                base.TargetKey = TargetKey.GetTargetContentData();
                base.ReplaceContent = ReplaceContent.GetTargetContentData();
            }
            return base.GetFinalContent(sourceContent);
        }

        public new string GetFinalContent(string sourceContent)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();
            return GetFinalContent(sourceContent, nameValueCollection, out string _);
        }
    }
}
