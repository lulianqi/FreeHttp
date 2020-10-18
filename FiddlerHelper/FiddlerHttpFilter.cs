using Fiddler;
using FreeHttp.AutoTest;
using FreeHttp.HttpHelper;
using FreeHttp.MyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FreeHttp.FiddlerHelper
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
    [DataContract]
    public class FiddlerUriMatch
    {
        [DataMember]
        public FiddlerUriMatchMode MatchMode { get; set; }
        [DataMember]
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
    [DataContract]
    public class FiddlerHeadMatch
    {
        [DataMember]
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
            if(tempSb[tempSb.Length-2]=='\r'&& tempSb[tempSb.Length - 1] == '\n')
            {
                tempSb.Remove(tempSb.Length - 2, 2);
            }
            return tempSb.ToString();
        }
    }

    [Serializable]
    [DataContract]
    public class FiddlerBodyMatch: FiddlerUriMatch
    {
        [DataMember]
        public Byte[] MatchBodyBytes { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public bool IsHexMatch{ get { return MatchBodyBytes != null; } }

        private string bufferBodyBytesStr;

        public new bool Match(string matchString)
        {
            if (IsHexMatch)
            {
                return false;
            }
            return base.Match(matchString);
        }

        public FiddlerBodyMatch() : base()
        { }
        public FiddlerBodyMatch(FiddlerUriMatchMode matchMode, string matchData) //: base(matchMode, matchUri)
        {
            if (String.IsNullOrEmpty(matchData) && matchMode != FiddlerUriMatchMode.AllPass)
            {
                throw new Exception("empty data is illegal for this mode");
            }
            if (matchData.StartsWith("<hex>"))
            {
                if(matchMode== FiddlerUriMatchMode.Regex)
                {
                    throw new Exception("Regex can not use hex mode");
                }
                MatchBodyBytes = MyBytes.HexStringToByte(matchData.Remove(0, "<hex>".Length), HexDecimal.hex16);
                if((MatchBodyBytes==null || MatchBodyBytes.Length==0)&& matchMode != FiddlerUriMatchMode.AllPass)
                {
                    throw new Exception("empty data is illegal for this mode");
                }
                MatchMode = matchMode;
                MatchUri = string.Format("<hex>{0}", BitConverter.ToString(MatchBodyBytes));
            }
            else
            {
                MatchMode = matchMode;
                MatchUri = matchData;
            }
        }

        public static FiddlerBodyMatch GetFiddlerBodyMatch(FiddlerUriMatchMode matchMode, string matchData)
        {
            try { return new FiddlerBodyMatch(matchMode, matchData); } catch { }
            return null;            
        }

        public bool Match(Byte[] matchBytes)
        {
            if(MatchBodyBytes==null && MatchBodyBytes.Length==0)
            {
                return false;
            }
            if (bufferBodyBytesStr == null)
            {
                bufferBodyBytesStr = BitConverter.ToString(MatchBodyBytes);
            }
            string matchString= BitConverter.ToString(matchBytes);
            switch (MatchMode)
            {
                case FiddlerUriMatchMode.AllPass:
                    return true;
                case FiddlerUriMatchMode.Contain:
                    return (matchString.Contains(bufferBodyBytesStr));
                case FiddlerUriMatchMode.Is:
                    return matchString == bufferBodyBytesStr;
                case FiddlerUriMatchMode.Regex:
                    return false;
                case FiddlerUriMatchMode.StartWith:
                    return matchString.StartsWith(bufferBodyBytesStr);
                default:
                    return false;
            }
        }
    }

    [Serializable]
    [DataContract]
    public class FiddlerHttpFilter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public FiddlerUriMatch UriMatch { get; set; }   //UriMatch  must not be null
        [DataMember]
        public FiddlerHeadMatch HeadMatch { get; set; }
        [DataMember]
        public FiddlerBodyMatch BodyMatch { get; set; }

        public FiddlerHttpFilter()
        {
            UriMatch = null;
        }

        public FiddlerHttpFilter(FiddlerUriMatch uriMatch)
        {
            UriMatch = uriMatch;
        }
        public bool Match(Session oSession, bool isRequest, WebSocketMessage webSocketMessage = null)
        {
            bool isWebSocket = webSocketMessage != null;// oSession.BitFlags.HasFlag(SessionFlags.IsWebSocketTunnel);
            bool isMatch = true;
            if (isWebSocket)
            {
                if(!oSession.BitFlags.HasFlag(SessionFlags.IsWebSocketTunnel))
                {
                    return false;
                }
                if(!((isRequest && webSocketMessage.IsOutbound) || (!isRequest && !webSocketMessage.IsOutbound)))
                {
                    return false;
                }
                if (!UriMatch.Match(oSession.fullUrl))
                {
                    return false;
                }
                if (BodyMatch != null)
                {
                    if (webSocketMessage.FrameType == WebSocketFrameTypes.Binary && BodyMatch.IsHexMatch)
                    {
                        if(! BodyMatch.Match(webSocketMessage.PayloadAsBytes()))
                        {
                            return false;
                        }
                    }
                    else if (webSocketMessage.FrameType == WebSocketFrameTypes.Text && !BodyMatch.IsHexMatch)
                    {
                        if (!BodyMatch.Match(webSocketMessage.PayloadAsString()))
                        {
                            return false;
                        }
                    }
                    else if(webSocketMessage.FrameType == WebSocketFrameTypes.Continuation)
                    {
                        //延续帧
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (UriMatch != null)
                {
                    if (!UriMatch.Match(oSession.fullUrl))
                    {
                        return false;
                    }
                }
                if (HeadMatch != null)
                {
                    if (!HeadMatch.Match(true ? (HTTPHeaders)oSession.RequestHeaders : (HTTPHeaders)oSession.ResponseHeaders))
                    {
                        return false;
                    }
                }
                if (BodyMatch != null)
                {
                    if (BodyMatch.IsHexMatch)
                    {
                        if (!BodyMatch.Match(true ? oSession.requestBodyBytes : oSession.responseBodyBytes))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!BodyMatch.Match(true ? oSession.GetRequestBodyAsString() : oSession.GetResponseBodyAsString()))
                        {
                            return false;
                        }
                    }
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
                tempSb.AppendLine(string.Format("Heads:\r\n{0}", HeadMatch.ToString()));
            }
            if(BodyMatch!=null)
            {
                tempSb.AppendLine(string.Format("Body:\r\n{0}", BodyMatch.ToString()));
            }
            return tempSb.ToString();
        }
    }
}
