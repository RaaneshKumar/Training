//An isogram is a word that has no duplicate letters.
//Create a function that takes a string and returns either true or false depending on whether it's an "isogram". 

Console.WriteLine ("Enter a string: ");
string input = Console.ReadLine (); string output = "";
if (isogram () == true) Console.WriteLine ("It is an isogram.");
else Console.WriteLine ("Not an isogram.");

bool isogram () {
   foreach (char item in input) {if (output.Contains (item) == false) output += item;}
   if (input == output) return true;
   return false;
}