// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to print the frequency of each charcter in the words.txt file in descending order.
// Also displays the most popular seeds for the spelling bee game.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Spelling Bee Frequency</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method calls the SpellBeeFreq method</summary>
      static void Main () => SpellBeeFreq ();

      /// <summary>This method reads all lines from the text file 
      /// and displays the frequency of each character in descending order 
      /// and the most popular seeds for the spell bee game</summary>
      static void SpellBeeFreq () {
         // Frequency of each character in the text file in descending order
         string words = String.Join ("", File.ReadAllLines ("C:/etc/words.txt"));
         var freqList = words.GroupBy (x => x)
                         .OrderByDescending (x => x.Count ())
                         .ToList ();
         foreach (var l in freqList) Console.WriteLine ($"{l.Key}  -  {l.Count ()} time(s)");

         // Most frequent seeds for spell bee game
         Console.WriteLine ($"\nSeed for spelling bee program: {String.Join (" ", freqList.Take (7).Select (x => x.Key))}");
      }
      #endregion
   }
   #endregion
}