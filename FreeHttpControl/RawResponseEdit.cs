using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreeHttp.HttpHelper;

namespace FreeHttp.FreeHttpControl
{
    public partial class RawResponseEdit : UserControl
    {
        public RawResponseEdit()
        {
            InitializeComponent();
        }


        Dictionary<string, string> responseLineDc;
        HttpResponse httpResponse;

        public event EventHandler OnRawResponseEditClose;
        public event EventHandler OnRawResponseEnableChange;
        public bool IsEnable
        {
            get { return ck_enabled.Checked; }
        }

        public bool IsDirectRespons
        {
            get { return ck_directResponse.Checked; }
        }

        public HttpResponse RawResponse
        {
            get { return httpResponse; }
        }
        private void RawResponseEdit_Load(object sender, EventArgs e)
        {
            initializeResponseLineDc(out responseLineDc);
            foreach(var tempKey in responseLineDc)
            {
                cb_responseLine.Items.Add(tempKey.Key);
            }
            cb_responseLine.SelectedIndex = 0;
        }

        private void initializeResponseLineDc(out Dictionary<string, string> rdc)
        {
            rdc = new Dictionary<string, string>();
            rdc.Add("Please select template", "edit raw response here");
            rdc.Add("HTTP/1.1 200 OK", "HTTP/1.1 200 OK\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nContent-Length: 51\r\n\r\nThis is a simple Fiddler-returned <B>HTML</B> page.");
            rdc.Add("HTTP/1.1 204 No Content", "HTTP/1.1 204 No Content\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nContent-Length: 0\r\n\r\n");
            rdc.Add("HTTP/1.1 302 Redirect", "HTTP/1.1 302 Redirect\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nLocation: http://www.fiddler2.com/sandbox/FormAndCookie.asp\r\nContent-Length: 0\r\n\r\n");
            rdc.Add("HTTP/1.1 303 Redirect Using GET", "HTTP/1.1 303 Redirect Using GET\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nLocation: http://www.fiddler2.com/sandbox/FormAndCookie.asp\r\nContent-Length: 0\r\n\r\n");
            rdc.Add("HTTP/1.1 304 Not Modified", "HTTP/1.1 304 Not Modified\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nContent-Length: 0\r\n\r\n");
            rdc.Add("HTTP/1.1 307 Redirect using same Method", "HTTP/1.1 307 Redirect using same Method\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nLocation: http://www.fiddler2.com/sandbox/FormAndCookie.asp\r\nContent-Length: 0\r\n\r\n");
            rdc.Add("HTTP/1.1 401 Authentication Required", "HTTP/1.1 401 Authentication Required\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nWWW-Authenticate: Basic realm=\"Fiddler\"\r\nContent-Type: text/html\r\nContent-Length: 520\r\n\r\nFiddler: HTTP/401 Basic Server Auth Required.");
            rdc.Add("HTTP/1.1 403 Access Denied", "HTTP/1.1 403 Access Denied\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nContent-Length: 520\r\n\r\nFiddler: HTTP/403 Access Denied.");
            rdc.Add("HTTP/1.1 404 Not Found", "HTTP/1.1 404 Not Found\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nContent-Type: text/html\r\nContent-Length: 520\r\n\r\nFiddler: HTTP/404 Not Found");
            rdc.Add("HTTP/1.1 407 Proxy Auth Required", "HTTP/1.1 407 Proxy Auth Required\r\nFiddlerTemplate: True\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nProxy-Authenticate: Basic realm=\"Fiddler (just hit Ok)\"\r\nContent-Type: text/html\r\nContent-Length: 520\r\n\r\nFiddler: HTTP/407 Proxy Auth Required. ");
            rdc.Add("HTTP/1.1 502 Unreachable Server", "HTTP/1.1 502 Unreachable Server\r\nDate: Fri, 25 Jan 2013 16:49:29 GMT\r\nFiddlerTemplate: True\r\nContent-Type: text/html\r\nContent-Length: 520\r\n\r\nFiddler: HTTP/502 unreachable server.");
        }

        private void pb_editResponseCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if(OnRawResponseEditClose!=null)
            {
                this.OnRawResponseEditClose(this, null);
            }
        }

        private void RawResponseEdit_Resize(object sender, EventArgs e)
        {
            rtb_rawResponse.Height = this.Height - 25;
        }

        private void cb_responseLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtb_rawResponse.Text = responseLineDc[cb_responseLine.Text];
        }

        private void ck_enabled_CheckedChanged(object sender, EventArgs e)
        {
            if(ck_enabled.Checked)
            {
                try
                {
                    httpResponse = HttpResponse.GetHttpResponse(rtb_rawResponse.Text.Replace("\n", "\r\n"));
                    cb_responseLine.Enabled = rtb_rawResponse.Enabled= ck_directResponse.Enabled = false;            
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format("{0}\r\n   please edit rhe raw response again", ex.Message), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ck_enabled.Checked = false;
                }
            }
            else
            {
                cb_responseLine.Enabled = rtb_rawResponse.Enabled = ck_directResponse.Enabled = true;
            }

            if (OnRawResponseEnableChange != null)
            {
                OnRawResponseEnableChange(this, null);
            }
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog_responseFile.ShowDialog() == DialogResult.OK)
            {
                string tempPath = openFileDialog_responseFile.FileName;
                int tempIndex = rtb_rawResponse.Text.IndexOf("<<replace file path>>");
                if (tempIndex >= 0)
                {
                    rtb_rawResponse.Text=rtb_rawResponse.Text.Remove(tempIndex);
                }

                if (!rtb_rawResponse.Text.EndsWith("\n"))
                {
                    rtb_rawResponse.AppendText("\n");
                }

                rtb_rawResponse.AppendText(string.Format("<<replace file path>>{0}", tempPath));
            }
        }


        public void SetText(string mes)
        {
            rtb_rawResponse.Clear();
            if(mes!=null)
            {
                rtb_rawResponse.Text = mes;
            }
        }

        public HttpResponse GetHttpResponse()
        {
            return HttpResponse.GetHttpResponse(rtb_rawResponse.Text.Replace("\n", "\r\n"));
        }
        
    }
}
