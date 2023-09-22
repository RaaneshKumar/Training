// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to display the individual digits of a given number.
// User enters a number and its individual digits are displayed seperately as integral part and factorial part.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Display individual digits</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method splits the integral and fractional parts of the given number and prints the individual digits of each part</summary>
      static void Main () {
         Console.Write ("Enter a number: ");
         if (!double.TryParse (Console.ReadLine (), out double input)) Console.WriteLine ("Invalid Input.");
         else {
            string[] parts = input.ToString ().Split ('.');
            Console.WriteLine ($"Integral part\t: {Digits (parts[0])} {(parts.Length == 1 ? " " : $"\nFactorial Part\t: {Digits (parts[1])}")}");
         }
      }
      /// <summary>This method gives the individual digits of a given part</summary>
      /// <param name="part"></param>
      /// <returns>Returns the individual digits of the part as a string</returns>
      static string Digits (string part) {
         List<char> digits = part.ToList ();
         string final = string.Join (" ", digits);
         return final;
      }
      #endregion
   }
   #endregion
}