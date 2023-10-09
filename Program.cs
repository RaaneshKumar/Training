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
         (int a, int b) = (GetValidNumber (), GetValidNumber ());
         Console.WriteLine ($"Before Swapping\t: a = {a}, b = {b}");
         Swap (ref a, ref b);
         Console.WriteLine ($"After swapping\t: a = {a}, b = {b}");
      }

      /// <summary>This method swaps the two numbers</summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      static void Swap (ref int a, ref int b) => (a, b) = (b, a);

      /// <summary>This method checks for valid input and converts it to an int if valid</summary>
      /// <returns>Returns an int if input is valid</returns>
      static int GetValidNumber () {
         for (int i = 1; ; i++) {
            if (!int.TryParse (Console.ReadLine (), out int b)) Console.WriteLine ("Invalid Input.");
            else return b;
         }
      }
      #endregion
   }
   #endregion
}