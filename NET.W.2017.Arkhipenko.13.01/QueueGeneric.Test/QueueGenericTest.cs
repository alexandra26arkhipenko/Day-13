
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace QueueGeneric.Test
{
    [TestClass]
    public class QueueGenericTest
    {
        [TestMethod]
        public void QueueTest()
        {
            QueueGeneric.Queue<int> queue = new QueueGeneric.Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(queue.Count, 5);
            Assert.AreEqual(queue.Dequeue(), 1);
            Assert.AreEqual(queue.Peek(), 2);

            int[] array = {1, 2, 3, 4, 5};
            int i = 0;
            foreach (var element in queue)
            {
                i++;
                Assert.AreEqual(array[i], element);
               
            }
        }
    }
}
