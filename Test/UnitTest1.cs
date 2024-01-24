using Training;

namespace Test;

[TestClass]
public class UnitTest1 {
   [TestMethod]
   public void TestMethod1 () {
      ComplexNumber m1 = new (3, 4);
      Assert.AreEqual (5, m1.Norm);
   }
}