using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.FiddlerHelper
{
    class FiddlerSessionHelper
    {

        public static List<IFiddlerHttpTamper> FindMatchTanperRule<T>(Session oSession, List<T> ruleList,bool isRequest,WebSocketMessage webSocketMessage = null) where T : IFiddlerHttpTamper
        {
            if (oSession == null || ruleList == null || ruleList.Count == 0)
            {
                return null;
            }
            List<IFiddlerHttpTamper> matchRuleList = new List<IFiddlerHttpTamper>();
            bool isMatchWebsocket = webSocketMessage != null;
            foreach (IFiddlerHttpTamper tempItem in ruleList)
            {
                if (!tempItem.IsEnable)
                {
                    continue;
                }
                if (isMatchWebsocket)
                {
                    if (tempItem.TamperProtocol == TamperProtocalType.Http)
                    {
                        continue;
                    }
                    if (!oSession.BitFlags.HasFlag(SessionFlags.IsWebSocketTunnel))
                    {
                        continue;
                    }
                    if (tempItem.HttpFilter.Match(oSession, isRequest, webSocketMessage))
                    {
                        matchRuleList.Add(tempItem);
                    }
                }
                else
                {
                    if (tempItem.TamperProtocol == TamperProtocalType.WebSocket)
                    {
                        continue;
                    }
                    if (tempItem.HttpFilter.Match(oSession, isRequest))
                    {
                        matchRuleList.Add(tempItem);
                    }
                }
            }
            return matchRuleList;
        }
    }
}
