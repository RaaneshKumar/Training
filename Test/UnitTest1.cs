using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void EnqueueTest () {
         myQueue.Enqueue (1);
         myQueue.Enqueue (2);
         queue.Enqueue (1);
         queue.Enqueue (2);
         Assert.AreEqual (queue.Count, myQueue.Count);
      }

      [TestMethod]
      public void DequeueTest () {
         Assert.ThrowsException<InvalidOperationException> (() => myQueue.Dequeue ());
         myQueue.Enqueue (1);
         myQueue.Enqueue (2);
         queue.Enqueue (1);
         queue.Enqueue (2);
         Assert.AreEqual (queue.Dequeue (), myQueue.Dequeue ());
         Assert.AreEqual (queue.Count, myQueue.Count);
      }

      [TestMethod]
      public void PeekTest () {
         Assert.ThrowsException<InvalidOperationException> (() => myQueue.Peek ());
         myQueue.Enqueue (1);
         myQueue.Enqueue (2);
         queue.Enqueue (1);
         queue.Enqueue (2);
         Assert.AreEqual (queue.Peek (), myQueue.Peek ());
      }

      TQueue<int> myQueue = new ();
      Queue<int> queue = new ();
   }
}