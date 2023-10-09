// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to help solve a New-York Times style Spelling Bee.
// A word list is given as a text file, and that the daily choice of 7 letters is provided as an array of 7 chars:
// char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' }
// Valid word conditions - Each word is at least 4 letters long, Each word uses only the 7 seed letters,
// Each word MUST use the first letter (in this case U),Any letter can be used more than once.
// Score conditions - 4 letter words score 1 point, Longer words score their no. of letters as points,
// Any word that uses all 7 seed letters (called pangrams) gets an additional 7 bonus points.
// Output is a list of words sorted in descending order of score.
// If two words have the same score, they are displayed in alphabetical order of the words.
// Pangrams are displayed in green color
// ---------------------------------------------------------------------------------------
using static System.Console;

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Spelling Bee</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method reads the text file, displays valid words in the arrangement of (score. word) 
      /// and displays pangrams in green color</summary>
      static void Main () {
         string[] words = File.ReadAllLines ("C:words.txt.crdownload");
         int nPangram = 0;

         var list = words.Where (IsValid).Select (x => (Score: GetScore (x, ref nPangram), Word: x)).ToList ();
         var orderedList = list.OrderByDescending (x => x.Score).ToList ();
         for (int i = 0; i < orderedList.Count; i++) {
            if (i < nPangram) { // Displays in green for pangrams
               ForegroundColor = ConsoleColor.Green;
               Console.WriteLine ($"{orderedList[i].Score,3}. {orderedList[i].Word}");
               Console.ResetColor ();
            } else Console.WriteLine ($"{orderedList[i].Score,3}. {orderedList[i].Word}");
         }
         Console.WriteLine ($"----\n{orderedList.Sum (x => x.Score)} total");
      }

      /// <summary>This method checks if the word is valid or not</summary>
      /// <param name="word"></param>
      /// <returns>Returns true if the word is valid</returns>
      static bool IsValid (string word)
         => word.Length >= 4
         && word.Any (x => x == sLetters[0]) // Checks if 'U' is present in the word 
         && word.All (sLetters.Contains); // Checks if all other letters in word are in sLetters array.

      /// <summary>This method gets the score for the given valid word</summary>
      /// <param name="word"></param>
      /// <param name="cnt"></param>
      /// <returns>Returns the score in the form of int</returns>
      static int GetScore (string word, ref int cnt)
         => word.Length == 4 ? 1 : Pangram (word, ref cnt).IsPangram ? word.Length + 7 : word.Length;

      /// <summary>This method checks for pangrams and counts no. of pangrams</summary>
      /// <param name="word"></param>
      /// <param name="cnt"></param>
      /// <returns>Returns true if Pangram with the count of pangrams as int</returns>
      static (bool IsPangram, int Count) Pangram (string word, ref int cnt)
         => sLetters.All (word.Contains) ? (true, cnt++) : (false, 0);
      #endregion

      #region Private ----------------------------------------------
      static char[] sLetters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
      #endregion
   }
   #endregion
}