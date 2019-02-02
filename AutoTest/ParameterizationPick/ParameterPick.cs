using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.ParameterizationPick
{

     [Serializable]
    public class ParameterPick
    {
        public string ParameterName { get; set; }
        public ParameterPickType PickType { get; set; }
        public ParameterPickRange PickRange { get; set; }
        public string PickTypeAdditional { get; set; }
        public string PickTypeExpression { get; set; }
    }

    public class ParameterPickInfo
    {
        public ParameterPickType PickType{get;private set;}
        public List<KeyValuePair<string, string>> PickTypeAdditionalList { get; private set; }
        public bool Editable { get; private set; }
        public Func<string,string, string, string> ParameterPickFunc { get; private set; }

        public ParameterPickInfo(ParameterPickType pickType, List<KeyValuePair<string, string>> pickTypeAdditionalList, bool editable, Func<string,string, string, string> parameterPickFunc)
        {
            PickType = pickType;
            PickTypeAdditionalList = pickTypeAdditionalList;
            Editable = editable;
            ParameterPickFunc = parameterPickFunc;
        }

    }

    public class ParameterPickTypeEngine
    {
        public static Dictionary<ParameterPickType, ParameterPickInfo> dictionaryParameterPickFunc = new Dictionary<ParameterPickType, ParameterPickInfo>() { 
            {ParameterPickType.Str , new ParameterPickInfo(ParameterPickType.Str,new List<KeyValuePair<string,string>>(){new KeyValuePair<string,string>("str-str","StartString-EndString"),new KeyValuePair<string,string>("str-len","StartString-StringLength"),new KeyValuePair<string,string>("index-len","StartIndex-StringLength")},false,ParameterPickHelper.ParameterPickStr)},
            {ParameterPickType.Regex , new ParameterPickInfo(ParameterPickType.Regex,new List<KeyValuePair<string,string>>(){new KeyValuePair<string,string>("1","RegexExpression"),new KeyValuePair<string,string>("0","RegexExpression")},true,ParameterPickHelper.ParameterPickRegex)},
            {ParameterPickType.Xml , new ParameterPickInfo(ParameterPickType.Xml,new List<KeyValuePair<string,string>>(){new KeyValuePair<string,string>("1","XpathExpression"),new KeyValuePair<string,string>("0","XpathExpression")},true,ParameterPickHelper.ParameterPickXml)}
        };
    }

}
