//Number guessing game
//Computer will think of a random number and user has to find it.

var mode = GetMode ();
Console.WriteLine (mode);
var random = new Random ();
int number = random.Next (1, GetMax () + 1);
Console.WriteLine ($"The computer has picked a number between 1 and {GetMax ()}. Guess it correctly if you can. ");
for (int tries = 1; ; tries++) {
   Console.Write ("Enter your guess: ");
   int.TryParse (Console.ReadLine (), out int guess);
   if (guess == number) {
      Console.WriteLine ($"Correct. You guessed it in {tries} tries.");
      break;
   } else if (guess > number) Console.WriteLine ("Too High");
   else if (guess < number) Console.WriteLine ("Too Low");
   else Console.WriteLine ("Invalid entry.");
}

int GetMax () {
   switch (mode) {
      case Level.Easy: return 10;
      case Level.Hard: return 1000;
      default: return 100;
   }
}
Level GetMode () {
   Console.WriteLine ("Choose the difficulty level: (E)asy , (M)edium , (H)ard ");
   for (; ; ) {
      var difficulty = Console.ReadKey (true).Key;
      switch (difficulty) {
         case ConsoleKey.E: return Level.Easy;
         case ConsoleKey.H: return Level.Hard;
         case ConsoleKey.M: return Level.Medium;
         default: Console.WriteLine ("Incorrect Choice."); break;
      }
   }
}
enum Level { Easy, Medium, Hard }