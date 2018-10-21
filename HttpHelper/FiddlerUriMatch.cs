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
    public class FiddlerUriMatch
    {
        public FiddlerUriMatchMode MatchMode { get; set; }
        public String MatchUri { get; set; }

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
        public new bool Equals(FiddlerUriMatch targetUriMatch)
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
            return this.Equals(fiddlerHttpTamper.UriMatch);
        }
    }
}
