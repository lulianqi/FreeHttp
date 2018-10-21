using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public class HttpRequest
    {
        private string requestLine;
        private string requestMethod;
        private string requestUri;
        private string requestVersions;
        private List<KeyValuePair<string, string>> requestHeads;
        private byte[] requestEntity;

        public string RequestLine { get { return requestLine; } set { requestLine = value; ChangeRawData(); } }
        public string RequestMethod { get { return requestMethod; } set { requestMethod = value; ChangeRawData(); } }
        public string RequestUri { get { return requestUri; } set { requestUri = value; ChangeRawData(); } }
        public string RequestVersions { get { return requestVersions; } set { requestVersions = value; ChangeRawData(); } }
        public List<KeyValuePair<string, string>> RequestHeads { get { return requestHeads; } set { requestHeads = value; ChangeRawData(); } }
        public byte[] RequestEntity { get { return requestEntity; } set { requestEntity = value; ChangeRawData(); } }


        public string OriginSting { get;private set; }

        private byte[] rawRequest;
        public HttpRequest()
        {
            RequestHeads = new List<KeyValuePair<string, string>>();
            rawRequest = null;
        }

        public void ChangeRawData()
        {
            rawRequest = null;
        }

        public void SetAutoContentLength()
        {
            if (RequestHeads==null)
            {
                RequestHeads = new List<KeyValuePair<string, string>>();
            }
            else
            {
                List<KeyValuePair<string, string>> mvKvpList = new List<KeyValuePair<string, string>>();
                foreach (KeyValuePair<string, string> kvp in RequestHeads)
                {
                    if (kvp.Key == "Content-Length")
                    {
                        mvKvpList.Add(kvp);
                    }
                }
                if (mvKvpList.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in mvKvpList)
                    {
                        RequestHeads.Remove(kvp);
                    }
                }
            }
            RequestHeads.Add(new KeyValuePair<string, string>("Content-Length", RequestEntity == null ? "0" : RequestEntity.Length.ToString()));
        }
        
        public byte[] GetRawHttpRequest()
        {
            if (rawRequest == null)
            {
                StringBuilder tempResponseSb = new StringBuilder();
                tempResponseSb.AppendLine(RequestLine);
                foreach (var tempHead in RequestHeads)
                {
                    tempResponseSb.AppendLine(string.Format("{0}: {1}", tempHead.Key, tempHead.Value));
                }
                tempResponseSb.Append("\r\n");
                if (RequestEntity != null)
                {
                    rawRequest = Encoding.UTF8.GetBytes(tempResponseSb.ToString()).Concat(RequestEntity).ToArray();
                }
                else
                {
                    rawRequest = Encoding.UTF8.GetBytes(tempResponseSb.ToString());
                }
            }
            return rawRequest;
        }

        public static HttpRequest GetHttpRequest(string yourRequest)
        {
            HttpRequest httpRequest = new HttpRequest();
            httpRequest.OriginSting = yourRequest;
            if (yourRequest != null)
            {
                int tempIndex;
                string tempString;
                //ResponseLine
                tempIndex = yourRequest.IndexOf("\r\n");
                if (tempIndex < 1)
                {
                    throw new Exception("can not find request line");
                }
                tempString = yourRequest.Substring(0, tempIndex);
                string[] requestLineStrs = tempString.Split(' ');
                if (requestLineStrs.Length != 3)
                {
                    throw new Exception("error format in request line");
                }
                httpRequest.RequestMethod = requestLineStrs[0];
                httpRequest.RequestUri = requestLineStrs[1];
                httpRequest.RequestVersions = requestLineStrs[2];
                httpRequest.RequestLine = tempString;
                //ResponseHeads
                yourRequest = yourRequest.Remove(0, tempIndex + 2);
                tempIndex = yourRequest.IndexOf("\r\n");
                while (tempIndex > 0)
                {
                    tempString = yourRequest.Substring(0, tempIndex);
                    yourRequest = yourRequest.Remove(0, tempIndex + 2);
                    tempIndex = tempString.IndexOf(':');
                    if (tempIndex < 0)
                    {
                        throw new Exception(string.Format("error format in response head [{0}]", tempString));
                    }
                    httpRequest.RequestHeads.Add(new KeyValuePair<string, string>(tempString.Substring(0, tempIndex), tempString.Remove(0, tempIndex + 1).TrimStart(' ')));
                    tempIndex = yourRequest.IndexOf("\r\n");
                }
                if (tempIndex < 0)
                {
                    throw new Exception("Please ensure that there is a single empty line after the HTTP headers.");
                }
                //ResponseEntity
                yourRequest = yourRequest.Remove(0, tempIndex + 2);
                if (yourRequest == "\r\n")
                {
                    httpRequest.RequestEntity = new byte[0];
                    return httpRequest;
                }
                else if (yourRequest.StartsWith("<<replace file path>>"))
                {
                    tempString = yourRequest.Remove(0, 21);
                    if (File.Exists(tempString))
                    {
                        using (FileStream fileStream = new FileStream(tempString, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            if (fileStream.Length > int.MaxValue)
                            {
                                throw new Exception(string.Format("your file path in  ResponseEntity is too  large with {0}", tempString));
                            }
                            httpRequest.RequestEntity = new byte[fileStream.Length];
                            fileStream.Read(httpRequest.RequestEntity, 0, httpRequest.RequestEntity.Length);
                        }

                    }
                    else
                    {
                        throw new Exception(string.Format("your file path in  ResponseEntity is not Exists with {0}", tempString));
                    }
                }
                else
                {
                    httpRequest.RequestEntity = Encoding.UTF8.GetBytes(yourRequest);
                }
            }
            return httpRequest;
        }
    }
}
