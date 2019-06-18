using System;
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
            MyWebTool.MyHttp.EnableServerCertificateValidation = true;
            myHttp = new MyWebTool.MyHttp();
        }

        public void StartCheckUpgrade()
        {
            //Task checkUpgradeCheckUpgrade = new Task(CheckUpgrade);
            //checkUpgradeCheckUpgrade.Start();
            //checkUpgradeCheckUpgrade.ContinueWith((task) => { StartCheckUpgrade(); });

            Task<UpgradeServiceEventArgs> checkUpgradeTask = new Task<UpgradeServiceEventArgs>(() =>
            {
                string tempResponse = myHttp.SendData(string.Format(@"https://api.lulianqi.com/freehttp/UpdateCheck/v1.2?user={0}&dotnetrelease={1}", UserComputerInfo.GetComputerMac(), UserComputerInfo.GetDotNetRelease()));
                string isNeedUpdata = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"isNeedUpdata\":", ",", tempResponse);
                string url = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"url\":", ",", tempResponse);
                string message = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"message\":", ",", tempResponse);
                if (string.IsNullOrEmpty(isNeedUpdata))
                {
                    return new UpgradeServiceEventArgs(false, null);
                }
                if (isNeedUpdata == "true")
                {
                    return new UpgradeServiceEventArgs(true, url);
                }
                return null;
            });
            checkUpgradeTask.Start();
            checkUpgradeTask.ContinueWith((task) => { if (checkUpgradeTask.Result != null) this.GetUpgradeMes(this, checkUpgradeTask.Result); });
        }

        public void StartCheckUpgradeThread()
        {
            Thread checkUpgradeTaskThread = new Thread(new ThreadStart(CheckUpgrade));
            checkUpgradeTaskThread.Name = "CheckUpgradeTaskThread";
            checkUpgradeTaskThread.Priority = ThreadPriority.Normal;
            checkUpgradeTaskThread.IsBackground = true;
            checkUpgradeTaskThread.Start();
        }

        private void CheckUpgrade()
        {
            string tempResponse = myHttp.SendData(string.Format(@"https://api.lulianqi.com/freehttp/UpdateCheck/v1.1?user={0}", UserComputerInfo.GetComputerMac()));
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
}
