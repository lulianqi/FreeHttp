using FreeHttp.HttpHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class HttpFilterWindow : Form
    {
        public HttpFilterWindow()
        {
            InitializeComponent();
        }

        FiddlerHttpFilter httpFilter;
        public HttpFilterWindow(object filter):this()
        {
            httpFilter = filter as FiddlerHttpFilter;
        }

        private void HttpFilterWindow_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            if (httpFilter == null)
            {
                MessageBox.Show("your FiddlerHttpFilter is null","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
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
               
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
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
                throw new Exception("get error FiddlerUriMatchMode");
            }
            if (matchMode == FiddlerUriMatchMode.AllPass || (rtb_bodyFilter.Text == "" && matchMode != FiddlerUriMatchMode.Is))
            {
                    httpFilter.BodyMatch = null;
            }
            else
            {
                httpFilter.BodyMatch = new FiddlerUriMatch(matchMode, rtb_bodyFilter.Text);
                
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

    }
}
