// Write a program to find the digital root of a given number.

Console.WriteLine ("Enter a number: ");
if (int.TryParse (Console.ReadLine (), out int input)) {
   if (input == 0) Console.WriteLine ("The digital root is 0");
   else {
      int remainder = input % 9;
      Console.WriteLine ((remainder != 0) ? $"The digital root is {remainder}" : $"The digital root is 9");
   }
} else Console.WriteLine ("Invalid Input.");