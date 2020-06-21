using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

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

        public static void SetRichTextBoxDropString(System.Windows.Forms.TextBoxBase yourCtr, Action action = null)
        {
            if (yourCtr == null)
            {
                return;
            }
            if (yourCtr is RichTextBox)
            {
                ((RichTextBox)yourCtr).AllowDrop = true;
            }
            else if (yourCtr is TextBox)
            {
                ((TextBox)yourCtr).AllowDrop = true;
            }
            else
            {
                yourCtr.AllowDrop = true;
            }
            yourCtr.DragDrop += (sender, e) =>
            {
                System.Windows.Forms.TextBoxBase tempTextBoxBase = sender as System.Windows.Forms.TextBoxBase;
                string tempText = (string)e.Data.GetData(typeof(string));
                if (tempText == null || tempTextBoxBase == null)
                {
                    return;
                }
                int selectionStart = tempTextBoxBase.SelectionStart;
                tempTextBoxBase.Text = tempTextBoxBase.Text.Insert(selectionStart, tempText);
                tempTextBoxBase.Select(selectionStart, tempText.Length);
                action?.Invoke();
            };
            yourCtr.DragEnter += (sender,e)=>
            {
                if (e.Data.GetData(typeof(string)) == null)
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.None;
                }
                else
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.Move;
                }
            };
        }


        public static void SetRichTextBoxDropString(System.Windows.Forms.RichTextBox yourRtb)
        {
            if(yourRtb==null)
            {
                return;
            }
            yourRtb.AllowDrop = true;
            yourRtb.DragDrop += Rtb_DragDrop;
            yourRtb.DragEnter += Rtb_DragEnter;
        }

        private static void Rtb_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetData(typeof(string)) == null)
            {
                e.Effect = System.Windows.Forms.DragDropEffects.None;
            }
        }

        private static void Rtb_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Windows.Forms.RichTextBox tempRichTextBox = sender as System.Windows.Forms.RichTextBox;
            string tempText = (string)e.Data.GetData(typeof(string));
            if (tempText == null || tempRichTextBox==null)
            {
                return;
            }
            int selectionStart = tempRichTextBox.SelectionStart;
            tempRichTextBox.Text = tempRichTextBox.Text.Insert(selectionStart, tempText);
            tempRichTextBox.Select(selectionStart, tempText.Length);
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
