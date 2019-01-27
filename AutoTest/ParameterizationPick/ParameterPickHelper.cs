using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            catch (Exception ex)
            {
                return null;
            }
            XmlNodeList tempNodeList = xml.SelectNodes("//" + yourTarget);
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

        /// <summary>
        /// 查找指定字符串并截取指定长度
        /// </summary>
        /// <param name="yourTarget">匹配字符串</param>
        /// <param name="yourStrLen">指定长度，如果为0则表示长度为取后面所有</param>
        /// <param name="yourSouce">源数据</param>
        /// <returns>结果，如果没有匹配到返回null</returns>
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
                    if (yourParameterPick.PickTypeAdditional == "str-str")
                    {

                    }
                    else if (yourParameterPick.PickTypeAdditional == "str-len")
                    {

                    }
                    break;
                default:
                    return "unknow ParameterPickType";
            }
            return null;
        }
    }
}
