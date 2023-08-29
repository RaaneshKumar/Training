// Check whether the given number is a Prime Number or not

Console.Write ("Enter a number: ");
if (int.TryParse (Console.ReadLine (), out int givenNumber)) {
   if (givenNumber < 0) Console.WriteLine ("Negative Numbers cannot be prime.");
   if (givenNumber is 0 or 1) Console.WriteLine ("{0} is neither prime nor composite.", givenNumber);
   if (givenNumber > 2) {
      for (int i = 2; i < givenNumber / 2; i++) {
         int result = givenNumber % i;
         if (result == 0) {
            Console.WriteLine ("{0} is not a prime number.", givenNumber);
            break;
         }
         if (i == givenNumber / 2 - 1) {
            Console.WriteLine ("{0} is a prime number.", givenNumber);
            break;
         }
      }
   }
   if (givenNumber == 2) Console.WriteLine ("2 is a prime number");
} else Console.WriteLine ("Invlaid input");