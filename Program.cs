//Write a program that reverses a given number and check if it is a palindrome. 
//Note: The input should first be converted to an integer before the check.
//Do not do any string manipulations like reversing a string and converting it to an integer.

Console.Write ("Enter a number: ");
if (int.TryParse (Console.ReadLine (), out int input)) {
   int reverse = 0; int input1 = input;
   while (input1 > 0) {
      reverse = (reverse * 10) + (input1 % 10);
      input1 /= 10;
   }
   Console.WriteLine ($"Reversed number = {reverse}");
   Console.WriteLine ((input == reverse) ? "Given number is a palindrome." : "Given number is not a palindrome");
} else Console.WriteLine ("Invalid Input.");