// To check whether the given input is a palindrome or not

Console.Write ("Enter something to check whether it is a palindrome or not: ");
string userinput = Console.ReadLine ();
string input = userinput.ToLower ();
List<char> order = new List<char> ();
for (int i = 0; i < input.Length; i++) if (input[i] != ' ') order.Add (input[i]);
List<char> reverseorder = Enumerable.Reverse (order).ToList ();
for (int i = 0; i < order.Count; i++) {
   if (order[i] == reverseorder[i]) {
      if (i == order.Count - 1) Console.WriteLine("The given input is a palindrome");
      continue;
   } else {
      Console.WriteLine ("The given input is not a palindrome.");
      break;
   }
}