using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData
{
    public enum CaseStaticDataType
    {
        caseStaticData_vaule = 10000,

        caseStaticData_index = 20000,
        caseStaticData_long = 20001,
        caseStaticData_random = 20002,
        caseStaticData_time = 20003,
        caseStaticData_list = 20004,
        caseStaticData_strIndex = 20005,

        caseStaticData_csv = 30000,
        caseStaticData_mysql = 30001,
        caseStaticData_redis = 30002,
    }

    /// <summary>
    /// 静态参数化数据大分类
    /// </summary>
    public enum CaseStaticDataClass
    {
        caseStaticDataKey = 0,
        caseStaticDataParameter = 1,
        caseStaticDataSource = 2
    }
}
