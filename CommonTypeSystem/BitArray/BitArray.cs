using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class BitArray:IEnumerable<int?>
    {
        private int?[] arr = null;
        private int count = 0;
        private int size = 64;
        private void Resize()
        {
            if(count==size)
            {
                size = size * 2;
            }
        }
        public BitArray(int Size)
        {
            this.size = Size;
            arr = new int?[size];
        }
        public void Add(int? number)
        {
            Resize();
            arr[count] = number;
            count++;
        }
        public void Remove()
        {
            arr[count - 1] = null;
            count--;
        }
        public int Length()
        {
            return count;
        }
        public int? this[int i]
        {
            get
            {
                if (i < 0 || i >= this.count)
                {
                    throw new ArgumentOutOfRangeException("Invalid index!");
                }
                else return arr[i];
            }
            set
            {
                if (i < 0 || i >= this.count)
                {
                    throw new ArgumentOutOfRangeException("Invalid index!");
                }
                arr[i] = value;
            }
        }

        public IEnumerator<int?> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
                yield return this[i];
        }

        IEnumerator<int?> IEnumerable<int?>.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override bool Equals(object obj)
        {
            if(!(obj is BitArray))
            {
                return false;
            }
            BitArray newArr = obj as BitArray;
            return Enumerable.SequenceEqual(this.arr, newArr.arr);
        }
        public override string ToString()
        {
            return String.Join(" ", this);
        }
        public override int GetHashCode()
        {
            return size ^ count;
        }
        public static bool operator==(BitArray brr,BitArray crr)
        {
            return BitArray.Equals(brr, crr);
        }
        public static bool operator!=(BitArray brr,BitArray crr)
        {
            return !BitArray.Equals(brr, crr);
        }
    }
}
