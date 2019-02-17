using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FreeHttp.WebService
{
    public class UpgradeService
    {
        public class UpgradeServiceEventArgs : EventArgs
        {
            public bool IsSuccess { get; set; }
            public string UpgradeMes{get ;set;}
            public UpgradeServiceEventArgs(bool isSuccess ,string upgradeMes)
            {
                IsSuccess = isSuccess;
                UpgradeMes= upgradeMes;
            }
        }

        MyWebTool.MyHttp myHttp;

        public event EventHandler<UpgradeServiceEventArgs> GetUpgradeMes;

        public UpgradeService()
        {
            myHttp = new MyWebTool.MyHttp();
        }

        public void StartCheckUpgrade()
        {
            Thread checkUpgradeTaskThread = new Thread(new ThreadStart(CheckUpgrade));
            checkUpgradeTaskThread.Name = "CheckUpgradeTaskThread";
            checkUpgradeTaskThread.Priority = ThreadPriority.Normal;
            checkUpgradeTaskThread.IsBackground = true;
            checkUpgradeTaskThread.Start();
        }

        private void CheckUpgrade()
        {
            string tempResponse = myHttp.SendData(string.Format(@"http://api.lulianqi.com/UpdateCheck/v0?user={0}", UserComputerInfo.GetComputerMac()));
            string isNeedUpdata = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter( "\"isNeedUpdata\":", ",",tempResponse);
            string url = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"url\":", ",", tempResponse);
            string message = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"message\":", ",", tempResponse);
            if (string.IsNullOrEmpty(isNeedUpdata))
            {
                this.GetUpgradeMes(this, new UpgradeServiceEventArgs(false, null));
            }
            if(isNeedUpdata=="true")
            {
                this.GetUpgradeMes(this, new UpgradeServiceEventArgs(true,url));
            }
        }
    }

    internal class UserComputerInfo
    {
        internal static string GetComputerMac()
        {
            ManagementClass mc = null;
            ManagementObjectCollection moc = null;
            try
            {
                string mac = "";
                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                return mac;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (moc != null)
                {
                    moc.Dispose();
                }
                if(mc!=null)
                {
                    mc.Dispose();
                }
            }

        }
    
    }
}
