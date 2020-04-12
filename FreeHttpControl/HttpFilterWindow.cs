using FreeHttp.FiddlerHelper;
using FreeHttp.HttpHelper;
using FreeHttp.MyHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FreeHttp.FreeHttpControl.FreeHttpWindow;

namespace FreeHttp.FreeHttpControl
{
    public partial class HttpFilterWindow : Form
    {
        public HttpFilterWindow()
        {
            InitializeComponent();
        }

        FiddlerHttpFilter httpFilter;
        TamperProtocalType protocolMode;
        public HttpFilterWindow(object filter , TamperProtocalType mode = TamperProtocalType.Http) :this()
        {
            httpFilter = filter as FiddlerHttpFilter;
            protocolMode = mode;
        }

        private void HttpFilterWindow_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            tbe_urlFilter.Visible = tb_urlFilter.Focused;
            tbe_urlFilter.OnCloseEditBox += tbe_urlFilter_OnCloseEditBox;
            if (httpFilter == null)
            {
                MessageBox.Show("your FiddlerHttpFilter is null","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if(httpFilter.UriMatch!=null)
            {
                cb_macthUriMode.Text = httpFilter.UriMatch.MatchMode.ToString();
                tb_urlFilter.Text = string.IsNullOrEmpty(httpFilter.UriMatch.MatchUri) ? "" : httpFilter.UriMatch.MatchUri;
            }
            else
            {
                cb_macthUriMode.SelectedIndex = 0;
            }

            if(httpFilter.HeadMatch!=null)
            {
                foreach(var tempHeadsFilter in httpFilter.HeadMatch.HeadsFilter)
                {
                    FilterHeads.ListDataView.Items.Add(string.Format("{0}{1}{2}", tempHeadsFilter.Key, FilterHeads.SplitStr, tempHeadsFilter.Value));
                }
            }

            if(httpFilter.BodyMatch!=null)
            {
                cb_macthMode.Text = httpFilter.BodyMatch.MatchMode.ToString();
                rtb_bodyFilter.Text = string.IsNullOrEmpty(httpFilter.BodyMatch.MatchUri) ? "" : httpFilter.BodyMatch.MatchUri;
            }
            else
            {
                cb_macthMode.SelectedIndex = 4;
            }

            if(!string.IsNullOrEmpty(httpFilter.Name))
            {
                tb_RuleAlias.Text = httpFilter.Name;
            }
            
            if(protocolMode == TamperProtocalType.WebSocket)
            {
                this.Text = "WebsocketFilterWindow";
                FilterHeads.Enabled = false;
                lb_info_1.Text = "Payload Filter";
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            FiddlerUriMatchMode matchUriMode = FiddlerUriMatchMode.AllPass;
            if (!Enum.TryParse<FiddlerUriMatchMode>(cb_macthUriMode.Text, out matchUriMode))
            {
                throw new Exception("get error FiddlerUriMatchMode");
            }
            if (httpFilter.UriMatch!=null)
            {
                httpFilter.UriMatch.MatchMode = matchUriMode;
                httpFilter.UriMatch.MatchUri = tb_urlFilter.Text;
            }
            else
            {
                httpFilter.UriMatch = new FiddlerUriMatch(matchUriMode, tb_urlFilter.Text);
            }

            if(FilterHeads.ListDataView.Items.Count>0)
            {
                httpFilter.HeadMatch = new FiddlerHeadMatch();
                foreach (ListViewItem tempLv in FilterHeads.ListDataView.Items)
                {
                    string tempStr = tempLv.Text;
                    string tempKey;
                    string tempVaule;
                    if (tempStr.Contains(FilterHeads.SplitStr))
                    {
                        tempKey = tempStr.Remove(tempStr.IndexOf(FilterHeads.SplitStr));
                        tempVaule = tempStr.Substring(tempStr.IndexOf(FilterHeads.SplitStr) + FilterHeads.SplitStr.Length);
                        httpFilter.HeadMatch.AddHeadMatch(new MyKeyValuePair<string, string>(tempKey, tempVaule));
                    }
                    else
                    {
                        httpFilter.HeadMatch.AddHeadMatch(new MyKeyValuePair<string, string>(tempStr, ""));
                    }
                }
            }
            else
            {
                httpFilter.HeadMatch = null;
            }

            FiddlerUriMatchMode matchMode = FiddlerUriMatchMode.AllPass;
            if (!Enum.TryParse<FiddlerUriMatchMode>(cb_macthMode.Text, out matchMode))
            {
                throw new Exception("get error FiddlerBodyMatchMode");
            }
            if (matchMode == FiddlerUriMatchMode.AllPass || (rtb_bodyFilter.Text == "" && matchMode != FiddlerUriMatchMode.Is))
            {
                    httpFilter.BodyMatch = null;
            }
            else
            {
                try
                {
                    httpFilter.BodyMatch = new FiddlerBodyMatch(matchMode, rtb_bodyFilter.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format("your body filter is illage \r\n{0}", ex.Message), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (tb_RuleAlias.Text!=null)
            {
                httpFilter.Name = tb_RuleAlias.Text;
            }

            this.Close();
        }

        private void cb_macthMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_macthMode.SelectedIndex==4)
            {
                rtb_bodyFilter.Clear();
                rtb_bodyFilter.Enabled = false;
            }
            else
            {
                rtb_bodyFilter.Enabled = true;
            }
        }


        void tbe_urlFilter_OnCloseEditBox(object sender, TextBoxEditer.CloseEditBoxEventArgs e)
        {
            //如果主窗口失活导致编辑窗关闭，不会有textbox Leave的事件
            tbe_urlFilter.Visible = false;
        }

        private void HttpFilterWindow_Deactivate(object sender, EventArgs e)
        {
            tbe_urlFilter.CloseRichTextBox();
            tbe_urlFilter.Visible = tb_urlFilter.Focused;
        }

        private void tb_urlFilter_Enter(object sender, EventArgs e)
        {
            tbe_urlFilter.Visible = true;
        }

        private void tb_urlFilter_Leave(object sender, EventArgs e)
        {
            if (!(tbe_urlFilter.IsShowEditRichTextBox))
            {
                tbe_urlFilter.Visible = false;
            }
        }

    }
}
