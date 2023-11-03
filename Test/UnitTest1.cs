using Training;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PushTest () {
            TStack<int> stack = new ();
            stack.Push (1);
            Assert.AreEqual (1, stack.Count);
        }

        [TestMethod]
        public void PopTest () {
            TStack<int> stack = new ();
            stack.Push (1);
            stack.Push (2);
            Assert.AreEqual (2, stack.Pop());
            Assert.AreEqual (1, stack.Count);
        }

        [TestMethod]
        public void PeekTest () {
            TStack<int> stack = new ();
            stack.Push (1);
            stack.Push (2);
            Assert.AreEqual (2, stack.Peek());
        }

        [TestMethod]
        public void IsEmptyTest () {
            TStack<int> stack = new ();
            stack.Push (1);
            Assert.IsFalse (stack.IsEmpty);
        }
    }
}