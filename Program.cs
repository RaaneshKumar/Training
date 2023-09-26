// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to find the number of chocolates that can be bought with the money available and the wrappers available.
// Money available, price of a chocolate and required wrappers for a chocolate exchange are taken as inputs.  
// The maximum number of chocolates you can get along with any unused money and wrappers is displayed. 
// ---------------------------------------------------------------------------------------
using static System.Console;
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) {
         Console.WriteLine ("Enter the (M)oney available, (P)rice of chocolate, (W)rappers required to exchange a chocolate in the format (M P W): ");
         string[] inputArray = Console.ReadLine ().Split (" ");
         if (inputArray.Length != 3) Console.WriteLine ("Input not in expected format.");
         else {
            int[] values = { };
            for (int i = 0; i < 3; i++) {
               if (!int.TryParse (inputArray[i], out int data)) Console.WriteLine ("Invalid Input.");
               else values = values.Append (data).ToArray ();
            }
            if (values.Length == 3) Console.WriteLine (values.Any (x => x < 0) ? "No Negative inputs." : $"(Chocolates, Money remaining, Wrappers remaining) : {ChocolateCalculator (values[0], values[1], values[2])}");
         }
      }
      static (int, int, int) ChocolateCalculator (int money, int price, int wrappers) {
         int chocolates = (money / price);
         chocolates += chocolates / wrappers;
         return (chocolates, money % price, chocolates % wrappers);
      }
      #endregion
   }
   #endregion
}