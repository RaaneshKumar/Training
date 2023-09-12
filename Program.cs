// To print the factorial of a given number.

Console.Write ("Enter a number to print its factorial: ");
if (int.TryParse (Console.ReadLine (), out int input)) {
   if (input < 0) Console.WriteLine("Factorial can be printed only for non-negative integers.");
   else Console.WriteLine ($"Factorial of {input} is {Factorial (input)}.");
} else Console.WriteLine ("Invalid Input.");

int Factorial (int number) {
   int factorial = 1;
   for (int i = 1; i <= number; i++) {
      factorial *= i;
   }
   return factorial;
} 