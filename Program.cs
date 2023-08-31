//Reduce a string of lowercase characters by deleting a pair of adjacent letters that match. 

Console.WriteLine ("Enter a string: ");
string user_input = Console.ReadLine ();
user_input = user_input.ToLower();
List<char> input = new List<char> () { };
foreach (char item in user_input) input.Add (item);
for (int i = 1; i < input.Count; i++) {
   if (input[i] == input[i - 1]) {
      input.RemoveAt (i); input.RemoveAt (i - 1);
      i--;
   }
}
foreach (char item in input) Console.Write (item);