//An abecedarian word is a word where all its letters are arranged in alphabetical order. 
//Given an array of words, create a function which returns the longest abecedarian word. 
//If no word in an array matches the criteria, return an empty string. 

Console.Write ("Enter no. words to check the longest abecedarian word: ");
bool input = int.TryParse (Console.ReadLine (), out int count);
if (input) {
   List<string> words = new ();
   List<string> abecedarian = new ();
   for (int i = 0; i < count; i++) {
      Console.Write ("Enter a string: ");
      words.Add (Console.ReadLine ());
   }
   foreach (string eachWord in words) {
      char[] letters = eachWord.ToCharArray ();
      Array.Sort (letters);
      string sorted = new (letters);
      if (eachWord == sorted) abecedarian.Add (sorted);
   }
   Console.WriteLine (abecedarian.Count > 0 ? abecedarian.MaxBy (x => x.Length) : "No abecedarian words.");
} else Console.WriteLine ("Invalid input.");