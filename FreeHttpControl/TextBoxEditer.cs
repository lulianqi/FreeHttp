using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class TextBoxEditer : UserControl
    {
        public class CloseEditBoxEventArgs: EventArgs
        {
            public String EditData { get; set; }
            public CloseEditBoxEventArgs(string editData)
            {
                EditData = editData;
            }
        }

        public TextBoxEditer()
        {
            InitializeComponent();
            myResources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxEditer));
            rtb_editTextBox.Leave += rtb_editTextBox_Leave;
            IsShowEditRichTextBox = false;
        }

        public TextBoxEditer(ContainerControl yourContainerControl): this()
        {
            MainContainerControl = yourContainerControl;
        }

        private RichTextBox rtb_editTextBox = new RichTextBox();
        private bool isShowEditRichTextBox;   //not set this vaule (you should call IsShowEditRichTextBox to set this vaule)
        System.ComponentModel.ComponentResourceManager myResources;
        public delegate void CloseEditBoxEventHandler(object sender, CloseEditBoxEventArgs e);

        public event CloseEditBoxEventHandler OnCloseEditBox;

        /// <summary>
        /// get a value that is RichTextBox showing
        /// </summary>
        public bool IsShowEditRichTextBox 
        { 
            get{return isShowEditRichTextBox;}
            private set
            {
                if (isShowEditRichTextBox == value)
                {
                    return;
                }
                isShowEditRichTextBox = value;
                pb_editTextBox.Image = isShowEditRichTextBox ? ((Image)(myResources.GetObject("affirm"))) : ((Image)(myResources.GetObject("edit")));
            } 
        }

        

        [DescriptionAttribute("the TextBox that you want to binding")]
        /// <summary>
        /// get or set EditTextBox (the TextBox that you want to binding)
        /// </summary>
        public TextBox EditTextBox { get; set; }

        [DescriptionAttribute("the main window that RichTextBox will add it")]
        /// <summary>
        /// get or set MainContainerControl (the main window that RichTextBox will add it)
        /// </summary>
        public ContainerControl MainContainerControl { get; set; }

        //pictureBox change for all
        public void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Honeydew;
        }

        //pictureBox change for all
        public void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }

        private void pb_editTextBox_Click(object sender, EventArgs e)
        {
            if(IsShowEditRichTextBox)
            {
                CloseRichTextBox();
            }
            else
            {
                ShowRichTextBox();
            }
        }

        void rtb_editTextBox_Leave(object sender, EventArgs e)
        {
            CloseRichTextBox();    
        }
 
        /// <summary>
        /// Close EditRichTextBox  (when the windows Deactivate you should call it )
        /// </summary>
        public void CloseRichTextBox()
        {
            if (!IsShowEditRichTextBox||MainContainerControl == null || EditTextBox == null)
            {
                return;
            }
            if (MainContainerControl.Contains(rtb_editTextBox))
            {
                EditTextBox.Clear();
                EditTextBox.AppendText(rtb_editTextBox.Text);
                MainContainerControl.Controls.Remove(rtb_editTextBox);
                IsShowEditRichTextBox = false;
                if(OnCloseEditBox!=null)
                {
                    this.OnCloseEditBox(this, new CloseEditBoxEventArgs(rtb_editTextBox.Text));
                }
            }
        }

        /// <summary>
        /// Show EditRichTextBox 
        /// </summary>
        public void ShowRichTextBox()
        {
            if (MainContainerControl == null || EditTextBox == null)
            {
                return;
            }

            if (!IsShowEditRichTextBox)
            {
                Point myClientLocation = MainContainerControl.PointToClient(EditTextBox.Parent.PointToScreen(EditTextBox.Location));
                rtb_editTextBox.Location = new Point(myClientLocation.X, myClientLocation.Y + EditTextBox.Height);
                rtb_editTextBox.Width = EditTextBox.Width;
                rtb_editTextBox.Height = 200;
                rtb_editTextBox.Clear();
                MainContainerControl.Controls.Add(rtb_editTextBox);
                IsShowEditRichTextBox = true;
                rtb_editTextBox.BringToFront();
                rtb_editTextBox.AppendText(EditTextBox.Text);
                rtb_editTextBox.Focus();
            }
        }
    }
}
