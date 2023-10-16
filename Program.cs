// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to print the given numbers in words or roman numerals.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Number to wrods and roman numerals</summary>
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>This method asks the user whether to display the num in words 
      /// or roman numbers and displays accordingly</summary>
      static void Main () {
         Console.WriteLine ("Enter a positive number: \n" +
                   "(Condition: Limit to convert to words is 10 crores. Limit to convert to roman numerals is 3999.)");
         if (!int.TryParse (Console.ReadLine (), out int num)) {
            Console.WriteLine ("Invalid Input");
            return;
         }
         Console.Write ("If you want to convert into words, enter w. If you want to convert to roman numerals, enter r: ");
         string choice = Console.ReadLine ();

         if (choice == "w") Console.WriteLine (num is > 100000000 or < 0 ? "Enter value within the limit."
                                                                         : num == 0 ? "Zero" : GetNumInWords (num));
         else if (choice == "r") Console.WriteLine (num is 3999 ? "Enter value within the limit."
                                                                : num <= 0 ? "No equivalent roman number" : GetRomanNum (num));
         else Console.WriteLine ("Invlaid Input.");
      }

      /// <summary>This method converts the number to words</summary>
      /// <param name="num">The number to be converted</param>
      /// <returns>Returns the number in words as string</returns>
      static string GetNumInWords (int num) {
         string numInWrds = "";
         Dictionary<int, int> divisor = new () { { 1, 1 }, { 2, 1 }, { 3, 100 }, { 4, 1000 }, { 5, 1000 },
                                                    { 6, 100000 }, { 7, 100000 }, { 8, 10000000 }, { 9, 10000000 } };
         while (num > 0) {
            (string words, num) = GetWords (num, divisor[num.ToString ().Length]);
            numInWrds += words;
         }
         return numInWrds;

         (string wrds, int rem) GetWords (int num, int div = 1) {
            int quo, rem, tempQuo, tempRem;
            string wrds = "";
            Dictionary<int, string> digits = new () { { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
                                             { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "ten" },
                                             { 11, "eleven" }, { 12, "twelve" }, { 13, "thirteen" }, { 14, "fourteen" }, { 15, "fifteen" },
                                             { 16, "sixteen" }, { 17, "seventeen" }, { 18, "eighteen" }, { 19, "nineteen" } };

            Dictionary<int, string> twentyToNinety = new () { { 2, "twenty "}, { 3, "thirty " }, { 4, "forty " }, { 5, "fifty " },
                                                                 { 6, "sixty " }, { 7, "seventy " }, { 8, "eighty " }, { 9, "ninety " }};

            Dictionary<int, string> divisor = new () { { 10000000, "crore(s)" }, { 100000, "lakh(s)" },
                                                          { 1000, "thousand" }, { 100, "hundred and" } };

            quo = num / div; rem = num % div;
            if (quo >= 20) {
               tempQuo = quo / 10; tempRem = quo % 10;
               wrds = twentyToNinety[tempQuo];
               quo = tempRem;
            }
            if (quo != 0) wrds += digits[quo] + $" {(div == 1 ? "" : divisor[div])} ";
            return (wrds, rem);
         }
      }

      /// <summary>This method converts the number to roman Numerals</summary>
      /// <param name="num">Number to be converted</param>
      /// <returns>Returns the number in roman numerals as string</returns>
      static string GetRomanNum (int num) {
         string numInRmn = "";
         List<int> numbers = new () { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000, 5000 };
         List<string> romNums = new () { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
         while (num > 0) { // idx gets index of req roman number.
            int idx = numbers.IndexOf (numbers.Where (x => num < x).ToList ()[0]) - 1;
            numInRmn += romNums[idx];
            num -= numbers[idx];
         }
         return numInRmn;
      }
      #endregion
   }
   #endregion
}