using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService.DataModel
{
    [DataContract]
    public enum ReturnStatus
    {
        Success = 0,
        Fail = 1,
        Error = 2
    }

    [DataContract]
    public class BaseResultModel<T>
    {
        public BaseResultModel(int? code = 0, string message = null, T result = default, ReturnStatus returnStatus = ReturnStatus.Success)
        {
            this.Code = code ?? 0;
            this.Message = message;
            this.Status = returnStatus;
            this.Result = result;

        }

        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public T Result { get; set; }

        [DataMember]
        public ReturnStatus Status { get; set; }

    }
}
