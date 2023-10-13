// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to generate all string permutations.
// Given a string, all of its possible permutations are displayed.
// ---------------------------------------------------------------------------------------
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method gets input from user and calls permutation method to print possible permutations</summary>
      static void Main () {
         Console.Write ("Enter a string to generate all string permutations: ");
         string input = Console.ReadLine ().Trim ();
         Permutation (input.ToCharArray (), 0, input.Length);
      }

      /// <summary>This method swaps, fixes and swaps chars from left index to right index 
      /// and prints all possible permutations</summary>
      /// <param name="array"></param>
      /// <param name="leftIdx"></param>
      /// <param name="len"></param>
      static void Permutation (char[] array, int leftIdx, int len) {
         if (leftIdx == len) Console.WriteLine (array); //When swapping is done till last char, one permutation is obtained.
         else {
            for (int i = leftIdx; i < len; i++) {
               Swap (ref array[leftIdx], ref array[i]); // Swaps and Fixes chars at particular indices
               Permutation (array, leftIdx + 1, len); // After fixing chars in left indices, function is again called to swap chars in right
               Swap (ref array[leftIdx], ref array[i]); // Changes the Fixed chars for the next loop
            }
         }

         /// <summary>This method swaps two characters</summary>
         /// <param name="a"></param>
         /// <param name="b"></param>
         static void Swap (ref char a, ref char b) => (a, b) = (b, a);
      }
      #endregion
   }
   #endregion
}