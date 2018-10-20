using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public class ContentModific
    {
        public bool IsEntireReplace { get; set; }
        public string TargetKey { get; set; }
        public string ReplaceContent { get; set; }

        public ContentModific(string targetKey,string replaceContent)
        {
            if (string.IsNullOrEmpty(targetKey))
            {
                IsEntireReplace = true;
                TargetKey = "";
            }
            else
            {
                TargetKey = targetKey;
            }
            ReplaceContent = replaceContent;
        }
    }
}
