using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.ParameterizationContent
{
    /// <summary>
    /// 描述[caseParameterizationContent]使用的数据附加编码类型，0标识不进行操作，基数encode偶数decode
    /// </summary>
    [Serializable]
    public enum ParameterizationContentEncodingType
    {
        encode_default = 0,
        encode_base64 = 1,
        decode_base64 = 2,
        encode_hex16 = 3,
        decode_hex16 = 4,
        encode_hex2 = 5,
        decode_hex2 = 6

    }
}
