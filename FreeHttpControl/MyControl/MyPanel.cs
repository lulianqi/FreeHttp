using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.FreeHttpControl
{
    class MyPanel : System.Windows.Forms.Panel
    {
        public MyPanel()
        {
            //this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint |System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,true);
            this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer | System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }
}
