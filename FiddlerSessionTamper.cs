using Fiddler;
using FreeHttp.FiddlerHelper;
using FreeHttp.HttpHelper;
using FreeHttp.AutoTest;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeHttp.AutoTest.ParameterizationPick;

namespace FreeHttp
{
    public class FiddlerSessionTamper
    {
        /// <summary>
        /// Modific the http request in oSession with your rule
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerRequsetChange">FiddlerRequsetChange</param>
        public static void ModificSessionRequest(Session oSession, FiddlerRequestChange nowFiddlerRequsetChange, Action<string> ShowError, Action<string> ShowMes)
        {
            if (nowFiddlerRequsetChange.ParameterPickList != null)
            {
                PickSessionParameter(oSession, nowFiddlerRequsetChange, ShowError, ShowMes, true);
            }
            if (nowFiddlerRequsetChange.IsRawReplace)
            {
                ReplaceSessionRequest(oSession, nowFiddlerRequsetChange, ShowError, ShowMes);
            }
            else
            {
                string errMes;
                NameValueCollection nameValueCollection = new NameValueCollection();
                //Modific uri
                if (nowFiddlerRequsetChange.UriModific != null && nowFiddlerRequsetChange.UriModific.ModificMode != ContentModificMode.NoChange)
                {
                    try
                    {
                        oSession.fullUrl = nowFiddlerRequsetChange.UriModific.GetFinalContent(oSession.fullUrl, nameValueCollection, out errMes);
                    }
                    catch(Exception ex)
                    {
                        errMes = ex.Message;
                    }
                    if(errMes!=null)
                    {
                        ShowError(string.Format("error in GetFinalContent in UriModific that [{0}]", errMes));
                    }
                }
                //Modific body
                if (nowFiddlerRequsetChange.BodyModific != null && nowFiddlerRequsetChange.BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    if (nowFiddlerRequsetChange.BodyModific.ModificMode == ContentModificMode.HexReplace)
                    {
                        try
                        {
                            oSession.RequestBody = nowFiddlerRequsetChange.BodyModific.GetFinalContent(oSession.requestBodyBytes);
                        }
                        catch (Exception ex)
                        {
                            ShowError(string.Format("error in GetFinalContent in HexReplace with [{0}]", ex.Message));
                        }
                    }
                    else
                    {
                        string sourceRequestBody = null;
                        try  //GetRequestBodyAsString may throw exception
                        {
                            //oSession.utilDecodeRequest();
                            sourceRequestBody = oSession.GetRequestBodyAsString();
                        }
                        catch (Exception ex)
                        {
                            ShowError(string.Format("error in GetRequestBodyAsString [{0}]", ex.Message));
                            oSession.utilDecodeRequest();
                            sourceRequestBody = oSession.GetRequestBodyEncoding().GetString(oSession.requestBodyBytes);
                        }
                        finally
                        {
                            if (nowFiddlerRequsetChange.BodyModific.ModificMode == ContentModificMode.ReCode)
                            {
                                try
                                {
                                    oSession.RequestBody = nowFiddlerRequsetChange.BodyModific.GetRecodeContent(sourceRequestBody);
                                }
                                catch (Exception ex)
                                {
                                    ShowError(string.Format("error in GetRecodeContent in ReCode with [{0}]", ex.Message));
                                }
                            }
                            else
                            {
                                //oSession.requestBodyBytes = oSession.GetRequestBodyEncoding().GetBytes(nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody)); // requestBodyBytes直接修改内部成员
                                //oSession.ResponseBody = oSession.GetRequestBodyEncoding().GetBytes(nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody)); //ResponseBody修改内部成员 更新Content-Length ，同时删除编码头，适用于hex数据
                                //Session.RequestBody : Gets or Sets the HTTP Request body bytes. Setter adjusts Content-Length header, and removes Transfer-Encoding and Content-Encoding headers. Setter DOES NOT CLONE the passed array. Setter will throw if the Request object does not exist for some reason. Use utilSetRequestBody(sStr) to ensure proper character encoding if you need to use a string. 
                                //oSession.utilSetRequestBody(nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody));  //utilSetRequestBody 虽然会自动更新Content-Length 但是会强制使用utf8 ，适用于字符串
                                string tempRequestBody = nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody, nameValueCollection, out errMes);
                                if (errMes != null)
                                {
                                    ShowError(string.Format("error in GetFinalContent in BodyModific that [{0}]", errMes));
                                }
                                if (tempRequestBody != sourceRequestBody)
                                {
                                    oSession.utilSetRequestBody(tempRequestBody);
                                }
                            }
                        }
                    }
                }
                //Modific heads
                if (nowFiddlerRequsetChange.HeadDelList != null && nowFiddlerRequsetChange.HeadDelList.Count > 0)
                {
                    foreach (var tempDelHead in nowFiddlerRequsetChange.HeadDelList)
                    {
                        oSession.RequestHeaders.Remove(tempDelHead);
                    }
                }
                if (nowFiddlerRequsetChange.HeadAddList != null && nowFiddlerRequsetChange.HeadAddList.Count > 0)
                {
                    foreach (var tempAddHead in nowFiddlerRequsetChange.HeadAddList)
                    {
                        if (tempAddHead.Contains(": "))
                        {
                            oSession.RequestHeaders.Add(tempAddHead.Remove(tempAddHead.IndexOf(": ")), tempAddHead.Substring(tempAddHead.IndexOf(": ") + 2));
                        }
                        else
                        {
                            ShowError(string.Format("error to deal add head string with [{0}]", tempAddHead));
                        }
                    }
                }
                //other action              
                if (nameValueCollection != null && nameValueCollection.Count > 0)
                {
                    ShowMes(string.Format("[ParameterizationContent]:{0}", nameValueCollection.MyToFormatString()));
                }

            }
        }

        /// <summary>
        /// Replace the http request in oSession with your rule (it may call by ModificSessionRequest)
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerRequsetChange">FiddlerRequsetChange</param>
        public static void ReplaceSessionRequest(Session oSession, FiddlerRequestChange nowFiddlerRequsetChange, Action<string> ShowError, Action<string> ShowMes)
        {
            string errMes;
            NameValueCollection nameValueCollection;
            HttpRequest tempRequestHttpRequest;
            try
            {
                tempRequestHttpRequest = nowFiddlerRequsetChange.HttpRawRequest.UpdateHttpRequest(out errMes, out nameValueCollection);
            }
            catch (Exception ex)
            {
                ShowError(string.Format("Fail to ReplaceSessionResponse :{0}", ex.Message));
                return;
            }
            if (errMes != null)
            {
                ShowError(errMes);
            }
            if (nameValueCollection != null && nameValueCollection.Count > 0)
            {
                ShowMes(string.Format("[ParameterizationContent]:{0}", nameValueCollection.MyToFormatString()));
            }

            oSession.oRequest.headers = new HTTPRequestHeaders();
            oSession.RequestMethod = tempRequestHttpRequest.RequestMethod;
            try
            {
                oSession.fullUrl = tempRequestHttpRequest.RequestUri;
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == "URI scheme must be http, https, or ftp")
                {
                    oSession.url = tempRequestHttpRequest.RequestUri;
                }
                else
                {
                    ShowError(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            ((Fiddler.HTTPHeaders)(oSession.RequestHeaders)).HTTPVersion = tempRequestHttpRequest.RequestVersions;
            if (tempRequestHttpRequest.RequestHeads != null)
            {

                foreach (var tempHead in tempRequestHttpRequest.RequestHeads)
                {
                    if (tempHead.Key == "Host")
                    {
                        oSession.oRequest.headers.Remove("Host");
                    }
                    oSession.oRequest.headers.Add(tempHead.Key, tempHead.Value);
                }
            }
            oSession.requestBodyBytes = tempRequestHttpRequest.RequestEntity;
        }

        /// <summary>
        /// Modific the http response in oSession with your rule (if IsRawReplace and  IsIsDirectRespons it will not call ReplaceSessionResponse)
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerResponseChange">FiddlerResponseChange</param>
        public static void ModificSessionResponse(Session oSession, FiddlerResponseChange nowFiddlerResponseChange, Action<string> ShowError, Action<string> ShowMes)
        {
            if (nowFiddlerResponseChange.ParameterPickList != null && nowFiddlerResponseChange.ParameterPickList.Count>0)
            {
                PickSessionParameter(oSession, nowFiddlerResponseChange, ShowError, ShowMes, false);
            }
            if (nowFiddlerResponseChange.IsRawReplace)
            {
                //if IsIsDirectRespons do nothing
                if (!nowFiddlerResponseChange.IsIsDirectRespons)
                {
                    ReplaceSessionResponse(oSession, nowFiddlerResponseChange, ShowError, ShowMes);
                }
            }
            else
            {
                string errMes;
                NameValueCollection nameValueCollection = new NameValueCollection();
                //modific body
                if (nowFiddlerResponseChange.BodyModific != null && nowFiddlerResponseChange.BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    if (nowFiddlerResponseChange.BodyModific.ModificMode == ContentModificMode.HexReplace)
                    {
                        try
                        {
                            oSession.ResponseBody = nowFiddlerResponseChange.BodyModific.GetFinalContent(oSession.responseBodyBytes);
                        }
                        catch (Exception ex)
                        {
                            ShowError(string.Format("error in GetFinalContent in HexReplace with [{0}]", ex.Message));
                        }
                    }
                    else
                    {
                        //you should not change the media data as string
                        string sourceResponseBody = null;
                        try
                        {
                            sourceResponseBody = oSession.GetResponseBodyAsString(); //if the head encode is change ,GetResponseBodyAsString maybe fail 
                            if (nowFiddlerResponseChange.BodyModific.ParameterTargetKey.ToString().Contains('\n'))
                            {
                                sourceResponseBody = sourceResponseBody.Replace("\r\n", "\n");
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowError(string.Format("error in GetResponseBodyAsString [{0}]", ex.Message));
                            oSession.utilDecodeResponse();
                            sourceResponseBody = oSession.GetResponseBodyEncoding().GetString(oSession.ResponseBody);
                        }
                        finally
                        {
                            if (nowFiddlerResponseChange.BodyModific.ModificMode == ContentModificMode.ReCode)
                            {
                                try
                                {
                                    oSession.ResponseBody = nowFiddlerResponseChange.BodyModific.GetRecodeContent(sourceResponseBody);
                                }
                                catch (Exception ex)
                                {
                                    ShowError(string.Format("error in GetRecodeContent in ReCode with [{0}]", ex.Message));
                                }
                            }
                            else
                            {
                                //oSession.utilSetResponseBody(nowFiddlerResponseChange.BodyModific.GetFinalContent(sourceResponseBody));
                                string tempResponseBody = nowFiddlerResponseChange.BodyModific.GetFinalContent(sourceResponseBody, nameValueCollection, out errMes);
                                if (errMes != null)
                                {
                                    ShowError(string.Format("error in GetFinalContent in BodyModific that [{0}]", errMes));
                                }
                                if (tempResponseBody != sourceResponseBody)
                                {
                                    oSession.utilSetResponseBody(tempResponseBody);
                                }
                            }
                        }

                        //you can use below code to modific the body
                        //oSession.utilDecodeResponse();
                        //oSession.utilReplaceInResponse("","");
                        //oSession.utilDeflateResponse();
                    }
                }
                //modific heads
                if (nowFiddlerResponseChange.HeadDelList != null && nowFiddlerResponseChange.HeadDelList.Count > 0)
                {
                    foreach (var tempDelHead in nowFiddlerResponseChange.HeadDelList)
                    {
                        oSession.ResponseHeaders.Remove(tempDelHead);
                    }
                }
                if (nowFiddlerResponseChange.HeadAddList != null && nowFiddlerResponseChange.HeadAddList.Count > 0)
                {
                    foreach (var tempAddHead in nowFiddlerResponseChange.HeadAddList)
                    {
                        if (tempAddHead.Contains(": "))
                        {
                            oSession.ResponseHeaders.Add(tempAddHead.Remove(tempAddHead.IndexOf(": ")), tempAddHead.Substring(tempAddHead.IndexOf(": ") + 2));
                        }
                        else
                        {
                            ShowError(string.Format("error to deal add head string with [{0}]", tempAddHead));
                        }
                    }
                }
                //other action
                if (nameValueCollection != null && nameValueCollection.Count > 0)
                {
                    ShowMes(string.Format("[ParameterizationContent]:{0}", nameValueCollection.MyToFormatString()));
                }
            }
        }

        /// <summary>
        /// Replace the http response in oSession with your rule
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerResponseChange">FiddlerResponseChange</param>
        public static void ReplaceSessionResponse(Session oSession, FiddlerResponseChange nowFiddlerResponseChange, Action<string> ShowError, Action<string> ShowMes)
        {
            bool isClosePipeWhenReplace = false;
            byte[] tempResponseBytes;
            string errMes;
            NameValueCollection nameValueCollection;
            HttpResponse tempHttpResponse;
            try
            {
                tempHttpResponse = nowFiddlerResponseChange.HttpRawResponse.UpdateHttpResponse(out errMes, out nameValueCollection);
                tempResponseBytes = tempHttpResponse.GetRawHttpResponse();
            }
            catch (Exception ex)
            {
                ShowError(string.Format("Fail to ReplaceSessionResponse :{0}", ex.Message));
                return;
            }
            if (errMes != null)
            {
                ShowError(errMes);
            }
            if (nameValueCollection != null && nameValueCollection.Count > 0)
            {
                ShowMes(string.Format("[ParameterizationContent]:{0}", nameValueCollection.MyToFormatString()));
            }
            using (MemoryStream ms = new MemoryStream(tempResponseBytes))
            {
                if (isClosePipeWhenReplace)
                {
                    oSession.PoisonClientPipe();  //关闭客户端与代理的连接(Ensures that, after the response is complete, the client socket is closed and not reused. Does NOT (and must not) close the pipe. )
                    oSession.PoisonServerPipe();  //关闭代理与服务器的连接
                }
                if (!oSession.LoadResponseFromStream(ms, null))
                {
                    ShowError("error to oSession.LoadResponseFromStream");
                    ShowError("try to modific the response");

                    //modific the response
                    oSession.oResponse.headers = new HTTPResponseHeaders();
                    oSession.oResponse.headers.HTTPResponseCode = tempHttpResponse.ResponseCode;
                    oSession.ResponseHeaders.StatusDescription = tempHttpResponse.ResponseStatusDescription;
                    ((Fiddler.HTTPHeaders)(oSession.ResponseHeaders)).HTTPVersion = tempHttpResponse.ResponseVersion;
                    if (tempHttpResponse.ResponseHeads != null && tempHttpResponse.ResponseHeads.Count > 0)
                    {
                        foreach (var tempHead in tempHttpResponse.ResponseHeads)
                        {
                            oSession.oResponse.headers.Add(tempHead.Key, tempHead.Value);
                        }
                    }
                    oSession.responseBodyBytes = tempHttpResponse.ResponseEntity;
                }
            }
        }


        /// <summary>
        ///  Modific the websocket message with your rule
        /// </summary>
        /// <param name="oSession"></param>
        /// <param name="webSocketMessage"></param>
        /// <param name="nowFiddlerRequsetChange"></param>
        /// <param name="ShowError"></param>
        /// <param name="ShowMes"></param>
        public static void ModificWebSocketMessage(Session oSession, WebSocketMessage webSocketMessage, IFiddlerHttpTamper nowFiddlerChange, bool isRequest,Action<string> ShowError, Action<string> ShowMes)
        {
            if (nowFiddlerChange.ParameterPickList != null)
            {
                PickSessionParameter(oSession, nowFiddlerChange, ShowError, ShowMes, webSocketMessage.IsOutbound, webSocketMessage);
            }
            ParameterContentModific payLoadModific = null;
            if (isRequest)
            {
                FiddlerRequestChange nowFiddlerRequsetChange = (FiddlerRequestChange)nowFiddlerChange;
                payLoadModific = nowFiddlerRequsetChange.BodyModific;
            }
            else
            {
                FiddlerResponseChange nowFiddlerResponseChange = (FiddlerResponseChange)nowFiddlerChange;
                payLoadModific = nowFiddlerResponseChange.BodyModific;
            }
            //Modific body
            if (payLoadModific != null && payLoadModific.ModificMode != ContentModificMode.NoChange)
            {
                if (payLoadModific.ModificMode == ContentModificMode.HexReplace)
                {
                    try
                    {
                        webSocketMessage.SetPayload(payLoadModific.GetFinalContent(webSocketMessage.PayloadAsBytes()));
                    }
                    catch (Exception ex)
                    {
                        ShowError(string.Format("error in GetFinalContent in HexReplace with [{0}]", ex.Message));
                    }
                }
                else
                {
                    if (webSocketMessage.FrameType == WebSocketFrameTypes.Binary)
                    {
                        ShowError("error in GetFinalContent that WebSocketFrameTypes is Binary ,just use <hex> mode");
                    }
                    else if (webSocketMessage.FrameType == WebSocketFrameTypes.Ping || webSocketMessage.FrameType == WebSocketFrameTypes.Pong || webSocketMessage.FrameType == WebSocketFrameTypes.Close)
                    {
                        // do nothing
                    }
                    else
                    {
                        string sourcePayload = webSocketMessage.PayloadAsString();
                        if (payLoadModific.ModificMode == ContentModificMode.ReCode)
                        {
                            try
                            {
                                webSocketMessage.SetPayload(payLoadModific.GetRecodeContent(sourcePayload));
                            }
                            catch (Exception ex)
                            {
                                ShowError(string.Format("error in GetRecodeContent in ReCode with [{0}]", ex.Message));
                            }
                        }
                        else
                        {
                            string errMes;
                            NameValueCollection nameValueCollection = new NameValueCollection();

                            //webSocketMessage.SetPayload(payLoadModific.GetFinalContent(sourcePayload));
                            string tempPayload = payLoadModific.GetFinalContent(sourcePayload, nameValueCollection, out errMes);
                            if (errMes != null)
                            {
                                ShowError(string.Format("error in GetFinalContent in PayLoadModific that [{0}]", errMes));
                            }
                            if (tempPayload != sourcePayload) //非标准协议的实现，或没有实现的压缩会导致PayloadAsString()使数据不可逆
                            {
                                webSocketMessage.SetPayload(tempPayload);
                            }

                            if (nameValueCollection != null && nameValueCollection.Count > 0)
                            {
                                ShowMes(string.Format("[ParameterizationContent]:{0}", nameValueCollection.MyToFormatString()));
                            }
                        }
                    }
                }
            }

        }



        public static void PickSessionParameter(Session oSession, IFiddlerHttpTamper nowFiddlerHttpTamper, Action<string> ShowError, Action<string> ShowMes, bool isRequest , WebSocketMessage webSocketMessage=null)
        {
            Func<string, ParameterPick, string> PickFunc = (sourceStr, parameterPick) =>
            {
                try { return ParameterPickTypeEngine.dictionaryParameterPickFunc[parameterPick.PickType].ParameterPickFunc(sourceStr, parameterPick.PickTypeExpression, parameterPick.PickTypeAdditional); }
                catch (Exception) { return null; }
            };

            bool isWebSocket = webSocketMessage != null;

            if (nowFiddlerHttpTamper.ParameterPickList != null)
            {
                foreach (ParameterPick parameterPick in nowFiddlerHttpTamper.ParameterPickList)
                {
                    string pickResult = null;
                    string pickSource = null;
                    switch (parameterPick.PickRange)
                    {
                        case ParameterPickRange.Line:
                            if (isRequest)
                            {
                                pickSource = oSession.fullUrl;
                                if (string.IsNullOrEmpty(pickSource))
                                {
                                    pickResult = null;
                                    break;
                                }
                            }
                            else
                            {
                                if (oSession.oResponse.headers == null)
                                {
                                    pickResult = null;
                                    break;
                                }
                                else
                                {
                                    //pickSource = string.Format("{0} {1} {}", oSession.oResponse.headers.HTTPVersion, oSession.oResponse.headers.HTTPResponseCode,oSession.oResponse.headers.StatusDescription);
                                    pickSource = string.Format("{0} {1}", oSession.oResponse.headers.HTTPVersion, oSession.oResponse.headers.HTTPResponseStatus);
                                }
                            }
                            pickResult = PickFunc(pickSource, parameterPick);
                            break;
                        case ParameterPickRange.Heads:
                            if(isWebSocket)
                            {
                                ShowError("[ParameterizationPick] can not pick parameter in head when the session is websocket");
                                break;
                            }
                            IEnumerable<HTTPHeaderItem> headerItems = isRequest ? (IEnumerable<HTTPHeaderItem>)oSession.RequestHeaders : (IEnumerable<HTTPHeaderItem>)oSession.ResponseHeaders;
                            foreach (HTTPHeaderItem tempHead in headerItems)
                            {
                                pickResult = PickFunc(tempHead.ToString(), parameterPick);
                                if (pickResult != null)
                                {
                                    break;
                                }
                            }
                            break;
                        case ParameterPickRange.Entity:
                            if (isWebSocket)
                            {
                                if(webSocketMessage.PayloadLength==0)
                                {
                                    pickResult = null;
                                    break;
                                }
                                pickSource = webSocketMessage.PayloadAsString();
                                pickResult = PickFunc(pickSource, parameterPick);
                            }
                            else
                            {
                                if (((oSession.requestBodyBytes == null || oSession.requestBodyBytes.Length == 0) && isRequest) && ((oSession.ResponseBody == null || oSession.ResponseBody.Length == 0) && isRequest))
                                {
                                    pickResult = null;
                                    break;
                                }
                                pickSource = isRequest ? oSession.GetRequestBodyAsString() : oSession.GetResponseBodyAsString();
                                pickResult = PickFunc(pickSource, parameterPick);
                            }
                            break;
                        default:
                            ShowError("[ParameterizationPick] unkonw pick range");
                            break;
                    }
                    if (pickResult == null)
                    {
                        ShowMes(string.Format("[ParameterizationPick] can not find the parameter with [{0}]", parameterPick.ParameterName));
                    }
                    else
                    {
                        ShowMes(string.Format("[ParameterizationPick] pick the parameter [{0} = {1}]", parameterPick.ParameterName, pickResult));
                        if (nowFiddlerHttpTamper.ActuatorStaticDataController.SetActuatorStaticData(parameterPick.ParameterName, pickResult))
                        {
                            ShowMes(string.Format("[ParameterizationPick] add the parameter [{0}] to ActuatorStaticDataCollection", parameterPick.ParameterName));
                        }
                        else
                        {
                            ShowError(string.Format("[ParameterizationPick] fail to add the parameter [{0}] to ActuatorStaticDataCollection", parameterPick.ParameterName));
                        }
                    }
                }
            }
            else
            {
                ShowError("[ParameterizationPick] not find ParameterPick to pick");
            }
        }

        public static string GetSessionRawData(Session oSession, bool isHaveResponse)
        {
            if (oSession == null)
            {
                return null;
            }
            StringBuilder sbRawData = new StringBuilder();
            MemoryStream ms = new MemoryStream();
            //tempSession.WriteToStream(SmartAssembly, false);
            oSession.WriteRequestToStream(true, true, ms);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms, Encoding.UTF8);
            sbRawData.Append(sr.ReadToEnd());
            sr.Close();
            ms.Close();

            if (oSession.requestBodyBytes != null && oSession.requestBodyBytes.Length > 0)
            {
                sbRawData.AppendLine(oSession.GetRequestBodyAsString());
                sbRawData.Append("\r\n");
            }
            if (isHaveResponse && oSession.bHasResponse)
            {
                sbRawData.AppendLine(oSession.ResponseHeaders.ToString());
                if (oSession.responseBodyBytes != null && oSession.responseBodyBytes.Length > 0)
                {
                    sbRawData.AppendLine(oSession.GetResponseBodyAsString());
                }
            }
            return sbRawData.ToString();
        }

        public static bool GetSessionData(Session oSession, FreeHttpControl.FreeHttpWindow.GetSessionEventArgs sessionEventArgs)
        {
            if (sessionEventArgs == null || oSession==null)
            {
                return false;
            }
            sessionEventArgs.Uri = oSession.fullUrl;
            if (oSession.oRequest!=null)
            {
                sessionEventArgs.RequestHeads = new List<KeyValuePair<string, string>>(oSession.oRequest.headers.Count());
                foreach (var head in oSession.oRequest.headers)
                {
                    sessionEventArgs.RequestHeads.Add(new KeyValuePair<string, string>(head.Name, head.Value));
                }
                if(sessionEventArgs.IsGetEntity)
                {
                    sessionEventArgs.RequestEntity = oSession.GetRequestBodyAsString();
                }
            }
            if (oSession.bHasResponse && oSession.oResponse != null)
            {
                sessionEventArgs.ResponseHeads = new List<KeyValuePair<string, string>>(oSession.oResponse.headers.Count());
                foreach (var head in oSession.oResponse.headers)
                {
                    sessionEventArgs.ResponseHeads.Add(new KeyValuePair<string, string>(head.Name, head.Value));
                }
                if (sessionEventArgs.IsGetEntity)
                {
                    sessionEventArgs.ResponseEntity = oSession.GetResponseBodyAsString();
                }
            }
            return true;
        }
    }
}
