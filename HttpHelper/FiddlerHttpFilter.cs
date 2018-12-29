using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public enum FiddlerUriMatchMode
    {
        Contain,
        StartWith,
        Is,
        Regex,
        AllPass
    }

    [Serializable]
    public class FiddlerUriMatch
    {
        public FiddlerUriMatchMode MatchMode { get; set; }
        public String MatchUri { get; set; }

        public FiddlerUriMatch()
        {
            MatchMode = FiddlerUriMatchMode.AllPass;
            MatchUri = null;
        }
        public FiddlerUriMatch(FiddlerUriMatchMode matchMode,string matchUri)
        {
            MatchMode = matchMode;
            MatchUri = matchUri;
        }

        public bool Match(string matchString)
        {
            switch(MatchMode)
            {
                case FiddlerUriMatchMode.AllPass:
                    return true;
                case FiddlerUriMatchMode.Contain:
                    return (matchString.Contains(MatchUri));
                case FiddlerUriMatchMode.Is:
                    return matchString == MatchUri;
                case FiddlerUriMatchMode.Regex:
                    return System.Text.RegularExpressions.Regex.IsMatch(matchString, MatchUri);
                case FiddlerUriMatchMode.StartWith:
                    return matchString.StartsWith(MatchUri);
                default:
                    return false;
            }

        }
        public bool Equals(FiddlerUriMatch targetUriMatch)
        {
            return (this.MatchMode == targetUriMatch.MatchMode && this.MatchUri == targetUriMatch.MatchUri);
        }
        public new bool Equals(object targetFiddlerHttpTamper)
        {
            IFiddlerHttpTamper fiddlerHttpTamper = targetFiddlerHttpTamper as IFiddlerHttpTamper;
            if(fiddlerHttpTamper== null)
            {
                return false;
            }
            return this.Equals(fiddlerHttpTamper.HttpFilter.UriMatch);
        }

        public new string ToString()
        {
            return string.Format("[{0}] {1}", MatchMode.ToString(), string.IsNullOrEmpty(MatchUri) ? "" : MatchUri);
        }
    }

    [Serializable]
    public class FiddlerHeadMatch
    {
        public List<MyKeyValuePair<string, string>> HeadsFilter { get; set; }

        public FiddlerHeadMatch()
        {
            HeadsFilter = null;
        }

        public FiddlerHeadMatch(List<MyKeyValuePair<string, string>> headsFilter)
        {
            HeadsFilter = headsFilter;
        }

        public void AddHeadMatch(MyKeyValuePair<string, string> yourHeadMatch)
        {
            if(HeadsFilter==null)
            {
                HeadsFilter=new List<MyKeyValuePair<string,string>>();
            }
            HeadsFilter.Add(yourHeadMatch);
        }

        public bool Match(HTTPHeaders matchHeaders)
        {
            if(HeadsFilter!=null && HeadsFilter.Count>0)
            {
                foreach(MyKeyValuePair<string, string> headFilter in HeadsFilter)
                {
                    if(!matchHeaders.ExistsAndContains(headFilter.Key,headFilter.Value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Equals(FiddlerHeadMatch yourFiddlerHeadMatch)
        {
            if (yourFiddlerHeadMatch.HeadsFilter.Count == HeadsFilter.Count)
            {
                List<MyKeyValuePair<string, string>> HeadsFilterForEqual = HeadsFilter.MyClone();
                foreach(var tempHead in yourFiddlerHeadMatch.HeadsFilter)
                {
                    if(HeadsFilterForEqual.MyContains(tempHead))
                    {
                        HeadsFilterForEqual.Remove(tempHead);
                    }
                    else
                    {
                        return false;
                    }
                }
                if(HeadsFilterForEqual.Count==0)
                {
                    return true;
                }
            }
            return false;
        }

        public new string ToString()
        {
            if (HeadsFilter == null || HeadsFilter.Count == 0)
            {
                return null;
            }
            StringBuilder tempSb = new StringBuilder(HeadsFilter.Count * 30);
            foreach(MyKeyValuePair<string, string> tempKv in HeadsFilter)
            {
                tempSb.AppendLine(string.Format("{0} [contain] {1}", tempKv.Key, tempKv.Value));
            }
            return tempSb.ToString();
        }
    }

    [Serializable]
    public class FiddlerHttpFilter
    {
        public string Name { get; set; } 
        public FiddlerUriMatch UriMatch { get; set; }   //UriMatch  must not be null
        public FiddlerHeadMatch HeadMatch { get; set; }
        public FiddlerUriMatch BodyMatch { get; set; }

        public FiddlerHttpFilter()
        {
            UriMatch = null;
        }

        public FiddlerHttpFilter(FiddlerUriMatch uriMatch)
        {
            UriMatch = uriMatch;
        }
        public bool Match(Session oSession, bool isRequest)
        {
            bool isMatch = true;
            if (UriMatch != null)
            {
                if(!UriMatch.Match(oSession.fullUrl))
                {
                    return false;
                }
            }
            if (HeadMatch!=null)
            {
                if (!HeadMatch.Match(isRequest ? (HTTPHeaders)oSession.RequestHeaders : (HTTPHeaders)oSession.ResponseHeaders))
                {
                    return false;
                }
            }
            if (BodyMatch!=null)
            {
                if (!BodyMatch.Match(isRequest?oSession.GetRequestBodyAsString():oSession.GetResponseBodyAsString()))
                {
                    return false;
                }
            }
            return isMatch;
        }
    
        public bool Equals(FiddlerHttpFilter yourFiddlerHttpFilter)
        {
            if (!UriMatch.Equals(yourFiddlerHttpFilter.UriMatch))
            {
                return false;
            }

            if ((HeadMatch == null || yourFiddlerHttpFilter.HeadMatch == null) && (!(HeadMatch == null && yourFiddlerHttpFilter.HeadMatch == null)))
            {
                return false;
            }
            if (HeadMatch != null && yourFiddlerHttpFilter.HeadMatch != null)
            {
                if(!HeadMatch.Equals(yourFiddlerHttpFilter.HeadMatch))
                {
                    return false;
                }
            }

            if ((BodyMatch == null || yourFiddlerHttpFilter.BodyMatch == null) && (!(BodyMatch == null && yourFiddlerHttpFilter.BodyMatch == null)))
            {
                return false;
            }
            if (BodyMatch != null && yourFiddlerHttpFilter.BodyMatch != null)
            {
                if (!BodyMatch.Equals(yourFiddlerHttpFilter.BodyMatch))
                {
                    return false;
                }
            }

            return true;
        }

        public new bool Equals(object targetFiddlerHttpFilter)
        {
            IFiddlerHttpTamper fiddlerHttpTamper = targetFiddlerHttpFilter as IFiddlerHttpTamper;
            if (fiddlerHttpTamper == null)
            {
                return false;
            }
            return this.Equals(fiddlerHttpTamper.HttpFilter);
        }

        public new string ToString()
        {
            StringBuilder tempSb = new StringBuilder(string.Format("Uri:\r\n{0}\r\n",UriMatch.ToString()));
            if(HeadMatch!=null)
            {
                tempSb.Append(string.Format("Heads:\r\n{0}", HeadMatch.ToString()));
            }
            if(BodyMatch!=null)
            {
                tempSb.AppendLine(string.Format("Body:\r\n{0}", BodyMatch.ToString()));
            }
            return tempSb.ToString();
        }
    }
}
