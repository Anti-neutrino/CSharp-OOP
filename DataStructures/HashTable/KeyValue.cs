using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableNamespace
{
    public class KeyValue<TKey,TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public KeyValue(TKey key,TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            KeyValue<TKey, TValue> keyValue = obj as KeyValue<TKey, TValue>;

            return this.Key.Equals(keyValue.Key) && this.Value.Equals(keyValue.Value);
        }

        public override int GetHashCode()
        {
            return ((this.Key.GetHashCode() << 5) + this.Key.GetHashCode()) ^ this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[{0} -> {1}]", this.Key, this.Value);
        }
    }
}
