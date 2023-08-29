//Number guessing game
//User thinks of a number between 0 to 127 and computer finds it in 7 tries.

Console.WriteLine ("Think of a number between 0 to 127.");
int maxLimit = 128; int minLimit = 0; int average = (minLimit + maxLimit) / 2;
for (int i = 0; i < 7; i++) {
   Console.WriteLine ($"Is the number less than {average}? (Y)es or (N)o");
   var answer = Console.ReadKey (true).Key;
   if (answer == ConsoleKey.Y) {
      maxLimit = average;
      average = (minLimit + maxLimit) / 2;
   } else if (answer == ConsoleKey.N) {
      minLimit = average;
      average = (minLimit + maxLimit) / 2;
   } else {
      Console.WriteLine ("Incorrect choice. Please try again.");
      break;
   } if (i == 6) Console.WriteLine ($"\nThe number you had in mind is {average}.");
}
