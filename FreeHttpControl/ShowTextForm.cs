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
    public partial class ShowTextForm : Form
    {
        public ShowTextForm()
        {
            InitializeComponent();
        }

        public ShowTextForm(string name,string textInfo):this()
        {
            this.Name = string.IsNullOrEmpty(name) ? "" : name;
            if (textInfo!=null){ rtb_textInfo.AppendText(textInfo); }
        } 
    }
}
