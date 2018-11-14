using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.FreeHttpControl
{
    public class MyControlHelper
    {
        private const int WM_SETREDRAW = 0xB;

        /// <summary>
        /// 停止控件刷新
        /// </summary>
        /// <param name="yourCtr">your Control</param>
        public static void SetControlFreeze(System.Windows.Forms.Control yourCtr)
        {
            UnsafeNativeMethods.SendMessage(yourCtr.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
        }

        /// <summary>
        /// 恢复控件刷新
        /// </summary>
        /// <param name="yourCtr">your Control</param>
        public static void SetControlUnfreeze(System.Windows.Forms.Control yourCtr)
        {
            UnsafeNativeMethods.SendMessage(yourCtr.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            yourCtr.Refresh();
        }
    }

    [System.Security.SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);

    }

    public static class MyExtensionMethods
    {
        public static int GetLatency(this System.Windows.Forms.LinkLabel llb)
        {
            //delay:200ms
            string tempText = llb.Text;
            int latency = 0;
            if (tempText.StartsWith("delay:") && tempText.EndsWith("ms"))
            {
                tempText = tempText.Substring(6, tempText.Length - 8);
                if(!int.TryParse(tempText,out latency))
                {
                    latency = 0;
                }
            }
            return latency;
        }

        public static void SetLatency(this System.Windows.Forms.LinkLabel llb, int latency)
        {
            if(latency>0)
            {
                llb.Text = string.Format("delay:{0}ms", latency);
            }
            else
            {
                llb.Text = "";
            }
        }

    }
}
