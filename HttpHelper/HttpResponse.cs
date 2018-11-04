using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    public class HttpResponse
    {
        private string responseLine;
        private string responseVersion;
        private int responseCode;
        private string responseStatusDescription;
        private List<MyKeyValuePair<string, string>> responseHeads;
        private byte[] responseEntity;

        /// <summary>
        /// get or set the response line (it will updata ResponseStatusDescription,ResponseVersion,ResponseCode)
        /// </summary>
        public string ResponseLine { get { return responseLine; } set { SetResponseLine(value); ChangeRawData(); } }

        /// <summary>
        /// get or set the response version (it will updata ResponseLine)
        /// </summary>
        public string ResponseVersion { get { return responseVersion; } set { responseVersion = value; UpdataResponseLine(); ChangeRawData(); } }

        /// <summary>
        /// get or set the response code (it will updata ResponseLine)
        /// </summary>
        public int ResponseCode { get { return responseCode; } set { responseCode = value; UpdataResponseLine(); ChangeRawData(); } }

        /// <summary>
        /// get or set the response StatusDescription (it will updata ResponseLine)
        /// </summary>
        public string ResponseStatusDescription { get { return responseStatusDescription; } set { responseStatusDescription = value; UpdataResponseLine(); ChangeRawData(); } }

        /// <summary>
        /// get or set response heads (if you not set the List<MyKeyValuePair<string, string>> and just change or add a element ,the ChangeRawData() will not trigger ,so your should call ChangeRawData() )
        /// </summary>
        public List<MyKeyValuePair<string, string>> ResponseHeads { get { return responseHeads; } set { responseHeads = value; ChangeRawData(); } }

        /// <summary>
        /// get or set response body (if you not set the byte[] and just change or add a element ,the ChangeRawData() will not trigger ,so your should call ChangeRawData() )
        /// </summary>
        public byte[] ResponseEntity { get { return responseEntity; } set { responseEntity = value; ChangeRawData(); } }

        /// <summary>
        /// get or set OriginSting (the OriginSting is not the infor in http ,it only use for show ui)
        /// </summary>
        public string OriginSting { get; set; }

        private byte[] rawResponse;
        public HttpResponse()
        {
            ResponseHeads = new List<MyKeyValuePair<string, string>>();
            rawResponse = null;
        }

        private void SetResponseLine(string yourResponseLine)
        {
            string[] responseLineStrs = yourResponseLine.Split(new char[] { ' ' }, 3);
            if (responseLineStrs.Length < 2)
            {
                throw new Exception("error format in response line");
            }
            responseVersion = responseLineStrs[0];
            int tempCode;
            if (int.TryParse(responseLineStrs[1], out tempCode))
            {
                responseCode = tempCode;
            }
            else
            {
                throw new Exception("error format in responseCode");
            }
            responseStatusDescription = responseLineStrs.Length == 3 ? responseLineStrs[2] : "";
            responseLine = yourResponseLine;
        }

        private void UpdataResponseLine()
        {
            responseLine = string.Format("{0} {1} {2}", responseVersion == null ? "" : responseVersion, responseCode.ToString(), responseStatusDescription == null ? "" : responseStatusDescription);
        }

        /// <summary>
        /// when you want refresh the GetRawHttpResponse cache call it
        /// </summary>
        public void ChangeRawData()
        {
            rawResponse = null;
        }

        /// <summary>
        /// reset ContentLength with the accurate value
        /// </summary>
        public void SetAutoContentLength()
        {
            if (ResponseHeads == null)
            {
                ResponseHeads = new List<MyKeyValuePair<string, string>>();
            }
            else
            {
                List<MyKeyValuePair<string, string>> mvKvpList = new List<MyKeyValuePair<string, string>>();
                foreach (MyKeyValuePair<string, string> kvp in ResponseHeads)
                {
                    if (kvp.Key == "Content-Length")
                    {
                        mvKvpList.Add(kvp);
                    }
                }
                if (mvKvpList.Count > 0)
                {
                    foreach (MyKeyValuePair<string, string> kvp in mvKvpList)
                    {
                        ResponseHeads.Remove(kvp);
                    }
                }
            }
            ResponseHeads.Add(new MyKeyValuePair<string, string>("Content-Length", ResponseEntity == null ? "0" : ResponseEntity.Length.ToString()));
        }

        /// <summary>
        /// Get the raw byte[] response (it will use cache ,if you want refresh it just call ChangeRawData() first)
        /// </summary>
        /// <returns></returns>
        public byte[] GetRawHttpResponse()
        {
            if (rawResponse == null)
            {
                StringBuilder tempResponseSb = new StringBuilder();
                tempResponseSb.AppendLine(ResponseLine);
                foreach (var tempHead in ResponseHeads)
                {
                    tempResponseSb.AppendLine(string.Format("{0}: {1}", tempHead.Key, tempHead.Value));
                }
                tempResponseSb.Append("\r\n");
                if (ResponseEntity != null)
                {
                    rawResponse = Encoding.UTF8.GetBytes(tempResponseSb.ToString()).Concat(ResponseEntity).ToArray();
                }
                else
                {
                    rawResponse = Encoding.UTF8.GetBytes(tempResponseSb.ToString());
                }
            }
            return rawResponse;
        }

        /// <summary>
        /// Get HttpResponse from a raw data string (it will throw exception when find the error string)
        /// </summary>
        /// <param name="yourResponse">raw response string</param>
        /// <returns>HttpResponse</returns>
        public static HttpResponse GetHttpResponse(string yourResponse)
        {
            HttpResponse httpResponse = new HttpResponse();
            httpResponse.OriginSting = yourResponse;
            if (yourResponse != null)
            {
                int tempIndex;
                string tempString;
                //ResponseLine
                tempIndex = yourResponse.IndexOf("\r\n");
                if (tempIndex < 1)
                {
                    throw new Exception("can not find response line");
                }
                tempString = yourResponse.Substring(0, tempIndex);
                httpResponse.SetResponseLine(tempString);
                #region SetResponseLine replace
                //string[] ResponseLineStrs = tempString.Split(new char[]{' '},3);
                //if (ResponseLineStrs.Length < 2)
                //{
                //    throw new Exception("error format in response line");
                //}
                //httpResponse.responseVersion = ResponseLineStrs[0];
                //int responseCode;
                //if (int.TryParse(ResponseLineStrs[1], out responseCode))
                //{
                //    httpResponse.responseCode = responseCode;
                //}
                //else
                //{
                //    throw new Exception("error format in responseCode");
                //}
                //httpResponse.responseStatusDescription = ResponseLineStrs.Length == 3 ? ResponseLineStrs[2] : "";
                //httpResponse.responseLine = tempString;
                //ResponseHeads 
                #endregion
                yourResponse = yourResponse.Remove(0, tempIndex + 2);
                tempIndex = yourResponse.IndexOf("\r\n");
                while (tempIndex > 0)
                {
                    tempString = yourResponse.Substring(0, tempIndex);
                    yourResponse = yourResponse.Remove(0, tempIndex + 2);
                    tempIndex = tempString.IndexOf(':');
                    if (tempIndex < 0)
                    {
                        throw new Exception(string.Format("error format in response head [{0}]", tempString));
                    }
                    httpResponse.ResponseHeads.Add(new MyKeyValuePair<string, string>(tempString.Substring(0, tempIndex), tempString.Remove(0, tempIndex + 1).TrimStart(' ')));
                    tempIndex = yourResponse.IndexOf("\r\n");
                }
                if (tempIndex < 0)
                {
                    throw new Exception("Please ensure that there is a single empty line after the HTTP headers.");
                }
                //ResponseEntity
                yourResponse = yourResponse.Remove(0, tempIndex + 2);
                if (yourResponse == "\r\n")
                {
                    httpResponse.ResponseEntity = new byte[0];
                    return httpResponse;
                }
                else if (yourResponse.StartsWith("<<replace file path>>"))
                {
                    tempString = yourResponse.Remove(0, 21);
                    if (File.Exists(tempString))
                    {
                        using (FileStream fileStream = new FileStream(tempString, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            if (fileStream.Length > int.MaxValue)
                            {
                                throw new Exception(string.Format("your file path in  ResponseEntity is too  large with {0}", tempString));
                            }
                            httpResponse.ResponseEntity = new byte[fileStream.Length];
                            fileStream.Read(httpResponse.ResponseEntity, 0, httpResponse.ResponseEntity.Length);
                        }

                    }
                    else
                    {
                        throw new Exception(string.Format("your file path in  ResponseEntity is not Exists with {0}", tempString));
                    }
                }
                else
                {
                    httpResponse.ResponseEntity = Encoding.UTF8.GetBytes(yourResponse);
                }
            }
            return httpResponse;
        }
    }
}
