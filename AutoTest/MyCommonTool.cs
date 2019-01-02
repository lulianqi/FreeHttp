using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest
{
    public static class MyCommonTool
    {
        /// <summary>
        /// seed for GenerateRandomStr
        /// </summary>
        private static int externRandomSeed = 0;

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="strCount">字符串长度</param>
        /// <param name="GenerateType">生成模式： 0-是有可见ASCII / 1-数字 / 2-大写字母 / 3-小写字母 / 4-特殊字符 / 5-大小写字母 / 6-字母和数字</param>
        /// <returns>随机字符串</returns>
        public static string GenerateRandomStr(int strCount, int GenerateType)
        {
            externRandomSeed++;
            StringBuilder myRandomStr = new StringBuilder(strCount);
            long mySeed = DateTime.Now.Ticks + externRandomSeed;
            Random random = new Random((int)(mySeed & 0x0000ffff));
            for (int i = 0; i < strCount; i++)
            {
                char tempCh;
                int num = random.Next();
                switch (GenerateType)
                {
                    case 1:
                        tempCh = (char)(0x30 + (num % 10));
                        break;
                    case 2:
                        tempCh = (char)(0x41 + (num % 26));
                        break;
                    case 3:
                        tempCh = (char)(0x61 + (num % 26));
                        break;
                    case 4:
                        int tempValue = 0x20 + ((num % 95));
                        if ((tempValue >= 0x30 && tempValue <= 0x39) || (tempValue >= 0x41 && tempValue <= 0x5a) || (tempValue >= 0x61 && tempValue <= 0x7a))
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            tempCh = (char)tempValue;
                        }
                        break;
                    case 5:
                        tempValue = 0x20 + ((num % 95));
                        if ((tempValue >= 0x41 && tempValue <= 0x5a) || (tempValue >= 0x61 && tempValue <= 0x7a))
                        {
                            tempCh = (char)tempValue;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                        break;
                    case 6:
                        tempValue = 0x20 + ((num % 95));
                        if ((tempValue >= 0x30 && tempValue <= 0x39) || (tempValue >= 0x41 && tempValue <= 0x5a) || (tempValue >= 0x61 && tempValue <= 0x7a))
                        {
                            tempCh = (char)tempValue;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                        break;
                    default:
                        tempCh = (char)(0x20 + (num % 95));
                        break;
                }
                myRandomStr.Append(tempCh);
            }
            return myRandomStr.ToString();
        }

    }
}
