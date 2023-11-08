using Training;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        MyList<int> myList = new ();

        [TestMethod]
        public void AddTest () {
            myList.Add (1);
            myList.Add (2);
            List<int> list = new () { 1, 2 };
            Assert.AreEqual (list.Count, myList.Count);
            Assert.AreEqual (list.Capacity, myList.Capacity);
        }

        [TestMethod]
        public void RemoveTest () {
            myList.Add (1);
            myList.Add (2);
            List<int> list = new () { 1, 2 };
            myList.Remove (1);
            list.Remove (1);
            Assert.ThrowsException<InvalidOperationException> ( () => myList.Remove(5));
            Assert.AreEqual (list.Count, myList.Count);
        }

        [TestMethod]
        public void ClearTest () {
            myList.Add (1);
            myList.Add (2);
            List<int> list = new () { 1, 2 };
            myList.Clear ();
            list.Clear ();
            Assert.AreEqual (list.Count, myList.Count);
        }

        [TestMethod]
        public void InsertTest () {
            myList.Add (1);
            myList.Add (2);
            List<int> list = new () { 1, 2 };
            myList.Insert (1, 5);
            list.Insert (1, 5);
            Assert.AreEqual (list[1], myList[1]);
            Assert.ThrowsException<IndexOutOfRangeException> ( () => myList.Insert(3, 7));
        }

        [TestMethod]
        public void RemoveAtTest () {
            myList.Add (1);
            myList.Add (2);
            List<int> list = new () { 1, 2 };
            myList.RemoveAt (0);
            list.RemoveAt (0);
            Assert.AreEqual (list.Count,myList.Count);
            Assert.ThrowsException<IndexOutOfRangeException> ( () => myList.RemoveAt(3));
        }

        [TestMethod]
        public void ThisIndexTest () {
            myList.Add (1);
            myList.Add (2);
            List<int> list = new () { 1, 2 };
            Assert.AreEqual (myList[0], list[0]);
            Assert.ThrowsException<IndexOutOfRangeException> ( () => myList[3]);
            myList[1] = 3;
            Assert.AreEqual (3, myList[1]);
        }
    }
}