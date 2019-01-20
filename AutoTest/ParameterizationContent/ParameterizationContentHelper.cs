using FreeHttp.AutoTest.RunTimeStaticData;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.ParameterizationContent
{
    public static class ParameterizationContentHelper
    {

        //仅用于【caseParameterizationContent】内部
        //如果没有任何valid identification，直接返回原始数据，不报错（为实现最大兼容）
        /// <summary>
        /// get the getTargetContentData in caseParameterizationContent
        /// </summary>
        /// <param name="yourSourceData">Source Data</param>
        /// <param name="yourParameterList">ParameterList</param>
        /// <param name="yourStaticDataList">StaticDataList</param>
        /// <param name="errorMessage">error Message</param>
        /// <returns></returns>
        public static string GetCurrentParametersData(string yourSourceData, string splitStr, ActuatorStaticDataCollection yourActuatorStaticDataCollection, NameValueCollection yourDataResultCollection, out string errorMessage)
        {
            errorMessage = null;
            if (yourSourceData.Contains(splitStr))
            {
                var yourParameterList = yourActuatorStaticDataCollection.RunActuatorStaticDataKeyList;
                var yourStaticDataList = yourActuatorStaticDataCollection.RunActuatorStaticDataParameterList;
                var yourStaticDataSourceList = yourActuatorStaticDataCollection.RunActuatorStaticDataSouceList;
                int tempStart, tempEnd = 0;
                string tempKeyVaule = null;
                string keyParameter = null;
                string keyAdditionData = null;
                string tempVaule = null;
                while (yourSourceData.Contains(splitStr))
                {
                    tempStart = yourSourceData.IndexOf(splitStr);
                    tempEnd = yourSourceData.IndexOf(splitStr, tempStart + splitStr.Length);
                    if (tempEnd == -1)
                    {
                        errorMessage = string.Format("the identification  not enough in Source[{0}]", yourSourceData);
                        return yourSourceData;
                    }
                    tempKeyVaule = yourSourceData.Substring(tempStart + splitStr.Length, tempEnd - (tempStart + splitStr.Length));
                    keyParameter = TryGetParametersAdditionData(tempKeyVaule, out keyAdditionData);
                    if (keyAdditionData != null)
                    {
                        keyAdditionData = GetCurrentParametersData(keyAdditionData, MyConfiguration.ParametersExecuteSplitStr, yourActuatorStaticDataCollection, yourDataResultCollection, out errorMessage);
                    }

                    Func<string> DealErrorAdditionData = () =>
                    {
                        tempVaule = "[ErrorData]";
                        return string.Format("ParametersAdditionData error find in the runTime data with keyParameter:[{0}] keyAdditionData:[{1}]", keyParameter, keyAdditionData);
                    };

                    #region RunTimeStaticKey
                    if (yourParameterList.Keys.Contains(keyParameter))
                    {
                        //RunTimeParameter 不含有参数信息，所以不处理keyParameter
                        tempVaule = yourParameterList[keyParameter].DataCurrent();
                        yourSourceData = yourSourceData.Replace(splitStr + tempKeyVaule + splitStr, tempVaule);
                        yourDataResultCollection.MyAdd(tempKeyVaule, tempVaule);
                    }
                    #endregion

                    #region RunTimeStaticParameter
                    else if (yourStaticDataList.Keys.Contains(keyParameter))
                    {
                        if (keyAdditionData == null)
                        {
                            tempVaule = yourStaticDataList[keyParameter].DataCurrent();
                        }
                        else if (keyAdditionData == "=")
                        {
                            tempVaule = yourStaticDataList[keyParameter].DataCurrent();
                        }
                        else if (keyAdditionData == "+")
                        {
                            tempVaule = yourStaticDataList[keyParameter].DataMoveNext();
                        }
                        else if (keyAdditionData.StartsWith("+")) //+10 前移10
                        {
                            int tempTimes;
                            if (int.TryParse(keyAdditionData.Remove(0, 1), out tempTimes))
                            {
                                if (tempTimes > 0)
                                {
                                    for (int i = 0; i < tempTimes; i++)
                                    {
                                        yourStaticDataList[keyParameter].DataMoveNext();
                                    }
                                    tempVaule = yourStaticDataList[keyParameter].DataCurrent();
                                }
                                else
                                {
                                    errorMessage = DealErrorAdditionData();
                                }
                            }
                            else
                            {
                                errorMessage = DealErrorAdditionData();
                            }
                        }
                        else
                        {
                            errorMessage = DealErrorAdditionData();
                        }

                        yourSourceData = yourSourceData.Replace(splitStr + tempKeyVaule + splitStr, tempVaule);
                        yourDataResultCollection.MyAdd(tempKeyVaule, tempVaule);
                    }
                    #endregion

                    #region RunTimeStaticDataSource
                    else if (yourStaticDataSourceList.Keys.Contains(keyParameter))
                    {
                        if (keyAdditionData == null)
                        {
                            tempVaule = yourStaticDataSourceList[tempKeyVaule].DataCurrent();
                        }
                        else if (keyAdditionData == "=")
                        {
                            tempVaule = yourStaticDataSourceList[keyParameter].DataCurrent();
                        }
                        else if (keyAdditionData == "+")
                        {
                            tempVaule = yourStaticDataSourceList[keyParameter].DataMoveNext();
                        }
                        else if (keyAdditionData.StartsWith("+")) //+10 前移10
                        {
                            int tempTimes;
                            if (int.TryParse(keyAdditionData.Remove(0, 1), out tempTimes))
                            {
                                if (tempTimes > 0)
                                {
                                    for (int i = 0; i < tempTimes; i++)
                                    {
                                        yourStaticDataSourceList[keyParameter].DataMoveNext();
                                    }
                                    tempVaule = yourStaticDataSourceList[keyParameter].DataCurrent();
                                }
                                else
                                {
                                    errorMessage = DealErrorAdditionData();
                                }
                            }
                            else
                            {
                                errorMessage = DealErrorAdditionData();
                            }
                        }
                        else
                        {
                            tempVaule = yourStaticDataSourceList[keyParameter].GetDataVaule(keyAdditionData);
                            if (tempVaule == null)
                            {
                                errorMessage = DealErrorAdditionData();
                            }
                        }

                        yourSourceData = yourSourceData.Replace(splitStr + tempKeyVaule + splitStr, tempVaule);
                        yourDataResultCollection.MyAdd(tempKeyVaule, tempVaule);
                    }
                    #endregion

                    else
                    {
                        tempVaule = "[ErrorData]";
                        errorMessage = string.Format("can not find your key [{0}] in StaticDataList", keyParameter);
                        yourSourceData = yourSourceData.Replace(splitStr + tempKeyVaule + splitStr, tempVaule);
                        yourDataResultCollection.MyAdd(tempKeyVaule, tempVaule);
                    }
                }

            }

            return yourSourceData;
        }

        /// <summary>
        /// 处理ParametersData，解析静态数据名及其参数
        /// </summary>
        /// <param name="souceData">souce parameter data 原数据</param>
        /// <param name="additionData">返回辅助参数数据，若没有或无法解析返回null</param>
        /// <returns></returns>
        private static string TryGetParametersAdditionData(string souceData, out string additionData)
        {
            additionData = null;
            string parametersData = null;
            if (souceData != null)
            {
                if (souceData.EndsWith(")"))
                {
                    int startIndex = souceData.LastIndexOf('(');
                    if (startIndex > 0)
                    {
                        parametersData = souceData.Remove(startIndex);
                        additionData = souceData.Substring(startIndex + 1, souceData.Length - startIndex - 2);
                    }
                    else
                    {
                        parametersData = souceData;
                    }
                }
                else
                {
                    parametersData = souceData;
                }
            }
            return parametersData;
        }

    }

    public class MyConfiguration
    {
        //◎●◐◑◒◓◔◕◖◗▼▲
        public static string ParametersDataSplitStr = "*#";                                                     //参数化数据分隔符
        public static string ParametersExecuteSplitStr = "`";                                                   //参数再运算风格符
        public static string CaseShowTargetAndContent = "➤";
        public static string CaseShowCaseNodeStart = "◆";
        public static string CaseShowJumpGotoNode = "▼";
        public static string CaseShowGotoNodeStart = "▲";
    }
}
