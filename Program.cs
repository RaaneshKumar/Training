// To print the factorial of a given number.

Console.WriteLine (factorial ());
string factorial () {
   Console.Write ("Enter a number to print its factorial: ");
   if (int.TryParse (Console.ReadLine (), out int input)) {
      int factorial = 1;
      for (int i = 1; i <= input; i++) {
         factorial *= i;
      }
      return ($"Factorial of {input} is {factorial}");
   } else return ("Ivalid Input.");
} 