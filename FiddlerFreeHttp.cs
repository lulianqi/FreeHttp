using Fiddler;
using FreeHttp.FreeHttpControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


[assembly: Fiddler.RequiredVersion("2.3.5.0")]
namespace FreeHttp
{
    
    public class FiddlerFreeHttp : IAutoTamper
    {
        private bool isOnLoad = false;
        private TabPage tabPage; //创建插件的选项卡页
        private FreeHttpWindow myFreeHttpWindow; //MyControl自定义控件


        public void OnBeforeUnload()
        {
            throw new NotImplementedException();
        }

        private void PrintFiddlerLog(string mes)
        {
            FiddlerObject.log(string.Format("【FiddlerFreeHttp】:{0}", mes));
        }

        public void OnLoad()
        {
            FiddlerObject.log(string.Format("【FiddlerFreeHttp】:{0}", "OnLoad"));
            if (!isOnLoad)
            {

                tabPage = new TabPage();
                tabPage.Text = "Free Http";
                if (FiddlerApplication.UI.tabsViews.ImageList != null)
                {
                    Image myIco = FreeHttp.Resources.MyResource.freehttpico;
                    FiddlerApplication.UI.tabsViews.ImageList.Images.Add(myIco);
                    tabPage.ImageIndex = FiddlerApplication.UI.tabsViews.ImageList.Images.Count - 1;
                }
                myFreeHttpWindow = new FreeHttpWindow();
                myFreeHttpWindow.Dock = DockStyle.Fill;
                tabPage.Controls.Add(myFreeHttpWindow);
                FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
                isOnLoad = true;
            }
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void OnBeforeReturningError(Session oSession)
        {
            //throw new NotImplementedException();
        }

    }
}
