using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData
{
    public interface IRunTimeDataSource : IRunTimeStaticData
    {
        /// <summary>
        /// 获取一个值指示该数据源是否已经连接
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// 连接数据源
        /// </summary>
        /// <returns></returns>
        bool ConnectDataSource();

        /// <summary>
        /// 断开数据源连接
        /// </summary>
        /// <returns></returns>
        bool DisConnectDataSource();

        /// <summary>
        /// 以指定地址返回数据源中的数据（地址无效或错误请返回null）
        /// </summary>
        /// <param name="vauleAddress">地址字符串（需要按格式指定并定义）</param>
        /// <returns>目标数据</returns>
        string GetDataVaule(string vauleAddress);

        /// <summary>
        /// 设置指定地址的数据值 （IRunTimeStaticData 中的DataSet 设置的是当前值）
        /// </summary>
        /// <param name="vauleAddress">地址字符串（需要按格式指定并定义）</param>
        /// <param name="expectData">期望值</param>
        /// <returns>是否成功设置</returns>
        bool DataSet(string vauleAddress, string expectData);
    }
}
