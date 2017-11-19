using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree;

namespace Tree.Test
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void AddItemInt()
        {
            var tree = new BinarySearchTree<int> {1, 5, 3, 7, 4};
            Assert.AreEqual(tree.Count, 5); 
        }

        [TestMethod]
        public void FindItemInt()
        {
            var tree = new BinarySearchTree<int> { 1, 5, 3, 7, 4 };
            Assert.AreEqual(tree.Find(5), 5);
        }

        [TestMethod]
        public void RemoveItemInt()
        {
            var tree = new BinarySearchTree<int> { 1, 5, 3, 7, 4 };
            Assert.AreEqual(tree.Count, 5);
            tree.Remove(4);
            Assert.AreEqual(tree.Count, 4);
        }

        [TestMethod]
        public void AddItemString()
        {
            var tree = new BinarySearchTree<string> { "a", "b", "c", "d" };
            Assert.AreEqual(tree.Count, 4);
        }

        [TestMethod]
        public void FindItemString()
        {
            var tree = new BinarySearchTree<string> { "a", "b", "c", "d" };
            Assert.AreEqual(tree.Find("b"), "b");
        }

        [TestMethod]
        public void RemoveItemString()
        {
            var tree = new BinarySearchTree<string> { "a", "b", "c", "d" };
            Assert.AreEqual(tree.Count, 4);
            tree.Remove("a");
            Assert.AreEqual(tree.Count, 3);
        }

        [TestMethod]
        public void AddItemBook()
        {
            var tree = new BinarySearchTree<Book> { new Book("qaz"), new Book("wsx"), new Book("edc")};
            Assert.AreEqual(tree.Count, 3);
        }

        [TestMethod]
        public void FindItemBook()
        {
            Book book = new Book("qaz");
            var tree = new BinarySearchTree<Book> { book, new Book("wsx"), new Book("edc") };
            Assert.AreEqual(tree.Find(book), book);
        }

        [TestMethod]
        public void RemoveItemBook()
        {
            Book book = new Book("qaz");
            var tree = new BinarySearchTree<Book> { book, new Book("wsx"), new Book("edc") };
            Assert.AreEqual(tree.Count, 3);
            tree.Remove(book);
            Assert.AreEqual(tree.Count, 2);
        }

        [TestMethod]
        public void AddItemPoint()
        {
            int Comparer(Point p1, Point p2)
            {
                if (p1.X > p2.X) return 1;
                if (p1.X == p2.X) return 0;
                return -1;
            }

            var tree = new BinarySearchTree<Point> (Comparer){ new Point(1,2), new Point(3, 4), new Point(5, 2) };
            Assert.AreEqual(tree.Count, 3);
        }

        [TestMethod]
        public void FindItemPoint()
        {
            int Comparer(Point p1, Point p2)
            {
                if (p1.X > p2.X) return 1;
                if (p1.X == p2.X) return 0;
                return -1;
            }
            Point point = new Point(1, 2);
            var tree = new BinarySearchTree<Point>(Comparer) {point , new Point(3, 4), new Point(5, 2) };
            Assert.AreEqual(tree.Find(point), point);
        }

        [TestMethod]
        public void RemoveItemPoint()
        {
            int Comparer(Point p1, Point p2)
            {
                if (p1.X > p2.X) return 1;
                if (p1.X == p2.X) return 0;
                return -1;
            }
            Point point = new Point(1, 2);
            var tree = new BinarySearchTree<Point>(Comparer) { point, new Point(3, 4), new Point(5, 2) };
            Assert.AreEqual(tree.Count, 3);
            tree.Remove(point);
            Assert.AreEqual(tree.Count, 2);
        }
    }
}
