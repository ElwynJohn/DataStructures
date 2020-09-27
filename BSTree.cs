using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithmsSpecialization.DataStructures
{
    public partial class BSTree<T> where T : IComparable<T>
    {
        public int Size { get; private set; }

        private BSTreeNode<T> root;



        //Time Complexity: O(tree height)
        public BSTreeNode<T> Find(T key)
        {
            BSTreeNode<T> currentNode = root;
            BSTreeNode<T> prevNode = root;
            while (currentNode != null)
            {
                if (currentNode.Keys.First.Value.CompareTo(key) == -1)
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Right; 
                }
                else if (currentNode.Keys.First.Value.CompareTo(key) == 1)
                {
                    prevNode = currentNode;
                    currentNode = currentNode.Left; 
                }
                else if (currentNode.Keys.First.Value.CompareTo(key) == 0)
                { return currentNode; }
            }
            return prevNode;
        }

        //Time Complexity: O(tree height)
        public virtual BSTreeNode<T> Insert(T key)
        {
            if (root == null)
            {
                root = new BSTreeNode<T>(new LinkedList<T>(), null);
                root.Keys.AddFirst(key);
                Size++;
                return root;
            }
            
            BSTreeNode<T> node = Find(key);
            if (node.Keys.First.Value.CompareTo(key) == 0)
            {
                node.Keys.AddFirst(key);
                return node;
            }

            BSTreeNode<T> nodeToInsert = new BSTreeNode<T>(new LinkedList<T>(), node);
            nodeToInsert.Keys.AddFirst(key);
            if (node.Keys.First.Value.CompareTo(key) == -1)
            {
                node.Right = nodeToInsert;
            }
            else
            {
                node.Left = nodeToInsert;
            }
            Size++;
            return nodeToInsert;
        }

        //Time Complexity: O(Size)
        public T[] InOrderTraversal()
        {
            int arrayIndex = 0;
            return InOrderTraversal(root, new T[Size], ref arrayIndex);
        }
        public T[] InOrderTraversal(BSTreeNode<T> node, T[] orderedKeys, ref int arrayIndex)
        {
            if (node == null)
            { return orderedKeys; }

            InOrderTraversal(node.Left, orderedKeys, ref arrayIndex);
            orderedKeys[arrayIndex] = node.Keys.First.Value;
            arrayIndex++;

            InOrderTraversal(node.Right, orderedKeys, ref arrayIndex);
            return orderedKeys;
        }

        //Time Complexity: O(Size)
        public T[] PreOrderTraversal()
        {
            int arrayIndex = 0;
            return PreOrderTraversal(root, new T[Size], ref arrayIndex);
        }
        public T[] PreOrderTraversal(BSTreeNode<T> node, T[] orderedKeys, ref int arrayIndex)
        {
            if (node == null)
            { return orderedKeys; }

            orderedKeys[arrayIndex] = node.Keys.First.Value;
            arrayIndex++;

            PreOrderTraversal(node.Left, orderedKeys, ref arrayIndex);
            PreOrderTraversal(node.Right, orderedKeys, ref arrayIndex);
            return orderedKeys;
        }
    }

    public sealed class BSTreeNode<T> where T : IComparable<T>
    {
        public BSTreeNode(LinkedList<T> keys, BSTreeNode<T> parent)
        {
            Keys = keys;
            Parent = parent;
        }
        public LinkedList<T> Keys { get; }
        public BSTreeNode<T> Parent { get; internal set; }
        public BSTreeNode<T> Left { get; internal set; }
        public BSTreeNode<T> Right { get; internal set; }
    }
}
