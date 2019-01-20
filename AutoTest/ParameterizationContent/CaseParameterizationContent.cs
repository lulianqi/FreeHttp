using FreeHttp.AutoTest.RunTimeStaticData;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.ParameterizationContent
{
    /// <summary>
    /// 描述可参数化数据结构 (请尽量不要自行解析数据，建议使用getXmlParametContent解析xml数据)
    /// </summary>
    [Serializable]
    public class CaseParameterizationContent
    {
        public string contentData;
        public bool hasParameter;
        public ParameterizationContentEncodingType encodetype;

        public CaseParameterizationContent()
        {
            contentData=null;
            hasParameter = false;
            encodetype = ParameterizationContentEncodingType.encode_default;
        }
        public CaseParameterizationContent(string yourContentData, bool isParameter)
        {
            contentData = yourContentData;
            hasParameter = isParameter;
            encodetype = ParameterizationContentEncodingType.encode_default;
        }
        public CaseParameterizationContent(string yourContentData)
        {
            contentData = yourContentData;
            hasParameter = false;
            encodetype = ParameterizationContentEncodingType.encode_default;
        }

        /// <summary>
        ///返回一个值指示该caseParameterizationContent是否有被任何数据填充过
        /// </summary>
        /// <returns></returns>
        public bool IsFilled()
        {
            if (contentData != null)
            {
                if (contentData != "")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取运算后的值，掉用此法的该版本的重载将会改变涉及到的staticData数据的游标
        /// </summary>
        /// <param name="yourActuatorStaticDataCollection">可用staticData集合</param>
        /// <param name="yourDataResultCollection">返回对所有staticData数据运算后的结果列表</param>
        /// <param name="errorMessage">错误消息（如果没有错误则为null）(在获取参数化数据产生错误后因对当前case设置警示)</param>
        /// <returns>运算结果</returns>
        public string GetTargetContentData(ActuatorStaticDataCollection yourActuatorStaticDataCollection, NameValueCollection yourDataResultCollection, out string errorMessage)
        {
            string myTargetContentData = contentData;
            errorMessage = null;
            if (hasParameter)
            {
                myTargetContentData = ParameterizationContentHelper.GetCurrentParametersData(contentData, MyConfiguration.ParametersDataSplitStr, yourActuatorStaticDataCollection, yourDataResultCollection, out errorMessage);
            }
            if (encodetype != ParameterizationContentEncodingType.encode_default)
            {
                switch (encodetype)
                {
                    //base64
                    case ParameterizationContentEncodingType.encode_base64:
                        myTargetContentData = Convert.ToBase64String(Encoding.UTF8.GetBytes(myTargetContentData));
                        break;
                    case ParameterizationContentEncodingType.decode_base64:
                        try
                        {
                            myTargetContentData = Encoding.UTF8.GetString(Convert.FromBase64String(myTargetContentData));
                        }
                        catch (Exception ex)
                        {
                            myTargetContentData = "ContentEncoding Error:" + ex.Message;
                        }
                        break;
                    //hex 16
                    case ParameterizationContentEncodingType.encode_hex16:
                        myTargetContentData = MyBytes.StringToHexString(myTargetContentData);
                        break;
                    case ParameterizationContentEncodingType.decode_hex16:
                        try
                        {
                            byte[] nowBytes = MyBytes.HexStringToByte(myTargetContentData, HexaDecimal.hex16, ShowHexMode.space);
                            myTargetContentData = Encoding.UTF8.GetString(nowBytes);
                        }
                        catch (Exception ex)
                        {
                            myTargetContentData = "ContentEncoding Error:" + ex.Message;
                        }
                        break;
                    //hex 2
                    case ParameterizationContentEncodingType.encode_hex2:
                        myTargetContentData = MyBytes.StringToHexString(myTargetContentData, Encoding.UTF8, HexaDecimal.hex2, ShowHexMode.space);
                        break;
                    case ParameterizationContentEncodingType.decode_hex2:
                        try
                        {
                            byte[] nowBytes = MyBytes.HexStringToByte(myTargetContentData, HexaDecimal.hex2, ShowHexMode.space);
                            myTargetContentData = Encoding.UTF8.GetString(nowBytes);
                        }
                        catch (Exception ex)
                        {
                            myTargetContentData = "ContentEncoding Error:" + ex.Message;
                        }
                        break;
                    default:
                        errorMessage = "[getTargetContentData] unknow or not supported this encodetype";
                        break;
                }
            }
            return myTargetContentData;
        }

        /// <summary>
        /// 获取原始数据，掉用此法的该版本的重载将不会会改变涉及到的staticData数据的游标，也不会对其进行运算
        /// </summary>
        /// <returns>原始数据数据</returns>
        public string GetTargetContentData()
        {
            return contentData;
        }
    }

}
