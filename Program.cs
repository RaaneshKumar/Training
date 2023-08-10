Console.Write ("Enter a number: ");
string number = Console.ReadLine ();
int num = int.Parse (number);
Console.Write ("If you want to convert into words, enter w. If you want to convert to roman numerals, enter rn. (Condition: Limit to convert to words is 10 crores. Limit to convert to roman numerals is 3999. Enter your choice: ");
string choice = Console.ReadLine ();
if (choice == "w") {
   if (num > 100000000) {
      Console.WriteLine ("Enter value within the limit.");
   } else {
      Console.WriteLine (to_words (num));
   }
}
if (choice == "rn") {
   if (num > 3999) {
      Console.WriteLine ("Enter value within the limit.");
   } else {
      Console.WriteLine (to_roman_numerals (num));
   }
}

// To print the given number in words
// For example: 376 must be printed as three hundred and seventy six
// Code is written for user input upto 10 crores

string to_words (int num) {
   string number_in_words = "";
   while (num > 0) {
      if (num >= 10000000) {
         int quotient = num / 10000000; int remainder = num % 10000000;
         one_to_nineteen (quotient);
         Console.Write ((one_to_nineteen (quotient)) + " crores ");
         num = remainder;
      }
      if (num >= 100000) {
         int quotient = num / 100000; int remainder = num % 100000;
         one_to_nineteen (quotient);
         Console.Write ((one_to_nineteen (quotient)) + " lakhs ");
         num = remainder;
      }
      if (num >= 1000) {
         int quotient = num / 1000; int remainder = num % 1000;
         one_to_nineteen (quotient);
         Console.Write ((one_to_nineteen (quotient)) + " thousand ");
         num = remainder;
      }
      if (num >= 100) {
         int quotient = num / 100; int remainder = num % 100;
         one_to_nineteen (quotient);
         Console.Write ((one_to_nineteen (quotient)) + " hundred and ");
         num = remainder;
      }
      if (num >= 0) {
         one_to_nineteen (num);
         Console.Write ((one_to_nineteen (num)));
      }
      Console.WriteLine (number_in_words);
      break;
   }


   string one_to_nineteen (int num1) {
      string quotientstring = "";
      if (num1 > 10) {
         int quotient1 = num1 / 10; int remainder1 = num1 % 10;
         if (quotient1 == 2) {
            quotientstring = " twenty ";
         }
         if (quotient1 == 3) {
            quotientstring = " thirty ";
         }
         if (quotient1 == 4) {
            quotientstring = " forty ";
         }
         if (quotient1 == 5) {
            quotientstring = " fifty ";
         }
         if (quotient1 == 6) {
            quotientstring = " sixty ";
         }
         if (quotient1 == 7) {
            quotientstring = " seventy ";
         }
         if (quotient1 == 8) {
            quotientstring = "eighty ";
         }
         if (quotient1 == 9) {
            quotientstring = " ninety ";
         }
         num1 = remainder1;
      }
      if (num1 == 1) {
         quotientstring = quotientstring + "one";
      }
      if (num1 == 2) {
         quotientstring = quotientstring + "two";
      }
      if (num1 == 3) {
         quotientstring = quotientstring + "three";
      }
      if (num1 == 4) {
         quotientstring = quotientstring + "four";
      }
      if (num1 == 5) {
         quotientstring = quotientstring + "five";
      }
      if (num1 == 6) {
         quotientstring = quotientstring + "six";
      }
      if (num1 == 7) {
         quotientstring = quotientstring + "seven";
      }
      if (num1 == 8) {
         quotientstring = quotientstring + "eight";
      }
      if (num1 == 9) {
         quotientstring = quotientstring + "nine";
      }
      if (num1 == 10) {
         quotientstring = quotientstring + "ten";
      }
      return quotientstring;
   }
   return number_in_words;
}
// Convert a given number to its corresponding roman numerals
// Code is written for User input less than 4000

string to_roman_numerals (int input) {
   string number_in_rn = "";
   while (input > 0) {
      if (input > 1000) {
         int quotient = input / 1000; int remainder = input % 1000;
         number_in_rn = string.Concat (Enumerable.Repeat ("M", quotient));
         input = remainder;
      }
      if (input > 100) {
         int quotient = input / 100; int remainder = input % 100;
         if (quotient == 9) {
            number_in_rn+= "CM";

         }
         if (quotient > 5 && quotient < 9) {
            number_in_rn += "D" + string.Concat (Enumerable.Repeat ("C", quotient - 5));
         }
         if (quotient == 5) {
            number_in_rn += "D";

         }
         if (quotient == 4) {
            number_in_rn += "CD";

         }
         if (quotient >= 1 && quotient < 4) {
           number_in_rn += string.Concat (Enumerable.Repeat ("C", quotient));
         }
         input = remainder;
      }
      if (input > 10) {
         int quotient = input / 10; int remainder = input % 10;
         if (quotient == 9) {
            number_in_rn += "XC";
         }
         if (quotient > 5 && quotient < 9) {
            number_in_rn += "L" + string.Concat(Enumerable.Repeat("X", quotient - 5));
         }
         if (quotient == 5) {
            number_in_rn += "L";
         }
         if (quotient == 4) {
            number_in_rn += "XL";
         }
         if (quotient >= 1 && quotient < 4) {
            number_in_rn += string.Concat(Enumerable.Repeat("X", quotient));
         }
         input = remainder;
      }
      if (input >= 1) {
         if (input == 9) {
            number_in_rn += "IX";
         }
         if (input == 8) {
            number_in_rn += "VIII";
         }
         if (input == 7) {
            number_in_rn += "VII";
         }
         if (input == 6) {
            number_in_rn += "VI";
         }
         if (input == 5) {
            number_in_rn += "V";
         }
         if (input == 4) {
            number_in_rn += "IV";
         }
         if (input == 3) {
            number_in_rn += "III";
         }
         if (input == 2) {
            number_in_rn += "II";
         }
         if (input == 1) {
            number_in_rn += "I";
         }
      }
      break;
   }
   return number_in_rn; 
}