// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to find the number of chocolates that can be bought with the money available and the wrappers available.
// Money available, price of a chocolate and required wrappers for a chocolate exchange are taken as inputs.  
// The maximum number of chocolates you can get along with any unused money and wrappers is displayed. 
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Chocolate Wrappers</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method displays the number of chocolates, unused money and wrappers if input is valid</summary>
      static void Main () {
         Console.WriteLine ("Enter the (M)oney available, (P)rice of chocolate, (W)rappers required to exchange a chocolate in the format (M P W): ");
         int[] vals = new int[3];
         if (!IsValidInput (ref vals)) {
            Console.WriteLine ("Invalid Input.");
            return;
         }
         if (vals.Length == 3) Console.WriteLine (vals.Any (x => x < 0) ?
            "No Negative inputs." : $"(Chocolates, Money remaining, Wrappers remaining) : {ChocolateCalculator (vals[0], vals[1], vals[2])}");
      }

      /// <summary>This method calculates the number of chocolates, unused money and wrappers</summary>
      /// <param name="money"></param>
      /// <param name="price"></param>
      /// <param name="wrappers"></param>
      /// <returns>This method returns the chocolates, unused money and wrappes in the form of a tuple</returns>
      static (int, int, int) ChocolateCalculator (int money, int price, int wrappers) {
         int chocolates = (money / price);
         chocolates += chocolates / wrappers;
         return (chocolates, money % price, chocolates % wrappers);
      }

      /// <summary>This method checks for valid input and stores it in an array if valid</summary>
      /// <param name="values"></param>
      /// <returns>Returns false if invalid input is entered</returns>
      static bool IsValidInput (ref int[] values) {
         string[] inputArray = Console.ReadLine ().Split (" ");
         if (inputArray.Length != 3) return false;
         for (int i = 0; i < 3; i++) {
            if (!int.TryParse (inputArray[i], out int data)) return false;
            values[i] = data;
         }
         return true;
      }
      #endregion
   }
   #endregion
}