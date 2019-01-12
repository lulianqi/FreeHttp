using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


/*******************************************************************************
* Copyright (c) 2016 lijie
* All rights reserved.
* 
* 文件名称: 
* 内容摘要: mycllq@hotmail.com
* 
* 历史记录:
* 日	  期:   201601010          创建人: lulianqi
* 描    述: 创建
*******************************************************************************/

namespace FreeHttp.AutoTest.MyCommonHelper.FileHelper
{
    /// <summary>
    /// 单个元素支持包括tab，换行回车（\r\n），空内容等在内的所有文本字符 （在使用时请确定文件的编码方式）
    /// 可指定元素分割符，行非官方必须为\r\n(\r\n可以作为内容出现在元素中)，转义字符必须为".
    /// 转义所有的引号必须出现在首尾（如果不在首尾，则不会按转义符处理，直接作为引号处理）[excel可以读取转义出现在中间的情况，而本身存储不会使用这种方式，保存时并会强制修复这种异常，所以这里遇到中间转义的情况直接抛出指定异常]
    /// 如果在被转义的情况下需要出现引号，则使用2个引号代替（如果需要在首部使用双引号，则需要转义该元素，其他地方可直接使用）（excel对所有双引号都进行转义，无论其出现位置,对于保存方式可以选择是否按excel的方式进行保存）
    /// 每一行的结尾是不需要逗号结束的，如果多加一个逗号则标识该行会多一个空元素
    /// 空行也是一个空元素,一个逗号是2个空元素，所以不可能出现有的行元素为空
    /// 使用问题或疑问可通过mycllq@hotmail.com进行联系
    /// </summary>
    public sealed class CsvFileHelper : IDisposable
    {

        #region Members

        //private FileStream _fileStream;
        private Stream _stream;
        private StreamReader _streamReader;
        //private StreamWriter _streamWriter;
        //private Stream _memoryStream;
        private Encoding _encoding;
        //private readonly StringBuilder _columnBuilder = new StringBuilder(100);
        private Type _type = Type.File;
        private bool _trimColumns = false;

        private char _csvSeparator = ',';


        #endregion Members

        #region Properties

        /// <summary>
        /// Gets or sets whether column values should be trimmed
        /// </summary>
        public bool TrimColumns
        {
            get { return _trimColumns; }
            set { _trimColumns = value; }
        }

        public Type DataSouceType
        {
            get{ return _type;}
        }

        /// <summary>
        /// get or set Csv Separator (Default Values is ,)
        /// </summary>
        public char CsvSeparator
        {
            get { return _csvSeparator; }
            set { _csvSeparator = value; }
        }
        #endregion Properties

        #region Enums

        /// <summary>
        /// Type enum
        /// </summary>
        public enum Type
        {
            File,
            Stream
        }

        #endregion Enums

        #region Methods
        
        /// <summary>
        /// Initialises the reader to work from a file
        /// </summary>
        /// <param name="filePath">File path</param>
        public CsvFileHelper(string filePath):this(filePath, Encoding.Default)
        {
        }

        /// <summary>
        /// Initialises the reader to work from a file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="encoding">Encoding</param>
        public CsvFileHelper(string filePath, Encoding encoding)
        {
            _type = Type.File;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("The file '{0}' does not exist.", filePath));
            }
            //_stream = File.OpenRead(filePath); //return a FileStream   (OpenRead 源码就是 return new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);)
            _stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _stream.Position = 0;
            _encoding = (encoding ?? Encoding.Default);
            _streamReader = new StreamReader(_stream, _encoding);
        }

       
        /// <summary>
        /// Initialises the reader to work from an existing stream
        /// </summary>
        /// <param name="stream">Stream</param>
        public CsvFileHelper(Stream stream):this(stream, Encoding.Default)
        {
        }

        /// <summary>
        /// Initialises the reader to work from an existing stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="encoding">Encoding</param>
        public CsvFileHelper(Stream stream, Encoding encoding)
        {
            _type = Type.Stream;
            if (stream == null)
            {
                throw new ArgumentNullException("The supplied stream is null.");
            }
            _stream = stream;
            _stream.Position = 0;
            _encoding = (encoding ?? Encoding.Default);
            _streamReader = new StreamReader(_stream, _encoding);
        }

        /// <summary>
        /// Initialises the reader to work from an existing stream (with the Separator char)
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="yourSeparator"> the Separator char</param>
        public CsvFileHelper(Stream stream, Encoding encoding, char yourSeparator): this(stream, encoding)
        {
            CsvSeparator = yourSeparator;
        }


        private List<string> ParseLine(string line)
        {
            StringBuilder _columnBuilder = new StringBuilder();
            List<string> Fields = new List<string>();
            bool inColumn = false;  //是否是在一个列元素里
            bool inQuotes = false;  //是否需要转义
            bool isNotEnd = false;  //读取完毕未结束转义
            _columnBuilder.Remove(0, _columnBuilder.Length);


            // Iterate through every character in the line
            for (int i = 0; i < line.Length; i++)
            {
                char character = line[i];

                // If we are not currently inside a column
                if (!inColumn)
                {
                    // If the current character is a double quote then the column value is contained within
                    // double quotes, otherwise append the next character
                    inColumn = true;
                    if (character == '"')
                    {
                        inQuotes = true;
                        continue;
                    }
                    
                }

                // If we are in between double quotes
                if (inQuotes)
                {
                    if ((i + 1) == line.Length)//这个字符已经结束了整行
                    {
                        if (character == '"') //正常转义结束，且该行已经结束
                        {
                            inQuotes = false;
                            continue;     //当前字符不用添加，跳出后直结束后会添加该元素
                        }
                        else //异常结束，转义未收尾
                        {
                            isNotEnd = true;
                        }
                    }
                    else if (character == '"' && line[i + 1] == _csvSeparator) //结束转义，且后面有可能还有数据
                    {
                        inQuotes = false;
                        inColumn = false;
                        i++; //跳过下一个字符
                    }
                    else if (character == '"' && line[i + 1] == '"') //双引号转义
                    {
                        i++; //跳过下一个字符
                    }
                    else if (character == '"') //双引号单独出现（这种情况实际上已经是格式错误，为了兼容可暂时不处理）
                    {
                        throw new Exception(string.Format("[{0}]:格式错误，错误的双引号转义 near [{1}] ","ParseLine", line));
                    }
                    //其他情况直接跳出，后面正常添加

                }
                else if (character == _csvSeparator)
                    inColumn = false;

                // If we are no longer in the column clear the builder and add the columns to the list
                if (!inColumn) //结束该元素时inColumn置为false，并且不处理当前字符，直接进行Add
                {
                    Fields.Add(TrimColumns ? _columnBuilder.ToString().Trim() : _columnBuilder.ToString());
                    _columnBuilder.Remove(0, _columnBuilder.Length);
                   
                }
                else // append the current column
                    _columnBuilder.Append(character);
            }

            // If we are still inside a column add a new one （标准格式一行结尾不需要逗号结尾，而上面for是遇到逗号才添加的，为了兼容最后还要添加一次）
            if (inColumn)
            {
                if (isNotEnd)
                {
                    _columnBuilder.Append("\r\n");
                }
                Fields.Add(TrimColumns ? _columnBuilder.ToString().Trim() : _columnBuilder.ToString());
            }
            //如果inColumn为false，说明已经添加，因为最后一个字符为分隔符，所以后面要加上一个空元素
            //另外一种情况是line为""空行，（空行也是一个空元素,一个逗号是2个空元素），正好inColumn为默认值false，在此处添加一空元素
            else  
            {
                Fields.Add("");
            }


            return Fields;
        }

        /// <summary>
        /// 处理未完成的Csv单行
        /// </summary>
        /// <param name="line">数据源</param>
        /// <returns>元素列表</returns>
        private List<string> ParseContinueLine(string line)
        {
            StringBuilder _columnBuilder = new StringBuilder();
            List<string> Fields = new List<string>();
            _columnBuilder.Remove(0, _columnBuilder.Length);
            if (line == "")
            {
                Fields.Add("\r\n");
                return Fields;
            }

            for (int i = 0; i < line.Length; i++)
            {
                char character = line[i];

                if ((i + 1) == line.Length)//这个字符已经结束了整行
                {
                    if (character == '"') //正常转义结束，且该行已经结束
                    {
                        Fields.Add(TrimColumns ? _columnBuilder.ToString().TrimEnd() : _columnBuilder.ToString());
                        return Fields;
                    }
                    else //异常结束，转义未收尾
                    {
                        _columnBuilder.Append("\r\n");
                        Fields.Add(_columnBuilder.ToString());
                        return Fields;
                    }
                }
                else if (character == '"' && line[i + 1] == _csvSeparator) //结束转义，且后面有可能还有数据
                {
                    Fields.Add(TrimColumns ? _columnBuilder.ToString().TrimEnd() : _columnBuilder.ToString());
                    i++; //跳过下一个字符
                    Fields.AddRange(ParseLine(line.Remove(0, i+1)));
                    break;
                }
                else if (character == '"' && line[i + 1] == '"') //双引号转义
                {
                    i++; //跳过下一个字符
                }
                else if (character == '"') //双引号单独出现（这种情况实际上已经是格式错误，转义用双引号一定是【,"】【",】形式，包含在里面的双引号需要使用一对双引号进行转义）
                {
                    throw new Exception(string.Format("[{0}]:格式错误，错误的双引号转义 near [{1}]", "ParseContinueLine", line));
                }
                _columnBuilder.Append(character);
            }
            return Fields;
        }

        public List<List<string>> GetListCsvData()
        {
            _stream.Position = 0;
            List<List<string>> tempListCsvData = new List<List<string>>();
            bool isNotEndLine = false;
            //这里的ReadLine可能把转义的/r/n分割，需要后面单独处理
            string tempCsvRowString = _streamReader.ReadLine();
            while (tempCsvRowString!=null)
            {
                List<string> tempCsvRowList;
                if (isNotEndLine)
                {
                    tempCsvRowList = ParseContinueLine(tempCsvRowString);
                    isNotEndLine = (tempCsvRowList.Count > 0 && tempCsvRowList[tempCsvRowList.Count - 1].EndsWith("\r\n"));
                    List<string> myNowContinueList = tempListCsvData[tempListCsvData.Count - 1];
                    myNowContinueList[myNowContinueList.Count - 1] += tempCsvRowList[0];
                    tempCsvRowList.RemoveAt(0);
                    myNowContinueList.AddRange(tempCsvRowList);
                }
                else
                {
                    tempCsvRowList = ParseLine(tempCsvRowString);
                    isNotEndLine = (tempCsvRowList.Count > 0 && tempCsvRowList[tempCsvRowList.Count - 1].EndsWith("\r\n"));
                    tempListCsvData.Add(tempCsvRowList);
                }
                tempCsvRowString = _streamReader.ReadLine();
            }
            return tempListCsvData;
        }

        public void Dispose()
        {
            if(_streamReader!=null)
            {
                _streamReader.Dispose();
            }
            if(_stream!=null)
            {
                _stream.Dispose();
            }
        }

        #endregion

        #region StaticTool
    
        #region 编码方式可接受值
        //请考虑让应用程序使用 UTF-8 或 Unicode (UTF-16) 作为默认编码。大多数其他编码要么不完整并将许多字符转换为“?”，要么在不同的平台上具有稍有不同的行为。非 Unicode 编码通常具有多义性，应用程序则不再试图确定合适的编码，也不再提供用户用来修复文本语言或编码的更正下拉菜单。 
        /* 
        This code produces the following output.

        CodePage identifier and name     BrDisp   BrSave   MNDisp   MNSave   1-Byte   ReadOnly 
        37     IBM037                    False    False    False    False    True     True     
        437    IBM437                    False    False    False    False    True     True     
        500    IBM500                    False    False    False    False    True     True     
        708    ASMO-708                  True     True     False    False    True     True     
        720    DOS-720                   True     True     False    False    True     True     
        737    ibm737                    False    False    False    False    True     True     
        775    ibm775                    False    False    False    False    True     True     
        850    ibm850                    False    False    False    False    True     True     
        852    ibm852                    True     True     False    False    True     True     
        855    IBM855                    False    False    False    False    True     True     
        857    ibm857                    False    False    False    False    True     True     
        858    IBM00858                  False    False    False    False    True     True     
        860    IBM860                    False    False    False    False    True     True     
        861    ibm861                    False    False    False    False    True     True     
        862    DOS-862                   True     True     False    False    True     True     
        863    IBM863                    False    False    False    False    True     True     
        864    IBM864                    False    False    False    False    True     True     
        865    IBM865                    False    False    False    False    True     True     
        866    cp866                     True     True     False    False    True     True     
        869    ibm869                    False    False    False    False    True     True     
        870    IBM870                    False    False    False    False    True     True     
        874    windows-874               True     True     True     True     True     True     
        875    cp875                     False    False    False    False    True     True     
        932    shift_jis                 True     True     True     True     False    True     
        936    gb2312                    True     True     True     True     False    True     
        949    ks_c_5601-1987            True     True     True     True     False    True     
        950    big5                      True     True     True     True     False    True     
        1026   IBM1026                   False    False    False    False    True     True     
        1047   IBM01047                  False    False    False    False    True     True     
        1140   IBM01140                  False    False    False    False    True     True     
        1141   IBM01141                  False    False    False    False    True     True     
        1142   IBM01142                  False    False    False    False    True     True     
        1143   IBM01143                  False    False    False    False    True     True     
        1144   IBM01144                  False    False    False    False    True     True     
        1145   IBM01145                  False    False    False    False    True     True     
        1146   IBM01146                  False    False    False    False    True     True     
        1147   IBM01147                  False    False    False    False    True     True     
        1148   IBM01148                  False    False    False    False    True     True     
        1149   IBM01149                  False    False    False    False    True     True     
        1200   utf-16                    False    True     False    False    False    True     
        1201   unicodeFFFE               False    False    False    False    False    True     
        1250   windows-1250              True     True     True     True     True     True     
        1251   windows-1251              True     True     True     True     True     True     
        1252   Windows-1252              True     True     True     True     True     True     
        1253   windows-1253              True     True     True     True     True     True     
        1254   windows-1254              True     True     True     True     True     True     
        1255   windows-1255              True     True     True     True     True     True     
        1256   windows-1256              True     True     True     True     True     True     
        1257   windows-1257              True     True     True     True     True     True     
        1258   windows-1258              True     True     True     True     True     True     
        1361   Johab                     False    False    False    False    False    True     
        10000  macintosh                 False    False    False    False    True     True     
        10001  x-mac-japanese            False    False    False    False    False    True     
        10002  x-mac-chinesetrad         False    False    False    False    False    True     
        10003  x-mac-korean              False    False    False    False    False    True     
        10004  x-mac-arabic              False    False    False    False    True     True     
        10005  x-mac-hebrew              False    False    False    False    True     True     
        10006  x-mac-greek               False    False    False    False    True     True     
        10007  x-mac-cyrillic            False    False    False    False    True     True     
        10008  x-mac-chinesesimp         False    False    False    False    False    True     
        10010  x-mac-romanian            False    False    False    False    True     True     
        10017  x-mac-ukrainian           False    False    False    False    True     True     
        10021  x-mac-thai                False    False    False    False    True     True     
        10029  x-mac-ce                  False    False    False    False    True     True     
        10079  x-mac-icelandic           False    False    False    False    True     True     
        10081  x-mac-turkish             False    False    False    False    True     True     
        10082  x-mac-croatian            False    False    False    False    True     True     
        20000  x-Chinese-CNS             False    False    False    False    False    True     
        20001  x-cp20001                 False    False    False    False    False    True     
        20002  x-Chinese-Eten            False    False    False    False    False    True     
        20003  x-cp20003                 False    False    False    False    False    True     
        20004  x-cp20004                 False    False    False    False    False    True     
        20005  x-cp20005                 False    False    False    False    False    True     
        20105  x-IA5                     False    False    False    False    True     True     
        20106  x-IA5-German              False    False    False    False    True     True     
        20107  x-IA5-Swedish             False    False    False    False    True     True     
        20108  x-IA5-Norwegian           False    False    False    False    True     True     
        20127  us-ascii                  False    False    True     True     True     True     
        20261  x-cp20261                 False    False    False    False    False    True     
        20269  x-cp20269                 False    False    False    False    True     True     
        20273  IBM273                    False    False    False    False    True     True     
        20277  IBM277                    False    False    False    False    True     True     
        20278  IBM278                    False    False    False    False    True     True     
        20280  IBM280                    False    False    False    False    True     True     
        20284  IBM284                    False    False    False    False    True     True     
        20285  IBM285                    False    False    False    False    True     True     
        20290  IBM290                    False    False    False    False    True     True     
        20297  IBM297                    False    False    False    False    True     True     
        20420  IBM420                    False    False    False    False    True     True     
        20423  IBM423                    False    False    False    False    True     True     
        20424  IBM424                    False    False    False    False    True     True     
        20833  x-EBCDIC-KoreanExtended   False    False    False    False    True     True     
        20838  IBM-Thai                  False    False    False    False    True     True     
        20866  koi8-r                    True     True     True     True     True     True     
        20871  IBM871                    False    False    False    False    True     True     
        20880  IBM880                    False    False    False    False    True     True     
        20905  IBM905                    False    False    False    False    True     True     
        20924  IBM00924                  False    False    False    False    True     True     
        20932  EUC-JP                    False    False    False    False    False    True     
        20936  x-cp20936                 False    False    False    False    False    True     
        20949  x-cp20949                 False    False    False    False    False    True     
        21025  cp1025                    False    False    False    False    True     True     
        21866  koi8-u                    True     True     True     True     True     True     
        28591  iso-8859-1                True     True     True     True     True     True     
        28592  iso-8859-2                True     True     True     True     True     True     
        28593  iso-8859-3                False    False    True     True     True     True     
        28594  iso-8859-4                True     True     True     True     True     True     
        28595  iso-8859-5                True     True     True     True     True     True     
        28596  iso-8859-6                True     True     True     True     True     True     
        28597  iso-8859-7                True     True     True     True     True     True     
        28598  iso-8859-8                True     True     False    False    True     True     
        28599  iso-8859-9                True     True     True     True     True     True     
        28603  iso-8859-13               False    False    False    False    True     True     
        28605  iso-8859-15               False    True     True     True     True     True     
        29001  x-Europa                  False    False    False    False    True     True     
        38598  iso-8859-8-i              True     True     True     True     True     True     
        50220  iso-2022-jp               False    False    True     True     False    True     
        50221  csISO2022JP               False    True     True     True     False    True     
        50222  iso-2022-jp               False    False    False    False    False    True     
        50225  iso-2022-kr               False    False    True     False    False    True     
        50227  x-cp50227                 False    False    False    False    False    True     
        51932  euc-jp                    True     True     True     True     False    True     
        51936  EUC-CN                    False    False    False    False    False    True     
        51949  euc-kr                    False    False    True     True     False    True     
        52936  hz-gb-2312                True     True     True     True     False    True     
        54936  GB18030                   True     True     True     True     False    True     
        57002  x-iscii-de                False    False    False    False    False    True     
        57003  x-iscii-be                False    False    False    False    False    True     
        57004  x-iscii-ta                False    False    False    False    False    True     
        57005  x-iscii-te                False    False    False    False    False    True     
        57006  x-iscii-as                False    False    False    False    False    True     
        57007  x-iscii-or                False    False    False    False    False    True     
        57008  x-iscii-ka                False    False    False    False    False    True     
        57009  x-iscii-ma                False    False    False    False    False    True     
        57010  x-iscii-gu                False    False    False    False    False    True     
        57011  x-iscii-pa                False    False    False    False    False    True     
        65000  utf-7                     False    False    True     True     False    True     
        65001  utf-8                     True     True     True     True     False    True     
        65005  utf-32                    False    False    False    False    False    True     
        65006  utf-32BE                  False    False    False    False    False    True     

        */
        #endregion

        /// <summary>
        /// 静态构造函数只有在静态方法将要使用的时候才进行调用（静态成员同理）
        /// </summary>
        static CsvFileHelper()
        {
            isSaveAsExcel = true;
            defaultEncoding = new System.Text.UTF8Encoding(false);
        }

        private static bool isSaveAsExcel ;
        private static Encoding defaultEncoding;
        private static char csvSeparator = ',';
        //private static Encoding utfBom = System.Text.Encoding.GetEncoding("GB2312");

        /// <summary>
        /// get or set Csv Separator (Default Values is ,)
        /// </summary>
        public static char DefaultCsvSeparator
        {
            get { return csvSeparator; }
            set { csvSeparator = value; }
        }

        /// <summary>
        /// get or set if save as Excel type (出现在首部的“是必须转义的，而出现在中间的不可以不用专门转义，而excel对所有双引号都进行转义，无论其出现位置)
        /// </summary>
        public static bool IsSaveAsExcel
        {
            get { return isSaveAsExcel; }
            set { isSaveAsExcel = value; }
        }

        /// <summary>
        /// get or set Default Encoding (notice : if your want the System not with bom ,you should use the relevant Encoding)
        /// </summary>
        public static Encoding DefaultEncoding
        {
            get { return defaultEncoding; }
            set { defaultEncoding = value; }
        }

        private static void WriteCsvVeiw(List<List<string>> yourListCsvData, TextWriter writer)
        {
            foreach(List<string> tempField in yourListCsvData)
            {
                WriteCsvLine(tempField, writer);
            }
        }

        private static void WriteCsvLine(List<string> fields, TextWriter writer)
        {
            StringBuilder myStrBld = new StringBuilder();
            //对于CSV数据来说不可能出现一行的数据元素的数量是0的情况，所以不用考虑fields.Count为0的情况(如果为0则为错误数据直接忽略)
            //foreach(string tempField in fields)  //使用foreach会产生许多不必要的string拷贝
            for (int i = 0; i < fields.Count; i++)
            {
                //通过文件转换出来的fields是不会为null的，为了兼容外部构建数据源，可能出现null的情况，这里强制转换为""
                if (fields[i] == null)
                {
                    myStrBld.Append("");
                }
                else
                {
                    bool quotesRequired = (isSaveAsExcel ? (fields[i].Contains(csvSeparator) || fields[i].Contains("\r\n") || fields[i].Contains("\"")) : (fields[i].Contains(csvSeparator) || fields[i].Contains("\r\n") || fields[i].StartsWith("\"")));
                    if (quotesRequired)
                    {
                        if (fields[i].Contains("\""))
                        {
                            myStrBld.Append(String.Format("\"{0}\"", fields[i].Replace("\"", "\"\"")));
                        }
                        else
                        {
                            myStrBld.Append(String.Format("\"{0}\"", fields[i]));
                        }
                    }
                    else
                    {
                        myStrBld.Append(fields[i]);
                    }
                }

                if (i < fields.Count - 1)
                {
                    myStrBld.Append(csvSeparator);
                }
            }
            writer.WriteLine(myStrBld.ToString());
        }

        public static void SaveCsvFile(string yourFilePath,List<List<string>> yourDataSouse,bool isAppend,Encoding yourEncode)
        {
            //FileStream myCsvStream = new FileStream(yourFilePath, FileMode.Create, FileAccess.ReadWrite);
            if (isAppend && !File.Exists(yourFilePath))
            {
                throw new Exception("in Append mode the FilePath must exist");
            }
            if(!isAppend && !File.Exists(yourFilePath))
            {
                if (yourFilePath.Contains('\\'))
                {
                    if (!Directory.Exists(yourFilePath.Remove(yourFilePath.LastIndexOf('\\'))))
                    {
                        throw new Exception("the FilePath or the Directory it not exist");
                    }
                    
                }
                else
                {
                    throw new Exception("find error in your FilePath");
                }
            }
            //StreamWriter myCsvSw = new StreamWriter(yourFilePath, isAppend, yourEncode);   //isAppend对应的Stream的FileMode 为 append  ? FileMode.Append : FileMode.Create
            //文件如果被其他任务打开并处于Write模式，此处会抛出异常（该工具也含多处异常抛出，使用时务必考虑接收这些异常）
            StreamWriter myCsvSw = new StreamWriter(new FileStream(yourFilePath, isAppend ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.ReadWrite), yourEncode);
            if (yourDataSouse == null)
            {
                throw new Exception("your DataSouse is null");
            }
            WriteCsvVeiw(yourDataSouse, myCsvSw);
            myCsvSw.Dispose();
        }

        public static void SaveCsvFile(string yourFilePath, List<List<string>> yourDataSouse)
        {
            SaveCsvFile(yourFilePath, yourDataSouse, false, defaultEncoding);
        }

        public static Stream OpenFile(string filePath)
        {
            Stream myStream;
            try
            {
                myStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            }
            catch (Exception)
            {
                return null;
            }
            return myStream;
        }

        #endregion
    }
}
