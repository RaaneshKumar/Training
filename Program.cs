//Number guessing game
//User thinks of a number between 0 to 127 and computer finds it in 7 tries.

Console.WriteLine ("Think of a number between 0 to 127.");
int max_limit = 128;
int min_limit = 0;
int average = (min_limit + max_limit) / 2;
for (int i = 0; i < 7; i++) {
   Console.WriteLine ($"Is the number less than {average}? (Y)es or (N)o");
   var answer = Console.ReadKey (true).Key;
   if (answer == ConsoleKey.Y) {
      max_limit = average;
      average = (min_limit + max_limit) / 2;
   } else if (answer == ConsoleKey.N) {
      min_limit = average;
      average = (min_limit + max_limit) / 2;
   } else {
      Console.WriteLine ("Incorrect choice.");
      i--;
   }
}
Console.WriteLine ($"\nThe number you had in mind is {average}.");

