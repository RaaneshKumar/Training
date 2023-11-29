using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void DoubleParseValidTest () {
         Assert.AreEqual (double.Parse ("12"), DoubleParse.Parse ("12"));
         Assert.AreEqual (double.Parse ("12.5"), DoubleParse.Parse ("12.5"));
         Assert.AreEqual (double.Parse (".3"), DoubleParse.Parse (".3"));
         Assert.AreEqual (double.Parse ("-12.0"), DoubleParse.Parse ("-12.0"));
         Assert.AreEqual (double.Parse ("-.2"), DoubleParse.Parse ("-.2"));
         Assert.AreEqual (double.Parse ("1e13"), DoubleParse.Parse ("1e13"));
         Assert.AreEqual (double.Parse ("3.15e-3"), DoubleParse.Parse ("3.15e-3"));
         Assert.AreEqual (double.Parse ("3.4e+4"), DoubleParse.Parse ("3.4e+4"));
         Assert.AreEqual (double.Parse ("3.e2"), DoubleParse.Parse ("3.e2"));
      }

      [TestMethod]
      public void DoubleParseInValidTest () {
         Assert.IsFalse (DoubleParse.IsValid ("123a"));
         Assert.IsFalse (DoubleParse.IsValid ("456.a"));
         Assert.IsFalse (DoubleParse.IsValid ("-789.a"));
         Assert.IsFalse (DoubleParse.IsValid ("e123"));
         Assert.IsFalse (DoubleParse.IsValid ("456e"));
         Assert.IsFalse (DoubleParse.IsValid ("789.e"));
         Assert.IsFalse (DoubleParse.IsValid ("123+"));
         Assert.IsFalse (DoubleParse.IsValid ("456-"));
         Assert.IsFalse (DoubleParse.IsValid ("12.34.5"));
         Assert.IsFalse (DoubleParse.IsValid ("12e3e2"));
         Assert.IsFalse (DoubleParse.IsValid ("12+12"));
         Assert.IsFalse (DoubleParse.IsValid ("12-32"));
         Assert.IsFalse (DoubleParse.IsValid ("+1+2e+2"));
         Assert.IsFalse (DoubleParse.IsValid ("+e."));
         Assert.IsFalse (DoubleParse.IsValid ("+9e."));
         Assert.IsFalse (DoubleParse.IsValid ("+e.9"));
         Assert.IsFalse (DoubleParse.IsValid ("+9e+"));
      }
   }
}