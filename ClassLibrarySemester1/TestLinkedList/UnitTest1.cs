using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROCvanTwente.Sumpel.Semester1;
using System;

namespace TestLinkedList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOneNode()
        {
            ListNode first = new ListNode(5);

            Assert.IsNotNull(first);
            Assert.AreEqual(5, first.getData());
            Assert.AreEqual(1, first.getSize());
            Assert.IsNull(first.getNext());
        }

        [TestMethod]
        public void TestTwoNodes()
        {
            ListNode last = new ListNode(1);
            ListNode first = new ListNode(7, last);

            Assert.IsNotNull(first);
            Assert.IsNotNull(last);
            Assert.AreEqual(7, first.getData());
            Assert.AreEqual(1, last.getData());

            Assert.IsNotNull(first.getNext());
            Assert.AreSame(last, first.getNext());
            Assert.AreEqual(1, first.getNext().getData());

            Assert.IsNull(last.getNext());
            Assert.IsNull(first.getNext().getNext());
            Assert.AreEqual(2, first.getSize());
            Assert.AreEqual(1, last.getSize());

            Assert.AreEqual("7, 1", first.ToString());
        }

        [TestMethod]
        public void TestCreateList()
        {
            LinkedList list = new LinkedList(7, 1, 3, 2, 5);

            Assert.IsNotNull(list.getFirst());
            Assert.AreEqual(5, list.getSize());
            Assert.AreEqual("[ 7, 1, 3, 2, 5 ]", list.ToString());

        }
    }
}
