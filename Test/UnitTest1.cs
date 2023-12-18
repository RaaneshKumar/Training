using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void ValidPathTest () {
         Assert.IsTrue (mFileParser.IsValidPath ("C:/TRAINING/TRAINING.SLN"));
         Assert.IsTrue (mFileParser.IsValidPath ("C:/WORKGIT/TRAINING/TRAINING.SLN"));
         Assert.IsTrue (mFileParser.IsValidPath (@"C:/TRAINING\TRAINING.SLN"));
         Assert.IsTrue (mFileParser.IsValidPath (@"C:\TRAINING\TRAINING.SLN"));
         Assert.IsFalse (mFileParser.IsValidPath ("C:/TRAINING.SLN"));
         Assert.IsFalse (mFileParser.IsValidPath ("C:/TRAINING/TRAINING.TRAINING.SLN"));
         Assert.IsFalse (mFileParser.IsValidPath ("C:TRAINING/TRAINING.SLN"));
      }

      [TestMethod]
      public void FileParserTest () {
         Assert.AreEqual ("WORKGIT/TRAINING",
                           mFileParser.GetFilePathData ("C:/WORKGIT/TRAINING/TRAINING.SLN").folder);
         Assert.AreEqual ("C", mFileParser.GetFilePathData ("C:/TRAINING/TRAINING.SLN").drive);
         Assert.AreEqual ("TRAINING", mFileParser.GetFilePathData ("C:/TRAINING/TRAINING.SLN").folder);
         Assert.AreEqual ("TRAINING.SLN", mFileParser.GetFilePathData ("C:/TRAINING/TRAINING.SLN").file);
      }
      FileParser mFileParser = new ();
   }
}