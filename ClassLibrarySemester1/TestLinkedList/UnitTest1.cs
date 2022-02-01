using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROCvanTwente.Sumpel.Semester1;
using System;

namespace TestLinkedList
{
    [TestClass]
    public class UnitTestForListNodeInts
    {
        [TestMethod]
        public void TestOneNode()
        {
            ListNodeInt first = new ListNodeInt(5);

            Assert.IsNotNull(first);
            Assert.AreEqual(5, first.getData());
            Assert.AreEqual(1, first.getSize());
            Assert.IsNull(first.getNext());
        }

        [TestMethod]
        public void TestTwoNodes()
        {
            ListNodeInt last = new ListNodeInt(1);
            ListNodeInt first = new ListNodeInt(7, last);

            // Check that the creation went as expected. (Ultra-paranoid mode.)
            Assert.IsNotNull(first);
            Assert.IsNotNull(last);
            Assert.AreEqual(7, first.getData());
            Assert.AreEqual(1, last.getData());

            // The first node SHOULD have a next (node)
            Assert.IsNotNull(first.getNext());
            // That node SHOULD be the last node.
            Assert.AreSame(last, first.getNext());
            // Check that the data is also the correct value.
            Assert.AreEqual(1, first.getNext().getData());

            // Check that the last node has no next node.
            Assert.IsNull(last.getNext());
            // Check that the first nodes next node has no next node...
            Assert.IsNull(first.getNext().getNext());
            // Check that the first node counts correctly...
            Assert.AreEqual(2, first.getSize());
            // Last node as well...
            Assert.AreEqual(1, last.getSize());

            // Check the to String for both nodes...
            Assert.AreEqual("7, 1", first.ToString());
        }

        [TestMethod]
        public void TestCreateList()
        {
            LinkedListInt list = new LinkedListInt(7, 1, 3, 2, 5);

            Assert.IsNotNull(list.getFirst());
            Assert.AreEqual(5, list.getSize());
            Assert.AreEqual("[ 7, 1, 3, 2, 5 ]", list.ToString());

        }

        [TestMethod]
        public void TestOrderedList()
        {
            OrderedListObj list = new OrderedListObj(
                "Alpha", "Gamma", "Beta"
                );
//            Console.WriteLine(list.ToString());

            Assert.AreEqual(3, list.getSize());
            Assert.AreEqual("Alpha", list.getFirst().getData());
            Assert.AreEqual("Beta", list.getFirst().getNext().getData());
            Assert.AreEqual("Gamma", list.getFirst().getNext().getNext().getData());
            Assert.IsNull(list.getFirst().getNext().getNext().getNext());
        }
    }
}
