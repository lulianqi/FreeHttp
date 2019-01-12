using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.HttpHelper
{
    [Serializable]
    public class MyKeyValuePair<TKey, TValue> :ICloneable
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

        public bool Equals(MyKeyValuePair<TKey, TValue> yourKvp)
        {
            if (yourKvp == null)
            {
                return false;
            }
            return (Key.Equals(yourKvp.key)&&Value.Equals(yourKvp.Value));
        }

        //public new bool Equals(object obj)     用new重写，强制转换的目标类型不会调用该重载，使用override 只要类型对象指针是目标类型，都会调用目标重载
        public override bool Equals(object obj)
        {
            if (typeof(MyKeyValuePair<TKey, TValue>)==obj.GetType())
            {
                return Equals((MyKeyValuePair<TKey, TValue>)obj);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            try
            {
                return key.GetHashCode() ^ value.GetHashCode();
            }
            catch
            {
                return base.GetHashCode();
            }
        }

        public object Clone()
        {
            return new MyKeyValuePair<TKey, TValue>(key, value);
        }
    }


}
