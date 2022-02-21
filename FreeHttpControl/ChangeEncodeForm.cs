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
    public partial class ChangeEncodeForm : Form
    {
        public class ChangeEncodeInfo
        {
            public String ContentType_Request { get; set; }
            public String ContentType_Response { get; set; }
            public String NowEncode { get; set; }

            public FreeHttpWindow.RuleEditMode EditMode { get; set; } = FreeHttpWindow.RuleEditMode.NewRuleMode;
        }

        ChangeEncodeInfo changeEncodeInfo;

        public ChangeEncodeForm(ChangeEncodeInfo info)
        {
            InitializeComponent();
            if(info!=null)
            {
                changeEncodeInfo = info;
            }
            else
            {
                throw new Exception("your ChangeEncodeInfo is null");
            }
        }


        private void ChangeEncodeForm_Load(object sender, EventArgs e)
        {
            if (changeEncodeInfo.EditMode == FreeHttpWindow.RuleEditMode.EditRequsetRule)
            {
                cb_body.Enabled = false;
                cb_body.SelectedIndex = 0;
            }
            else if (changeEncodeInfo.EditMode == FreeHttpWindow.RuleEditMode.EditResponseRule)
            {
                cb_body.Enabled = false;
                cb_body.SelectedIndex = 1;
            }
            //cb_body.SelectedIndex = changeEncodeInfo.EditMode ==FreeHttpWindow.RuleEditMode.EditResponseRule ? 1:0 ;
            UpdataContentType();
            tb_contentType.Enabled = false;
            tb_recode.Focus();
        }

        private void Tb_recode_TextChanged(object sender, EventArgs e)
        {
            UpdataContentType();
        }
        private void UpdataContentType()
        {
            string nowContentType = cb_body.SelectedIndex == 0 ? changeEncodeInfo.ContentType_Request : changeEncodeInfo.ContentType_Response;
            if (!string.IsNullOrEmpty(nowContentType))
            {
                nowContentType = nowContentType.Trim();
                if (nowContentType.Contains("charset"))
                {
                    int startIndex = nowContentType.IndexOf("charset");
                    int endIndex = nowContentType.IndexOf(';', startIndex);
                    if (endIndex < 0)
                    {
                        tb_contentType.Text = string.Format("{0}charset={1}", nowContentType.Remove(startIndex), tb_recode.Text);
                    }
                    else
                    {
                        tb_contentType.Text = string.Format("{0};charset={1}", nowContentType.Remove(startIndex, endIndex + 1 - startIndex), tb_recode.Text);
                    }
                }
                else
                {
                    tb_contentType.Text = string.Format("{0};charset={1}", nowContentType, tb_recode.Text);
                }
            }
            else
            {
                tb_contentType.Text = string.Format("charset={0}", tb_recode.Text);
            }
        }
        private void bt_ok_Click(object sender, EventArgs e)
        {
            try
            {
                Encoding.GetEncoding(tb_recode.Text);
                changeEncodeInfo.NowEncode = tb_recode.Text;
                if(cb_body.SelectedIndex==0)
                {
                    changeEncodeInfo.ContentType_Request = tb_contentType.Text;
                    changeEncodeInfo.ContentType_Response = null;
                }
                else
                {
                    changeEncodeInfo.ContentType_Response = tb_contentType.Text;
                    changeEncodeInfo.ContentType_Request = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("your recode is illegal that {0}", ex.Message),"Stop",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            this.Close();
        }

        
    }
}
