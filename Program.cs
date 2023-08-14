// Find LCM and GCD of two numbers

Console.Write ("Enter the first number: ");
int number1 = int.Parse (Console.ReadLine ());
Console.Write ("Enter the second number: ");
int number2 = int.Parse (Console.ReadLine ());
int[] multiples = new int[] { };
for (int i = 1; i <= number1; i++) {
   int lcm1 = number1 % i; int lcm2 = number2 % i;
   if (lcm1 == 0 && lcm2 == 0) multiples = multiples.Append (i).ToArray ();
}
int gcd = multiples.Max ();
int lcm = (number1 * number2) / gcd;
Console.WriteLine ("LCM of given numbers is {0} \nGCD of given numbers is {1}", lcm , gcd);
