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
         (double firstNumber, double secondNumber) = (GetValidNumber (), GetValidNumber ());
         var swappedNumbers = Swap (firstNumber, secondNumber);
         Console.WriteLine ($"Before Swapping\t: a = {firstNumber}, b = {secondNumber}\nAfter swapping\t: a = {swappedNumbers.Item1}, b = {swappedNumbers.Item2}");

      }

      /// <summary>This method swaps the two numbers</summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns>Returns the swapped numbers in the form of a tuple</returns>
      static (double, double) Swap (double a, double b) => (b, a);

      /// <summary>This method checks for valid input and converts it to a double if valid</summary>
      /// <returns>Returns a double if input is valid</returns>
      static double GetValidNumber () {
         for (int i = 1; ; i++) {
            if (!double.TryParse (Console.ReadLine (), out double b)) Console.WriteLine ("Invalid Input.");
            else return b;
         }
      }
      #endregion
   }
   #endregion
}