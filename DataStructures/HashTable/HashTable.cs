using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableNamespace
{
    public class HashTable<Key, Value> : IEnumerable<KeyValue<Key, Value>>
    {
        private LinkedList<KeyValue<Key, Value>>[] slots;

        public int Count { get; set; }
        public int Capacity
        {
            get
            {
                return this.slots.Length;
            }
        }

        public const int InitialCapacity = 16;
        public const float LoadFactor = 0.75f;

        public HashTable()
        {
            this.slots = new LinkedList<KeyValue<Key, Value>>[InitialCapacity];
            this.Count = 0;
        }

        public HashTable(int capacity)
        {
            this.slots = new LinkedList<KeyValue<Key, Value>>[capacity];
            this.Count = 0;
        }

        private void Grow()
        {
            var newHashTable = new HashTable<Key,Value>(2 * Capacity);
            foreach(var element in this)
            {
                newHashTable.Add(element.Key, element.Value);
            }

            this.slots = newHashTable.slots;
            this.Count = newHashTable.Count;
        }

        private void GrowIfNeeded()
        {
            if((float)(this.Count+1)/this.Capacity>LoadFactor)
            {
                this.Grow();
            }
        }

        private int FindSlotNumber(Key key)
        {
            var slotNumber = Math.Abs(key.GetHashCode()) % this.slots.Length;
            return slotNumber;
        }

        private void Add(Key key, Value value)
        {
            GrowIfNeeded();
            int slotNumber = this.FindSlotNumber(key);

            if(this.slots[slotNumber]==null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<Key, Value>>();
            }

            foreach(var element in this.slots[slotNumber])
            {
                if(element.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists: " + key);
                }
            }

            var newElement = new KeyValue<Key, Value>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;
        }

        public bool AddOrReplace(Key key,Value value)
        {
            GrowIfNeeded();
            int slotNumber = this.FindSlotNumber(key);

            if(this.slots[slotNumber]==null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<Key, Value>>();
            }

            foreach(var element in this.slots[slotNumber])
            {
                if(element.Key.Equals(key))
                {
                    element.Value = value;
                    return false;
                }
            }

            var newElement = new KeyValue<Key, Value>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;
            return true;
        }

        public Value Get(Key key)
        {
            var element = this.Find(key);
            if(element==null)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }

        public Value this[Key key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(Key key,Value value)
        {
            var element = this.Find(key);
            if(element!=null)
            {
                value = element.Value;
                return true;
            }

            value = default(Value);
            return false;
        }

        private KeyValue<Key,Value> Find(Key key)
        {
            int slotNumber = this.FindSlotNumber(key);
            var elements = this.slots[slotNumber];

            if(elements!=null)
            {
                foreach(var element in elements)
                {
                    if(element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(Key key)
        {
            var element = this.Find(key);
            return element != null;
        }

        public bool Remove(Key key)
        {
            int slotnumber = this.FindSlotNumber(key);
            var element = this.slots[slotnumber];

            if(element!=null)
            {
                var currentElement = element.First;
                while(currentElement!=null)
                {
                    if (currentElement.Value.Key.Equals(key))
                    {
                        element.Remove(currentElement);
                        this.Count--;
                        return true;
                    }

                    currentElement = currentElement.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<Key, Value>>[InitialCapacity];
            this.Count = 0;
        }

        public IEnumerable<Key> Keys
        {
            get
            {
                return this.Select(n => n.Key);
            }
        }

        public IEnumerable<Value> Values
        {
            get
            {
                return this.Select(n => n.Value);
            }
        }

        public IEnumerator<KeyValue<Key, Value>> GetEnumerator()
        {
            foreach(var elements in this.slots)
            {
                if(elements!=null)
                {
                    foreach(var element in elements)
                    {
                        yield return element;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
