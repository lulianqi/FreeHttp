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
    public partial class SetVaule : Form
    {
        public class SetVauleEventArgs:EventArgs
        {
            public string SetValue{get; set;}
            public SetVauleEventArgs(string setValue)
            {
                SetValue= setValue;
            }
        }
        public SetVaule()
        {
            InitializeComponent();
        }

        Func<string,bool> CheckValueFunc;
        public event EventHandler<SetVauleEventArgs> OnSetValue;

        public SetVaule(string formName, string remarkInfo, string nowValue, Func<string, bool> checkValueDelegate)
            : this()
        {
            if (formName != null){ this.Name = formName; }
            if (remarkInfo != null) { lb_info.Text = remarkInfo; }
            if (nowValue != null) { tb_vaule.Text = nowValue; }
            if (checkValueDelegate != null) { CheckValueFunc = checkValueDelegate; }
        }


        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (CheckValueFunc != null && !CheckValueFunc(tb_vaule.Text))
            {
                MessageBox.Show("your value is not legal \r\n edit it again", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if(OnSetValue!=null)
            {
                this.OnSetValue(this, new SetVauleEventArgs(tb_vaule.Text));
            }

            this.Close();
        }
    }
}
