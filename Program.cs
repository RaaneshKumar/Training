// Find LCM and GCD of two numbers

Console.Write ("Enter the first number: ");
string first_number = Console.ReadLine ();
Console.Write ("Enter the second number: ");
string second_number = Console.ReadLine ();
int number1 = int.Parse (first_number);
int number2 = int.Parse (second_number);
int[] multiples = new int[] { };
for (int i = 2; i <= number1; i++) {
   int lcm1 = number1 % i;
   int lcm2 = number2 % i;
   if (lcm1 == 0 && lcm2 == 0) {
      multiples = multiples.Append (i).ToArray ();
   }
}
int gcd = multiples.Max ();
int lcm = (number1 * number2) / gcd;
Console.WriteLine ("LCM of given numbers is {0}", lcm);
Console.WriteLine ("GCD of given numbers is {0}", gcd);