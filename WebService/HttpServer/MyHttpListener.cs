using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService.HttpServer
{
    public class MyHttpListener
    {
        public class HttpListenerMessageEventArgs : EventArgs
        {
            public bool IsErrorMessage { get; set; }
            public string Message{ get; set; }
            public HttpListenerMessageEventArgs(bool isErrorMessage, string message)
            {
                IsErrorMessage = isErrorMessage;
                Message = message;
            }
        }

        HttpListener listener;
        public event EventHandler<HttpListenerMessageEventArgs> OnGetHttpListenerMessage;
        public MyHttpListener()
        {
            if (!HttpListener.IsSupported)
            {
                return;
            }
            listener = new HttpListener();
        }

        public bool IsStart
        {
            get { return listener == null ? false : listener.IsListening; }
        }

        public bool Start(string prefixes)
        {
            return Start(new string[] { prefixes },true);
        }
        public bool Start(string[] prefixesArray ,bool isClear)
        {
            
            if (!HttpListener.IsSupported)
            {
                throw new Exception("not supported");
            }
           
            //listener.Prefixes.Add("http://localhost:9998/");
            //listener.Prefixes.Add("https://localhost:44399/");
            //listener.Prefixes.Add("https://*:443/");
            //listener.Prefixes.Add("https://*:9996/");
            //listener.Prefixes.Add("https://*:9996/test/");
            try
            {
                if (isClear)
                {
                    listener.Prefixes.Clear();
                }
                foreach(var prefixes in prefixesArray)
                {
                    listener.Prefixes.Add(prefixes);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                if (!listener.IsListening)
                    listener.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ListenerAsync();
            return true;

            System.Threading.Thread ListenerThread = new System.Threading.Thread(new System.Threading.ThreadStart(ListenerWorker));
            ListenerThread.Name = "ListenerThread";
            ListenerThread.Priority = System.Threading.ThreadPriority.Normal;
            ListenerThread.IsBackground = true;
            ListenerThread.Start();
        }

        public void Close()
        {
            if (listener != null )
            {
                Stop();
                listener.Close();
            }
        }

        public void Stop()
        {
            if (listener != null && listener.IsListening)
            {
                listener.Stop();
            }
        }

        private async void ListenerAsync()
        {
            HttpListenerContext context;
            string responseString = "Hello FreeHttp";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            while (listener.IsListening)
            {
                try
                {
                    context = await listener.GetContextAsync();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    await output.WriteAsync(buffer, 0, buffer.Length);
                    output.Close();
                }
                catch(Exception ex)
                {
                    if(!IsStart)
                    {
                        return;
                    }
                    else
                    {
                        if(OnGetHttpListenerMessage!=null)
                        {
                            this.OnGetHttpListenerMessage(this, new HttpListenerMessageEventArgs(true, ex.Message));
                        }
                    }
                }
                
            }
        }

        private void ListenerWorker()
        {
            while(listener.IsListening)
            {
                // Note: The GetContext method blocks while waiting for a request. 
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                string responseString = "ok";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
                //listener.Stop();
            }
        }

    }
}
