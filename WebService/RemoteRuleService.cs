using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.FiddlerHelper;
using FreeHttp.MyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class RemoteRuleService
    {
        [DataContract]
        public class RuleDetails
        {
            [DataContract]

            public class RuleCell
            {
                public RuleCell() { }

                [DataMember]
                public string RuleContent { get; set; }
                [DataMember]
                public string RuleVersion { get; set; }
            }

            public RuleDetails()
            {
                RequestRuleCells = new List<RuleCell>();
                ResponseRuleCells = new List<RuleCell>();
            }


            [DataMember]
            public List<RuleCell> RequestRuleCells { get; set; }

            [DataMember]
            public List<RuleCell> ResponseRuleCells { get; set; }

            [DataMember]
            public RuleCell RuleStaticData { get; set; }

            public FiddlerModificHttpRuleCollection ModificHttpRuleCollection { get; set; }

            public ActuatorStaticDataCollection StaticDataCollection { get; set; }

        }

        private static HttpClient httpClient;
        static RemoteRuleService()
        {
            httpClient = new HttpClient();
        }

        public static async Task<RuleDetails> GetRemoteRuleAsync(string token)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(string.Format(@"{0}freehttp/RuleDetails?userToken={1}", ConfigurationData.BaseUrl, token));
            if(responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            RuleDetails ruleDetails = MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<RuleDetails>(await responseMessage.Content.ReadAsStringAsync());
            if(ruleDetails==null)
            {
                return null;
            }

            string nowVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (ruleDetails.RuleStaticData!=null)
            {
                //if (ruleDetails.RuleStaticData.RuleVersion == nowVersion)
                ruleDetails.StaticDataCollection = MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<ActuatorStaticDataCollection>(ruleDetails.RuleStaticData.RuleContent);

            }
           
            if (ruleDetails.RequestRuleCells!=null ||  ruleDetails.ResponseRuleCells!=null)
            {
                ruleDetails.ModificHttpRuleCollection = new FiddlerModificHttpRuleCollection();
                ruleDetails.ModificHttpRuleCollection.RequestRuleList = new List<FiddlerRequestChange>();
                ruleDetails.ModificHttpRuleCollection.ResponseRuleList = new List<FiddlerResponseChange>();
                //fill RequestRule
                foreach (var cell in ruleDetails.RequestRuleCells)
                {
                    if(cell.RuleVersion != nowVersion)
                    {
                        ruleDetails.ModificHttpRuleCollection.RequestRuleList.Add(new FiddlerRequestChange() {
                            IsEnable =false,
                            HttpFilter=new FiddlerHttpFilter() { 
                                Name = "unmatch rule version", 
                                UriMatch = new FiddlerUriMatch() {
                                    MatchMode = FiddlerUriMatchMode.Is,
                                    MatchUri = "unmatch rule version"
                                } 
                            } 
                        });
                    }
                    else
                    {
                        FiddlerRequestChange tmepRequestChange = MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<FiddlerRequestChange>(cell.RuleContent);
                        ruleDetails.ModificHttpRuleCollection.RequestRuleList.Add(tmepRequestChange ?? new FiddlerRequestChange()
                        {
                            IsEnable = false,
                            HttpFilter = new FiddlerHttpFilter()
                            {
                                Name = "can not parse this rule",
                                UriMatch = new FiddlerUriMatch()
                                {
                                    MatchMode = FiddlerUriMatchMode.Is,
                                    MatchUri = "can not parse this rule"
                                }
                            }
                        });
                    }
                }
                //fill ResponseRule
                foreach (var cell in ruleDetails.ResponseRuleCells)
                {
                    if (cell.RuleVersion != nowVersion)
                    {
                        ruleDetails.ModificHttpRuleCollection.ResponseRuleList.Add(new FiddlerResponseChange()
                        {
                            IsEnable = false,
                            HttpFilter = new FiddlerHttpFilter()
                            {
                                Name = "unmatch rule version",
                                UriMatch = new FiddlerUriMatch()
                                {
                                    MatchMode = FiddlerUriMatchMode.Is,
                                    MatchUri = "unmatch rule version"
                                }
                            }
                        });
                    }
                    else
                    {
                        FiddlerResponseChange tmepRequestChange = MyJsonHelper.JsonDataContractJsonSerializer.JsonStringToObject<FiddlerResponseChange>(cell.RuleContent);
                        ruleDetails.ModificHttpRuleCollection.ResponseRuleList.Add(tmepRequestChange ?? new FiddlerResponseChange()
                        {
                            IsEnable = false,
                            HttpFilter = new FiddlerHttpFilter()
                            {
                                Name = "can not parse this rule",
                                UriMatch = new FiddlerUriMatch()
                                {
                                    MatchMode = FiddlerUriMatchMode.Is,
                                    MatchUri = "can not parse this rule"
                                }
                            }
                        });
                    }
                }
            }

            return ruleDetails;
        }
    }
}
