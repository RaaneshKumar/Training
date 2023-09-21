// Check whether the given number is a Prime Number or not

Console.Write ("Enter a number: ");
if (!int.TryParse (Console.ReadLine (), out int givenNumber)) Console.WriteLine ("Invlaid input");
else {
   if (givenNumber < 0) Console.WriteLine ("Negative Numbers cannot be prime.");
   else if (givenNumber is 0 or 1) Console.WriteLine ($"{givenNumber} is neither prime nor composite.");
   else if (givenNumber == 2) Console.WriteLine ("2 is a prime number");
   else Console.WriteLine ($"{givenNumber} is {(IsPrime (givenNumber) ? "" : "not ")}a prime number");
}

bool IsPrime (int number) {
   bool primeCheck = true;
   for (int i = 2; i <= Math.Sqrt (number); i++) {
      if (number % i == 0) {
         primeCheck = false;
         break;
      }
   }
   return primeCheck;
}