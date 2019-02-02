using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace FreeHttp.AutoTest.ParameterizationPick
{
    public class ParameterPickHelper
    {

        /// <summary>
        /// 使用xpth查找xml匹配项
        /// </summary>
        /// <param name="yourTarget">xpth表达式 （如//从匹配选择的当前节点选择文档中的节点，而不考虑它们的位置）</param>
        /// <param name="yourSouce">数据源</param>
        /// <returns>返回结果（结果为XmlNodeList的InnerXml字符串数组）</returns>
        public static string[] PickXmlParameter(string yourTarget, string yourSouce)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(yourSouce);

            }
            catch (Exception)
            {
                return null;
            }
            XmlNodeList tempNodeList;
            try
            {
                tempNodeList = xml.SelectNodes("//" + yourTarget);
            }
            catch (Exception)
            {
                return null;
            }
            if (tempNodeList.Count > 0)
            {
                string[] backStrs = new string[tempNodeList.Count];
                for (int i = 0; i < tempNodeList.Count; i++)
                {
                    backStrs[i] = tempNodeList[i].InnerXml;
                }
                return backStrs;
            }
            return null;
        }

        public static string[] PickRegexParameter(string yourTarget, string yourSouce)
        {
            MatchCollection mc;
            try
            {
                mc = Regex.Matches(yourSouce, yourTarget);
            }
            catch (Exception )
            {
                return null;
            }
            if (mc.Count > 0)
            {
                string[] backStrs = new string[mc.Count];
                for (int i = 0; i < mc.Count; i++)
                {
                    backStrs[i] = mc[i].Value;
                }
                return backStrs;
            }
            return null;
        }

        public static string PickStrParameter(int yourStrStart, int yourStrLen, string yourSouce)
        {
            if (yourStrStart < 0 || yourStrLen < 0)
            {
                return null;
            }
            if (yourSouce.Length >= yourStrStart + yourStrLen)
            {
                yourSouce.Substring(yourStrStart, yourStrLen);
            }
            return null;
        }

        public static string PickStrParameter(string yourTarget, int yourStrLen, string yourSouce)
        {
            if (yourStrLen < 0)
            {
                return null;
            }
            if (yourSouce.Contains(yourTarget))
            {
                string tempPickStr;
                int tempStart = yourSouce.IndexOf(yourTarget) + yourTarget.Length;
                tempPickStr = yourSouce.Remove(0, tempStart);
                if (tempPickStr.Length > yourStrLen)
                {
                    if (yourStrLen != 0)
                    {
                        tempPickStr = tempPickStr.Remove(yourStrLen);
                    }
                }
                return tempPickStr;
            }
            return null;
        }

        public static string PickStrParameter(string yourTarget, string yourStrEnd, string yourSouce)
        {
            if (yourSouce.Contains(yourTarget))
            {
                string tempPickStr;
                int tempStart = yourSouce.IndexOf(yourTarget) + yourTarget.Length;
                tempPickStr = yourSouce.Remove(0, tempStart);
                if (tempPickStr.Contains(yourStrEnd))
                {
                    int tempEnd = tempPickStr.IndexOf(yourStrEnd);
                    tempPickStr = tempPickStr.Remove(tempEnd);
                }
                return tempPickStr;
            }
            return null;
        }
  


        public static bool GetStrPickData(string yourSouce, out string yourFrontTarget, out string yourBackStr)
        {
            yourFrontTarget = null;
            yourBackStr = null;
            if (yourSouce.Contains("-"))
            {
                yourFrontTarget = yourSouce.Remove(yourSouce.LastIndexOf("-"));
                yourBackStr = yourSouce.Remove(0, yourSouce.LastIndexOf("-") + 1);
                return true;
            }
            else
            {
                yourFrontTarget = yourSouce;
            }
            return false;
        }

        public static string CheckParameterPickExpression(ParameterPick yourParameterPick)
        {
            if (string.IsNullOrEmpty(yourParameterPick.PickTypeExpression))
            {
                return "your Expression is empty"; 
            }
            switch(yourParameterPick.PickType)
            {
                    
                case ParameterPickType.Regex:
                    int tempAdditionalIndex;
                    if (int.TryParse(yourParameterPick.PickTypeAdditional, out tempAdditionalIndex))
                    {
                        if(tempAdditionalIndex<0)
                        {
                            return "this PickTypeAdditional should greater than 0";
                        }
                    }
                    else 
                    {
                        return "this PickTypeAdditional should be a number";
                    }
                    try
                    {
                        
                        System.Text.RegularExpressions.Regex.Matches("", yourParameterPick.PickTypeExpression);
                    }
                    catch(Exception ex)
                    {
                        return string.Format("this Regex Expressions error :{0}", ex.Message);
                    }
                    break;
                case ParameterPickType.Xml:
                    if (int.TryParse(yourParameterPick.PickTypeAdditional, out tempAdditionalIndex))
                    {
                        if(tempAdditionalIndex<0)
                        {
                            return "this PickTypeAdditional should greater than 0";
                        }
                    }
                    else 
                    {
                        return "this PickTypeAdditional should be a number";
                    }
                    try
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml("<example/>");
                        xml.SelectSingleNode(yourParameterPick.PickTypeExpression);
                    }
                    catch(Exception ex)
                    {
                        return string.Format("this Xpath Expressions error :{0}", ex.Message);
                    }
                    break;
                case ParameterPickType.Str:
                    string frontStr;
                    string backStr;
                    if (!GetStrPickData(yourParameterPick.PickTypeExpression, out frontStr, out backStr))
                    {
                        return string.Format("this Expressions error :{0}", "it should contain '-'");
                    }
                    if (string.IsNullOrEmpty(frontStr) || string.IsNullOrEmpty(backStr))
                    {
                        return string.Format("this Expressions error :{0}", "the '-' position is illegal");
                    }
                    if (yourParameterPick.PickTypeAdditional == "str-str")
                    {
                        
                    }
                    else if (yourParameterPick.PickTypeAdditional == "str-len")
                    {
                        if(!int.TryParse(backStr,out tempAdditionalIndex))
                        {
                            return string.Format("this Expressions error :{0}", "the len should be a int value");
                        }
                    }
                    else if (yourParameterPick.PickTypeAdditional == "index-len")
                    {
                        if (!int.TryParse(frontStr, out tempAdditionalIndex))
                        {
                            return string.Format("this Expressions error :{0}", "the index should be a int value");
                        }
                        if (!int.TryParse(backStr, out tempAdditionalIndex))
                        {
                            return string.Format("this Expressions error :{0}", "the len should be a int value");
                        }
                    }
                    break;
                default:
                    return "unknow ParameterPickType";
            }
            return null;
        }


        public static string ParameterPickStr(string sourceStr,string pickExpression,string pickExpressionAdditional)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(pickExpression) || string.IsNullOrEmpty(pickExpressionAdditional))
            {
                throw new Exception("your ParameterPick data is null or empty");
            }
            string frontStr;
            string backStr;
            int frontIndex;
            int strLen;
            if (!GetStrPickData(pickExpression, out frontStr, out backStr))
            {
                throw new Exception( string.Format("this Expressions error :{0}", "it should contain '-'"));
            }
            if (string.IsNullOrEmpty(frontStr) || string.IsNullOrEmpty(backStr))
            {
                throw new Exception( string.Format("this Expressions error :{0}", "the '-' position is illegal"));
            }
            switch(pickExpressionAdditional)
            {
                case "str-str":
                    return PickStrParameter(frontStr, backStr, sourceStr);
                case "str-len":
                    if(!int.TryParse(backStr,out strLen))
                    {
                        throw new Exception(string.Format("this Expressions error :{0}", "the len should be a int value"));
                    }
                    return PickStrParameter(frontStr, strLen, sourceStr);
                case "index-len":
                    if (!int.TryParse(backStr, out strLen) )
                    {
                        throw new Exception(string.Format("this Expressions error :{0}", "the len should be a int value"));
                    }
                    if(!int.TryParse(frontStr, out frontIndex))
                    {
                        throw new Exception(string.Format("this Expressions error :{0}", "the index should be a int value"));
                    }
                    return PickStrParameter(frontIndex, strLen, sourceStr);
                default:
                    throw new Exception("your ParameterPick data is null or empty");
            }
        }

        public static string ParameterPickXml(string sourceStr, string pickExpression, string pickExpressionAdditional)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(pickExpression) || string.IsNullOrEmpty(pickExpressionAdditional))
            {
                throw new Exception("your ParameterPick data is null or empty");
            }
            int returnIndex;
            if (!int.TryParse(pickExpressionAdditional, out returnIndex))
            {
                throw new Exception("this PickTypeAdditional should be a number");
            }
            if (returnIndex<0)
            {
                throw new Exception("this PickTypeAdditional should greater than 0");
            }
            string[] returnArray = PickXmlParameter(pickExpressionAdditional, sourceStr);
            if (returnArray==null)
            {
                return null; 
            }
            if (returnIndex==0)
            {
                return string.Join(",", returnArray);
            }
            else if (returnIndex > returnArray.Length)
            {
                return null;
            }
            else
            {
                return returnArray[returnIndex - 1];
            }
        }

        public static string ParameterPickRegex(string sourceStr, string pickExpression, string pickExpressionAdditional)
        {
            {
                if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(pickExpression) || string.IsNullOrEmpty(pickExpressionAdditional))
                {
                    throw new Exception("your ParameterPick data is null or empty");
                }
                int returnIndex;
                if (!int.TryParse(pickExpressionAdditional, out returnIndex))
                {
                    throw new Exception("this PickTypeAdditional should be a number");
                }
                if (returnIndex < 0)
                {
                    throw new Exception("this PickTypeAdditional should greater than 0");
                }
                string[] returnArray = PickRegexParameter(pickExpression, sourceStr);
                if (returnArray == null)
                {
                    return null;
                }
                if (returnIndex == 0)
                {
                    return string.Join(",", returnArray);
                }
                else if (returnIndex > returnArray.Length)
                {
                    return null;
                }
                else
                {
                    return returnArray[returnIndex - 1];
                }
            }
        }
    }
}
