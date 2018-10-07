using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public class HttpResponse
    {
        public string ResponseLine { get; set; }
        public int ResponseCode { get; set; }
        public List<KeyValuePair<string, string>> ResponseHeads { get; set; }

        public byte[] ResponseEntity { get; set; }
        public HttpResponse()
        {
            ResponseHeads = new List<KeyValuePair<string, string>>();
        }

        public byte[] GetRawHttpResponse()
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
                return Encoding.UTF8.GetBytes(tempResponseSb.ToString()).Concat(ResponseEntity).ToArray();
            }
            else
            {
                return Encoding.UTF8.GetBytes(tempResponseSb.ToString());
            }
        }

        public static HttpResponse GetHttpResponse(string yourResponse)
        {
            HttpResponse httpResponse = new HttpResponse();
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
                    httpResponse.ResponseHeads.Add(new KeyValuePair<string, string>(tempString.Substring(0, tempIndex), tempString.Remove(0, tempIndex + 1).TrimStart(' ')));
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
