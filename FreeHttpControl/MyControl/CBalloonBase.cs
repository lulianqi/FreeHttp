using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CBalloon
{
    /// <summary>
    /// Summary description for CBalloonBase.
    /// </summary>
    public class CBalloonBase : System.Windows.Forms.Form
    {
        #region enumeration describing the orientation of the bubble tip
        public enum sdSide
        {
            sd_top,
            sd_left,
            sd_bottom,
            sd_right,
            sd_horizontal,
            sd_vertical
        }

        public enum alAlign
        {
            al_lhs,
            al_mid,
            al_rhs
        }
        #endregion

        const int C_QUOTEH = 25;
        const int C_ARCH = 5;
        const int C_SHADOW = 5;

        protected GraphicsPath m_path;
        protected Region m_rOuterFrame;
        protected Region m_rInnerFrame;

        protected bool m_bShowFrame = true;
        protected bool m_bIsShadow = false;
        protected bool m_bHasShadow = false;

        // properties that allow a color gradient from top left to top right of the balloon's frame
        protected Color m_cTopLeft = Color.Aqua;
        protected Color m_cBotRite = Color.Lime;

        // location of the balloon's tail tip (left, right, top, bottom etc)
        private alAlign m_tipAlign = alAlign.al_lhs;
        private sdSide m_tipSide = sdSide.sd_top;

        // absolute position of the balloon's tail tip
        public Point m_ptTipPosition = new Point(0, 0);

        // rectangle and center point used to calculate the color gradient for the frame
        public RectangleF m_rtBalloonF = new RectangleF(0.0F, 0.0F, 1.0F, 1.0F);
        private Point m_ptCenter = new Point(0, 0);
        // tail offset from the nearest rounded edge (auto calculated when anchored to a point or control)
        protected int m_nTailOffset = 30;

        // marks the position, width and height of the anchor point or control
        // if a point is used, the width and height are set to zero
        protected Rectangle m_rtAnchor = new Rectangle(0, 0, 0, 0);
        // the parent form which contains the anchor point
        private Form m_fmParent = null;
        // a shadow form constructed from this class, shaded gray with opacity below 100% to simulate a shadow
        private CBalloon.CBalloonBase m_fmShadow = null;

        // event handler which is attached to the form containing the anchor point. when
        // the form moves, the balloon will move with it
        public System.EventHandler m_evhMove;

        // stuff the compiler adds

        private System.ComponentModel.Container components = null;

        public CBalloonBase()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CBalloonBase
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(295, 214);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CBalloonBase";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CBalloonBase_Paint);
            this.VisibleChanged += new System.EventHandler(this.CBalloonBase_VisibleChanged);
            this.Click += new System.EventHandler(this.CBalloonBase_Click);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CBalloonBase_Closing);
            this.Move += new System.EventHandler(this.CBalloonBase_Move);
            this.Resize += new System.EventHandler(this.CBalloonBase_Resize);
            this.ResumeLayout(false);

        }
        #endregion

        // regenerate the path for the balloon, and set the region for the window 
        public void reSizeMe()
        {
            m_path = new GraphicsPath();

            // nW and nH are just shorthand for the width and height of the form
            int nW = this.Width;
            int nH = this.Height;

            int nOuter = C_QUOTEH;
            int nInner = C_QUOTEH + C_ARCH;

            // define the points for the balloon tail pA, pB and pC denote the outer frame for the tail while pAi,
            // pBi and pCi denote the inner border (used to create the inside boundary of a frame for our balloon)
            Point pA = new Point();
            Point pAi = new Point();
            Point pB = new Point();
            Point pBi = new Point();
            Point pC = new Point();
            Point pCi = new Point();

            #region this section calculates the position of the ballon tail
            switch (m_tipSide)
            {
                // calculate vertical displacement for all top tails
                case sdSide.sd_top:
                    pA.Y = nOuter; pB.Y = 0; pC.Y = nOuter;
                    pAi.Y = pA.Y + 4; pBi.Y = pB.Y + 4; pCi.Y = pC.Y + 4;
                    goto case sdSide.sd_horizontal;

                case sdSide.sd_left:
                    pA.X = nOuter; pC.X = nOuter; pB.X = 0;
                    pAi.X = pA.X + 4; pCi.X = pC.X + 4; pBi.X = pB.X + 4;
                    goto case sdSide.sd_vertical;

                case sdSide.sd_right:
                    pA.X = nW - nOuter; pC.X = nW - nOuter; pB.X = nW;
                    pAi.X = pA.X - 4; pCi.X = pC.X - 4; pBi.X = pB.X - 4;
                    goto case sdSide.sd_vertical;

                case sdSide.sd_bottom:
                    pA.Y = nH - nOuter; pC.Y = nH - nOuter; pB.Y = nH;
                    pAi.Y = pA.Y - 4; pCi.Y = pC.Y - 4; pBi.Y = pB.Y - 4;
                    goto case sdSide.sd_horizontal;

                case sdSide.sd_horizontal:
                    if (m_tipAlign == alAlign.al_lhs)
                    {
                        pA.X = nInner + m_nTailOffset;
                        pB.X = pA.X - 10;
                        pC.X = pA.X + 30;
                        pAi.X = pA.X + 4;
                        pBi.X = pB.X + 3;
                        pCi.X = pC.X + 2;
                    }
                    else if (m_tipAlign == alAlign.al_mid)
                    {
                        pB.X = (int)(nW / 2);
                        pA.X = pB.X - 10;
                        pC.X = pB.X + 10;
                        pAi.X = pA.X;
                        pBi.X = pB.X;
                        pCi.X = pC.X;
                    }
                    else
                    {
                        pC.X = (nW - nInner) - m_nTailOffset;
                        pA.X = pC.X - 30;
                        pB.X = pC.X + 10;
                        pAi.X = pA.X - 2;
                        pBi.X = pB.X - 3;
                        pCi.X = pC.X - 4;
                    }
                    break;

                case sdSide.sd_vertical:
                    if (m_tipAlign == alAlign.al_lhs)
                    {
                        pA.Y = nInner + m_nTailOffset;
                        pC.Y = pA.Y + 30;
                        pB.Y = pA.Y - 10;
                        pAi.Y = pA.Y + 4;
                        pBi.Y = pB.Y + 3;
                        pCi.Y = pC.Y + 2;
                    }
                    else if (m_tipAlign == alAlign.al_mid)
                    {
                        pB.Y = (int)(nH / 2);
                        pA.Y = pB.Y - 10;
                        pC.Y = pB.Y + 10;
                        pAi.Y = pA.Y;
                        pBi.Y = pB.Y;
                        pCi.Y = pC.Y;
                    }
                    else
                    {
                        pC.Y = (nH - nInner) - m_nTailOffset;
                        pA.Y = pC.Y - 30;
                        pB.Y = pC.Y + 10;
                        pAi.Y = pA.Y - 2;
                        pBi.Y = pB.Y - 3;
                        pCi.Y = pC.Y - 4;
                    }
                    break;

            }
            #endregion

            // the new tip position is determined by pB
            m_ptTipPosition = pB;

            // generate balloon tail outer path
            m_path.AddLines(new Point[] { pA, pB, pC });
            m_path.CloseFigure();
            // generate balloon tail inner path
            GraphicsPath iPath = new GraphicsPath();
            iPath.AddLines(new Point[] { pAi, pBi, pCi });
            iPath.CloseFigure();

            #region generate the outer frame (m_rOuterFrame) which becomes the shape of the balloon form
            Size pSize = new Size(nW - (nInner + nInner), nH - (nOuter + nOuter));
            Point pLoc = new Point(nInner, nOuter);
            Rectangle aRect = new Rectangle(pLoc, pSize);
            m_rOuterFrame = new Region(aRect);

            // generate 2nd pass region for the outer frame, starting to form the rounded edges
            pSize.Width += 4;
            pSize.Height -= 2;
            pLoc.X -= 2;
            pLoc.Y += 1;
            m_rOuterFrame.Union(new Rectangle(pLoc, pSize));

            // generate 3rd pass for the outer frame, developing rounded edges
            pSize.Width += 2;
            pSize.Height -= 2;
            pLoc.X -= 1;
            pLoc.Y += 1;
            m_rOuterFrame.Union(new Rectangle(pLoc, pSize));

            // generate 4th pass for the outer frame, developing rounded edges
            pSize.Width += 2;
            pSize.Height -= 2;
            pLoc.X -= 1;
            pLoc.Y += 1;
            m_rOuterFrame.Union(new Rectangle(pLoc, pSize));

            // generate 5th pass for the outer frame, completing the rounded edges
            pSize.Width += 2;
            pSize.Height -= 4;
            pLoc.X -= 1;
            pLoc.Y += 2;
            m_rOuterFrame.Union(new Rectangle(pLoc, pSize));

            // generate 6th pass for the outer frame, adding the balloon tail
            m_rOuterFrame.Union(m_path);
            #endregion

            #region for shadow windows we don't need to paint the area under the foreground balloon
            if (m_bIsShadow == true)
            {
                Region rgnEx;
                rgnEx = m_rOuterFrame.Clone();
                rgnEx.Translate(-C_SHADOW, -C_SHADOW);
                m_rOuterFrame.Exclude(rgnEx);
            }
            #endregion

            // set the region for the form
            this.Region = m_rOuterFrame;
            Graphics eg = Graphics.FromHwnd(this.Handle);
            // calculate the bounding rectangle for this region (within the context of the form itself) and the centre point for
            // the rectangle
            m_rtBalloonF = this.Region.GetBounds(eg);
            m_ptCenter = new Point((int)((m_rtBalloonF.Width / 2) + m_rtBalloonF.X), (int)((m_rtBalloonF.Height / 2) + m_rtBalloonF.Y));
            eg.Dispose();

            #region always generate the outline region (m_rInnerFrame), even if we are not going to display it immediately
            Rectangle myRect = new Rectangle(C_QUOTEH + 6, C_QUOTEH + 4, nW - ((2 * C_QUOTEH) + 12), nH - ((2 * C_QUOTEH) + 8));
            Region aRegion = new Region(myRect);
            // develop client region with rounded edges, 2nd and 3rd pass
            myRect.X -= 1; myRect.Y += 1; myRect.Width += 2; myRect.Height -= 2;
            aRegion.Union(myRect);
            myRect.X -= 1; myRect.Y += 1; myRect.Width += 2; myRect.Height -= 2;
            aRegion.Union(myRect);

            // clone the outer region
            m_rInnerFrame = m_rOuterFrame.Clone();
            // exclude the client area and inner balloon tail edge
            m_rInnerFrame.Exclude(aRegion);
            m_rInnerFrame.Exclude(iPath);
            #endregion


            //add by lulianqi resize the m_fmShadow size when the main window size change
            if (m_fmShadow != null)
            {
                m_fmShadow.Width = this.Width;
                m_fmShadow.Height = this.Height;
            }

            // force a complete redraw
            this.Invalidate();
        }

        // There are many possible variations on this routine. However this works by calculating the distance to the side
        // of the screen, then adjusting the position, and direction, of the tail to avoid going off the edge of the screen
        private bool bCalcTailPos(Point ptA, bool bOnlyBelow)
        {
            int nBWidth = this.Width + C_SHADOW - C_QUOTEH;
            int nBHeight = this.Height + C_SHADOW;

            // get the pixel dimensions of the screen assuming a single monitor (or two monitors creating a single screen space)
            Screen[] screens = Screen.AllScreens;
            int nSWd = screens[0].Bounds.Width;
            int nSHt = screens[0].Bounds.Height;

            // if use below is false then we always draw the balloon above the anchor
            if (bOnlyBelow == false)
            {
                this.tailSide = sdSide.sd_bottom;
            }
            else
            {
                // if we cannot go below, then return false so the calling routine can set a new anchor point
                // positioned above the control (so the balloon tail is not drawn across the anchor)
                if (ptA.Y + nBHeight >= nSHt) { return false; }
                this.tailSide = sdSide.sd_top;
            }

            // look for best horizontal fit
            int nDistToEdge = nSWd - ptA.X;

            // a) the left-most position of the tail tip is C_QUOTEH from the LHS (corresponding to a tail offset of 5)
            // b) the tail must be adjust so the remaining balloon plus the shadow and overhang must fit on the screen
            int nMinLength = (this.Width + C_SHADOW) - C_QUOTEH;

            if (nDistToEdge > nMinLength)
            {
                // okay entire balloon fits, so use the minimum tail offset
                this.tailOffset = 5;
                this.tailAlign = alAlign.al_lhs;
            }
            else
            {
                int nOverlap = nMinLength - nDistToEdge;
                if (nOverlap < (int)Math.Round(nMinLength / 3.0))
                {
                    this.tailOffset = nOverlap + 5;
                    this.tailAlign = alAlign.al_lhs;
                }
                else if (nOverlap > (int)Math.Round((nMinLength - (C_QUOTEH + C_ARCH)) / 2.0))
                {
                    // tail offset is now measure from the rhs
                    int nTempOffset = (nMinLength - nOverlap) - (C_QUOTEH + C_ARCH);
                    if (nTempOffset < 0) { nTempOffset = 0; }
                    this.tailOffset = nTempOffset + 5;
                    this.tailAlign = alAlign.al_rhs;
                }
                else
                {
                    // tail offset not currently used for mid-point set... probably at some point I will need
                    this.tailOffset = 0;
                    this.tailAlign = alAlign.al_mid;
                }
            }

            // now adjust the position
            Point atPoint = new Point(0, 0);
            atPoint.X = ptA.X - m_ptTipPosition.X;
            atPoint.Y = ptA.Y - m_ptTipPosition.Y;
            // locate our balloon
            this.Location = atPoint;
            return true;
        }

        public void setBalloonPosition(Form onForm, Control onControl)
        {
            // determine ownership so the balloon stays ontop of the owning form
            if (m_fmShadow == null)
            {
                this.Owner = onForm;
            }
            else
            {
                m_fmShadow.Owner = onForm;
            }
            // remember the control's position and dimensions
            m_rtAnchor = new Rectangle(onControl.Location, onControl.Size);
            Point ptA = m_rtAnchor.Location;
            Point ptC = ptA;

            // first, try for lower edge of the control as an anchor point
            ptA.Y += m_rtAnchor.Height;

            // calculate absolute position on the screen
            Point ptScreen = onForm.PointToScreen(ptA);

            // see if we can anchor below the control 
            if (bCalcTailPos(ptScreen, true) == false)
            {
                // unable to anchor below, so anchor above
                ptScreen = onForm.PointToScreen(ptC);
                bCalcTailPos(ptScreen, false);
            }
            m_fmParent = onForm;
            // attach a callback so we know when the owner is moved. Oh the joys and advantages of delegates!
            m_evhMove = new System.EventHandler(this.Parent_Move);
            onForm.Move += m_evhMove;
        }
        /// <summary>
        /// change by lulianqui for VinWiew,the old setBalloonPosition has bugs
        /// </summary>
        /// <param name="onForm">you form</param>
        /// <param name="myPoint">the position</param>
        /// <param name="mySize">any size</param>
        public void setBalloonPosition(Form onForm, Point myPoint ,Size mySize)
        {
            // determine ownership so the balloon stays ontop of the owning form
            if (m_fmShadow == null)
            {
                this.Owner = onForm;
            }
            else
            {
                m_fmShadow.Owner = onForm;
            }
            // remember the control's position and dimensions
            m_rtAnchor = new Rectangle(myPoint,mySize);
            Point ptA = m_rtAnchor.Location;
            Point ptC = ptA;

            // first, try for lower edge of the control as an anchor point
            ptA.Y += m_rtAnchor.Height;

            // calculate absolute position on the screen
            Point ptScreen = onForm.PointToScreen(ptA);

            // see if we can anchor below the control 
            if (bCalcTailPos(ptScreen, true) == false)
            {
                // unable to anchor below, so anchor above
                ptScreen = onForm.PointToScreen(ptC);
                bCalcTailPos(ptScreen, false);
            }
            m_fmParent = onForm;
            // attach a callback so we know when the owner is moved. Oh the joys and advantages of delegates!
            m_evhMove = new System.EventHandler(this.Parent_Move);
            onForm.Move += m_evhMove;
        }

        // attach the balloon to a point on a form. for the balloon to auto-track any movement in the owning form,
        // we need to attach an event handler to the Move event on the owning form. Setting ownership ensure the 
        // balloon is always shown on top of the owning form. In addition, a minimize action on the owning form will
        // force the balloon to minimize with it.
        public void setBalloonPosition(Form onForm, Point atPoint)
        {
            // to understand ownership, a balloon with a shadow has the shadow as the owner to ensure the balloon
            // is drawn directly on top of the shadow. Consequently when setting ownership to an attached point, 
            // it is the shadow that gets attached to the owning form. But if no shadow exists, it is the Balloon 
            // itself that must be attached
            if (m_fmShadow == null)
            {
                this.Owner = onForm;
            }
            else
            {
                m_fmShadow.Owner = onForm;
            }
            // calculate absolute position of the point
            m_rtAnchor = new Rectangle(atPoint, new Size(0, 0));
            Point ptScreen = onForm.PointToScreen(m_rtAnchor.Location);

            // see if we can anchor below the control 
            if (bCalcTailPos(ptScreen, true) == false)
            {
                // unable to anchor below, so anchor above
                ptScreen = onForm.PointToScreen(ptScreen);
                bCalcTailPos(ptScreen, false);
            }
            m_fmParent = onForm;
            // attach a callback so we know when the owner is moved. Oh the joys and advantages of delegates!
            m_evhMove = new System.EventHandler(this.Parent_Move);
            onForm.Move += m_evhMove;
        }


        /// <summary>
        /// UpdateBalloonPosition (add by lulianqi not change position with setBalloonPosition it will add EventHandler)
        /// </summary>
        /// <param name="atPoint">Point</param>
        public void UpdateBalloonPosition(Point atPoint)
        {
            // calculate absolute position of the point
            m_rtAnchor = new Rectangle(atPoint, new Size(0, 0));
            Point ptScreen = m_fmParent.PointToScreen(m_rtAnchor.Location);

            // see if we can anchor below the control 
            if (bCalcTailPos(ptScreen, true) == false)
            {
                // unable to anchor below, so anchor above
                ptScreen = m_fmParent.PointToScreen(ptScreen);
                bCalcTailPos(ptScreen, false);
            }
        }

        public void Parent_Move(object sender, System.EventArgs e)
        {
            if ((sender is Form) == false) { return; }

            // calculate absolute position on the screen and try for the lower edge first
            Point ptHigh = m_rtAnchor.Location;
            Point ptLow = ptHigh;
            ptLow.Y += m_rtAnchor.Height;
            Point ptScreen = ((Form)sender).PointToScreen(ptLow);

            // see if we can anchor below the control 
            if (bCalcTailPos(ptScreen, true) == false)
            {
                // unable to anchor below, so anchor above
                ptScreen = ((Form)sender).PointToScreen(ptHigh);
                bCalcTailPos(ptScreen, false);
            }
        }

        // if a shadow window does not yet exist, create it
        private bool bMakeShadow()
        {
            // a shadow cannot have another shadow
            if (this.m_bIsShadow) { return false; }

            // only generate a shadow if required
            if (m_bHasShadow != true) { return false; }

            // no shadows in design mode
            if (DesignMode == true) { return false; }

            // create shadow if non exists
            if (m_fmShadow == null)
            {
                m_fmShadow = new CBalloon.CBalloonBase();
                this.Owner = m_fmShadow;
                m_fmShadow.Width = this.Width;
                m_fmShadow.Height = this.Height;
                m_fmShadow.StartPosition = FormStartPosition.Manual;
                m_fmShadow.Location = new Point(this.Location.X + C_SHADOW, this.Location.Y + C_SHADOW);
                m_fmShadow.IsShadow = true;
                m_fmShadow.Opacity = 0.6;
            }
            return true;
        }

        private void DestroyShadow()
        {
            if (m_fmShadow != null)
            {
                // if the shadow has an owner, we need to attach the balloon to the owner and
                // sever existing owned form relationships
                if (m_fmShadow.Owner != null)
                {
                    this.Owner = m_fmShadow.Owner;
                    m_fmShadow.RemoveOwnedForm(this);
                    this.Owner.RemoveOwnedForm(m_fmShadow);
                }
                m_fmShadow.Close();
                m_fmShadow.Dispose();
                m_fmShadow = null;
            }
        }

        // the shape of the form is maintained by reSizeMe() so the only function or reDrawMe() is to 
        // paint the frame itself
        public void reDrawMe()
        {
            // shadow boxes don't have a frame
            if (m_bShowFrame)
            {
                // for no particular reason, I'm using a gradient brush from top-left to bottom-right... 
                // to grab the User's attention a pulsing frame (variable luminence) works much better
                Graphics eg = Graphics.FromHwnd(this.Handle);
                // the bounding rectangle was calculated in reSizeMe()
                eg.RenderingOrigin = m_ptCenter;
                eg.FillRegion(new LinearGradientBrush(m_rtBalloonF, m_cTopLeft, m_cBotRite, 45, true), m_rInnerFrame);
                eg.Dispose();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    Application.Run(new CBalloonBase());
        //}

        private void CBalloonBase_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            reDrawMe();
        }

        private void CBalloonBase_Click(object sender, System.EventArgs e)
        {
            //if (false == this.m_bIsShadow)
            //{
            //    this.Close();
            //}
        }

        private void CBalloonBase_Resize(object sender, System.EventArgs e)
        {
            reSizeMe();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            // do not allow a shadow box to open another box...
            //if (this.m_bIsShadow == false)
            //{
            //    if (this is CExample)
            //    {
            //        this.Close();
            //    }
            //    else
            //    {
            //        CBalloon.Form3 aForm = new Form3();
            //        aForm.Show();
            //    }
            //}
        }
        private void CBalloonBase_VisibleChanged(object sender, System.EventArgs e)
        {
            if (!m_bHasShadow) { return; }

            if ((this.Visible == true) && (m_fmShadow != null))
            {
                m_fmShadow.Show();
            }
            //add by lulianqi when hide the base window the m_fmShadow is not hide
            else if ((this.Visible == false) && (m_fmShadow != null))
            {
                m_fmShadow.Visible = false;
            }
        }

        private void CBalloonBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region remove any form-owner relationships and events, and close the shadow form if it exists
            // clean up owner-form relationships from the Balloon form
            if (this.Owner != null)
            {
                this.Owner.RemoveOwnedForm(this);
                this.Owner = null;
            }

            // clean up owner-form relationships from the Shadow form, then close the Shadow
            if (m_fmShadow != null)
            {
                if (m_fmShadow.Owner != null)
                {
                    m_fmShadow.Owner.RemoveOwnedForm(m_fmShadow);
                    m_fmShadow.Owner = null;
                }
                m_fmShadow.Close();
            }

            // here we need to remove the event handler from the form with the anchor point
            if (m_fmParent != null)
            {
                m_fmParent.Move -= m_evhMove;
                m_fmParent = null;
            }
            #endregion
        }

        private void CBalloonBase_Move(object sender, System.EventArgs e)
        {
            if (m_fmShadow != null) { m_fmShadow.Location = new Point(this.Location.X + C_SHADOW, this.Location.Y + C_SHADOW); }
        }

        #region form properties

        public bool IsShadow
        {
            set
            {
                if (value == true)
                {
                    if (m_bIsShadow == false)
                    {
                        this.ShowFrame = false;
                        this.BackColor = Color.DarkGray;
                    }
                }
                m_bIsShadow = value;
            }
            get
            {
                return m_bIsShadow;
            }
        }

        public bool HasShadow
        {
            set
            {
                m_bHasShadow = value;
                if (m_bHasShadow)
                {
                    bMakeShadow();
                }
                else
                {
                    DestroyShadow();
                }
            }
            get { return m_bHasShadow; }
        }

        public bool ShowFrame
        {
            set
            {
                if (m_bShowFrame != value)
                {
                    m_bShowFrame = value;
                    this.reDrawMe();
                }
            }
            get
            {
                return m_bShowFrame;
            }
        }

        public sdSide tailSide
        {
            set
            {
                m_tipSide = value;
                reSizeMe();
                if ((m_bHasShadow) && (this.m_fmShadow != null))
                {
                    m_fmShadow.tailSide = value;
                }
            }

            get { return m_tipSide; }
        }

        public int tailOffset
        {
            set
            {
                m_nTailOffset = value;
                reSizeMe();
                if (this.m_fmShadow != null)
                {
                    m_fmShadow.tailOffset = value;
                }
            }

            get { return m_nTailOffset; }
        }

        public alAlign tailAlign
        {
            set
            {
                m_tipAlign = value;
                // better method is to generate a resize event but its 3am and I'm tired
                reSizeMe();
                if (this.m_fmShadow != null)
                {
                    m_fmShadow.tailAlign = value;
                }
            }
            get { return m_tipAlign; }
        }

        // set the color gradient from the top-left of the frame
        public Color FrameTopLeft
        {
            set
            {
                m_cTopLeft = value;
                // better method is to generate a paint event but its 3am and I'm tired
                this.reDrawMe();
            }
            get
            {
                return m_cTopLeft;
            }
        }

        // set the color gradient running to the bottom-left of the frame
        public Color FrameBottomRight
        {
            set
            {
                m_cBotRite = value;
                // better method is to generate a paint event but its 3am and I'm tired
                this.reDrawMe();
            }
            get
            {
                return m_cBotRite;
            }
        }
        #endregion
    }
}
