using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData
{
    /// <summary>
    /// StaticData数据结构接口
    /// Current 属性指向集合中的当前成员。
    /// MoveNext 属性将枚举数移到集合中的下一成员
    /// Reset 属性将枚举数移回集合的开始处
    /// </summary>
    public interface IRunTimeStaticData : ICloneable
    {
        /// <summary>
        /// 获取当前初始化数据类型
        /// </summary>
        string RunTimeStaticDataType
        {
            get;
        }
        /// <summary>
        /// 获取当前游标地址的值
        /// </summary>
        /// <returns></returns>
        string DataCurrent();
        /// <summary>
        /// 将游标下移，并返回下移之后的值（如何已经到达上边界，则重置游标）（为方便使用请特殊处理初始游标也包括重置后的DataMoveNext与DataCurrent一致，即此时DataMoveNext不向下移动）
        /// </summary>
        /// <returns></returns>
        string DataMoveNext();
        /// <summary>
        /// 重置游标
        /// </summary>
        void DataReset();
        /// <summary>
        /// 设置当前游标指示的数据的值
        /// </summary>
        /// <param name="expectData">期望值</param>
        /// <returns>设置是否成功</returns>
        bool DataSet(string expectData);
    }

}
