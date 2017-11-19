using System;
using System.Collections;
using System.Collections.Generic;
using static Tree.BinarySearchTreeHelper;

namespace Tree
{
    public class BinarySearchTree<T> :  IEnumerable<T>, IEnumerable
    {
        #region private fields
        private Tree<T> _tree;
        private int _count;
        private Comparison<T> Comparer { get;}
        #endregion

        #region ctor
        public BinarySearchTree()
        {
            Comparer = (lhs, rhs) => GetComparer<T>().Compare(lhs, rhs);
        }
        #endregion
        
        #region public

        #region functions of the tree
        /// <summary>
        /// Add element to the tree
        /// </summary>
        /// <param name="item"> the element which is added </param>
        public void Add(T item)
        {
            BinarySearchTreeHelper.Add(ref _tree, item, Comparer);
            _count++;
        }

        /// <summary>
        /// Find element into the tree
        /// </summary>
        /// <param name="item"> the element which we are looking for</param>
        /// <returns>found item</returns>
        public T Find(T item) => BinarySearchTreeHelper.Find(ref _tree, item, Comparer);

        /// <summary>
        /// Remove element from the tree
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
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            var temp = _tree;
            var removed = BinarySearchTreeHelper.Remove(ref _tree, ref temp, item, comparer);
            if (removed)
            {
                _count--;
            }

            return removed;
        }

        /// <summary>
        /// Amount od the elements into the tree
        /// </summary>
        public int Count => _count;

        #endregion

        #region IEnumerable
        /// <summary>
        /// IEnumerable implementation
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => GetInorderEnumerator().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public IEnumerable<T> GetPreorderEnumerator()
        {
            if (ReferenceEquals(_tree, null))
            {
                yield break;
            }

            foreach (var item in GetPrefixEnumerator(_tree))
            {
                yield return item;
            }
        }

       
        public IEnumerable<T> GetInorderEnumerator()
        {
            if (ReferenceEquals(_tree, null))
            {
                yield break;
            }

            foreach (var item in GetInfixEnumerator(_tree))
            {
                yield return item;
            }
        }

      
        public IEnumerable<T> GetPostorderEnumerator()
        {
            if (ReferenceEquals(_tree, null))
            {
                yield break;
            }

            foreach (var item in GetPostfixEnumerator(_tree))
            {
                yield return item;
            }
        }
        #endregion
#endregion
    }
}