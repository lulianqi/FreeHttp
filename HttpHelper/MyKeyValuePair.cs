using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    public class MyKeyValuePair<TKey, TValue>
    {
        private TKey key;
        private TValue value;

        public TKey Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        public TValue Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public MyKeyValuePair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public MyKeyValuePair()
        {
            this.key = default(TKey);
            this.value = default(TValue);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            if (this.Key != null)
            {
                sb.Append(this.Key.ToString());
            }
            sb.Append(", ");
            if (this.Value != null)
            {
                sb.Append(this.Value.ToString());
            }
            sb.Append(']');
            return sb.ToString();
        }
    }


}
