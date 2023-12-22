using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void UnaryMinusTest () {
         Dictionary<string, double> testCases = new () {
            ["---5"] = -5, ["-5+10"] = 5, ["-2-4"] = -6, ["---4+5--2+3"] = 6,
            ["(2+3)*-4"] = -20, ["(2+3)*+5"] = 25, ["-4*(3+5)"] = -32, ["-4+5--8"] = 9,
            ["-4+5-(-8)"] = 9, ["10^(-4+2)"] = .01, ["-10-10^2"] = -110,
            ["---4+5--6-2"] = 5, ["-sin 90"] = -1, ["sin -90"] = -1, ["sin --90"] = 1,
            ["(5-4)-1"] = 0, ["(sin -90)-1"] = -2
         };
         foreach (var item in testCases)
            Assert.AreEqual (mEvaluator.Evaluate (item.Key), item.Value);
      }
      Evaluator mEvaluator = new ();
   }
}