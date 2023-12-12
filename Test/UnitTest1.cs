using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void UnaryMinusTest () {
         Assert.AreEqual (-5, mEvaluator.Evaluate ("---5"));
         Assert.AreEqual (5, mEvaluator.Evaluate ("-5+10"));
         Assert.AreEqual (-6, mEvaluator.Evaluate ("-2-4"));
         Assert.AreEqual (6, mEvaluator.Evaluate ("---4+5--2+3"));
         Assert.AreEqual (-20, mEvaluator.Evaluate ("(2+3)*-4"));
         Assert.AreEqual (25, mEvaluator.Evaluate ("(2+3)*+5"));
         Assert.AreEqual (-32, mEvaluator.Evaluate ("-4*(3+5)"));
         Assert.AreEqual (9, mEvaluator.Evaluate ("-4+5--8"));
         Assert.AreEqual (9, mEvaluator.Evaluate ("-4+5-(-8)"));
         Assert.AreEqual (0.01, mEvaluator.Evaluate ("10^(-4+2)"));
         Assert.AreEqual (-110, mEvaluator.Evaluate ("-10-10^2"));
         Assert.AreEqual (5, mEvaluator.Evaluate ("---4+5--6-2"));
      }
      Evaluator mEvaluator = new ();
   }
}