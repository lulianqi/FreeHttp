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

        class JsonDataContractJsonSerializer
        {
            public static string ObjectToJson(object obj)
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, obj);
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        stream.Position = 0;
                        return sr.ReadToEnd();
                    }
                }
            }

        }


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

            [System.Runtime.Serialization.DataMember(Name = "UserMac")]
            public String UserMac { get; set; }

            [System.Runtime.Serialization.DataMember(Name = "OperationDetailCells")]
            public List<OperationDetailCell> OperationDetailCells { get; set; }

            public OperationDetail(string mac = "FF:FF:FF;FF:FF:FF")
            {
                UserMac = mac;
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

        public OperationReportService()
        {
            operationDetail = new OperationDetail(WebService.UserComputerInfo.GetComputerMac());
            nowInTime = null;
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
            reportThread.IsBackground = false;
            reportThread.Start();
        }

        private void Report()
        {
            if(System.Threading.Thread.CurrentThread.IsBackground)
            {
                System.Threading.Thread.CurrentThread.IsBackground = false;
            }
            if (operationDetail.OperationDetailCells.Count > 0)
            {
                string operationBody = null;
                //operationBody = Fiddler.WebFormats.JSON.JsonEncode(this.operationDetail);
                operationBody = JsonDataContractJsonSerializer.ObjectToJson(this.operationDetail);
                (new WebService.MyWebTool.MyHttp()).SendHttpRequest("https://api.lulianqi.com/freehttp/OperationReport", operationBody, "POST", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Content-Type", "application/json") }, false, null, null);
                //(new WebService.MyWebTool.MyHttp()).SendHttpRequest("http://localhost:5000/freehttp/OperationReport", operationBody, "POST", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Content-Type", "application/json") }, false, null, null);
            }
        }
    }
}
