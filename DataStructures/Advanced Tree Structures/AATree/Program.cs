using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class AATree<TKey,TValue> where TKey:IComparable<TKey>
    {
        private class Node
        {
            internal int level;
            internal Node left;
            internal Node rigth;

            internal TKey key;
            internal TValue value;

            internal Node()
            {
                this.level = 0;
                this.left = this;
                this.rigth = this;
            }

            internal Node(TKey key,TValue value,Node Sentinel)
            {
                this.level = 1;
                this.left = Sentinel;
                this.rigth = Sentinel;
                this.key = key;
                this.value = value;
            }
        }

        private Node root;
        private Node sentinel;
        private Node deleted;

        public AATree()
        {
            this.root = this.sentinel = new Node();
            deleted = null;
        }

        //rotate rigth
        private void Skew(ref Node node)
        {
            if(node.level==node.left.level)
            {
                Node left = node.left;
                node.left = node.rigth;
                left.rigth = node;
                node = left;
            }
        }

        //rotate left
        private void Split(ref Node node)
        {
            if(node.rigth.rigth.level==node.level)
            {
                Node right = node.rigth;
                node.rigth = right.left;
                right.left = node;
                node = right;
                node.level++;
            }
        }

        private bool Insert(ref Node node,TKey key,TValue value)
        {
            if(node==sentinel)
            {
                node = new Node(key, value, sentinel);
                return true;
            }

            int compare = key.CompareTo(node.key);
            if(compare<0)
            {
                if(!Insert(ref node.left,key,value))
                {
                    return false;
                }
            }
            else if(compare>0)
            {
                if(!Insert(ref node.rigth,key,value))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            Skew(ref node);
            Split(ref node);

            return true;
        }

        private bool Delete(ref Node node,TKey key)
        {
            if(node==sentinel)
            {
                return deleted != null;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if (!Delete(ref node.left, key))
                {
                    return false;
                }
            }
            else
            {
                if(compare==0)
                {
                    deleted = node;
                }
                if(!Delete(ref node.rigth,key))
                {
                    return false;
                }
            }

            if(deleted!=null)
            {
                deleted.key = node.key;
                deleted.value = node.value;
                deleted = null;
                node = node.rigth;
            }
            else if(node.left.level<node.level-1||node.rigth.level<node.level-1)
            {
                --node.level;
                if(node.rigth.level>node.level)
                {
                    node.rigth.level = node.level;
                }

                Skew(ref node);
                Skew(ref node.rigth);
                Skew(ref node.rigth.rigth);
                Split(ref node);
                Split(ref node.rigth);
            }

            return true;
        }

        private Node Search(Node node, TKey key)
        {
            if (node == sentinel)
            {
                return null;
            }

            int compare = key.CompareTo(node.key);
            if (compare > 0)
            {
                return Search(node.rigth, key);
            }
            else if (compare < 0)
            {
                return Search(node.left, key);
            }
            else
            {
                return node;
            }
        }

        public bool Add(TKey key,TValue value)
        {
            return Insert(ref root, key, value);
        }

        public bool Remove(TKey key)
        {
            return Delete(ref root, key);
        }

        public TValue this[TKey key]
        {
            get
            {
                Node node = Search(root, key);
                return node == null ? default(TValue) : node.value;
            }
            set
            {
                Node node = Search(root, key);
                if(node==null)
                {
                    Add(key, value);
                }
                else
                {
                    node.value = value;
                }
            }
        }
    }
}
