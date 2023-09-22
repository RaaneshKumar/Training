// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to Swap a given number
// User gives two numbers to be swapped and the swapped numbers are displayed.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Swap numbers</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method gets the numbers from the user and displays the swapped numbers</summary>
      static void Main () {
         Console.WriteLine ("Enter two numbers to be swapped: ");
         if (!double.TryParse (Console.ReadLine (), out double firstNumber)) Console.WriteLine ("Invalid Input.");
         else {
            if (!double.TryParse (Console.ReadLine (), out double secondNumber)) Console.WriteLine ("Invalid Input.");
            else Console.WriteLine (Swap (firstNumber, secondNumber));
         }
      }
      /// <summary>This method swaps the two numbers</summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns>Returns the swapped numbers in the form of a tuple</returns>
      static (double, double) Swap (double a, double b) => (b, a);
      #endregion
   }
   #endregion
}