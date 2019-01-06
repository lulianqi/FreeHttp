using FreeHttp.AutoTest.RunTimeStaticData.MyStaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData
{
    /// <summary>
    /// 如果您想要添加新类型的【RunTimeStaticData】请在此处添加解释器，并为它添加相应的继承于【IRunTimeStaticData】存储的结构
    /// 然后在CaseStaticDataType枚举中直接新增自己的类型（请与原有格式保持一致），最后您还需要在执行器【LoadScriptRunTime】函数中添加自己的分支
    /// </summary>
    public class CaseRunTimeDataTypeEngine
    {
        #region TypeDictionary

        /// <summary>
        /// 参数化数据类型映射表
        /// </summary>
        public static Dictionary<CaseStaticDataType, CaseStaticDataClass> dictionaryStaticDataTypeClass = new Dictionary<CaseStaticDataType, CaseStaticDataClass>() { { CaseStaticDataType.caseStaticData_vaule, CaseStaticDataClass.caseStaticDataKey },
        { CaseStaticDataType.caseStaticData_index, CaseStaticDataClass.caseStaticDataParameter }, { CaseStaticDataType.caseStaticData_long, CaseStaticDataClass.caseStaticDataParameter},{ CaseStaticDataType.caseStaticData_list, CaseStaticDataClass.caseStaticDataParameter},
        { CaseStaticDataType.caseStaticData_time, CaseStaticDataClass.caseStaticDataParameter},{ CaseStaticDataType.caseStaticData_random, CaseStaticDataClass.caseStaticDataParameter},
        { CaseStaticDataType.caseStaticData_csv, CaseStaticDataClass.caseStaticDataSource},{ CaseStaticDataType.caseStaticData_mysql, CaseStaticDataClass.caseStaticDataSource},{ CaseStaticDataType.caseStaticData_redis, CaseStaticDataClass.caseStaticDataSource},
        {CaseStaticDataType.caseStaticData_strIndex, CaseStaticDataClass.caseStaticDataParameter}};

        //参数化数据处理函数委托
        public delegate bool GetStaticDataAction<T>(out T yourStaticData, out string errorMes, string yourFormatData) where T : IRunTimeStaticData;

        /// <summary>
        /// CaseStaticDataType数据与处理函数映射表
        /// </summary>
        public static Dictionary<CaseStaticDataType, GetStaticDataAction<IRunTimeStaticData>> dictionaryStaticDataParameterAction = new Dictionary<CaseStaticDataType, GetStaticDataAction<IRunTimeStaticData>>() { 
        { CaseStaticDataType.caseStaticData_index, new GetStaticDataAction<IRunTimeStaticData>(CaseRunTimeDataTypeEngine.GetIndexStaticData) } ,
        { CaseStaticDataType.caseStaticData_strIndex, new GetStaticDataAction<IRunTimeStaticData>(CaseRunTimeDataTypeEngine.GetStrIndexStaticData) } ,
        { CaseStaticDataType.caseStaticData_long, new GetStaticDataAction<IRunTimeStaticData>(CaseRunTimeDataTypeEngine.GetLongStaticData) } ,
        { CaseStaticDataType.caseStaticData_list, new GetStaticDataAction<IRunTimeStaticData>(CaseRunTimeDataTypeEngine.GetListStaticData) } ,
        { CaseStaticDataType.caseStaticData_time, new GetStaticDataAction<IRunTimeStaticData>(CaseRunTimeDataTypeEngine.GetTimeStaticData) } ,
        { CaseStaticDataType.caseStaticData_random, new GetStaticDataAction<IRunTimeStaticData>(CaseRunTimeDataTypeEngine.GetRandomStaticData) } 
        };

        /// <summary>
        /// CaseStaticDataType数据与处理函数映射表
        /// </summary>
        public static Dictionary<CaseStaticDataType, GetStaticDataAction<IRunTimeDataSource>> dictionaryStaticDataSourceAction = new Dictionary<CaseStaticDataType, GetStaticDataAction<IRunTimeDataSource>>() { 
        { CaseStaticDataType.caseStaticData_csv, new GetStaticDataAction<IRunTimeDataSource>(CaseRunTimeDataTypeEngine.GetCsvStaticDataSource) } 
         };

        #endregion

        #region IRunTimeStaticData

        public static bool GetIndexStaticData(out IRunTimeStaticData yourStaticData, out string errorMes, string yourFormatData)
        {
            try
            {
                string[] tempStartEnd;
                tempStartEnd = yourFormatData.Split('-');
                if (tempStartEnd.Length == 2)
                {
                    yourStaticData = new MyStaticDataIndex(int.Parse(tempStartEnd[0]), int.Parse(tempStartEnd[1]), 1);
                    errorMes = null;
                    return true;
                }
                if (tempStartEnd.Length == 3)
                {
                    yourStaticData = new MyStaticDataIndex(int.Parse(tempStartEnd[0]), int.Parse(tempStartEnd[1]), int.Parse(tempStartEnd[2]));
                    errorMes = null;
                    return true;
                }
                else
                {
                    yourStaticData = new MyStaticDataIndex(0, 2147483647, 1);
                    errorMes = "find error data[myStaticDataIndex] in RunTimeStaticData - ScriptRunTime :(find error number of parameters)";
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataIndex(0, 2147483647, 1);
                errorMes = "find error data[myStaticDataIndex] in RunTimeStaticData - ScriptRunTime ";
            }
            return false;
        }

        public static bool GetStrIndexStaticData(out IRunTimeStaticData yourStaticData, out string errorMes, string yourFormatData)
        {
            try
            {
                string[] tempStartEnd;
                tempStartEnd = yourFormatData.Split('-');
                if (tempStartEnd.Length == 2)
                {
                    if (tempStartEnd[0].Length == tempStartEnd[0].Length)
                    {
                        yourStaticData = new MyStaticDataStrIndex(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), 1, tempStartEnd[0].Length);
                        errorMes = null;
                        return true;
                    }
                    else
                    {
                        yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19);
                        errorMes = "find error data[myStaticDataStrIndex] with error len in RunTimeStaticData - ScriptRunTime ";
                    }

                }
                else if (tempStartEnd.Length == 3)
                {
                    if (tempStartEnd[0].Length == tempStartEnd[0].Length)
                    {
                        yourStaticData = new MyStaticDataStrIndex(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), long.Parse(tempStartEnd[2]), tempStartEnd[0].Length);
                        errorMes = null;
                        return true;
                    }
                    else
                    {
                        yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19);
                        errorMes = "find error data[myStaticDataStrIndex] with error len in RunTimeStaticData - ScriptRunTime ";
                    }
                }
                else
                {
                    yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19);
                    errorMes = "find error data[myStaticDataLong] in RunTimeStaticData - ScriptRunTime  :(find error number of parameters)";
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19);
                errorMes = "find error data[myStaticDataLong] in RunTimeStaticData - ScriptRunTime ";
            }
            return false;
        }
        public static bool GetLongStaticData(out IRunTimeStaticData yourStaticData, out string errorMes, string yourFormatData)
        {
            try
            {
                string[] tempStartEnd;
                tempStartEnd = yourFormatData.Split('-');
                if (tempStartEnd.Length == 2)
                {
                    yourStaticData = new MyStaticDataLong(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), 1);
                    errorMes = null;
                    return true;
                }
                else if (tempStartEnd.Length == 3)
                {
                    yourStaticData = new MyStaticDataLong(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), long.Parse(tempStartEnd[2]));
                    errorMes = null;
                    return true;
                }
                else
                {
                    yourStaticData = new MyStaticDataLong(0, 9223372036854775807, 1);
                    errorMes = "find error data[myStaticDataLong] in RunTimeStaticData - ScriptRunTime  :(find error number of parameters)";
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataLong(0, 9223372036854775807, 1);
                errorMes = "find error data[myStaticDataLong] in RunTimeStaticData - ScriptRunTime ";
            }
            return false;
        }

        public static bool GetTimeStaticData(out IRunTimeStaticData yourStaticData, out string errorMes, string yourFormatData)
        {
            errorMes = null;
            try
            {
                System.DateTime.Now.ToString(yourFormatData);
            }
            catch
            {
                errorMes = "find error data[myStaticDataNowTime] in RunTimeStaticData - ScriptRunTime ";
                yourStaticData = new MyStaticDataNowTime("");
                return false;
            }
            yourStaticData = new MyStaticDataNowTime(yourFormatData);
            return true;
        }

        public static bool GetRandomStaticData(out IRunTimeStaticData yourStaticData, out string errorMes, string yourFormatData)
        {
            try
            {
                string[] tempStartEnd;
                tempStartEnd = yourFormatData.Split('-');
                if (tempStartEnd.Length < 2)
                {
                    yourStaticData = new MyStaticDataRandomStr(10, 0);
                    errorMes = "find error data[myStaticDataRandomNumber] in RunTimeStaticData - ScriptRunTime ";
                }
                else
                {
                    yourStaticData = new MyStaticDataRandomStr(int.Parse(tempStartEnd[0]), int.Parse(tempStartEnd[1]));
                    errorMes = null;
                    return true;
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataRandomStr(10, 0);
                errorMes = "find error data[myStaticDataRandomNumber] in RunTimeStaticData - ScriptRunTime ";
            }
            return false;
        }

        public static bool GetListStaticData(out IRunTimeStaticData yourStaticData, out string errorMes, string yourFormatData)
        {
            try
            {
                if (yourFormatData.EndsWith("-1"))
                {
                    yourFormatData = yourFormatData.Remove(yourFormatData.Length - 2);
                    yourStaticData = new MyStaticDataList(yourFormatData, false);
                }
                else if (yourFormatData.EndsWith("-2"))
                {
                    yourFormatData = yourFormatData.Remove(yourFormatData.Length - 2);
                    yourStaticData = new MyStaticDataList(yourFormatData, true);
                }
                else
                {
                    yourStaticData = new MyStaticDataList(yourFormatData, false);
                }
                errorMes = null;
                return true;
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataList("", false);
                errorMes = "find error data[myStaticDataList] in RunTimeStaticData - ScriptRunTime ";
            }
            return false;
        }

        #endregion

        #region IRunTimeDataSource

        public static bool GetCsvStaticDataSource(out IRunTimeDataSource yourStaticData, out string errorMes, string yourFormatData)
        {
            errorMes = null;
            yourStaticData = new MyStaticDataSourceCsv();
            string csvPath = null;
            int CodePage = 65001;
            Encoding csvEncoding = null;
            if (yourFormatData.Contains('-'))
            {
                if (!yourFormatData.MySplitIntEnd('-', out csvPath, out CodePage))
                {
                    errorMes = string.Format("[GetCsvStaticDataSource]error in [MySplitIntEnd] with :[{0}]", yourFormatData);
                    return false;
                }
            }
            else
            {
                csvPath = yourFormatData;
            }
            try
            {
                csvEncoding = System.Text.Encoding.GetEncoding(CodePage);
            }
            catch
            {
                errorMes = string.Format("[GetCsvStaticDataSource]error in 【CodePage】 [{0}]", yourFormatData);
                return false;
            }
            csvPath = csvPath.StartsWith("@") ? csvPath.Remove(0, 1) : string.Format("{0}\\casefile\\{1}", CaseTool.rootPath, csvPath);
            if (!System.IO.File.Exists(csvPath))
            {
                errorMes = string.Format("[GetCsvStaticDataSource]error in csv path [path not exixts] [{0}]", yourFormatData);
                return false;
            }
            MyCommonHelper.FileHelper.CsvFileHelper myCsv = new MyCommonHelper.FileHelper.CsvFileHelper(csvPath, csvEncoding);
            try
            {
                yourStaticData = new MyStaticDataSourceCsv(myCsv.GetListCsvData());
            }
            catch (Exception ex)
            {
                errorMes = ex.Message;
                return false;
            }
            finally
            {
                myCsv.Dispose();
            }
            return true;
        }

        #endregion

    }

}
