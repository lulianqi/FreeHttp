using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public class HttpResponse
    {
        private string responseLine;
        private int responseCode;
        private List<MyKeyValuePair<string, string>> responseHeads;
        private byte[] responseEntity;

        public string ResponseLine { get { return responseLine; } set { responseLine = value; ChangeRawData(); } }
        public int ResponseCode { get { return responseCode; } set { responseCode = value; ChangeRawData(); } }
        public List<MyKeyValuePair<string, string>> ResponseHeads { get { return responseHeads; } set { responseHeads = value; ChangeRawData(); } }

        public byte[] ResponseEntity { get { return responseEntity; } set { responseEntity = value; ChangeRawData(); } }

        public string OriginSting { get; set; }

        private byte[] rawResponse;
        public HttpResponse()
        {
            ResponseHeads = new List<MyKeyValuePair<string, string>>();
            rawResponse = null;
        }

        public void ChangeRawData()
        {
            rawResponse = null;
        }

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
                string[] ResponseLineStrs = tempString.Split(' ');
                if (ResponseLineStrs.Length < 3)
                {
                    throw new Exception("error format in response line");
                }
                int responseCode;
                if (int.TryParse(ResponseLineStrs[1], out responseCode))
                {
                    httpResponse.ResponseCode = responseCode;
                }
                else
                {
                    throw new Exception("error format in responseCode");
                }
                httpResponse.ResponseLine = tempString;
                //ResponseHeads
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
