using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FiddlerRequsetChange = FreeHttp.FiddlerHelper.FiddlerRequestChange;


namespace FreeHttp.FiddlerHelper.VersionControlV1
{
    [Serializable]
    public class FiddlerModificHttpRuleCollection
    {
        List<FiddlerRequsetChange> requestRuleList;
        List<FiddlerResponseChange> responseRuleList;

        //因为V1.0-V1.3 版本 FiddlerRequsetChange 这个英文拼错了 这里进行进行升级修复
        public List<FiddlerRequsetChange> RequestRuleList { get { return requestRuleList; } set { requestRuleList = value; } }
        public List<FiddlerResponseChange> ResponseRuleList { get { return responseRuleList; } set { responseRuleList = value; } }


        public FiddlerModificHttpRuleCollection()  // Serializable 需要空参数的构造函数
        {
            requestRuleList = null;
            responseRuleList = null;
        }

        public FiddlerModificHttpRuleCollection(List<FiddlerRequsetChange> yourRequestRuleList, List<FiddlerResponseChange> yourResponseRuleList)
        {
            requestRuleList = yourRequestRuleList;
            responseRuleList = yourResponseRuleList;
        }

        public static explicit operator FreeHttp.FiddlerHelper.FiddlerModificHttpRuleCollection(FiddlerModificHttpRuleCollection fiddlerModificHttpRuleCollectionV1)
        {
            List<FiddlerRequestChange> RequestRuleList = new List<FiddlerRequestChange>();
            if(fiddlerModificHttpRuleCollectionV1.RequestRuleList!=null && fiddlerModificHttpRuleCollectionV1.RequestRuleList.Count>0)
            {
                foreach(FiddlerRequsetChange item in fiddlerModificHttpRuleCollectionV1.RequestRuleList)
                {
                    RequestRuleList.Add(item.GetBase());
                }
            }
            FreeHttp.FiddlerHelper.FiddlerModificHttpRuleCollection fiddlerModificHttpRuleCollection = new FreeHttp.FiddlerHelper.FiddlerModificHttpRuleCollection(RequestRuleList, fiddlerModificHttpRuleCollectionV1.ResponseRuleList);
            
            if(fiddlerModificHttpRuleCollection.RequestRuleList!=null && fiddlerModificHttpRuleCollection.RequestRuleList.Count>0)
            {
                foreach (FiddlerRequestChange item in fiddlerModificHttpRuleCollection.RequestRuleList)
                {
                    if(item.UriModific!=null && item.UriModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                    {
                        item.UriModific.ParameterReplaceContent = new AutoTest.ParameterizationContent.CaseParameterizationContent(item.UriModific.ReplaceContent);
                        item.UriModific.ParameterTargetKey = new AutoTest.ParameterizationContent.CaseParameterizationContent(item.UriModific.TargetKey);
                    }
                    if (item.BodyModific != null && item.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                    {
                        item.BodyModific.ParameterReplaceContent = new AutoTest.ParameterizationContent.CaseParameterizationContent(item.BodyModific.ReplaceContent);
                        item.BodyModific.ParameterTargetKey = new AutoTest.ParameterizationContent.CaseParameterizationContent(item.BodyModific.TargetKey);
                    }
                    if(item.IsRawReplace && item.HttpRawRequest.ParameterizationContent.hasParameter)
                    {
                        item.IsHasParameter = true;
                        //item.SetHasParameter(true);
                    }
                }
            }
            if (fiddlerModificHttpRuleCollection.ResponseRuleList != null && fiddlerModificHttpRuleCollection.ResponseRuleList.Count > 0)
            {
                foreach (FiddlerResponseChange item in fiddlerModificHttpRuleCollection.ResponseRuleList)
                {
                    if (item.BodyModific != null && item.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                    {
                        item.BodyModific.ParameterReplaceContent = new AutoTest.ParameterizationContent.CaseParameterizationContent(item.BodyModific.ReplaceContent);
                        item.BodyModific.ParameterTargetKey = new AutoTest.ParameterizationContent.CaseParameterizationContent(item.BodyModific.TargetKey);
                    }
                    if (item.IsRawReplace && item.HttpRawResponse.ParameterizationContent.hasParameter)
                    {
                        item.IsHasParameter = true;
                        //item.SetHasParameter(true);
                    }
                }
            }
            return fiddlerModificHttpRuleCollection;
        }
    }

    [Serializable]
    [System.Runtime.Serialization.DataContract()]
    public class FiddlerRequsetChange : FiddlerRequestChange
    {
       public FiddlerRequestChange GetBase()
        {
            FiddlerRequestChange fiddlerRequestChange = new FiddlerRequestChange();
            fiddlerRequestChange.IsEnable = IsEnable;
            fiddlerRequestChange.TamperProtocol = TamperProtocol;
            fiddlerRequestChange.HttpFilter = HttpFilter;
            fiddlerRequestChange.ParameterPickList = ParameterPickList;
            fiddlerRequestChange.HttpRawRequest = HttpRawRequest;
            fiddlerRequestChange.UriModific = UriModific;
            fiddlerRequestChange.HeadAddList = HeadAddList;
            fiddlerRequestChange.HeadDelList = HeadDelList;
            fiddlerRequestChange.BodyModific = BodyModific;
            fiddlerRequestChange.Tag = Tag;
            fiddlerRequestChange.ActuatorStaticDataController = ActuatorStaticDataController;
            return fiddlerRequestChange;
        }
    }

}
