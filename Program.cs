// Find LCM and GCD of two numbers

Console.Write ("Enter the first number: ");
bool num1 = int.TryParse (Console.ReadLine (), out int number1);
Console.Write ("Enter the second number: ");
bool num2 = int.TryParse (Console.ReadLine (), out int number2);
if (!(num1 && num2)) Console.WriteLine ("Invalid Input.");
else {
   int gcd = 0;
   if (number1 < 0 || number2 < 0) Console.WriteLine ("Please enter non-negative integers.");
   else if (number1 == 0) Console.WriteLine ($"\nLCM of given numbers is 0. \nGCD of given numbers is {number2}.");
   else {
      for (int i = 1; i <= number1; i++)
         if (number1 % i == 0 && number2 % i == 0 && i > gcd) gcd = i;
      Console.WriteLine ($"\nLCM of given numbers is {number1 * number2 / gcd}. \nGCD of given numbers is {gcd}.");
   }
}