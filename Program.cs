// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to help solve a New-York Times style Spelling Bee.
// A word list is given as a text file, and that the daily choice of 7 letters is provided as an array of 7 chars: char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' }
// Valid word conditions - Each word is at least 4 letters long, Each word uses only the 7 seed letters, Each word MUST use the first letter (in this case U),Any letter can be used more than once.
// Score conditions - 4 letter words score 1 point, Longer words score their no. of letters as points, Any word that uses all 7 seed letters (called pangrams) gets an additional 7 bonus points.
// Output is a list of words sorted in descending order of score. If two words have the same score, they are displayed in alphabetical order of the words.
// Pangrams are displayed in green color
// ---------------------------------------------------------------------------------------
using static System.Console;

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Spelling Bee</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method reads the text file, displays valid words in the arrangement of (score. word) and displays pangrams in green color</summary>
      static void Main () {
         string[] words = File.ReadAllLines ("C:words.txt.crdownload");
         char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
         int pangramCount = 0;
         var eligibleWords = EligibleWords (words, letters, ref pangramCount);
         ForegroundColor = ConsoleColor.Green;
         for (int i = 0; i < eligibleWords.Count; i++) {
            if (i + 1 <= pangramCount) { //Since index is from 0, (i + 1) is checked with pangramCount
               ForegroundColor = ConsoleColor.Green;
               Console.WriteLine ($"{eligibleWords[i].Item1,3}. {eligibleWords[i].Item2}"); //If pangram, the word is displayed in green.
               Console.ResetColor ();
            } else Console.WriteLine ($"{eligibleWords[i].Item1,3}. {eligibleWords[i].Item2}");
         }
         Console.WriteLine ($"----\n{eligibleWords.Sum (x => x.Item1)} total"); // Displays the total points
      }

      /// <summary>This method checks valid words, find their points and counts the no. of pangrams</summary>
      /// <param name="stArr">Words Array</param>
      /// <param name="chArr">Letters Array</param>
      /// <param name="a">Pangram Count</param>
      /// <returns>This method returns all valid words and their points in the form of list of tuples</returns>
      static List<(int, string)> EligibleWords (string[] stArr, char[] chArr, ref int a) {
         List<(int, string)> list = new ();
         foreach (string word in stArr) {
            if (word.Length >= 4 && word.Any (x => x == chArr[0]) && word.All (x => chArr.Any (c => c == x))) { //Checks if letters in word >= 4, must use character 'U' is present, all other letters are in char[] letters.
               list.Add (word.Length == 4 ? (1, word) : chArr.All (x => word.Any (c => c == x)) ? (word.Length + 7, word) : (word.Length, word)); //Set points for word, checks for pangrams.
               a = list.Where (x => x.Item1 == x.Item2.Length + 7).Count (); //Finds Count of pangrams
            }
         }
         var newList = list.OrderByDescending (x => x.Item1).ToList (); //Arranged in descending order of their scores
         return newList;
      }
      #endregion
   }
   #endregion
}