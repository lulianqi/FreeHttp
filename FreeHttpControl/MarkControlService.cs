using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public class MarkControlService:IDisposable
    {
        /// <summary>
        /// the information for the mark Control
        /// </summary>
        class RemindControlInfo
        {
            public int RemindTime { get; set; }
            public Color OriginColor { get; set; }

            public RemindControlInfo(int yourRemindTime, Color yourOriginColor)
            {
                RemindTime = yourRemindTime;
                OriginColor = yourOriginColor;
            }
        }

        Timer myTimer = new Timer();
        Dictionary<ListViewItem, RemindControlInfo> remindItemDc;
        Dictionary<Control, RemindControlInfo> remindControlDc;

        public MarkControlService(int clickTime)
        {
            remindItemDc = new Dictionary<ListViewItem, RemindControlInfo>();
            remindControlDc = new Dictionary<Control, RemindControlInfo>();
            myTimer.Interval = clickTime;
            myTimer.Tick += myTimer_Tick;
            myTimer.Start();
        }

        void myTimer_Tick(object sender, EventArgs e)
        {
            if (remindItemDc.Count > 0)
            {
                //MyControlHelper.SetControlFreeze(lv_requestRuleList);
                List<ListViewItem> tempRemoveItem = new List<ListViewItem>();
                List<ListViewItem> tempHighlightList = new List<ListViewItem>();
                tempHighlightList.AddRange(remindItemDc.Keys);
                foreach (var tempHighlightItem in tempHighlightList)
                {
                    remindItemDc[tempHighlightItem].RemindTime--;
                    if (remindItemDc[tempHighlightItem].RemindTime == 0)
                    {
                        tempRemoveItem.Add(tempHighlightItem);
                    }
                }
                //MyControlHelper.SetControlUnfreeze(lv_requestRuleList);
                foreach (var tempItem in tempRemoveItem)
                {
                    tempItem.BackColor = remindItemDc[tempItem].OriginColor;
                    remindItemDc.Remove(tempItem);
                }
            }

            if (remindControlDc.Count > 0)
            {
                List<Control> tempRemoveControl = new List<Control>();
                List<Control> tempRemindList = new List<Control>();
                tempRemindList.AddRange(remindControlDc.Keys);
                foreach (var tempRemindControl in tempRemindList)
                {
                    remindControlDc[tempRemindControl].RemindTime--;
                    if (remindControlDc[tempRemindControl].RemindTime == 0)
                    {
                        tempRemoveControl.Add(tempRemindControl);
                    }
                }

                foreach (var tempItem in tempRemoveControl)
                {
                    tempItem.BackColor = remindControlDc[tempItem].OriginColor;
                    remindControlDc.Remove(tempItem);
                }
            }
        }

        public void MarkControl(Control yourControl, Color yourColor, int yourShowTick)
        {
            if (yourControl != null)
            {
                if (remindControlDc.ContainsKey(yourControl))
                {
                    remindControlDc[yourControl] = new RemindControlInfo(yourShowTick, remindControlDc[yourControl].OriginColor);
                }
                else
                {
                    remindControlDc.Add(yourControl, new RemindControlInfo(yourShowTick, yourControl.BackColor));
                }
                yourControl.BackColor = yourColor;
            }
        }

        public void MarkControl(ListViewItem yourItem, Color yourColor, int yourShowTick)
        {
            if (yourItem != null)
            {
                if (remindItemDc.ContainsKey(yourItem))
                {
                    remindItemDc[yourItem] = new RemindControlInfo(yourShowTick, remindItemDc[yourItem].OriginColor);
                }
                else
                {
                    remindItemDc.Add(yourItem, new RemindControlInfo(yourShowTick, yourItem.BackColor));
                }
                yourItem.BackColor = yourColor;
            }
        }

        public void SetColor(Control yourControl, Color yourColor)
        {
            if (yourControl != null)
            {
                if (remindControlDc.ContainsKey(yourControl))
                {
                    remindControlDc.Remove(yourControl);
                }
                yourControl.BackColor = yourColor;
            }
        }

        public void SetColor(ListViewItem yourItem, Color yourColor)
        {
            if (yourItem != null)
            {
                if (remindItemDc.ContainsKey(yourItem))
                {
                    remindItemDc.Remove(yourItem);
                }
                yourItem.BackColor = yourColor;
            }
        }

        public void Dispose()
        {
            myTimer.Dispose();
        }
    }
}
