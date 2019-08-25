using System;
using System.Collections.Generic;
using System.Linq;
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
        Recode
    }

     [Serializable]
    public class ContentModific
    {
        public ContentModificMode ModificMode { get; set; }
        public string TargetKey { get; set; }
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
                        AutoTest.MyBytes.HexStringToByte(replaceContent, AutoTest.HexaDecimal.hex16);
                        AutoTest.MyBytes.HexStringToByte(targetKey.Remove(0,5), AutoTest.HexaDecimal.hex16);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(string.Format("your input is illegal that your should use prescribed hex16 format like 0x00 0x01 0xff and the space or - will be ok for byte spit. \r\ninner Exception is [{0}]", ex.Message), ex);
                    }
                    ModificMode = ContentModificMode.HexReplace;
                    TargetKey = targetKey;
                }
                else
                {
                    ModificMode = ContentModificMode.KeyVauleReplace;
                    TargetKey = targetKey;
                }
            }

            if (ModificMode == ContentModificMode.EntireReplace && string.IsNullOrEmpty(replaceContent))
            {
                ModificMode = ContentModificMode.NoChange;
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
                        finalContent = System.Text.RegularExpressions.Regex.Replace(sourceContent, TargetKey.Remove(0, 7), ReplaceContent);
                    }
                    catch(Exception ex)
                    {
                        finalContent = string.Format("RegexReplace [{0}] GetFinalContent fail :{1}", TargetKey.Remove(0, 7), ex.Message);
                    }
                    break;
                case ContentModificMode.HexReplace:
                    throw new Exception("your should implement HexReplace with anther GetFinalContent overload");
                case ContentModificMode.Recode:
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
                case ContentModificMode.Recode:
                    throw new Exception("your should implement HexReplace with out GetFinalContent");
                case ContentModificMode.HexReplace:
                    byte[] replaceContentBytes = AutoTest.MyBytes.HexStringToByte(ReplaceContent, AutoTest.HexaDecimal.hex16);
                    string searchKey = TargetKey.Remove(0, 5);//<hex>
                    if (string.IsNullOrEmpty(searchKey))
                    {
                        return replaceContentBytes;
                    }
                    byte[] searchKeyBytes = AutoTest.MyBytes.HexStringToByte(searchKey, AutoTest.HexaDecimal.hex16);
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
                    throw new Exception("your should implement Recode with out GetRecodeContent");
                case ContentModificMode.Recode:
                    string searchKey = TargetKey.Remove(0, 7);//<recode>
                    Encoding nowEncoding = Encoding.GetEncoding(searchKey); //shoud check the searchKey when we creat ContentModific
                    return nowEncoding.GetBytes(sourceContent);
                    return null;
                default:
                    throw new Exception("not support ContentModificMode");
            }
        }
    }
}
