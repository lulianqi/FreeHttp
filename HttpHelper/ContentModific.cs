using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public enum ContentModificMode
    {
        NoChange,
        KeyVauleReplace,
        EntireReplace,
        RegexReplace,
        HexReplace,
        ReCode
    }

     [Serializable]
     [DataContract]
    public class ContentModific
    {
        [DataMember]
        public ContentModificMode ModificMode { get; set; }
        [DataMember]
        public string TargetKey { get; set; }
        [DataMember]
        public string ReplaceContent { get; set; }

        public ContentModific()
        {
            ModificMode = ContentModificMode.NoChange;
            TargetKey = null;
            ReplaceContent = null;
        }
        public ContentModific(string targetKey,string replaceContent)
        {
            if (string.IsNullOrEmpty(targetKey))
            {
                ModificMode = ContentModificMode.EntireReplace;
                TargetKey = null;
            }
            else
            {
                if (targetKey.StartsWith("<regex>"))
                {
                    ModificMode = ContentModificMode.RegexReplace;
                    TargetKey = targetKey;
                }
                else if (targetKey.StartsWith("<hex>"))
                {
                    //check data
                    try
                    {
                        replaceContent = replaceContent.TrimEnd(' ');
                        targetKey = targetKey.TrimEnd(' ');
                        replaceContent = BitConverter.ToString( AutoTest.MyBytes.HexStringToByte(replaceContent, AutoTest.HexDecimal.hex16));
                        TargetKey =string.Format("<hex>{0}", BitConverter.ToString(AutoTest.MyBytes.HexStringToByte(targetKey.Remove(0, "<hex>".Length), AutoTest.HexDecimal.hex16)));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("your input is illegal that your should use prescribed hex16 format like 0x00 0x01 0xff and the space or - will be ok for byte spit. \r\ninner Exception is [{0}]", ex.Message), ex);
                    }
                    ModificMode = ContentModificMode.HexReplace;
                }
                else if ((targetKey.StartsWith("<recode>")))
                {
                    try
                    {
                        targetKey = targetKey.TrimEnd(' ');
                        Encoding.GetEncoding(targetKey.Remove(0, 8).Trim(' '));  //https://docs.microsoft.com/zh-cn/dotnet/api/system.text.encoding?view=netcore-2.2
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("your input is illegal that your should use legal EncodingInfo.Name like utf-8;hz-gb-2312 ......\r\ninner Exception is [{0}]", ex.Message), ex);
                    }
                    ModificMode = ContentModificMode.ReCode;
                    TargetKey = targetKey;
                }
                else
                {
                    ModificMode = ContentModificMode.KeyVauleReplace;
                    TargetKey = targetKey;
                }
            }

            //set the ReplaceContent
            if (ModificMode == ContentModificMode.EntireReplace && string.IsNullOrEmpty(replaceContent))
            {
                ModificMode = ContentModificMode.NoChange;
                ReplaceContent = null;
            }
            else if(ModificMode == ContentModificMode.ReCode)
            {
                ReplaceContent = null;
            }
            else
            {
                ReplaceContent = (replaceContent == null ? "" : replaceContent);
            }
            
        }

        public string GetFinalContent(string sourceContent)
        {
            string finalContent = null;
            switch(ModificMode)
            {
                case ContentModificMode.NoChange:
                    finalContent = sourceContent;
                    break;
                case ContentModificMode.EntireReplace:
                    finalContent = ReplaceContent;
                    break;
                case ContentModificMode.KeyVauleReplace:
                    finalContent = sourceContent.Replace(TargetKey, ReplaceContent);
                    break;
                case ContentModificMode.RegexReplace:
                    try
                    {
                        finalContent = System.Text.RegularExpressions.Regex.Replace(sourceContent, TargetKey.Remove(0, 8), ReplaceContent);
                    }
                    catch(Exception ex)
                    {
                        finalContent = string.Format("RegexReplace [{0}] GetFinalContent fail :{1}", TargetKey.Remove(0, 7), ex.Message);
                    }
                    break;
                case ContentModificMode.HexReplace:
                    throw new Exception("your should implement HexReplace with anther GetFinalContent overload");
                case ContentModificMode.ReCode:
                    throw new Exception("your should implement Recode with GetRecodeContent");
                default:
                    throw new Exception("not support ContentModificMode");
            }
            return finalContent;
        }

        public byte[] GetFinalContent(byte[] sourceContent)
        {
            switch (ModificMode)
            {
                case ContentModificMode.NoChange:
                case ContentModificMode.EntireReplace:
                case ContentModificMode.KeyVauleReplace:
                case ContentModificMode.RegexReplace:
                case ContentModificMode.ReCode:
                    throw new Exception("this implement of GetFinalContent is only for HexReplace");
                case ContentModificMode.HexReplace:
                    byte[] replaceContentBytes = AutoTest.MyBytes.HexStringToByte(ReplaceContent, AutoTest.HexDecimal.hex16);
                    string searchKey = TargetKey.Remove(0, 5);//<hex>
                    if (string.IsNullOrEmpty(searchKey))
                    {
                        return replaceContentBytes;
                    }
                    byte[] searchKeyBytes = AutoTest.MyBytes.HexStringToByte(searchKey, AutoTest.HexDecimal.hex16);
                    return AutoTest.MyBytes.ReplaceBytes(sourceContent, searchKeyBytes, replaceContentBytes);
                default:
                    throw new Exception("not support ContentModificMode");
            }
        }

        public byte[] GetRecodeContent(string sourceContent)
        {
            switch (ModificMode)
            {
                case ContentModificMode.NoChange:
                case ContentModificMode.EntireReplace:
                case ContentModificMode.KeyVauleReplace:
                case ContentModificMode.RegexReplace:
                case ContentModificMode.HexReplace:
                    throw new Exception("this implement of GetRecodeContent is only for ReCode ");
                case ContentModificMode.ReCode:
                    string searchKey = TargetKey.Remove(0, 8).Trim(' ');
                    Encoding nowEncoding = Encoding.GetEncoding(searchKey); //shoud check the searchKey when we creat ContentModific
                    return nowEncoding.GetBytes(sourceContent);
                default:
                    throw new Exception("not support ContentModificMode");
            }
        }
    }
}
