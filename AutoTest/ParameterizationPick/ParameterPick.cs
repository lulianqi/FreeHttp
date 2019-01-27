using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.ParameterizationPick
{
    public class ParameterPick
    {
        public ParameterPickType PickType { get; set; }
        public string PickTypeAdditional { get; set; }
        public string PickTypeExpression { get; set; }
    }

    public class ParameterPickInfo
    {
        public ParameterPickType PickType{get;private set;}
        public List<KeyValuePair<string, string>> PickTypeAdditionalList { get; private set; }
        public bool Editable { get; private set; }
        public Func<ParameterPick, string, string> ParameterPickFunc { get; private set; }

        public ParameterPickInfo(ParameterPickType pickType, List<KeyValuePair<string, string>> pickTypeAdditionalList, bool editable, Func<ParameterPick, string, string> parameterPickFunc)
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
            {ParameterPickType.Str , new ParameterPickInfo(ParameterPickType.Str,new List<KeyValuePair<string,string>>(){new KeyValuePair<string,string>("",""),new KeyValuePair<string,string>("",""),new KeyValuePair<string,string>("","")},false,null)}
        };
    }

}
