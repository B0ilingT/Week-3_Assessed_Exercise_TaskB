using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees_Task_A
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public AVLTree()
        {
            root = null;
        }
        public void InsertItem(T item, ref Node<T> tree)
        {
            insertItem(item, ref tree);
        }
        private new void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);

            tree.BalanceFactor = height(tree.Left) - height(tree.Right);
            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);
        }
        public new void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }
        private new void removeItem(T item, ref Node<T> tree)
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

            tree.BalanceFactor = height(tree.Left) - height(tree.Right);
            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);
        }
        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right.BalanceFactor > 0)  //double rotate
                rotateRight(ref tree.Right);
            else
            {
                Node<T> oldRoot = tree;
                Node<T> newRoot = tree.Right;

                oldRoot.Right = newRoot.Left;
                newRoot.Left = oldRoot;
            }

        }

        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left.BalanceFactor < 0)  //double rotate
                rotateLeft(ref tree.Left);
            else
            {
                Node<T> oldRoot = tree;
                Node<T> newRoot = tree.Left;

                oldRoot.Left = newRoot.Right;
                newRoot.Right = oldRoot;
            }

        }


    }
}
