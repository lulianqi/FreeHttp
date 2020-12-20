using FreeHttp.FiddlerHelper;
using FreeHttp.MyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    public class RemoteLogService
    {
        [System.Runtime.Serialization.DataContract()]
        private  class RemoteLogDetail
        {
            [DataMember]
            public String UserMac { get; set; }
            [DataMember]
            public String MachineName { get; set; }
            [DataMember]
            public String Version { get; set; }
            [DataMember]
            public String Type { get; set; }
            [DataMember]
            public String Operation { get; set; }
            [DataMember]
            public String Message { get; set; }

        }

        public enum RemoteLogOperation
        {
            Unknown ,
            SilentUpgrade ,
            SessionTamp,
            WindowLoad,
            AddRule
        }

        public enum RemoteLogType
        {
            Unknown,
            Info,
            Warning,
            Error
        }

        private static HttpClient httpClient;
        static RemoteLogService()
        {
            httpClient = new HttpClient();
        }

        public static async Task ReportLogAsync(string message , RemoteLogOperation operation = RemoteLogOperation.Unknown, RemoteLogType type =  RemoteLogType.Info)
        {
            RemoteLogDetail remoteLogDetail = new RemoteLogDetail() {
                UserMac = WebService.UserComputerInfo.GetComputerMac(),
                MachineName = WebService.UserComputerInfo.GetMachineName(),
                Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                Type = type.ToString(),
                Operation = operation.ToString(),
                Message = message
            };
            await httpClient.PostAsync(string.Format(@"{0}freehttp/UserLogReport", ConfigurationData.BaseUrl), new StringContent(MyJsonHelper.JsonDataContractJsonSerializer.ObjectToJsonStr(remoteLogDetail), Encoding.UTF8, "application/json"));
        }
    }
}
