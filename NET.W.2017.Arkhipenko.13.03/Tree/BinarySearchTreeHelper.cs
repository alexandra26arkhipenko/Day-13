using System;
using System.Collections.Generic;

namespace Tree
{
    public class BinarySearchTreeHelper
    {
        #region public

        public static IComparer<T> GetComparer<T>()
        {
            var type = typeof(T);

            if (type == typeof(string))
            {
                return StringComparer.CurrentCulture as IComparer<T>;
            }

            if (!ReferenceEquals(type.GetInterface("IComparable`1"), null) ||
                !ReferenceEquals(type.GetInterface("IComparable"), null))
            {
                return Comparer<T>.Default;
            }

            throw new ArgumentException();
        }

        #region functions of the tree
        /// <summary>
        /// Add element to the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"> the tree where the element is added</param>
        /// <param name="item"> the element which is added</param>
        /// <param name="comparer">comparator</param>
        public static void Add<T>(ref Tree<T> tree, T item, Comparison<T> comparer)
        {
            if (ReferenceEquals(tree, null))
            {
                tree = new Tree<T>(null, null, item);
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
        /// Find element into the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"> the tree, where we looking for an element </param>
        /// <param name="item"> the element which we looking for</param>
        /// <param name="comparer">comparator</param>
        public static T Find<T>(ref Tree<T> tree, T item, Comparison<T> comparer)
        {
            while (true)
            {
                if (ReferenceEquals(tree, null))
                {
                    return default(T);
                }

                var result = comparer(tree.Data, item);
                if (result == 0)
                {
                    return tree.Data;
                }

                if (result > 0)
                {
                    tree = tree.Left;
                    continue;
                }

                tree = tree.Right;
            }
        }


       

        /// <summary>
        /// Remove element from the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"> child tree </param>
        /// <param name="treeGtreater"> parent tree </param>
        /// <param name="item">the element that is removing</param>
        /// <param name="comparer">comparator</param>
        /// <returns></returns>
        public static bool Remove<T>(ref Tree<T> tree, ref Tree<T> treeGtreater, T item, Comparison<T> comparer)
        {
            if (ReferenceEquals(tree, null))
            {
                return false;
            }
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
        #endregion

        #region TRAVERSE
        /// <summary>
        /// PREFIX_TRAVERSE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetPrefixEnumerator<T>(Tree<T> tree)
        {
            while (true)
            {
                yield return tree.Data;

                if (!ReferenceEquals(tree.Left, null))
                {
                    foreach (var item in GetPrefixEnumerator(tree.Left))
                    {
                        yield return item;
                    }
                }

                if (!ReferenceEquals(tree.Right, null))
                {
                    tree = tree.Right;
                    continue;
                }

                break;
            }
        }

        /// <summary>
        /// INFIX_TRAVERSE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetInfixEnumerator<T>(Tree<T> tree)
        {
            while (true)
            {
                if (!ReferenceEquals(tree.Left, null))
                {
                    foreach (var item in GetInfixEnumerator(tree.Left))
                    {
                        yield return item;
                    }
                }

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
        /// POSTFIX_TRAVERSE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetPostfixEnumerator<T>(Tree<T> root)
        {
            if (!ReferenceEquals(root.Left, null))
            {
                foreach (var item in GetPostfixEnumerator(root.Left))
                {
                    yield return item;
                }
            }

            if (!ReferenceEquals(root.Right, null))
            {
                foreach (var item in GetPostfixEnumerator(root.Right))
                {
                    yield return item;
                }
            }

            yield return root.Data;
        }
#endregion
        #endregion
    }
}