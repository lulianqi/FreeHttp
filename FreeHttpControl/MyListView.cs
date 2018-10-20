using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public class MyListView : ListView
    { 
        private const int WM_LBUTTONDBLCLK = 0x0203;  //左键双击
        public MyListView() : base() { }
        protected override void WndProc(ref Message m)
        { 
            if (m.Msg == WM_LBUTTONDBLCLK)
            { 
                Point p = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)); 
                ListViewItem lvi = GetItemAt(p.X, p.Y); 
                if (lvi != null) 
                    lvi.Selected = true; 
                OnDoubleClick(new EventArgs()); 
            } 
            else 
                base.WndProc(ref m); 
        }
    }
}
