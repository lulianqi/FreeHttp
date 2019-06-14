using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest
{
    /// <summary>
    /// hex 字符串显示时的分割方式
    /// </summary>
    public enum ShowHexMode
    {
        @null = 0,    //不分格每个字节
        space = 1,   //以分格分割
        spit0x = 2,   //以0x分割 (用于显示16进制)
        spitSpace0x = 3,   //以 0x分割 (用于显示16进制)
        spit0b = 4,   //以0b分割 (用于显示2进制)
        spitSpace0b = 5,   //以 0b分割 (用于显示2进制)
        spit0d = 6,   //以0d分割 (用于显示10进制)
        spitSpace0d = 7,   //以 0d分割 (用于显示10进制)
        spit_ = 8,    //以下划线分割
        spitM_ = 9  //以中划线分割

    }

    /// <summary>
    /// 表示要代表数据的进制
    /// </summary>
    public enum HexaDecimal
    {
        hex2 = 2,
        hex10 = 10,        //001 224 023  表示显示需要补0
        hex16 = 16
    }

    public class MyBytes
    {
        #region ByteSring

        private static Dictionary<HexaDecimal, int> DictionaryHexaDecimal = new Dictionary<HexaDecimal, int>() { { HexaDecimal.hex2, 8 }, { HexaDecimal.hex10, 3 }, { HexaDecimal.hex16, 2 } };
        private static Dictionary<ShowHexMode, string> DictionaryShowHexMode = new Dictionary<ShowHexMode, string>() { { ShowHexMode.spitSpace0x, " 0x" }, { ShowHexMode.spit0x, "0x" }, { ShowHexMode.spitSpace0d, " 0d" }, { ShowHexMode.spit0d, "0d" }, { ShowHexMode.spitSpace0b, " 0b" }, { ShowHexMode.spit0b, "0b" }, { ShowHexMode.spitM_, "-" }, { ShowHexMode.spit_, "_" }, { ShowHexMode.space, " " }, { ShowHexMode.@null, "" } };


        /// <summary>
        /// 将字符串转换成16进制的可读字符串（使用默认UTF8编码）
        /// </summary>
        /// <param name="yourStr">用户字符串</param>
        /// <returns>返回结果</returns>
        public static string StringToHexString(string yourStr)
        {
            return StringToHexString(yourStr, Encoding.UTF8, HexaDecimal.hex16, ShowHexMode.space);
        }

        /// <summary>
        /// 将字符串转换成指定进制的可读字符串 （使用指定编码指定进制及指定格式）
        /// </summary>
        /// <param name="yourStr">用户字符串</param>
        /// <param name="encode">指定编码</param>
        /// <param name="hexaDecimal">指定进制</param>
        /// <param name="stringMode">指定格式</param>
        /// <returns>返回结果</returns>
        public static string StringToHexString(string yourStr, Encoding encode, HexaDecimal hexaDecimal, ShowHexMode stringMode)
        {
            byte[] tempBytes = encode.GetBytes(yourStr);
            return ByteToHexString(tempBytes, hexaDecimal, stringMode);
        }

        /// <summary>
        /// 将字节数组转换为指定进制的可读字符串
        /// </summary>
        /// <param name="yourBytes">需要转换的字节数组</param>
        /// <param name="hexDecimal">指定进制</param>
        /// <param name="stringMode">指定格式</param>
        /// <returns>返回结果</returns>
        public static string ByteToHexString(byte[] yourBytes, HexaDecimal hexDecimal, ShowHexMode stringMode)
        {
            // 如果只考虑16进制对格式没有特殊要求 可以直接使用 ((byte)233).ToString("X2"); 或 BitConverter.ToString(new byte[]{1,2,3,10,12,233})
            if (yourBytes == null)
            {
                return null;
            }
            StringBuilder result = new StringBuilder(DictionaryHexaDecimal[hexDecimal] + DictionaryShowHexMode[stringMode].Length);

            for (int i = 0; i < yourBytes.Length; i++)
            {
                result.Append(DictionaryShowHexMode[stringMode]);
                result.Append(Convert.ToString(yourBytes[i], (int)hexDecimal).PadLeft(DictionaryHexaDecimal[hexDecimal], '0'));
            }
            return result.ToString().Trim();
        }

        /// <summary>
        /// 将可读指定进制的数据转换为字节数组（因为用户数据可能会是非法数据，遇到非法数据非法会抛出异常）
        /// </summary>
        /// <param name="yourStr">需要转换的字符串</param>
        /// <param name="hexDecimal">指定进制</param>
        /// <param name="stringMode">指定格式</param>
        /// <returns>返回结果(如果yourStr为""返回长度为0的byte[])</returns>
        public static byte[] HexStringToByte(string yourStr, HexaDecimal hexDecimal, ShowHexMode stringMode)
        {
            if (hexDecimal == HexaDecimal.hex16 && (stringMode == ShowHexMode.spit0b || stringMode == ShowHexMode.spit0d || stringMode == ShowHexMode.spitSpace0b || stringMode == ShowHexMode.spitSpace0d))
            {
                throw new Exception("your HexaDecimal and ShowHexMode is conflict");
            }
            string[] hexStrs;
            byte[] resultBytes;
            string modeStr = string.Empty;   //string.Empty 不等于 null
            if (stringMode != ShowHexMode.@null)
            {
                modeStr = DictionaryShowHexMode[stringMode];
            }
            if (modeStr == string.Empty)
            {
                if (yourStr.Length % DictionaryHexaDecimal[hexDecimal] != 0)
                {
                    throw new Exception("error leng of your data");
                }
                long tempHexNum = yourStr.Length / DictionaryHexaDecimal[hexDecimal];
                hexStrs = new string[tempHexNum];
                for (int startIndex = 0; startIndex < tempHexNum; startIndex++)
                {
                    hexStrs[startIndex] = yourStr.Substring(startIndex * DictionaryHexaDecimal[hexDecimal], DictionaryHexaDecimal[hexDecimal]);
                }
            }
            else
            {
                //使用StringSplitOptions.RemoveEmptyEntries去除空值因为0xFF0xFF可能会有第一个值为空的情况
                //对于0xFF 0xFF使用 0x分割，第一个值可能会带0x，不过 Convert.ToByte可以兼容这种情况（不过还是可能带来第一个字节允许使用不应用的分割的情况）
                hexStrs = yourStr.Split(new string[] { modeStr }, StringSplitOptions.RemoveEmptyEntries);
            }
            try
            {
                resultBytes = new byte[hexStrs.Length];
                for (int i = 0; i < hexStrs.Length; i++)
                {
                    resultBytes[i] = Convert.ToByte(hexStrs[i], (int)hexDecimal);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("error data ,can not change your hex string to your hex,  hexDecimal[{0}] ShowHexMode[{1}]", hexDecimal, stringMode), ex);
            }
            return resultBytes;
        }


        /// <summary>
        /// 将可读指定进制的数据转换为字节数组（因为用户数据可能会是非法数据，遇到非法数据非法会抛出异常）(使用猜测的方式发现分割字符串)
        /// </summary>
        /// <param name="yourStr">需要转换的字符串</param>
        /// <param name="hexDecimal">指定进制</param>
        /// <returns>返回结果(如果yourStr为""返回长度为0的byte[])</returns>
        public static byte[] HexStringToByte(string yourStr, HexaDecimal hexDecimal)
        {
            if (yourStr == null) throw new Exception("your source string is null");
            foreach(var tryStringSpitMode in DictionaryShowHexMode)
            {
                if (hexDecimal == HexaDecimal.hex16 && (tryStringSpitMode.Key == ShowHexMode.spit0b || tryStringSpitMode.Key == ShowHexMode.spit0d || tryStringSpitMode.Key == ShowHexMode.spitSpace0b || tryStringSpitMode.Key == ShowHexMode.spitSpace0d)) continue;
                if (yourStr.Contains(tryStringSpitMode.Value)) return HexStringToByte(yourStr, hexDecimal, tryStringSpitMode.Key);
            }
            throw new Exception("unknown exception with HexStringToByte");
        }

        public static bool ByteToSring(byte[] yourBytes, Encoding yourEncoding, ref string outStr)
        {
            try
            {
                outStr = yourEncoding.GetString(yourBytes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool StringToByte(string yourStr, Encoding yourEncoding, ref byte[] outBytes)
        {
            try
            {
                outBytes = yourEncoding.GetBytes(yourStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// 比较两个字节数组
        /// </summary>
        /// <param name="bytesA"></param>
        /// <param name="bytesB"></param>
        /// <returns></returns>
        public static bool IsBytesSame(byte[] bytesA, byte[] bytesB)
        {
            if (bytesA == null || bytesB == null)
            {
                return false;
            }
            if (bytesA.Length == bytesB.Length)
            {
                for (int i = 0; i < bytesB.Length; i++)
                {
                    if (bytesA[i] != bytesB[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 去除bytes尾部空值
        /// </summary>
        /// <param name="yourBytes"></param>
        /// <returns></returns>
        public static byte[] RmBytesEnd(byte[] yourBytes)
        {
            if (yourBytes == null)
            {
                return null;
            }
            int tempLen = yourBytes.Length;
            for (int i = yourBytes.Length - 1; i > 0; i--)
            {
                if (yourBytes[i] == 0x00)
                {
                    tempLen--;
                }
                else
                {
                    break;
                }
            }
            byte[] tempBytes = new byte[tempLen];
            for (int i = 0; i < tempLen; i++)
            {
                tempBytes[i] = yourBytes[i];
            }
            return tempBytes;
        }

        /// <summary>
        /// 生成随机字节数组
        /// </summary>
        /// <param name="byteLen">数组长度</param>
        /// <returns>随机字节数组</returns>
        public static byte[] CreatRandomBytes(int byteLen)
        {
            byte[] tempBytes = new byte[byteLen];
            for (int i = 0; i < byteLen; i++)
            {
                Random ran = new Random(Guid.NewGuid().GetHashCode());
                {
                    tempBytes[i] = (byte)ran.Next(0x00, 0xff);
                }
            }
            return tempBytes;
        }


        /// <summary>
        /// i will change your bytes to IP by vanelife way
        /// </summary>3
        /// <param name="yourData">your bytes</param>
        /// <returns>your IP</returns>
        public static string GetIpByBytes(byte[] yourData)
        {
            if (yourData == null)
            {
                return "null data";
            }
            if (yourData.Length > 6)
            {
                return "length error";
            }
            else
            {
                string tempIp = "";
                for (int i = 0; i < yourData.Length; i++)
                {
                    tempIp += (int)yourData[i] + ".";
                }
                tempIp = tempIp.TrimEnd(new char[] { '.' });
                return tempIp;
            }
        }

        /// <summary>
        /// i will change your bytes to int,and bytes can not more than 4 byte(默认 小端序，低位在前，这里使用大端序列，并仅取2字节)  
        /// </summary>
        /// <param name="yourLen">your bytes</param>
        /// <returns>your len</returns>
        public static int GetByteLen(byte[] yourLen)
        {
            //return BitConverter.ToUInt16(yourLen,0);
            if (yourLen.Length > 4)
            {
                return -1;
            }
            else
            {
                int tempLen = 0;
                for (int i = 0; i < yourLen.Length; i++)
                {
                    tempLen += (int)Math.Pow(256, yourLen.Length - i - 1) * yourLen[i];
                }
                return tempLen;
            }
        }

        /// <summary>
        /// i will change a int to byte and change the 1,2(默认 小端序，低位在前，这里使用大端序列，并仅取2字节)
        /// </summary>
        /// <param name="yourLen">your Len</param>
        /// <returns>your bytes</returns>
        public static byte[] CreateInt16Bytes(int yourLen)
        {
            byte[] tempData = BitConverter.GetBytes(yourLen);
            byte[] dataToBack = new byte[2];
            dataToBack[0] = tempData[1];
            dataToBack[1] = tempData[0];
            return dataToBack;

            //int c = 97;
            //byte[] cb = BitConverter.GetBytes(c);//小端
            //Array.Reverse(cb);//反转成大端   Reverse() 无返回值直接反转目标

            //也可以先把数值转换再转成字节数组
            //int c2 = IPAddress.HostToNetworkOrder(c);//大端字节数
            //byte[] bb = System.BitConverter.GetBytes(c2);//字节数组

            //string s = "code";
            //byte[] sbb = Encoding.BigEndianUnicode.GetBytes(s);//大端
            //byte[] sbs = Encoding.Unicode.GetBytes(s);//小端

            //.NET short 网络大小端转换 一般操作系统文件都是小端，网络传输一般使用大端
            //System.Net.IPAddress.HostToNetworkOrder（本机到网络转换）
            //System.Net.IPAddress.NetworkToHostOrder(网络字节转成本机)
        }

        /// <summary>
        /// 拼接一组byte[]
        /// </summary>
        /// <param name="yourByteList">byte[] List</param>
        /// <returns>拼接完成的的byte[]</returns>
        public static byte[] GroupByteList(List<byte[]> yourByteList)
        {
            if (yourByteList == null)
            {
                throw new Exception("yourByteList is null");
            }
            int byteLen = 0;
            int nowCopyIndex = 0;
            byte[] outBytes;
            foreach (byte[] tempBytes in yourByteList)
            {
                byteLen += tempBytes.Length;
            }
            outBytes = new byte[byteLen];
            foreach (byte[] tempBytes in yourByteList)
            {
                Array.Copy(tempBytes, 0, outBytes, nowCopyIndex, tempBytes.Length);
                nowCopyIndex += tempBytes.Length;
            }
            return outBytes;
        }

        /// <summary>
        /// byte[]替换 (如果 搜索目标或替换目标为null，直接返回源数组)
        /// </summary>
        /// <param name="src">替换源数组</param>
        /// <param name="search">需要被替换目标数组</param>
        /// <param name="repl">替换进入的数组</param>
        /// <returns>完成替换的byte[]</returns>
        public static byte[] ReplaceBytes(byte[] src, byte[] search, byte[] repl)
        {
            if (repl == null) return src;
            int index = FindBytes(src, search);
            if (index < 0) return src;
            byte[] dst = new byte[src.Length - search.Length + repl.Length];
            Buffer.BlockCopy(src, 0, dst, 0, index);
            Buffer.BlockCopy(repl, 0, dst, index, repl.Length);
            Buffer.BlockCopy(src, index + search.Length, dst, index + repl.Length,src.Length - (index + search.Length));
            return dst;
        }

        /// <summary>
        /// 在目标数组中查找指定目标第一次出现的索引（没有指定目标返回-1）
        /// </summary>
        /// <param name="src">查找源</param>
        /// <param name="find">需要查找的目标</param>
        /// <returns>第一次出现的索引（没有指定目标返回-1）</returns>
        public static int FindBytes(byte[] src, byte[] find)
        {
            if(src==null|| find==null|| src.Length==0|| find.Length == 0 || find.Length> src.Length) return -1;
            for (int i = 0; i < src.Length - find.Length +1 ; i++)
            {
                if (src[i] == find[0])
                {
                   for(int m=1;m< find.Length;m++)
                   {
                        if (src[i + m] != find[m]) break;
                        if (m == find.Length - 1) return i;
                   }
                }
            }
            return -1;
        }
    }
}
