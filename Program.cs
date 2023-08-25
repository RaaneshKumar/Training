//An abecedarian word is a word where all its letters are arranged in alphabetical order. 
//Given an array of words, create a function which returns the longest abecedarian word. 
//If no word in an array matches the criteria, return an empty string. 

Console.WriteLine ("Enter no. words to check the longest abecedarian word: ");
int.TryParse (Console.ReadLine (), out int count);
List<string> words = new List<string> ();
string sorted = "";
List<string> abecedarian = new List<string> ();
string result = "";


for (int i = 0; i < count; i++) {
   Console.Write ("Enter a string: ");
   string word = Console.ReadLine ();
   words.Add (word);
}
foreach (string each_word in words) {
   List<char> letters = new List<char> ();
   foreach (char item in each_word) letters.Add (item);
   letters.Sort ();
   foreach (char item in letters) sorted += item;
   if (each_word == sorted) abecedarian.Add (sorted);
   sorted = "";
}
if (abecedarian.Count > 0) {
   result = abecedarian[0];
   for (int i = 1; i < abecedarian.Count; i++) if (abecedarian[i].Length > result.Length) result = abecedarian[i];
   Console.WriteLine (result);
}
