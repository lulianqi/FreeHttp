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
    }
}
