using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class ListNode<T>
    {
        public T value;
        public ListNode<T> next;

        public ListNode(T val)
        {
            value = val;
        }
    }
}
