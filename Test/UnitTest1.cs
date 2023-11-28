using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void EnqueueTest () {
         mMyQueue.Enqueue (1);
         mMyQueue.Enqueue (2);
         mQueue.Enqueue (1);
         mQueue.Enqueue (2);
         Assert.AreEqual (mQueue.Count, mMyQueue.Count);
      }

      [TestMethod]
      public void DequeueTest () {
         Assert.ThrowsException<InvalidOperationException> (() => mMyQueue.Dequeue ());
         mMyQueue.Enqueue (1);
         mMyQueue.Enqueue (2);
         mQueue.Enqueue (1);
         mQueue.Enqueue (2);
         Assert.AreEqual (mQueue.Dequeue (), mMyQueue.Dequeue ());
         Assert.AreEqual (mQueue.Count, mMyQueue.Count);
      }

      [TestMethod]
      public void PeekTest () {
         Assert.ThrowsException<InvalidOperationException> (() => mMyQueue.Peek ());
         mMyQueue.Enqueue (1);
         mMyQueue.Enqueue (2);
         mQueue.Enqueue (1);
         mQueue.Enqueue (2);
         Assert.AreEqual (mQueue.Peek (), mMyQueue.Peek ());
         Assert.AreEqual (mQueue.Count, mMyQueue.Count);
      }

      TQueue<int> mMyQueue = new ();
      Queue<int> mQueue = new ();
   }
}