using FreeHttp.WebService.HttpServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.MyHelper
{
    public class MyGlobalHelper
    {
        public class GlobalMessageEventArgs : EventArgs
        {
            public bool IsErrorMessage { get; set; }
            public string Message { get; set; }
            public GlobalMessageEventArgs(bool isErrorMessage, string message)
            {
                IsErrorMessage = isErrorMessage;
                Message = message;
            }
        }

        public delegate void GetGlobalMessageEventHandler(object sender, GlobalMessageEventArgs yourMessage);
        
        /// <summary>
        /// it will called by other thread , you must keep the thread save
        /// </summary>
        public static GetGlobalMessageEventHandler OnGetGlobalMessage;

        public static FreeHttp.FreeHttpControl.MarkControlService markControlService;
        public static MyHttpListener myHttpListener;
        static MyGlobalHelper()
        {
            markControlService = new FreeHttp.FreeHttpControl.MarkControlService(1000);
            myHttpListener = new MyHttpListener();
        }

        public static void PutGlobalMessage(object sender, GlobalMessageEventArgs yourMessage)
        {
            if(OnGetGlobalMessage!=null && yourMessage!=null)
            {
                OnGetGlobalMessage(sender, yourMessage);
            }
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
