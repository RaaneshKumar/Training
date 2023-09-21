//Reduce a string of lowercase characters by deleting a pair of adjacent letters that match. 

Console.Write ("Enter a string: ");
string userInput = Console.ReadLine ().ToLower () ?? "";
List<char> input = userInput.ToList ();
for (int i = 1; i < input.Count; i++) {
   if (input[i] == input[i - 1]) {
      input.RemoveAt (i);
      input.RemoveAt (i - 1);
      i--;
   }
}
Console.WriteLine (string.Join ("", input));