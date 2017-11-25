using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    public class BinarySearchTree<T> : IEnumerable<T>, IEnumerable
    {
        #region private fields

        private Node<T> _tree;
        private Comparison<T> Comparer { get; }

        #endregion

        #region ctor

        public BinarySearchTree()
        {
            Comparer = (lhs, rhs) => GetComparer().Compare(lhs, rhs);
        }

        public BinarySearchTree(Comparison<T> comparer)
        {
            Comparer = comparer;
        }

        #endregion

        #region public

        public static IComparer<T> GetComparer()
        {
            var type = typeof(T);

            if (type == typeof(string))
                return StringComparer.CurrentCulture as IComparer<T>;

            if (!ReferenceEquals(type.GetInterface("IComparable`1"), null) ||
                !ReferenceEquals(type.GetInterface("IComparable"), null))
                return Comparer<T>.Default;

            throw new ArgumentException();
        }

        #region functions of the tree

        /// <summary>
        ///     Add element to the tree
        /// </summary>
        /// <param name="item"> the element which is added </param>
        public void Add(T item)
        {
            Add(ref _tree, item, Comparer);
            Count++;
        }

        /// <summary>
        ///     Find element into the tree
        /// </summary>
        /// <param name="item"> the element which we are looking for</param>
        /// <returns>found item</returns>
        public T Find(T item)
        {
            return Find(ref _tree, item, Comparer);
        }

        /// <summary>
        ///     Remove element from the tree
        /// </summary>
        /// <param name="item">the element that is removig</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            return Remove(item, Comparer);
        }

        public bool Remove(T item, Comparison<T> comparer)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer));

            var temp = _tree;
            var removed = Remove(ref _tree, ref temp, item, comparer);
            if (removed)
                Count--;

            return removed;
        }

        /// <summary>
        ///     Amount od the elements into the tree
        /// </summary>
        public int Count { get; private set; }

        #endregion


        #region IEnumerable

        /// <summary>
        ///     IEnumerable implementation
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return GetInorderEnumerator().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerable<T> GetPreorderEnumerator()
        {
            if (ReferenceEquals(_tree, null))
                yield break;

            foreach (var item in GetPrefixEnumerator(_tree))
                yield return item;
        }


        public IEnumerable<T> GetInorderEnumerator()
        {
            if (ReferenceEquals(_tree, null))
                yield break;

            foreach (var item in GetInfixEnumerator(_tree))
                yield return item;
        }


        public IEnumerable<T> GetPostorderEnumerator()
        {
            if (ReferenceEquals(_tree, null))
                yield break;

            foreach (var item in GetPostfixEnumerator(_tree))
                yield return item;
        }

        #endregion

        #endregion

        #region private

        /// <summary>
        ///     Add element to the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"> the tree where the element is added</param>
        /// <param name="item"> the element which is added</param>
        /// <param name="comparer">comparator</param>
        private static void Add(ref Node<T> tree, T item, Comparison<T> comparer)
        {
            if (ReferenceEquals(tree, null))
            {
                tree = new Node<T>(null, null, item);
                return;
            }

            var resultComparer = comparer(tree.Data, item);
            if (resultComparer == 0)
            {
                tree.Data = item;
                return;
            }

            if (resultComparer > 0)
            {
                Add(ref tree.Left, item, comparer);
                return;
            }

            Add(ref tree.Right, item, comparer);
        }

        /// <summary>
        ///     Find element into the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"> the tree, where we looking for an element </param>
        /// <param name="item"> the element which we looking for</param>
        /// <param name="comparer">comparator</param>
        private static T Find(ref Node<T> tree, T item, Comparison<T> comparer)
        {
            while (true)
            {
                if (ReferenceEquals(tree, null))
                    return default(T);

                var result = comparer(tree.Data, item);
                if (result == 0)
                    return tree.Data;

                if (result > 0)
                {
                    tree = tree.Left;
                    continue;
                }

                tree = tree.Right;
            }
        }

        /// <summary>
        ///     Remove element from the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"> child tree </param>
        /// <param name="treeGtreater"> parent tree </param>
        /// <param name="item">the element that is removing</param>
        /// <param name="comparer">comparator</param>
        /// <returns></returns>
        private static bool Remove(ref Node<T> tree, ref Node<T> treeGtreater, T item, Comparison<T> comparer)
        {
            if (ReferenceEquals(tree, null))
                return false;
            var result = comparer(item, tree.Data);
            if (result < 0)
            {
                treeGtreater = tree;
                return Remove(ref tree.Left, ref treeGtreater, item, comparer);
            }

            if (result > 0)
            {
                treeGtreater = tree;
                return Remove(ref tree.Right, ref treeGtreater, item, comparer);
            }

            if (ReferenceEquals(tree.Left, null) && ReferenceEquals(tree.Right, null))
            {
                tree = null;
                return true;
            }

            if (!ReferenceEquals(tree.Right, null) && ReferenceEquals(tree.Left, null))
            {
                tree = tree.Right;
                return true;
            }

            if (ReferenceEquals(tree.Right, null))
            {
                tree = tree.Left;
                return true;
            }

            if (ReferenceEquals(tree.Right.Left, null))
            {
                tree.Data = tree.Right.Data;
                tree.Right = tree.Right.Right;
                return true;
            }

            while (!ReferenceEquals(tree.Right.Left, null))
            {
                treeGtreater = tree.Right;
                tree.Right = tree.Right.Left;
            }

            Remove(ref tree, ref treeGtreater, tree.Right.Data, comparer);
            tree.Data = tree.Right.Data;
            return true;
        }

        #region TRAVERSE

        /// <summary>
        ///     PREFIX_TRAVERSE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <returns></returns>
        private static IEnumerable<T> GetPrefixEnumerator(Node<T> tree)
        {
            while (true)
            {
                yield return tree.Data;

                if (!ReferenceEquals(tree.Left, null))
                    foreach (var item in GetPrefixEnumerator(tree.Left))
                        yield return item;

                if (!ReferenceEquals(tree.Right, null))
                {
                    tree = tree.Right;
                    continue;
                }

                break;
            }
        }

        /// <summary>
        ///     INFIX_TRAVERSE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <returns></returns>
        private static IEnumerable<T> GetInfixEnumerator(Node<T> tree)
        {
            while (true)
            {
                if (!ReferenceEquals(tree.Left, null))
                    foreach (var item in GetInfixEnumerator(tree.Left))
                        yield return item;

                yield return tree.Data;

                if (!ReferenceEquals(tree.Right, null))
                {
                    tree = tree.Right;
                    continue;
                }

                break;
            }
        }

        /// <summary>
        ///     POSTFIX_TRAVERSE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        private static IEnumerable<T> GetPostfixEnumerator(Node<T> tree)
        {
            if (!ReferenceEquals(tree.Left, null))
                foreach (var item in GetPostfixEnumerator(tree.Left))
                    yield return item;

            if (!ReferenceEquals(tree.Right, null))
                foreach (var item in GetPostfixEnumerator(tree.Right))
                    yield return item;

            yield return tree.Data;
        }

        #endregion

        #endregion
    }

    /// <summary>
    ///     The tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Node<T>
    {
        #region ctor

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="left">the left subtree </param>
        /// <param name="right">the right subtree</param>
        /// <param name="data">tree top</param>
        public Node(Node<T> left, Node<T> right, T data)
        {
            Left = left;
            Right = right;
            Data = data;
        }

        #endregion

        #region fields

        /// <summary>
        ///     Left - is the left subtree, Right - is the right subtree, Data - tree top
        /// </summary>
        internal Node<T> Left;

        internal Node<T> Right;
        internal T Data { get; set; }

        #endregion
    }
}