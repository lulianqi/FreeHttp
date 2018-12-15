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
    }

    [Serializable]
    public class FiddlerHttpFilter
    {
        public FiddlerUriMatch UriMatch { get; set; }
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
    }
}
