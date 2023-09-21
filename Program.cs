//An isogram is a word that has no duplicate letters.
//Create a function that takes a string and returns either true or false depending on whether it's an "isogram". 

Console.Write ("Enter a string: ");
string input = Console.ReadLine (), output = "";
Console.WriteLine ((input.Length > 0) ? $"The given input is{(Isogram () ? "" : " not")} an isogram." : "Empty string.");

bool Isogram () {
   bool isogramCheck = true;
   foreach (char item in input) {
      if (output.Contains (item)) {
         isogramCheck = false;
         break;
      } else output += item;
   }
   return isogramCheck;
}