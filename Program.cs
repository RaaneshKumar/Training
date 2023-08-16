// Write a program to find the digital root of a given number.

Console.WriteLine ("Enter a number: ");
int input = int.Parse (Console.ReadLine ());
if (input == 0) Console.WriteLine ("The digital root is 0");
else {
   int remainder = input % 9;
   if (remainder != 0) Console.WriteLine ($"The digital root is {remainder}");
   else if (remainder == 0) Console.WriteLine ("The digital root is 9");
}