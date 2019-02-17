using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


/*******************************************************************************
* Copyright (c) 2015 lijie
* All rights reserved.
* 
* 文件名称: 
* 内容摘要: mycllq@hotmail.com
* 
* 历史记录:
* 日	  期:   201505016           创建人: 李杰 15158155511
* 描    述: 创建  (this file is from https://github.com/lulianqi/AutoTest/blob/master/AutoTest/MyCommonHelper/NetHelper/MyWebTool.cs)
*******************************************************************************/


//from  https://github.com/lulianqi/AutoTest/blob/master/AutoTest/MyCommonHelper/NetHelper/MyWebTool.cs
namespace FreeHttp.WebService
{
    public class MyWebTool
    {
        public class HttpMultipartDate
        {
            /** eg：
            -----------------8d46c074125a195
            Content-Disposition: form-data; name="name"; filename="filenmae"
            Content-Type: application/octet-stream

            testdata
            -----------------8d46c074125a195--
             * */
          
            /// <summary>
            /// name属性值,为null则不加
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// filename属性值,为null则不加
            /// </summary>
            public string FileName { get; set; }
            /// <summary>
            /// Multipart下Content-Type: application/octet-stream,为null则不加
            /// </summary>
            public string ContentType { get; set; }
            /// <summary>
            /// 是否把fileData当作文件路径处理
            /// </summary>
            public bool IsFile { get; set; }
            /// <summary>
            /// 文件内容或文件路径。为null则当作""
            /// </summary>
            public string FileData { get; set; }
            public HttpMultipartDate()
            {
                Name = FileName = ContentType = FileData = null;
            }

            /// <summary>
            /// 初始化 HttpMultipartDate
            /// </summary>
            /// <param name="yourName">name属性值,为null则不加</param>
            /// <param name="yourFileName">filename属性值,为null则不加</param>
            /// <param name="yourContentType">Multipart下Content-Type: application/octet-stream,为null则为默认值application/octet-stream</param>
            /// <param name="yourIsFile">是否把fileData当作文件路径处理</param>
            /// <param name="yourFileData">文件内容或文件路径。为null则当作""（作为路径时如果路径不存在将会返回错误）</param>
            public HttpMultipartDate(string yourName,string yourFileName,string yourContentType,bool yourIsFile,string yourFileData)
            {
                Name = yourName;
                FileName = yourFileName;
                ContentType = yourContentType;
                IsFile = yourIsFile;
                FileData = yourFileData;
            }

        }

        public class HttpHelper
        {
            private delegate void SetHeadAttributeCallback(HttpWebRequest yourRequest, string yourHeadValue);

            private static Dictionary<string, SetHeadAttributeCallback> dicHeadSetFun = new Dictionary<string, SetHeadAttributeCallback>();
            static HttpHelper()
            {
                dicHeadSetFun.Add("Accept".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.Accept = yourHeadValue));
                dicHeadSetFun.Add("Connection".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => { string tempHeadVaule = yourHeadValue.ToLower(); if (tempHeadVaule.IndexOf("keep-alive") != -1) { yourRequest.KeepAlive = true; } else if (tempHeadVaule.IndexOf("closee") != -1) { yourRequest.KeepAlive = false; } else { yourRequest.Connection = yourHeadValue; } }));
                dicHeadSetFun.Add("Date".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => { DateTime tempTime; if (!DateTime.TryParse(yourHeadValue, out tempTime)) tempTime = DateTime.Now; yourRequest.Date = tempTime; }));  //2009-05-01 14:57:32 //修改该头需要4.0版本支持，如果升级4.0可以取消该注释，启用该功能
                //dicHeadSetFun.Add("KeepAlive".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.KeepAlive = yourHeadValue));//该头可以直接使用Headers.Add
                dicHeadSetFun.Add("Transfer-Encoding".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.TransferEncoding = yourHeadValue));
                dicHeadSetFun.Add("Content-Length".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => { int tempLen; if (!int.TryParse(yourHeadValue, out tempLen)) tempLen = 0; yourRequest.ContentLength = tempLen; }));
                dicHeadSetFun.Add("Content-Type".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.ContentType = yourHeadValue));
                dicHeadSetFun.Add("Expect".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.Expect = yourHeadValue));
                dicHeadSetFun.Add("Host".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.Host = yourHeadValue)); //修改该头需要4.0版本支持，如果升级4.0可以取消该注释，启用该功能
                dicHeadSetFun.Add("IfModifiedSince".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.Referer = yourHeadValue));
                dicHeadSetFun.Add("Referer".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.Referer = yourHeadValue));
                dicHeadSetFun.Add("User-Agent".ToUpper(), new SetHeadAttributeCallback((yourRequest, yourHeadValue) => yourRequest.UserAgent = yourHeadValue));
            }

            /// <summary>
            /// 添加http请求头属性（特殊属性自动转化为dicHeadSetFun中委托完成设置）
            /// </summary>
            /// <param name="httpWebRequest">HttpWebRequest</param>
            /// <param name="heads">属性列表</param>
            public static void AddHttpHeads(HttpWebRequest httpWebRequest, List<KeyValuePair<string, string>> heads)
            {
                if (httpWebRequest == null)
                {
                    return;
                }
                if (heads != null && heads.Count>0)
                {
                    foreach (var Head in heads)
                    {
                        if (dicHeadSetFun.ContainsKey(Head.Key.ToUpper()))
                        {
                            (dicHeadSetFun[Head.Key.ToUpper()])(httpWebRequest, Head.Value);
                        }
                        else
                        {
                            httpWebRequest.Headers.Add(Head.Key, Head.Value);
                        }
                    }
                }
            }



            /// <summary>
            /// 添加http请求头属性（全部使用默认header.Add进行添加，失败后使用SetHeaderValue进行添加，不过依然可能失败）
            /// </summary>
            /// <param name="header">WebHeaderCollection</param>
            /// <param name="heads">属性列表</param>
            public static void AddHttpHeads(WebHeaderCollection header, List<KeyValuePair<string, string>> heads)
            {
                if (header == null)
                {
                    return;
                }
                if (heads != null)
                {
                    //wr.Headers.Add(new NameValueCollection());
                    foreach (var Head in heads)
                    {
                        try
                        {
                            header.Add(Head.Key, Head.Value);
                            //((HttpWebRequest)wr).Headers.Add(HttpRequestHeader.Host, "www.contoso.com"); //必须用适当的属性修改host   使用4.0也报必须使用适当的属性或方法修改“Host”标头
                            //((HttpWebRequest)wr).Headers.Add("Host", "192.168.0.1");//这样一样不行
                            //SetHeaderValue(wr.Headers, "Host", "www.contoso.com:8080");//即使是4.0也无法直接修改
                            //((HttpWebRequest)wr).Host = "www.contoso.com:8080";//只有这种方式在4.0可以生效
                        }
                        catch (Exception ex)
                        {
                            SetHeaderValue(header, Head.Key, Head.Value);
                            MyHttp.GetError(ex);
                        }
                    }
                }
            }

            /// <summary>
            /// 设置请求头（注意该方法未经过测试，使用前请先测试）
            /// </summary>
            /// <param name="header">WebHeaderCollection</param>
            /// <param name="name">key</param>
            /// <param name="value">value</param>
            public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
            {
                var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (property != null)
                {
                    var collection = property.GetValue(header, null) as NameValueCollection;
                    collection[name] = value;
                }
            }
        }

        public class HttpTimeLine
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime StartTime { get; set; }

            /// <summary>
            /// 耗时（毫秒为单位）
            /// </summary>
            public long ElapsedTime { get; set; }

            public HttpTimeLine()
            {
                ElapsedTime = 0;
            }
        }

        public class MyHttpResponse
        {
            private int statusCode = -99;
            private string responseLine = null;
            private string responseBody = null;
            private string responseRaw = null;
            private string errorMes=null;
            public HttpTimeLine TimeLine { get; internal set; }
            public HttpWebResponse HttpResponse { get; internal set; }
            public string ErrorMes 
            {   get{return errorMes;}
                internal set { errorMes = value; responseBody = value; }
            }

            public MyHttpResponse()
            {
                TimeLine = null;
                HttpResponse = null;
            }

            public int StatusCode
            {
                get
                {
                    if (HttpResponse == null)
                    {
                        return 0;
                    }
                    if (statusCode == -99)
                    {
                        statusCode = (int)HttpResponse.StatusCode;
                    }
                    return statusCode;
                }
            }

            public string ResponseLine
            {
                get
                {
                    if (responseLine == null && HttpResponse != null)
                    {
                        responseLine = string.Format(@"HTTP/{0} {1} {2}",
                            HttpResponse.ProtocolVersion==null? "NULL":HttpResponse.ProtocolVersion.ToString(),
                            StatusCode, 
                            HttpResponse.StatusCode==null? "NULL" :HttpResponse.StatusCode.ToString());
                    }
                    return responseLine;
                }
            }

            public WebHeaderCollection ResponseHeads
            {
                get
                {
                    if (HttpResponse == null)
                    {
                        return null;
                    }
                    return HttpResponse.Headers;
                }
            }

            public string ResponseBody
            {
                get
                {
                    if (responseBody == null && HttpResponse != null)
                    {
                        SeekResponseStream();
                    }
                    return responseBody;
                }
            }
            public string ResponseRaw
            {
                get
                {
                    if (responseRaw == null && HttpResponse != null)
                    {
                        responseRaw = string.Format("{0}\r\n{1}{2}", ResponseLine ?? "NULL", ResponseHeads.ToString(), ResponseBody ?? "NULL");
                    }
                    return responseRaw;
                }
            }

            internal void SavaData(string saveFileName)
            {
                Stream receiveStream = null;
                try
                {
                    using (FileStream stream = new FileStream(saveFileName, FileMode.Create, FileAccess.Write, FileShare.Write))
                    {
                        receiveStream = HttpResponse.GetResponseStream();
                        int tempReadCount = 1024;
                        byte[] infbytes = new byte[tempReadCount]; //反复使用前也不要清空，因为后面写入会指定有效长度
                        int tempLen = tempReadCount;
                        int offset = 0;
                        while (tempLen >= tempReadCount)
                        {
                            tempLen = receiveStream.Read(infbytes, 0, tempReadCount);
                            stream.Write(infbytes, 0, tempLen);//FileStream 内建缓冲区，不用自己构建缓存写入,FileStream的offset会自动维护，也可以使用stream.Position强制指定
                            offset += tempLen;
                        }
                        responseBody = string.Format("file save success in [ {0} ]  with {1}byte", saveFileName, offset);
                    }
                    #region WriteAllBytes
                    /**
                    byte[] infbytes = new byte[10240];
                    int tempLen = 512;
                    int offset = 0;

                    //数据最多20k可以不需要分段读取
                    while (tempLen - 512 >= 0)
                    {
                    tempLen = ReceiveStream.Read(infbytes, offset, 512);
                    offset += tempLen;
                    }
                    byte[] bytesToSave = new byte[offset];
                    for (int i = 0; i < offset; i++)
                    {
                    bytesToSave[i] = infbytes[i];
                    }
                    File.WriteAllBytes(saveFileName, bytesToSave);
                    */
                    #endregion
                }
                catch(Exception ex)
                {
                    responseBody = string.Format("file save fail with [ {0} ]  ", ex.Message);
                }
                finally
                {
                    if(receiveStream!=null)
                    {
                        receiveStream.Close();
                    }
                }
             }

            internal void SeekResponseStream()
            {
                if (HttpResponse != null && responseBody == null)
                {
                    Stream receiveStream = HttpResponse.GetResponseStream();
                    Encoding nowEncoding;
                    try
                    {
                        nowEncoding = string.IsNullOrEmpty(HttpResponse.CharacterSet) ? Encoding.UTF8 : Encoding.GetEncoding(HttpResponse.CharacterSet);
                    }
                    catch
                    {
                        nowEncoding = Encoding.UTF8;
                    }
                    try
                    {
                        using (var responseStreamReader = new StreamReader(receiveStream, nowEncoding))  //will close the HttpResponse Stream
                        {
                            responseBody = responseStreamReader.ReadToEnd();
                        }
                    }
                    catch(Exception ex)
                    {
                        responseBody = ex.Message;
                    }
                    #region Read
                    //使用如下方法自己读取byte[] 是可行的，不过在Encoding 可变编码方式时，不能确保分段不被截断，直接使用内置StreamReader也是可以的
                    /**  
                    Byte[] read = new Byte[512];
                    int bytes = receiveStream.Read(read, 0, 512);
                    if (showResponseHeads)
                    {
                        re = result.Headers.ToString();
                    }
                    while (bytes > 0)
                    {
                        re += responseEncoding.GetString(read, 0, bytes);
                        bytes = receiveStream.Read(read, 0, 512);
                    }
                     * */
                    #endregion
                }
            }
        }

        public class MyHttp
        {
            private int httpTimeOut = 100000;                                               //http time out ,SendData and HttpPostData will use this value   （连接超时）
            private int httpReadWriteTimeout = 300000;                                      //WebRequest.ReadWriteTimeout  [未使用]          （读取/写入超时）
            private string defaultContentType = null;                                       //请求默认ContentType  (Content-Type: text/plain; charset=utf-8)
            private bool withDefaultCookieContainer = false;                                //是否默认启用CookieContainer，如果启用则默认会管理所有使用MyHttp的cookie内容
            private bool recordRequestTimeLine = true;                                      //是否记录请求时间线
            private readonly string EOF = "\r\n";
            private CookieContainer cookieContainer;
            private List<KeyValuePair<string, string>> requestDefaultHeads;


            public Encoding RequestEncoding {get;set;}  //需要发送数据，将使用此编码   [未使用]
            public Encoding ResponseEncoding {get;set;} //如果要显示返回数据，返回数据将使用此编码  [未使用]

            /// <summary>
            /// get or set HttpTimeOut
            /// </summary>
            public int HttpTimeOut
            { 
                get { return httpTimeOut; } set { httpTimeOut = value; }
            }

            /// <summary>
            /// get or set default ContentType
            /// </summary>
            public string DefaultContentType
            { 
                get { return defaultContentType; } set { defaultContentType = value; } 
            }

            /// <summary>
            /// get is record RequestTimeLine
            /// </summary>
            public bool IsrecordRequestTimeLine
            {
                get { return recordRequestTimeLine; }
            }

            /// <summary>
            /// get or set is use DefaultCookieContainer
            /// </summary>
            public bool IsWithDefaultCookieContainer
            {
                get { return withDefaultCookieContainer; } set { withDefaultCookieContainer = value; } 
            }

            /// <summary>
            /// get Inner CookieContainer
            /// </summary>
            public CookieContainer InnerCookieContainer
            {
                get { return cookieContainer ; }
            }

            /// <summary>
            /// get default request heads
            /// </summary>
            public List<KeyValuePair<string, string>> RequestDefaultHeads
            {
                get { return requestDefaultHeads ; }
            }

            static MyHttp()
            {
                //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(
                //    (sender, certificate, chain, sslPolicyErrors) => { return true; });
                ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
                //Console.WriteLine(ServicePointManager.DefaultConnectionLimit); //默认最大并发数有限，可以使用System.Net.ServicePointManager.DefaultConnectionLimit重设该值
                System.Net.ServicePointManager.DefaultConnectionLimit = 2000;
            }

            private static bool MyRemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }

            public MyHttp()
            {
                //cookieContainer = new CookieContainer(5000, 500, 1000);
                cookieContainer = new CookieContainer();
                requestDefaultHeads = new List<KeyValuePair<string, string>>();
                RequestEncoding = System.Text.Encoding.GetEncoding("UTF-8");  
                ResponseEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            }

            public MyHttp(bool isRecordRequestTimeLine, bool isWithDefaultCookieContainer)
                : this()
            {
                recordRequestTimeLine = isRecordRequestTimeLine;
                withDefaultCookieContainer = isWithDefaultCookieContainer;
            }


            /// <summary>
            /// Send Http Request 
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) [ <scheme>://<user>:<password>@<host>:<port>/<path>;<params>?<query>#<frag> ]</param>
            /// <param name="data"> queryStr will add to the url (like url+?+data )  if method is not POST or PUT queryStr will add in request entity as body</param>
            /// <param name="method">GET/POST/PUT/HEAD/TRACE/OPTIONS/DELETE</param>
            /// <returns>back data</returns>
            public string SendData(string url, string data, string method)
            {
                return SendData(url, data, method, null,null);
            }

            /// <summary>
            /// Send Http Request 
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) [ <scheme>://<user>:<password>@<host>:<port>/<path>;<params>?<query>#<frag> ]</param>
            /// <returns>back data</returns>
            public string SendData(string url)
            {
                return SendData(url, null, "GET", null,null);
            }

            /// <summary>
            /// Send Http Request 
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) [ <scheme>://<user>:<password>@<host>:<port>/<path>;<params>?<query>#<frag> ]</param>
            /// <param name="data"> queryStr will add to the url (like url+?+data )  if method is not POST or PUT queryStr will add in request entity as body</param>
            /// <param name="method">GET/POST/PUT/HEAD/TRACE/OPTIONS/DELETE</param>
            /// <param name="heads">http Head list （if not need set it null）(header 名是不区分大小写的)</param>
            /// <returns>back data</returns>
            public string SendData(string url, string data, string method, List<KeyValuePair<string, string>> heads)
            {
                return SendData(url, data, method, heads, null);
            }

            /// <summary>
            /// Send Http Request 
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) [ <scheme>://<user>:<password>@<host>:<port>/<path>;<params>?<query>#<frag> ]</param>
            /// <param name="data"> queryStr will add to the url (like url+?+data )  if method is not POST or PUT queryStr will add in request entity as body</param>
            /// <param name="method">GET/POST/PUT/HEAD/TRACE/OPTIONS/DELETE</param>
            /// <param name="heads">http Head list （if not need set it null）(header 名是不区分大小写的)</param>
            /// <param name="saveFileName">save your response as file （if not need set it null）</param>
            /// <returns>back data</returns>
            public string SendData(string url, string data, string method, List<KeyValuePair<string, string>> heads, string saveFileName)
            {
                return SendData(url, data, method, heads, saveFileName,null);
            }

            /// <summary>
            /// Send Http Request 
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) [ <scheme>://<user>:<password>@<host>:<port>/<path>;<params>?<query>#<frag> ]</param>
            /// <param name="data"> queryStr will add to the url (like url+?+data )  if method is not POST or PUT queryStr will add in request entity as body</param>
            /// <param name="method">GET/POST/PUT/HEAD/TRACE/OPTIONS/DELETE</param>
            /// <param name="heads">http Head list （if not need set it null）(header 名是不区分大小写的)</param>
            /// <param name="saveFileName">save your response as file （if not need set it null）</param>
            /// <param name="manualResetEvent">ManualResetEvent 并发集合点 （if not need set it null）</param>
            /// <returns>back data</returns>
            public string SendData(string url, string data, string method, List<KeyValuePair<string, string>> heads, string saveFileName, System.Threading.ManualResetEvent manualResetEvent)
            {
                return SendData(url, data, method, heads, withDefaultCookieContainer, saveFileName, null);
            }

            /// <summary>
            /// Send Http Request 
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) [ <scheme>://<user>:<password>@<host>:<port>/<path>;<params>?<query>#<frag> ]</param>
            /// <param name="data"> queryStr will add to the url (like url+?+data )  if method is not POST or PUT queryStr will add in request entity as body</param>
            /// <param name="method">GET/POST/PUT/HEAD/TRACE/OPTIONS/DELETE</param>
            /// <param name="heads">http Head list （if not need set it null）(header 名是不区分大小写的)</param>
            /// <param name="isAntoCookie">is use static CookieContainer （是否使用默认CookieContainer管理cookie，优先级高于withDefaultCookieContainer）(使用CookieContainer ，将不能手动在header中设置cookies)</param>
            /// <param name="saveFileName">save your response as file （if not need set it null）</param>
            /// <param name="manualResetEvent">ManualResetEvent 并发集合点 （if not need set it null）</param>
            /// <returns>back data</returns>
            public string SendData(string url, string data, string method, List<KeyValuePair<string, string>> heads,bool isAntoCookie ,string saveFileName, System.Threading.ManualResetEvent manualResetEvent)
            {
                return SendHttpRequest(url, data, method, heads, isAntoCookie, saveFileName, manualResetEvent).ResponseBody;
            }

            /// <summary>
            /// Send Http Request 
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) [ <scheme>://<user>:<password>@<host>:<port>/<path>;<params>?<query>#<frag> ]</param>
            /// <param name="queryStr"> queryStr will add to the url (like url+?+data )  if method is not POST or PUT queryStr will add in request entity as body</param>
            /// <param name="method">GET/POST/PUT/HEAD/TRACE/OPTIONS/DELETE</param>
            /// <param name="heads">http Head list （if not need set it null）(header 名是不区分大小写的)</param>
            /// <param name="isAntoCookie">is use static CookieContainer （是否使用默认CookieContainer管理cookie，优先级高于withDefaultCookieContainer）(使用CookieContainer ，将不能手动在header中设置cookies)</param>
            /// <param name="saveFileName">save your response as file （if not need set it null）</param>
            /// <param name="manualResetEvent">ManualResetEvent 并发集合点 （if not need set it null）</param>
            /// <returns>MyHttpResponse</returns>
            public MyHttpResponse SendHttpRequest(string url, string queryStr, string method, List<KeyValuePair<string, string>> heads, bool isAntoCookie, string saveFileName, System.Threading.ManualResetEvent manualResetEvent)
            {
                MyHttpResponse myHttpResponse = new MyHttpResponse();
                HttpTimeLine timeline = new HttpTimeLine();
                Stopwatch myWatch = null;

                Action WaitStartSignal = () =>
                {
                    if (manualResetEvent != null)
                    {
                        manualResetEvent.WaitOne();
                    }

                    if (recordRequestTimeLine)
                    {
                        timeline.StartTime = DateTime.Now;
                        myWatch.Start();
                    }
                };

                if (recordRequestTimeLine)
                {
                    myWatch = new Stopwatch();
                }
                bool hasQueryString = !string.IsNullOrEmpty(queryStr);
                bool needBody = method.ToUpper() == "POST" || method.ToUpper() == "PUT";
                WebRequest webRequest = null;
                WebResponse webResponse = null;

                try
                {
                    //except POST / PUT other data will add the url,if you want adjust the rules change here
                    if (!needBody && hasQueryString)
                    {
                        url += "?" + queryStr;
                        queryStr = null;           //make sure the data is null when Request is not post
                    }
                    webRequest = WebRequest.Create(url);
                    webRequest.Timeout = httpTimeOut;
                    webRequest.Method = method;
                    //((HttpWebRequest)wr).KeepAlive = true;
                    //((HttpWebRequest)wr).Pipelined = true;

                    if (isAntoCookie)
                    {
                        ((HttpWebRequest)webRequest).CookieContainer = cookieContainer;  //设置CookieContainer后，将不能在heads中手动添加cookie
                    }
                    if (defaultContentType != null)
                    {
                        webRequest.ContentType = defaultContentType;
                    }
                    HttpHelper.AddHttpHeads((HttpWebRequest)webRequest, requestDefaultHeads);
                    HttpHelper.AddHttpHeads((HttpWebRequest)webRequest, heads);

                    if (needBody)
                    {
                        if (hasQueryString)
                        {
                            byte[] tempBodyBytes = null;
                            tempBodyBytes = RequestEncoding.GetBytes(queryStr);
                            webRequest.ContentLength = tempBodyBytes.Length;
                            WaitStartSignal();                                       //尽可能确保所有manualResetEvent都在数据完全准备完成后
                            Stream newStream = webRequest.GetRequestStream();        //连接建立Head已经发出，POST请求体还没有发送 (服务器可能会先回http 100)  (包括tcp及TLS链接建立都在这里)
                            newStream.Write(tempBodyBytes, 0, tempBodyBytes.Length);         //请求交互完成
                            newStream.Close();                                       //释放写入流（MSDN的示例也是在此处释放）(执行到此处请求就已经结束)
                            webResponse = webRequest.GetResponse();                  //此处的GetResponse不会发起任何网络请求，只是为了填充webResponse
                            if (recordRequestTimeLine)
                            {
                                myWatch.Stop();
                            }
                        }
                        else
                        {
                            webRequest.ContentLength = 0;
                            WaitStartSignal();
                            webResponse = webRequest.GetResponse();
                            if (recordRequestTimeLine)
                            {
                                myWatch.Stop();
                            }
                        }
                    }
                    else
                    {
                        WaitStartSignal();
                        webResponse = webRequest.GetResponse();                       //GetResponse 方法向 Internet 资源发送请求并返回 WebResponse 实例。如果该请求已由 GetRequestStream 调用启动，则 GetResponse 方法完成该请求并返回任何响应。
                        if (recordRequestTimeLine)
                        {
                            myWatch.Stop();
                        }
                    }

                    if (isAntoCookie)
                    {

                        if (((HttpWebResponse)webResponse).Cookies != null && ((HttpWebResponse)webResponse).Cookies.Count > 0)
                        {
                            cookieContainer.Add(((HttpWebResponse)webResponse).Cookies);
                        }
                    }
                    myHttpResponse.HttpResponse = (HttpWebResponse)webResponse;
                }

                catch (WebException wex)
                {
                    if (recordRequestTimeLine)
                    {
                        if (myWatch.IsRunning)
                        {
                            myWatch.Stop();
                        }
                    }
                    if (wex.Response != null)
                    {
                        myHttpResponse.HttpResponse = (HttpWebResponse)wex.Response;
                    }
                    else
                    {
                        myHttpResponse.ErrorMes = wex.Message;
                        GetError(wex);
                    }
                }

                catch (Exception ex)
                {
                    myHttpResponse.ErrorMes = ex.Message;
                    GetError(ex);
                }

                finally
                {
                    if (saveFileName != null)
                    {
                        myHttpResponse.SavaData(saveFileName);
                    }
                    myHttpResponse.SeekResponseStream();

                    if (webResponse != null)
                    {
                        webResponse.Close();
                    }
                    if (recordRequestTimeLine)
                    {
                        if (myWatch.IsRunning)
                        {
                            myWatch.Stop();
                        }
                        timeline.ElapsedTime = myWatch.ElapsedMilliseconds;
                    }
                }

                if (recordRequestTimeLine)
                {
                    myHttpResponse.TimeLine = timeline;
                }
                return myHttpResponse;
            }
          
            /// <summary>
            /// Send Http Request (post multipart data)
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) </param>
            /// <param name="heads">http Head list （if not need set it null）</param>
            /// <param name="isAntoCookie">is use static CookieContainer</param>
            /// <param name="bodyData">normal body (if not need it ,just set it null)</param>
            /// <param name="multipartDateList">MultipartDate list(if not need it ,just set it null)</param>
            /// <param name="bodyMultipartParameter">celerity MultipartParameter your should set it like "a=1&amp;b=2&amp;c=3" and it will send in multipart format (if not need it ,just set it null)</param>
            /// <param name="yourBodyEncoding">the MultipartParameter Encoding (if set it null ,it will be utf 8)</param>
            /// <param name="saveFileName">save your response as file （if not need set it null）</param>
            /// <param name="manualResetEvent">ManualResetEvent 并发集合点 （if not need set it null）</param>
            /// <returns>MyHttpResponse</returns>
            public MyHttpResponse SendMultipartRequest(string url, List<KeyValuePair<string, string>> heads, bool isAntoCookie, string bodyData, List<HttpMultipartDate> multipartDateList, string bodyMultipartParameter, Encoding yourBodyEncoding, string saveFileName, System.Threading.ManualResetEvent manualResetEvent)
            {
                MyHttpResponse myHttpResponse = new MyHttpResponse();
                HttpTimeLine timeline = new HttpTimeLine();

                Encoding httpBodyEncoding = Encoding.UTF8;
                string defaultMultipartContentType = "application/octet-stream";
                NameValueCollection stringDict = new NameValueCollection();
                HttpWebRequest webRequest = null;
                HttpWebResponse httpWebResponse = null;
                Stopwatch myWatch = null;

                if (recordRequestTimeLine)
                {
                    myWatch = new Stopwatch();
                }
                if (yourBodyEncoding != null)
                {
                    httpBodyEncoding = yourBodyEncoding;
                }

                var memStream = new MemoryStream();
                webRequest = (HttpWebRequest)WebRequest.Create(url);

                //设置CookieContainer
                if (isAntoCookie)
                {
                    ((HttpWebRequest)webRequest).CookieContainer = cookieContainer;
                }
                //写入http头
                if (defaultContentType != null)
                {
                    webRequest.ContentType = defaultContentType;
                }
                HttpHelper.AddHttpHeads(webRequest, requestDefaultHeads);
                HttpHelper.AddHttpHeads(webRequest, heads);

                // 边界符
                var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
                // 边界符
                var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
                // 最后的结束符
                var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

                // 设置属性
                webRequest.Method = "POST";
                webRequest.Timeout = httpTimeOut;
                webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

                //写入常规body
                if (bodyData != null)
                {
                    var bodybytes = httpBodyEncoding.GetBytes(bodyData);
                    memStream.Write(bodybytes, 0, bodybytes.Length);
                }

                if (multipartDateList != null)
                {
                    foreach (HttpMultipartDate nowMultipart in multipartDateList)
                    {
                        //Console.WriteLine(System.DateTime.Now.Ticks);
                        //const string filePartHeader = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" + "Content-Type: {2}\r\n\r\n";
                        string nowPartHeader = "Content-Disposition: form-data";
                        if (nowMultipart.Name != null)
                        {
                            nowPartHeader += string.Format("; name=\"{0}\"", nowMultipart.Name);
                        }
                        if (nowMultipart.FileName != null)
                        {
                            nowPartHeader += string.Format("; filename=\"{0}\"", nowMultipart.FileName);
                        }
                        nowPartHeader += "\r\n";
                        nowPartHeader += string.Format("Content-Type: {0}", nowMultipart.ContentType == null ? defaultMultipartContentType : nowMultipart.ContentType);
                        nowPartHeader += "\r\n\r\n";
                        //Console.WriteLine(System.DateTime.Now.Ticks);
                        byte[] nowHeaderbytes = httpBodyEncoding.GetBytes(nowPartHeader);
                        memStream.Write(Encoding.ASCII.GetBytes("\r\n"), 0, Encoding.ASCII.GetBytes("\r\n").Length);
                        memStream.Write(beginBoundary, 0, beginBoundary.Length);
                        memStream.Write(nowHeaderbytes, 0, nowHeaderbytes.Length);
                        //MultipartDate
                        if (nowMultipart.IsFile)
                        {
                            try
                            {
                                using (var fileStream = new FileStream(nowMultipart.FileData, FileMode.Open, FileAccess.Read))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead; // =0
                                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                    {
                                        memStream.Write(buffer, 0, bytesRead);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                GetError(ex);
                                myHttpResponse.ErrorMes = string.Format(@"the request not send , find error in multipartDateList [{0}]", ex.Message);
                                return myHttpResponse;
                            }
                        }
                        else
                        {
                            byte[] myCmd = httpBodyEncoding.GetBytes(nowMultipart.FileData == null ? "" : nowMultipart.FileData);
                            memStream.Write(myCmd, 0, myCmd.Length);
                        }
                    }
                }

                //解析快捷Multipart表单形式post参数
                if (bodyMultipartParameter != null)
                {
                    string[] sArray = bodyMultipartParameter.Split('&');
                    foreach (string tempStr in sArray)
                    {
                        int myBreak = tempStr.IndexOf('=');
                        if (myBreak == -1)
                        {
                            myHttpResponse.ErrorMes = string.Format(@"the request not send , can't find '=' in  bodyMultipartParameter [{0}]", bodyMultipartParameter);
                            return myHttpResponse;
                        }
                        stringDict.Add(tempStr.Substring(0, myBreak), tempStr.Substring(myBreak + 1));
                    }

                    //快捷写入写入POST非文件参数
                    string bodyParameterFormat = "\r\n--" + boundary +
                                           "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                           "\r\n\r\n{1}";
                    for (int i = 0; i < stringDict.Count; i++)
                    {
                        try
                        {
                            byte[] formitembytes = httpBodyEncoding.GetBytes(string.Format(bodyParameterFormat, stringDict.GetKey(i), stringDict.Get(i)));
                            memStream.Write(formitembytes, 0, formitembytes.Length);
                        }
                        catch (Exception ex)
                        {
                            GetError(ex);
                            myHttpResponse.ErrorMes = string.Format(@"the request not send , find error in bodyMultipartParameter [{0}]", ex.Message);
                            return myHttpResponse;
                        }
                    }
                }

                //写入最后的结束边界符
                if (!(bodyMultipartParameter == null && multipartDateList == null))
                {
                    memStream.Write(Encoding.ASCII.GetBytes("\r\n"), 0, Encoding.ASCII.GetBytes("\r\n").Length);
                    memStream.Write(endBoundary, 0, endBoundary.Length);
                }

                webRequest.ContentLength = memStream.Length;

                //开始请求
                try
                {
                    if (manualResetEvent != null)
                    {
                        manualResetEvent.WaitOne();
                    }
                    var requestStream = webRequest.GetRequestStream();
                    memStream.Position = 0;
                    var tempBuffer = new byte[memStream.Length];
                    memStream.Read(tempBuffer, 0, tempBuffer.Length);
                    memStream.Close();
                    if (recordRequestTimeLine)
                    {
                        timeline.StartTime = DateTime.Now;
                        myWatch.Start();
                    }
                    requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                    requestStream.Close();

                    httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                    if (recordRequestTimeLine)
                    {
                        myWatch.Stop();
                    }

                    if (isAntoCookie)
                    {
                        if (httpWebResponse.Cookies != null && httpWebResponse.Cookies.Count > 0)
                        {
                            cookieContainer.Add(httpWebResponse.Cookies);
                        }
                    }

                    myHttpResponse.HttpResponse = httpWebResponse;

                }
                catch (WebException wex)
                {
                    if (recordRequestTimeLine)
                    {
                        if (myWatch.IsRunning)
                        {
                            myWatch.Stop();
                        }
                    }
                    if (wex.Response != null)
                    {
                        myHttpResponse.HttpResponse = (HttpWebResponse)wex.Response;
                    }
                    else
                    {
                        myHttpResponse.ErrorMes = wex.Message;
                        GetError(wex);
                    }
                }

                catch (Exception ex)
                {
                    myHttpResponse.ErrorMes = ex.Message;
                    GetError(ex);
                }

                finally
                {
                    if (saveFileName != null)
                    {
                        myHttpResponse.SavaData(saveFileName);
                    }
                    myHttpResponse.SeekResponseStream();

                    if (httpWebResponse != null)
                    {
                        httpWebResponse.Close();
                    }
                    if (recordRequestTimeLine)
                    {
                        if (myWatch.IsRunning)
                        {
                            myWatch.Stop();
                        }
                        timeline.ElapsedTime = myWatch.ElapsedMilliseconds;
                    }
                }
                if (recordRequestTimeLine)
                {
                    myHttpResponse.TimeLine = timeline;
                }
                return myHttpResponse;
            }

            /// <summary>
            /// Send Http Request (post multipart data)
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) </param>
            /// <param name="heads">http Head list （if not need set it null）</param>
            /// <param name="isAntoCookie">is use static CookieContainer</param>
            /// <param name="bodyData">normal body (if not need it ,just set it null)</param>
            /// <param name="multipartDateList">MultipartDate list(if not need it ,just set it null)</param>
            /// <param name="bodyMultipartParameter">celerity MultipartParameter your should set it like "a=1&amp;b=2&amp;c=3" and it will send in multipart format (if not need it ,just set it null)</param>
            /// <param name="yourBodyEncoding">the MultipartParameter Encoding (if set it null ,it will be utf 8)</param>
            /// <returns>back data</returns>
            public string HttpPostData(string url, List<KeyValuePair<string, string>> heads, bool isAntoCookie, string bodyData, List<HttpMultipartDate> multipartDateList, string bodyMultipartParameter, Encoding yourBodyEncoding)
            {
                return SendMultipartRequest(url, heads, isAntoCookie, bodyData, multipartDateList, bodyMultipartParameter, yourBodyEncoding,null,null).ResponseBody;
            }


            /// <summary>
            /// Send Http Request (post multipart data)
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) </param>
            /// <param name="heads">http Head list (if not need it ,just set it null)</param>
            /// <param name="bodyData">normal body (if not need it ,just set it null)</param>
            /// <param name="HttpMultipartDate">MultipartDate list(if not need it ,just set it null)</param>
            /// <param name="bodyMultipartParameter">celerity MultipartParameter like "a=1&amp;b=2&amp;c=3" (if not need it ,just set it null)</param>
            /// <param name="yourBodyEncoding">the MultipartParameter Encoding (if set it null ,it will be utf 8)</param>
            /// <returns>back data</returns>
            public string HttpPostData(string url, List<KeyValuePair<string, string>> heads, string bodyData, List<HttpMultipartDate> multipartDateList, string bodyMultipartParameter, Encoding yourBodyEncoding)
            {
                return HttpPostData(url, heads, withDefaultCookieContainer, bodyData, multipartDateList, bodyMultipartParameter, yourBodyEncoding);
            }


            /// <summary>
            /// Send Http Request (post multipart data)
            /// </summary>
            /// <param name="url">url (must start with protocol scheme like [http://,https:// ,ftp:// ,file:// ]) </param>
            /// <param name="HttpMultipartDate">MultipartDate list(if not need it ,just set it null)</param>
            /// <returns>back data</returns>
            public string HttpPostData(string url,HttpMultipartDate HttpMultipartDate)
            {
                return HttpPostData(url, null, null, new List<HttpMultipartDate>() { HttpMultipartDate }, null , null);
            }

            #region static Func
            internal static void GetError(Exception ex)
            {
                //ErrorLog.PutInLog(ex);
            }

            /// <summary>
            /// DownloadFile with http
            /// </summary>
            /// <param name="url">url</param>
            /// <param name="heads">heads</param>
            /// <param name="saveFileName">save File path</param>
            public static void DownloadFile(string url, List<KeyValuePair<string, string>> heads, string saveFileName)
            {
                using (WebClient client = new WebClient())
                {
                    HttpHelper.AddHttpHeads(client.Headers, heads);
                    client.DownloadFile(url, saveFileName);
                }
            }

            /// <summary>
            /// DownloadFile with http 
            /// </summary>
            /// <param name="url">url</param>
            /// <param name="saveFileName">save File path</param>
            public static void DownloadFile(string url, string saveFileName)
            {
                DownloadFile(url, null, saveFileName);
            } 
            #endregion

        }
    }
}
