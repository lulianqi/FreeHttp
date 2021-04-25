using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.FiddlerHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class OperationReportService
    {

        [System.Runtime.Serialization.DataContract()]
        public class OperationDetail
        {
            public class OperationDetailCell
            {
                public DateTime InTime { get; set; }
                public DateTime OutTime { get; set; }
                public int RequestRuleCount { get; set; }
                public int ResponseRuleCount { get; set; }
            }

            [System.Runtime.Serialization.DataMember(Name = "UserToken")]
            public String UserToken { get; set; }

            [System.Runtime.Serialization.DataMember(Name = "UserMac")]
            public String UserMac { get; set; }

            [System.Runtime.Serialization.DataMember(Name = "MachineName")]
            public String MachineName { get; set; }

            [System.Runtime.Serialization.DataMember(Name = "OperationDetailCells")]
            public List<OperationDetailCell> OperationDetailCells { get; set; }

            public OperationDetail(string mac = "FF:FF:FF;FF:FF:FF" , string machineName =null ,string userToken=null)
            {
                UserMac = mac;
                MachineName = machineName;
                UserToken = userToken;
                OperationDetailCells = new List<OperationDetailCell>();
            }

            public void AddCell(DateTime inTime, DateTime outTime, int requestRuleCount, int responseRuleCount)
            {
                if (OperationDetailCells == null)
                {
                    OperationDetailCells = new List<OperationDetailCell>();
                }
                OperationDetailCells.Add(new OperationDetailCell() { InTime = inTime, OutTime = outTime, RequestRuleCount = requestRuleCount, ResponseRuleCount = responseRuleCount });
            }

        }

        private OperationDetail operationDetail;
        private DateTime? nowInTime;

        public List<FiddlerRequestChange> FiddlerRequestChangeRuleList { get; set; } = null;
        public List<FiddlerResponseChange> FiddlerResponseChangeRuleList { get; set; } = null;
        public ActuatorStaticDataCollection StaticDataCollection { get; set; } = null;
        public OperationReportService()
        {
            operationDetail = new OperationDetail(WebService.UserComputerInfo.GetComputerMac(), WebService.UserComputerInfo.GetMachineName(), WebService.UserComputerInfo.UserToken);
            nowInTime = null;
        }

        public bool HasAnyOperation
        {
            get
            {
                return operationDetail.OperationDetailCells.Count > 0;
            }
        }

        public void InOperation(DateTime inTime)
        {
            nowInTime = inTime;
        }

        public void OutOperation( DateTime outTime, int requestRuleCount, int responseRuleCount)
        {
            operationDetail.AddCell(nowInTime == null ? outTime : (DateTime)nowInTime, outTime, requestRuleCount, responseRuleCount);
            nowInTime = null;
        }

        public async void ReportAsync()
        {
            //task需要在执行时设置CurrentThread.IsBackground，不能确保在设置成功前主线程不退出
            Action reportAction = new Action(Report);
            await Task.Run(reportAction);
        }

        public void StartReportThread()
        {
            System.Threading.Thread reportThread = new System.Threading.Thread(new System.Threading.ThreadStart(Report));
            reportThread.IsBackground = false; //使用Thread创建的线程其实默认IsBackground就是false
            reportThread.Start();
        }

        private void Report()
        {
            if(System.Threading.Thread.CurrentThread.IsBackground)//大部分情况在async方法里使用这种方式也没有效果 1：不能确保线程执行到这里没有被主线程结束，2：对于async方法大部分情况执行这里的代码也是上一个线程，到await 才可能切换线程 （不过仍然可以通过同步的方式启动async方法）
            {
                System.Threading.Thread.CurrentThread.IsBackground = false;
            }
            if (operationDetail.OperationDetailCells.Count > 0)
            {
                string operationBody = null;
                //operationBody = Fiddler.WebFormats.JSON.JsonEncode(this.operationDetail);
                operationBody = MyHelper.MyJsonHelper.JsonDataContractJsonSerializer.ObjectToJsonStr(this.operationDetail);
                (new WebService.MyWebTool.MyHttp()).SendHttpRequest(string.Format("{0}freehttp/OperationReport",ConfigurationData.BaseUrl), operationBody, "POST", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Content-Type", "application/json") }, false, null, null);
                if (FiddlerRequestChangeRuleList != null || FiddlerResponseChangeRuleList != null)
                {
                    WebService.RemoteRuleService.UploadRulesAsync<FiddlerRequestChange, FiddlerResponseChange>(FiddlerRequestChangeRuleList, FiddlerResponseChangeRuleList , StaticDataCollection).Wait();
                }
            }
            //System.GC.Collect();
        }
    }
}
