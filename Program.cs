Console.Write ("Enter a number: ");
if (int.TryParse (Console.ReadLine (), out int num)) {
   Console.Write ("If you want to convert into words, enter w. If you want to convert to roman numerals, enter r. (Condition: Limit to convert to words is 10 crores. Limit to convert to roman numerals is 3999. Enter your choice: ");
   string choice = Console.ReadLine ();
   if (choice == "w") {
      if (num > 100000000) Console.WriteLine ("Enter value within the limit."); else Console.WriteLine (ToWords (num));
   } else if (choice == "r") {
      if (num > 3999) Console.WriteLine ("Enter value within the limit."); else Console.WriteLine (ToRomanNumerals (num));
   } else Console.WriteLine ("Invlaid Input.");
} else Console.WriteLine ("Invalid Input");

// To print the given number in words
// For example: 376 must be printed as three hundred and seventy six
// Code is written for user input upto 10 crores

string ToWords (int num) {
   string numberInWords = "";
   while (num > 0) {
      if (num >= 10000000) {
         int quotient = num / 10000000; int remainder = num % 10000000;
         Console.Write ((OneToNinetyNine (quotient)) + " crores ");
         num = remainder;
      }
      if (num >= 100000) {
         int quotient = num / 100000; int remainder = num % 100000;
         Console.Write ((OneToNinetyNine (quotient)) + " lakhs ");
         num = remainder;
      }
      if (num >= 1000) {
         int quotient = num / 1000; int remainder = num % 1000;
         Console.Write ((OneToNinetyNine (quotient)) + " thousand ");
         num = remainder;
      }
      if (num >= 100) {
         int quotient = num / 100; int remainder = num % 100;
         Console.Write ((OneToNinetyNine (quotient)) + " hundred and ");
         num = remainder;
      }
      if (num >= 0) Console.Write ((OneToNinetyNine (num)));
      Console.WriteLine (numberInWords);
      break;
   }


   string OneToNinetyNine (int num1) {
      string quotientstring = "";
      if (num1 >= 20) {
         int quotient1 = num1 / 10; int remainder1 = num1 % 10;
         Dictionary<int,string> twentyToNinety = new Dictionary<int,string> () { { 2, "twenty "}, { 3, "thirty " }, { 4, "forty " }, { 5, "fifty " }, { 6, "sixty " }, { 7, "seventy " }, { 8, "eighty " }, { 9, "ninety " } };
         quotientstring = twentyToNinety[quotient1];
         num1 = remainder1;
      }
      Dictionary<int, string> oneToNineteen = new Dictionary<int, string> () { { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" }, { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "ten" }, { 11, "eleven" }, { 12, "twelve" }, { 13, "thirteen" }, { 14, "fourteen" }, { 15, "fifteen" }, { 16, "sixteen" }, { 17, "seventeen" }, { 18, "eighteen" }, { 19, "nineteen" } };
      quotientstring += oneToNineteen[num1];
      return quotientstring;
   }
   return numberInWords;
}

// Convert a given number to its corresponding roman numerals
// Code is written for User input less than 4000

string ToRomanNumerals (int input) {
   string numberInRoman = "";
   while (input > 0) {
      if (input > 1000) {
         int quotient = input / 1000; int remainder = input % 1000;
         numberInRoman = string.Concat (Enumerable.Repeat ("M", quotient));
         input = remainder;
      }
      if (input > 100) {
         int quotient = input / 100; int remainder = input % 100;
         if (quotient == 9) numberInRoman += "CM";
         if (quotient > 5 && quotient < 9) numberInRoman += "D" + string.Concat (Enumerable.Repeat ("C", quotient - 5));
         if (quotient == 5) numberInRoman += "D";
         if (quotient == 4) numberInRoman += "CD";
         if (quotient >= 1 && quotient < 4) numberInRoman += string.Concat(Enumerable.Repeat("C", quotient));
         input = remainder;
      }
      if (input > 10) {
         int quotient = input / 10; int remainder = input % 10;
         if (quotient == 9) numberInRoman += "XC";
         if (quotient > 5 && quotient < 9) numberInRoman += "L" + string.Concat(Enumerable.Repeat("X", quotient - 5));
         if (quotient == 5) numberInRoman += "L";
         if (quotient == 4) numberInRoman += "XL";
         if (quotient >= 1 && quotient < 4) numberInRoman += string.Concat(Enumerable.Repeat("X", quotient));
         input = remainder;
      }
      if (input >= 1) {
         Dictionary<int,string> romanNumbers = new Dictionary<int, string> () { {1, "I"}, { 2, "II" }, { 3, "III" }, { 4, "IV" }, { 5, "V" }, { 6, "VI" }, { 7, "VII" }, { 8, "VIII" }, { 9, "IX" }, { 10, "X" } };
         numberInRoman += romanNumbers[input];
      }
      break;
   }
   return numberInRoman; 
}