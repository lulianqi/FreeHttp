using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService.HttpServer
{
    class MyHttpListener
    {
        HttpListener listener;
        public MyHttpListener()
        {
            if (!HttpListener.IsSupported)
            {
                return;
            }
            listener = new HttpListener();
        }

        public void Start()
        {
            if (!HttpListener.IsSupported)
            {
                throw new Exception("not supported");
            }
            try
            {
                if (!listener.IsListening)
                    listener.Start();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            listener.Prefixes.Add("http://localhost:9998/");
            listener.Prefixes.Add("https://localhost:44399/");
            ListenerAsync();

            return;
            System.Threading.Thread ListenerThread = new System.Threading.Thread(new System.Threading.ThreadStart(ListenerWorker));
            ListenerThread.Name = "ListenerThread";
            ListenerThread.Priority = System.Threading.ThreadPriority.Normal;
            ListenerThread.IsBackground = true;
            ListenerThread.Start();
        }

        public void Stop()
        {
            if(listener!=null)
            {
                listener.Stop();
            }
        }

        private async void ListenerAsync()
        {
            while (listener.IsListening)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                string responseString = "ok";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                await output.WriteAsync(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
                //listener.Stop();
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
