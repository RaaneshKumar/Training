//An isogram is a word that has no duplicate letters.
//Create a function that takes a string and returns either true or false depending on whether it's an "isogram". 

Console.Write ("Enter a string: ");
string input = Console.ReadLine () ?? "", output = "";
if (input.Length > 0) Console.WriteLine ($"The given input is{(Isogram () ? "" : " not")} an isogram.");
else Console.WriteLine ("Empty string");

bool Isogram () {
   foreach (char item in input) if (!output.Contains (item)) output += item;
   if (input == output) return true;
   return false;
}