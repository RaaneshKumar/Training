Console.WriteLine ("Enter a number: \n" +
                   "(Condition: Limit to convert to words is 10 crores. Limit to convert to roman numerals is 3999.)");
if (!int.TryParse (Console.ReadLine (), out int num)) {
   Console.WriteLine ("Invalid Input");
   return;
}
Console.Write ("If you want to convert into words, enter w. If you want to convert to roman numerals, enter r.");
string choice = Console.ReadLine ();
if (choice == "w") Console.WriteLine (num > 100000000 ? "Enter value within the limit." : GetNumInWords (num));
//else if (choice == "r") Console.WriteLine (num > 3999 ? "Enter value within the limit." : ToRomanNumerals (num));
else Console.WriteLine ("Invlaid Input.");
GetRomanNum (num);
string GetNumInWords (int num) {
   string numInWrds = "";
   Dictionary<int, int> divisor = new () { { 1, 1 }, { 2, 1 }, { 3, 100 }, { 4, 1000 }, { 5, 1000 }, { 6, 100000 }, { 7, 100000 }, { 8, 10000000 }, { 9, 10000000 }};
   while (num > 0) {
      (string words, num) = GetWords (num, divisor[num.ToString ().Length]);
      numInWrds += words;
   }
   return numInWrds;
}

(string wrds, int rem) GetWords (int num, int div = 1) {
   int quo, rem, tempQuo, tempRem;
   string wrds = "";
   Dictionary<int, string> digits = new () { { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
                                             { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "ten" },
                                             { 11, "eleven" }, { 12, "twelve" }, { 13, "thirteen" }, { 14, "fourteen" }, { 15, "fifteen" },
                                             { 16, "sixteen" }, { 17, "seventeen" }, { 18, "eighteen" }, { 19, "nineteen" } };
   Dictionary<int, string> twentyToNinety = new () { { 2, "twenty "}, { 3, "thirty " }, { 4, "forty " }, { 5, "fifty " },
                                                     { 6, "sixty " }, { 7, "seventy " }, { 8, "eighty " }, { 9, "ninety " }};
   Dictionary<int, string> divisor = new () { { 10000000, "crore(s)" }, { 100000, "lakh(s)" }, { 1000, "thousand" }, { 100, "hundred and" } };
   quo = num / div; rem = num % div;
   if (quo >= 20) {
      tempQuo = quo / 10; tempRem = quo % 10;
      wrds = twentyToNinety[tempQuo];
      quo = tempRem;
   }
   if (quo != 0) wrds += digits[quo] + $" {(div == 1 ? "" : divisor[div])} ";
   return (wrds, rem);
}




void GetRomanNum (int num) {
   string a = "";
   //Dictionary<int, char> romNum = new () { { 1, 'I' }, { 5, 'V' }, { 10, 'X' }, { 50, 'L' }, { 100, 'C' }, { 500, 'D' }, { 1000, 'M' } };
   List<int> number = new () { 1, 5, 10, 50, 100, 500, 1000, 5000 };
   List<char> romNum = new () { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
   while (num > 0) {
      int b = number.IndexOf (number.Where (x => num <= x).ToList ()[0]) - 1;
      a += romNum[b];
      num -= number[b];
   }
   Console.WriteLine (a);
}