//number guessing game
//User will think of a number between 0 to 127 and computer finds it in 7 tries.
//Write a code such that computer finds the number in the order LSB to MSB

Console.WriteLine ("Think of a number between 0 to 127");
string binary = "";
int divisor = 2;
int remainder = 0;
for (int i = 0; i < 7; i++) {
   Console.WriteLine ($"Is the remainder {remainder} when the number is divided by {divisor}? (Y)es or (N)o");
   var answer2 = Console.ReadKey (true).Key;
   if (answer2 == ConsoleKey.Y) {
      binary = "0" + binary;
      remainder = Convert.ToInt32 (binary, 2);
      divisor *= 2;
   } else if (answer2 == ConsoleKey.N) {
      binary = "1" + binary;
      remainder = Convert.ToInt32 (binary, 2);
      divisor *= 2;
   } else {
      Console.WriteLine ("Incorrect choice.");
      i--;
   }
}
Console.WriteLine ($"\nThe number you had in mind is {remainder}.");