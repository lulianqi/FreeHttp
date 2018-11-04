using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    public class HttpRequest
    {
        private string requestLine;
        private string requestMethod;
        private string requestUri;
        private string requestVersions;
        private List<MyKeyValuePair<string, string>> requestHeads;
        private byte[] requestEntity;

        /// <summary>
        /// get or set the request line (it will updata RequestMethod,RequestUri,RequestVersions)
        /// </summary>
        public string RequestLine { get { return requestLine; } set { SetRequestLine(value); ChangeRawData(); } }
        
        /// <summary>
        /// get or set the requst method (it will updata RequestLine)
        /// </summary>
        public string RequestMethod { get { return requestMethod; } set { requestMethod = value; UpdataRequestLine(); ChangeRawData(); } }
        
        /// <summary>
        /// get or set the requst uri (it will updata RequestLine)
        /// </summary>
        public string RequestUri { get { return requestUri; } set { requestUri = value; UpdataRequestLine(); ChangeRawData(); } }
        
        /// <summary>
        /// get or set the requst versions (it will updata RequestLine)
        /// </summary>
        public string RequestVersions { get { return requestVersions; } set { requestVersions = value; UpdataRequestLine(); ChangeRawData(); } }
        
        /// <summary>
        /// get or set request heads (if you not set the List<MyKeyValuePair<string, string>> and just change or add a element ,the ChangeRawData() will not trigger ,so your should call ChangeRawData() )
        /// </summary>
        public List<MyKeyValuePair<string, string>> RequestHeads { get { return requestHeads; } set { requestHeads = value; ChangeRawData(); } }

        /// <summary>
        /// get or set request body (if you not set the byte[] and just change or add a element ,the ChangeRawData() will not trigger ,so your should call ChangeRawData() )
        /// </summary>
        public byte[] RequestEntity { get { return requestEntity; } set { requestEntity = value; ChangeRawData(); } }

        //public string OriginSting { get; private set; }
        /// <summary>
        /// get or set OriginSting (the OriginSting is not the infor in http ,it only use for show ui)
        /// </summary>
        public string OriginSting { get; set; }

        private byte[] rawRequest;
        public HttpRequest()
        {
            RequestHeads = new List<MyKeyValuePair<string, string>>();
            rawRequest = null;
        }

        private void SetRequestLine(string yourRequestLine)
        {
            string[] requestLineStrs = yourRequestLine.Split(new char[] { ' ' }, 3);
            if (requestLineStrs.Length !=3)
            {
                throw new Exception("error format in response line");
            }
            requestMethod = requestLineStrs[0];
            requestUri = requestLineStrs[1];
            requestVersions = requestLineStrs[2];
            requestLine = yourRequestLine;
        }

        private void UpdataRequestLine()
        {
            requestLine = string.Format("{0} {1} {2}", requestMethod == null ? "" : requestMethod, requestUri == null ? "" : requestUri, requestVersions == null ? "" : requestVersions);
        }

        /// <summary>
        /// when you want refresh the GetRawHttpRequest cache call it
        /// </summary>
        public void ChangeRawData()
        {
            rawRequest = null;
        }

        /// <summary>
        /// reset ContentLength with the accurate value
        /// </summary>
        public void SetAutoContentLength()
        {
            if (RequestHeads==null)
            {
                RequestHeads = new List<MyKeyValuePair<string, string>>();
            }
            else
            {
                List<MyKeyValuePair<string, string>> mvKvpList = new List<MyKeyValuePair<string, string>>();
                foreach (MyKeyValuePair<string, string> kvp in RequestHeads)
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
                        RequestHeads.Remove(kvp);
                    }
                }
            }
            RequestHeads.Add(new MyKeyValuePair<string, string>("Content-Length", RequestEntity == null ? "0" : RequestEntity.Length.ToString()));
        }
        
        /// <summary>
        /// Get the raw byte[] request (it will use cache ,if you want refresh it just call ChangeRawData() first)
        /// </summary>
        /// <returns>request bytes</returns>
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

        /// <summary>
        /// Get HttpRequest from a raw data string (it will throw exception when find the error string)
        /// </summary>
        /// <param name="yourRequest">raw request string </param>
        /// <returns>HttpRequest</returns>
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
                httpRequest.SetRequestLine(tempString);
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
                    httpRequest.RequestHeads.Add(new MyKeyValuePair<string, string>(tempString.Substring(0, tempIndex), tempString.Remove(0, tempIndex + 1).TrimStart(' ')));
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
