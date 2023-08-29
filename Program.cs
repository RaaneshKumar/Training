// Find LCM and GCD of two numbers

Console.Write ("Enter the first number: ");
bool num1 = int.TryParse (Console.ReadLine (), out int number1);
Console.Write ("Enter the second number: ");
bool num2 = int.TryParse (Console.ReadLine (), out int number2);
if (num1 == true && num2 == true) {
   int gcd = 0;
   if (number1 == 0) Console.WriteLine ($"LCM of given numbers is 0. \nGCD of given numbers is {number2}.");
   if (number1 > 0) {
      for (int i = 1; i <= number1; i++) {
         int lcm1 = number1 % i; int lcm2 = number2 % i;
         if (lcm1 == 0 && lcm2 == 0 && i > gcd) gcd = i;
      }
      int lcm = (number1 * number2) / gcd;
      Console.WriteLine ("LCM of given numbers is {0}. \nGCD of given numbers is {1}.", lcm, gcd);
   }
} else Console.WriteLine ("Invalid Input.");