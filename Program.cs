// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to check a given number is armstrong or to print nth Armstrong number based on the user input.
// User either provides input in the command prompt or in the appliation to get nth armstrong number or to check whether the number is armstrong respectively. 
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary> Armstrong Number </summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method prints nth armstrong number when getting input from the command prompt and checks whether it is an armstrong number while executed in the file</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         if (args.Length > 0) {
            if (!int.TryParse (args[0], out int input)) Console.WriteLine ("Invalid Input.");
            else Console.WriteLine (NthArmstrong (input));
         } else {
            Console.Write ("Enter a number to check whether it is an armstrong number or not: ");
            if (!int.TryParse (Console.ReadLine (), out int input)) Console.WriteLine ("Invlaid Input.");
            else Console.WriteLine ($"{input} is{(ArmstrongCheck (input) ? "" : " not")} an armstrong number.");
         }
      }
      /// <summary> This method gives the nth armstrong number where n is the input provide by the user </summary>
      /// <param name="input"></param>
      /// <returns> Returns the nth Armstrong number itself </returns>
      static int NthArmstrong (int input) {
         int count = 0;
         for (int i = 1; ; i++) {
            if (ArmstrongCheck (i)) count++;
            if (count == input) return i;
         }
      }
      /// <summary>This method checks whether the given input is armstrong or not</summary>
      /// <param name="input"></param>
      /// <returns>Returns true when it is an armstrong number and false when it is not</returns>
      static bool ArmstrongCheck (int input) {
         int inputCopy = input;
         double sum = 0;
         int length = input.ToString ().Length;
         while (inputCopy > 0) {
            double digit = inputCopy % 10;
            sum += Math.Pow (digit, length);
            inputCopy /= 10;
         }
         return input == sum;
      }
      #endregion
   }
   #endregion
}