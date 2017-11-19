namespace Tree
{
    /// <summary>
    /// The tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T>
    {
        #region fields
        /// <summary>
        /// Left - is the left subtree, Right - is the right subtree, Data - tree top
        /// </summary>
        internal Tree<T> Left;
        internal Tree<T> Right;
        internal T Data { get; set; }
        #endregion

        #region ctor
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="left">the left subtree </param>
        /// <param name="right">the right subtree</param>
        /// <param name="data">tree top</param>
        public Tree(Tree<T> left, Tree<T> right, T data)
        {
            Left = left;
            Right = right;
            Data = data;
        }
#endregion
    }
}
