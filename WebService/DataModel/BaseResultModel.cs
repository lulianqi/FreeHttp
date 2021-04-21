using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService.DataModel
{
    public enum ReturnStatus
    {
        Success = 0,
        Fail = 1,
        Error = 2
    }
    public class BaseResultModel<T>
    {
        public BaseResultModel(int? code = null, string message = null, T result = default, ReturnStatus returnStatus = ReturnStatus.Success)
        {
            this.Code = code;
            this.Message = message;
            this.Status = returnStatus;
            this.Result = result;

        }
        public int? Code { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }

        public ReturnStatus Status { get; set; }

    }
}
