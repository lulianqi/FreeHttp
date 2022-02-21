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
        /// <summary>
        /// 在指定rule列表中寻找匹配rule列表
        /// </summary>
        /// <typeparam name="T">IFiddlerHttpTamper 类型</typeparam>
        /// <param name="oSession">目标oSession</param>
        /// <param name="ruleList">目标rule列表</param>
        /// <param name="isRequest">是否是request （如果不是则为response）</param>
        /// <param name="webSocketMessage">是否为WebSocket规则</param>
        /// <returns>匹配成功的rule列表</returns>
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
