using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void DequeTest () {
         mDeque.EnqueueFront (0);
         mDeque.EnqueueFront (1);
         mDeque.EnqueueRear (2);
         mDeque.EnqueueRear (3);
         Assert.AreEqual (3, mDeque.DequeueRear ());
         mDeque.EnqueueFront (4);
         Assert.AreEqual (4, mDeque.Count);
         Assert.AreEqual (4, mDeque.Capacity);
         mDeque.EnqueueFront (5);
         Assert.AreEqual (5, mDeque.Count);
         Assert.AreEqual (8, mDeque.Capacity);
         Assert.AreEqual (2, mDeque.DequeueRear ());
         Assert.AreEqual (5, mDeque.DequeueFront ());
         mDeque.EnqueueRear (6);
         Assert.AreEqual (4, mDeque.Count);
      }
      TDeque<int> mDeque = new ();
   }
}