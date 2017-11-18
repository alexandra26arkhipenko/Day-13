using System;
using System.Collections;


namespace QueueGeneric
{
    /// <summary>
    /// It is the generic class, that implements main methods of System Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> :  IEnumerable, IEnumerator
    {
        #region private fields

        private readonly Queue queue = new Queue();
        private int index = -1;

        #endregion

        #region Queue methods

        /// <summary>
        /// Count returns length of queue
        /// </summary>
        public int Count => queue.Count;

        /// <summary>
        /// Indexer returns indexinf element   
        /// </summary>
        /// <param name="index1"></param>
        /// <returns></returns>
        public T this[int index1] => (T)queue.ToArray()[index];

        /// <summary>
        /// Method Enqueue adds an element to the end of the Queue.
        /// </summary>
        /// <param name="item"> element that is added to queue</param>
        public void Enqueue(T item) => queue.Enqueue(item);

        /// <summary>
        /// Dequeue removes the oldest element from the start of the Queue.
        /// </summary>
        /// <returns> element that is removed from queue</returns>
        public T Dequeue() => (T) queue.Dequeue();

        /// <summary>
        /// Peek returns the oldest element that is at the start of the Queue 
        /// but does not remove it from the Queue.
        /// </summary>
        /// <returns> the element that is reurned from queue without removing</returns>
        public T Peek() => (T) queue.Peek();

       

       
        #endregion

        #region iterator
       
        IEnumerator IEnumerable.GetEnumerator() => queue.GetEnumerator();   
        public bool MoveNext()
        {
            index++;
            return index < queue.Count;

        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return queue.ToArray()[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        #endregion
    }
}
