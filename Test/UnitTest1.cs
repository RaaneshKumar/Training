using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestMethod1 () {
         MyPriorityQueue<int> p = new ();
         List<int> l = new ();
         var r = new Random ();
         for (int i = 0; i < 10; i++) {
            var a = r.Next (100);
            p.Enqueue (a);
            l.Add (a);
         }
         for (int i = 0; i < 5; i++) {
            l.Sort ();
            Assert.AreEqual (p.Dequeue (), l[0]);
            l.RemoveAt (0);
         }
         for (int i = 0; i < 10; i++) {
            var a = r.Next (100);
            p.Enqueue (a);
            l.Add (a);
         }
         for (int i = 0; i < 4; i++) {
            l.Sort ();
            Assert.AreEqual (p.Dequeue (), l[0]);
            l.RemoveAt (0);
         }
      }
   }
}