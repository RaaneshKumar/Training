// Check whether the given number is a Prime Number or not

Console.Write ("Enter a number: ");
int given_number = int.Parse (Console.ReadLine ());
if (given_number < 0) Console.WriteLine ("Negative Numbers cannot be prime.");
if (given_number is 0 or 1) Console.WriteLine ("{0} is neither prime nor composite.", given_number);
if (given_number > 2) {
   for (int i = 2; i < given_number; i++) {
      int result = given_number % i;
      if (result == 0) {
         Console.WriteLine ("{0} is not a prime number.", given_number);
         break;
      } if (i==given_number -1 ) {
         Console.WriteLine ("{0} is a prime number.", given_number);
         break;
      }
   }
}
if (given_number == 2) Console.WriteLine("2 is a prime number");
