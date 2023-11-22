using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void EnqueueTest () {
         mQueue.Enqueue (1);
         mQueue.Enqueue (2);
         Assert.AreEqual (2, mQueue.Count);
      }

      [TestMethod]
      public void DequeueTest () {
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.Dequeue ());
         mQueue.Enqueue (1);
         mQueue.Enqueue (2);
         Assert.AreEqual (1, mQueue.Dequeue ());
         Assert.AreEqual (1, mQueue.Count);
      }

      [TestMethod]
      public void PeekTest () {
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.Peek ());
         mQueue.Enqueue (1);
         mQueue.Enqueue (2);
         Assert.AreEqual (1, mQueue.Peek ());
      }

      TQueue<int> mQueue = new ();
   }
}