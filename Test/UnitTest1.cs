using Training;

namespace MSTestProject {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void AddTest () {
         myList.Add (1);
         myList.Add (2);
         list.Add (1);
         list.Add (2);
         Assert.AreEqual (list.Count, myList.Count);
         Assert.AreEqual (list.Capacity, myList.Capacity);
         myList.Clear ();
         list.Clear ();
      }

      [TestMethod]
      public void RemoveTest () {
         myList.Add (1);
         myList.Add (2);
         list.Add (1);
         list.Add (2);
         myList.Remove (1);
         list.Remove (1);
         Assert.AreEqual (list.Count, myList.Count);
         myList.Clear ();
         list.Clear ();
      }

      [TestMethod]
      public void ClearTest () {
         myList.Add (1);
         myList.Add (2);
         myList.Clear ();
         list.Clear ();
         Assert.AreEqual (list.Count, myList.Count);
      }

      [TestMethod]
      public void InsertTest () {
         myList.Add (1);
         myList.Add (2);
         myList.Insert (1, 5);
         list.Add (1);
         list.Add (2);
         list.Insert (1, 5);
         Assert.AreEqual (list[1], myList[1]);
         Assert.ThrowsException<ArgumentOutOfRangeException> (() => myList.Insert (5, 7));
         myList.Clear ();
         list.Clear ();
      }

      [TestMethod]
      public void RemoveAtTest () {
         myList.Add (1);
         myList.Add (2);
         myList.RemoveAt (0);
         list.Add (1);
         list.Add (2);
         list.RemoveAt (0);
         Assert.AreEqual (list.Count, myList.Count);
         Assert.ThrowsException<ArgumentOutOfRangeException> (() => myList.RemoveAt (3));
         myList.Clear ();
         list.Clear ();
      }

      [TestMethod]
      public void ThisIndexTest () {
         myList.Add (1);
         myList.Add (2);
         list.Add (1);
         list.Add (2);
         Assert.AreEqual (myList[0], list[0]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => myList[3]);
         myList[1] = 3;
         Assert.AreEqual (3, myList[1]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => myList[2]);
         myList.Clear ();
         list.Clear ();
      }

      MyList<int> myList = new ();
      List<int> list = new ();
   }
}