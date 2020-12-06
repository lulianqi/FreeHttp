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
            public bool IsSilentUpgrade { get; set; }
            public string UpgradeMes { get; set; }
            public string Message { get; set; }

            public UpgradeServiceEventArgs(bool isSuccess, string upgradeMes, string message = null, bool isSilentUpgrade = false)
            {
                IsSuccess = isSuccess;
                UpgradeMes = upgradeMes;
                Message = message;
                IsSilentUpgrade = isSilentUpgrade;
            }
        }

        MyWebTool.MyHttp myHttp;

        public event EventHandler<UpgradeServiceEventArgs> GetUpgradeMes;

        public string SilentUpgradeUrl { get; private set; }

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
                string tempResponse = myHttp.SendData(string.Format(@"{0}freehttp/UpdateCheck/v{1}?user={2}&dotnetrelease={3}&username={4}&machinename={5}", ConfigurationData.BaseUrl, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), UserComputerInfo.GetComputerMac(), UserComputerInfo.GetDotNetRelease(), UserComputerInfo.GetUserName(), UserComputerInfo.GetMachineName()));
                string isNeedUpdata = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"isNeedUpdata\":", ",", tempResponse);
                string isSilentUpgrade = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"isSilentUpgrade\":", ",", tempResponse);
                string url = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"url\":\"", "\",", tempResponse);
                string message = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"message\":\"", "\"", tempResponse);
                if (string.IsNullOrEmpty(isNeedUpdata))
                {
                    return new UpgradeServiceEventArgs(false, null);
                }
                if (isNeedUpdata == "true")
                {
                    if (isSilentUpgrade == "true") SilentUpgradeUrl = url;
                    return new UpgradeServiceEventArgs(true, url, null, isSilentUpgrade == "true");
                }
                if (!string.IsNullOrEmpty(message))
                {
                    return new UpgradeServiceEventArgs(true, null, message);
                }
                return null;
            });
            checkUpgradeTask.Start();
            checkUpgradeTask.ContinueWith((task) => { if (checkUpgradeTask.Result != null) this.GetUpgradeMes(this, checkUpgradeTask.Result); });
        }

        public void TrySilentUpgrade()
        {
            if (string.IsNullOrEmpty(SilentUpgradeUrl))
            {
                return;
            }
            System.Threading.Thread silentUpgradeThread = new System.Threading.Thread(new System.Threading.ThreadStart(StartSilentUpgrade));
            silentUpgradeThread.IsBackground = false; //使用Thread创建的线程其实默认IsBackground就是false
            silentUpgradeThread.Start();
        }

        private void StartSilentUpgrade()
        {
            if (System.Threading.Thread.CurrentThread.IsBackground)//大部分情况在async方法里使用这种方式也没有效果 1：不能确保线程执行到这里没有被主线程结束，2：对于async方法大部分情况执行这里的代码也是上一个线程，到await 才可能切换线程 （不过仍然可以通过同步的方式启动async方法）
            {
                System.Threading.Thread.CurrentThread.IsBackground = false;
            }
            //_ = await RemoteLogService.ReportLogAsync() 父进程可能先结束，不会管以异步启动的任务是否完成
            RemoteLogService.ReportLogAsync("start SilentUpgrade", RemoteLogService.RemoteLogOperation.SilentUpgrade, RemoteLogService.RemoteLogType.Info).Wait();
            //MyHelper.SelfUpgradeHelp.UpdateDllAsync("https://lulianqi.com/file/FreeHttpUpgradeFile").Wait();
            MyHelper.SelfUpgradeHelp.UpdateDllAsync(SilentUpgradeUrl).ContinueWith((result) =>
            {
                if (!string.IsNullOrEmpty(result.Result))
                {
                    RemoteLogService.ReportLogAsync(result.Result, RemoteLogService.RemoteLogOperation.SilentUpgrade, RemoteLogService.RemoteLogType.Error).Wait();
                }
                else
                {
                    RemoteLogService.ReportLogAsync("SilentUpgrade complete", RemoteLogService.RemoteLogOperation.SilentUpgrade, RemoteLogService.RemoteLogType.Info).Wait();
                }
            }).Wait();
        }


        /// <summary>
        /// give up maintenance
        /// </summary>
        public void StartCheckUpgradeThread()
        {
            Thread checkUpgradeTaskThread = new Thread(new ThreadStart(CheckUpgrade));
            checkUpgradeTaskThread.Name = "CheckUpgradeTaskThread";
            checkUpgradeTaskThread.Priority = ThreadPriority.Normal;
            checkUpgradeTaskThread.IsBackground = true;
            checkUpgradeTaskThread.Start();
        }

        /// <summary>
        /// give up maintenance
        /// </summary>
        private void CheckUpgrade()
        {
            string tempResponse = myHttp.SendData(string.Format(@"{0}freehttp/UpdateCheck/v1.1?user={1}", ConfigurationData.BaseUrl, UserComputerInfo.GetComputerMac()));
            string isNeedUpdata = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"isNeedUpdata\":", ",", tempResponse);
            string url = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"url\":", ",", tempResponse);
            string message = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"message\":", ",", tempResponse);
            if (string.IsNullOrEmpty(isNeedUpdata))
            {
                this.GetUpgradeMes(this, new UpgradeServiceEventArgs(false, null));
            }
            if (isNeedUpdata == "true")
            {
                this.GetUpgradeMes(this, new UpgradeServiceEventArgs(true, url));
            }
        }
    }
}
