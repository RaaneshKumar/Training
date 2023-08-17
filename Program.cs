//Write a program that reverses a given number and check if it is a palindrome. 
//Note: The input should first be converted to an integer before the check.
//Do not do any string manipulations like reversing a string and converting it to an integer.

Console.Write ("Enter a number: ");
int input = int.Parse (Console.ReadLine ());
int reverse = 0; int input1 = input;
while (input1 > 0) {
   reverse = (reverse * 10) + (input1 % 10);
   input1 /= 10;
}
Console.WriteLine ($"Reversed number = {reverse}");
if (input == reverse) Console.WriteLine ("Given number is a palindrome.");
else Console.WriteLine ("Given number is not a palindrome");
