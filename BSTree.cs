using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees_Task_A
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }
        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }
        protected void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
        }
        public void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }
        

        protected void removeItem(T item, ref Node<T> tree)
        {
            if (tree == null)

                if (item.CompareTo(tree.Data) < 0)
                    removeItem(item, ref tree.Left);

            if (item.CompareTo(tree.Data) > 0)
                removeItem(item, ref tree.Right);

            if (tree.Left == null)
                tree = tree.Right;

            if (tree.Right == null)
                tree = tree.Left;
        }
        protected int count(Node<T> tree) //Return the number of nodes contained in the tree
        {
            if (tree == null)
                return 0;
            else
            {
                return count(tree.Left) + count(tree.Right) + 1;
            }
        }

        protected string counting(Node<T> tree) //Return the number of nodes contained in the tree
        {
            if (tree == null)
                return "string is empty";
            else
            {
                return "" + count(tree.Left) + count(tree.Right) + 1;
            }
        }

        public int Count()
        {
            return count(root);
        }

        protected int height(Node<T> tree) //Return the length in nodes of the longest path in the tree
        {
            if (tree == null)
                return 0;

            else
                return Math.Max(height(tree.Right), height(tree.Left)) + 1;
        }
        public int Height()
        {
           return height(root);
        }

        protected Boolean contains(T item, Node<T> tree) //Return true if the item is contained in the BSTree
        {
            if (tree == null)
                return false;

            else if (item.CompareTo(tree.Data) == 0)
                return true;

            else if (contains(item, tree.Left) == false)
                return contains(item, tree.Right);

            else
                return contains(item, tree.Left);
        }

        public Boolean Contains(T item)
        {
           return contains(item, root);
        }
       
        
    }
}
