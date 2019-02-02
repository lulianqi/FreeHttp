#define ALLOW_CSV_EMPTY

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

        public static Dictionary<CaseStaticDataType, List<string>> dictionaryStaticDataAnnotation = new Dictionary<CaseStaticDataType, List<string>>()
        {
            {CaseStaticDataType.caseStaticData_vaule,new List<string>(){"Key-Value","value","value","this value the meaning is the key","provide a key value list like dictionary"}},
            {CaseStaticDataType.caseStaticData_index,new List<string>(){"Index","start-end-step","1-1000-2","start: the start of the number \nend: the end of the number (the max is 2147483647)\nstep: when get next value the number will add step (default is 1)","provide a number index ,you can get a increase index each time"}},
            {CaseStaticDataType.caseStaticData_long,new List<string>(){"LongIndex","start-end-step","1-1000-2","start: the start of the number \nend: the end of the number (the max is 9223372036854775807)\nstep: when get next value the number will add step (default is 1)","provide a number long index ,you can get a increase index each time"}},
            {CaseStaticDataType.caseStaticData_strIndex,new List<string>(){"StringIndex","start-end-step","0001-1000-2","start: the start of the number string (the lengh should equal to the end lengh)\nend: the end of the number sting (the max is 9223372036854775807)\nstep: when get next value the number will add step (default is 1)","provide a number string index ,you can keep the same lengh of the string each time"}},
            {CaseStaticDataType.caseStaticData_time,new List<string>(){"Time","DateTimeFormatInfo","yyyy-MM-ddTHH:mm:ss","DateTimeFormatInfo: the format for data time (find DateTimeFormatInfo in dotnet doc)","provide a data time string with your format"}},
            {CaseStaticDataType.caseStaticData_random,new List<string>(){"Random","len-type","10-1","len: the lengh of the random string\ntype: the type of random mode  (0 is all the visible asc2 ; 1 is only number ; 2 is letter in upper ; 3 is letter in lower ; 4 is the special character ; 5 is all the letters ; 6 is all the letters or numbers)(default is 1)","provide a random strng with your mode"}},
            {CaseStaticDataType.caseStaticData_list,new List<string>(){"List","v1,v2,v3,v4-mode","ab,c,de-1","v1,v2,v3: the value of the list (the value list segmentation by ,) \nmode: the mode read 1 is read by order ; 2 is read by random (default is 1)","provide a list value ,you can get it by order or random"}},
            {CaseStaticDataType.caseStaticData_csv,new List<string>(){"CSV","path-encode","csvdatasouce.csv-65001","path: the file path (start with @ means absolute path) \nencode: the encode of the file (default is 65001) \n[another expression] start with'*' and followed by ColumnCount-RowCount (like *10-10 mean creat a 10*10 empty csv data source)","provide a data souce form csv file ,you can get it by order or location"}}
        };

        /// <summary>
        /// 参数化数据类型映射表
        /// </summary>
        public static Dictionary<CaseStaticDataType, CaseStaticDataClass> dictionaryStaticDataTypeClass = new Dictionary<CaseStaticDataType, CaseStaticDataClass>() { 
        { CaseStaticDataType.caseStaticData_vaule, CaseStaticDataClass.caseStaticDataKey },
        { CaseStaticDataType.caseStaticData_index, CaseStaticDataClass.caseStaticDataParameter },
        { CaseStaticDataType.caseStaticData_long, CaseStaticDataClass.caseStaticDataParameter},
        { CaseStaticDataType.caseStaticData_list, CaseStaticDataClass.caseStaticDataParameter},
        { CaseStaticDataType.caseStaticData_time, CaseStaticDataClass.caseStaticDataParameter},
        { CaseStaticDataType.caseStaticData_random, CaseStaticDataClass.caseStaticDataParameter},
        { CaseStaticDataType.caseStaticData_csv, CaseStaticDataClass.caseStaticDataSource},
        { CaseStaticDataType.caseStaticData_mysql, CaseStaticDataClass.caseStaticDataSource},
        { CaseStaticDataType.caseStaticData_redis, CaseStaticDataClass.caseStaticDataSource},
        {CaseStaticDataType.caseStaticData_strIndex, CaseStaticDataClass.caseStaticDataParameter}};

        public static Dictionary<CaseStaticDataClass, List<CaseStaticDataType>> dictionaryStaticDataTypeSource = new Dictionary<CaseStaticDataClass, List<CaseStaticDataType>>()
        {
            {CaseStaticDataClass.caseStaticDataKey,new List<CaseStaticDataType>(){CaseStaticDataType.caseStaticData_vaule}},
            {CaseStaticDataClass.caseStaticDataParameter,new List<CaseStaticDataType>(){CaseStaticDataType.caseStaticData_index,CaseStaticDataType.caseStaticData_list,CaseStaticDataType.caseStaticData_long,CaseStaticDataType.caseStaticData_random,CaseStaticDataType.caseStaticData_strIndex,CaseStaticDataType.caseStaticData_time}},
            {CaseStaticDataClass.caseStaticDataSource,new List<CaseStaticDataType>(){CaseStaticDataType.caseStaticData_csv}}
        };

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
                    yourStaticData = new MyStaticDataIndex(int.Parse(tempStartEnd[0]), int.Parse(tempStartEnd[1]), 1, yourFormatData);
                    errorMes = null;
                    return true;
                }
                if (tempStartEnd.Length == 3)
                {
                    yourStaticData = new MyStaticDataIndex(int.Parse(tempStartEnd[0]), int.Parse(tempStartEnd[1]), int.Parse(tempStartEnd[2]), yourFormatData);
                    errorMes = null;
                    return true;
                }
                else
                {
                    yourStaticData = new MyStaticDataIndex(0, 2147483647, 1, yourFormatData);
                    errorMes = "find error data[myStaticDataIndex] in RunTimeStaticData - ScriptRunTime :(find error number of parameters)";
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataIndex(0, 2147483647, 1, yourFormatData);
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
                        yourStaticData = new MyStaticDataStrIndex(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), 1, tempStartEnd[0].Length, yourFormatData);
                        errorMes = null;
                        return true;
                    }
                    else
                    {
                        yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19, yourFormatData);
                        errorMes = "find error data[myStaticDataStrIndex] with error len in RunTimeStaticData - ScriptRunTime ";
                    }

                }
                else if (tempStartEnd.Length == 3)
                {
                    if (tempStartEnd[0].Length == tempStartEnd[0].Length)
                    {
                        yourStaticData = new MyStaticDataStrIndex(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), long.Parse(tempStartEnd[2]), tempStartEnd[0].Length, yourFormatData);
                        errorMes = null;
                        return true;
                    }
                    else
                    {
                        yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19, yourFormatData);
                        errorMes = "find error data[myStaticDataStrIndex] with error len in RunTimeStaticData - ScriptRunTime ";
                    }
                }
                else
                {
                    yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19, yourFormatData);
                    errorMes = "find error data[myStaticDataLong] in RunTimeStaticData - ScriptRunTime  :(find error number of parameters)";
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataStrIndex(0, 9223372036854775807, 1, 19, yourFormatData);
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
                    yourStaticData = new MyStaticDataLong(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), 1, yourFormatData);
                    errorMes = null;
                    return true;
                }
                else if (tempStartEnd.Length == 3)
                {
                    yourStaticData = new MyStaticDataLong(long.Parse(tempStartEnd[0]), long.Parse(tempStartEnd[1]), long.Parse(tempStartEnd[2]), yourFormatData);
                    errorMes = null;
                    return true;
                }
                else
                {
                    yourStaticData = new MyStaticDataLong(0, 9223372036854775807, 1, yourFormatData);
                    errorMes = "find error data[myStaticDataLong] in RunTimeStaticData - ScriptRunTime  :(find error number of parameters)";
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataLong(0, 9223372036854775807, 1, yourFormatData);
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
                yourStaticData = new MyStaticDataNowTime("", yourFormatData);
                return false;
            }
            yourStaticData = new MyStaticDataNowTime(yourFormatData, yourFormatData);
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
                    yourStaticData = new MyStaticDataRandomStr(10, 0, yourFormatData);
                    errorMes = "find error data[myStaticDataRandomNumber] in RunTimeStaticData - ScriptRunTime ";
                }
                else
                {
                    yourStaticData = new MyStaticDataRandomStr(int.Parse(tempStartEnd[0]), int.Parse(tempStartEnd[1]), yourFormatData);
                    errorMes = null;
                    return true;
                }
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataRandomStr(10, 0, yourFormatData);
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
                    yourStaticData = new MyStaticDataList(yourFormatData, false, yourFormatData);
                }
                else if (yourFormatData.EndsWith("-2"))
                {
                    yourFormatData = yourFormatData.Remove(yourFormatData.Length - 2);
                    yourStaticData = new MyStaticDataList(yourFormatData, true, yourFormatData);
                }
                else
                {
                    yourStaticData = new MyStaticDataList(yourFormatData, false, yourFormatData);
                }
                errorMes = null;
                return true;
            }
            catch (Exception)
            {
                yourStaticData = new MyStaticDataList("", false, yourFormatData);
                errorMes = "find error data[myStaticDataList] in RunTimeStaticData - ScriptRunTime ";
            }
            return false;
        }

        #endregion

        #region IRunTimeDataSource

        public static bool GetCsvStaticDataSource(out IRunTimeDataSource yourStaticData, out string errorMes, string yourFormatData)
        {
            errorMes = null;
            yourStaticData = null;
            string csvPath = null;
            int CodePage = 65001;
            Encoding csvEncoding = null;
#if ALLOW_CSV_EMPTY
            if (yourFormatData.StartsWith("*"))
            {
                int[] tempConuts;
                if (!yourFormatData.Remove(0, 1).MySplitToIntArray('-', out tempConuts) || tempConuts.Length!=2)
                {
                    errorMes = string.Format("[GetCsvStaticDataSource]error in [MySplitToIntArray] with :[{0}]", yourFormatData);
                    return false;
                }
                if(tempConuts[0]<1||tempConuts[1]<1)
                {
                    errorMes = string.Format("[GetCsvStaticDataSource]error in [MySplitToIntArray] with :[{0}] \nYour row conut and columu conut should greater than 0 ", yourFormatData);
                    return false;
                }
                List<string> tempRow = new List<string>(tempConuts[0]);
                for (int i = 0; i < tempConuts[0]; i++)
                {
                    tempRow.Add(null);
                }
                List<List<string>> tempCsvDataSource = new List<List<string>>(tempConuts[1]);
                for (int i = 0; i < tempConuts[1];i++ )
                {
                    tempCsvDataSource.Add(tempRow.ToList());
                }
                yourStaticData = new MyStaticDataSourceCsv(tempCsvDataSource, yourFormatData);
                return true;
            }
#endif
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
            csvPath = csvPath.StartsWith("@") ? csvPath.Remove(0, 1) : string.Format("{0}\\FreeHttp\\{1}", MyCommonTool.rootPath, csvPath);
            if (!System.IO.File.Exists(csvPath))
            {
                errorMes = string.Format("[GetCsvStaticDataSource]error in csv path [path not exixts] [{0}]", yourFormatData);
                return false;
            }
            MyCommonHelper.FileHelper.CsvFileHelper myCsv = new MyCommonHelper.FileHelper.CsvFileHelper(csvPath, csvEncoding);
            try
            {
                yourStaticData = new MyStaticDataSourceCsv(myCsv.GetListCsvData(), yourFormatData);
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
