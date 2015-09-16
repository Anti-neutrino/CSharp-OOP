using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedList
{
    class RiversedList<T> : IEnumerable<T>
    {
        private List<T> list;
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private void Resize()
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity = this.Capacity * 2;
            }
        }

        public RiversedList(List<T> newList)
        {
            this.list = newList;
            int index = this.list.Count - 1;
            for (int i = 0; i < this.list.Count / 2; i++)
            {
                T element = list[i];
                list[i] = list[index - i];
                list[index - i] = element;
            }

            this.Capacity = this.list.Capacity;
            this.Count = this.list.Count;
        }

        public void Add(T newElement)
        {
            List<T> newList = new List<T>();
            newList.Add(newElement);
            for (int i = 0; i < this.Count; i++)
            {
                newList.Add(list[i]);
            }
            this.list = newList;
            Resize();
            this.Count++;
        }

        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Remove(int index)
        {
            if ((index >= 0) && (index < this.Count))
            {
                List<T> newList = new List<T>();
                for (int i = 0; i < this.Count; i++)
                {
                    if (i != index)
                    {
                        newList.Add(list[i]);
                    }
                }
                list = newList;
                this.Count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return list[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
