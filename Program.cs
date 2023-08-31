// To check whether the given input is a palindrome or not

Console.Write ("Enter something to check whether it is a palindrome or not: ");
string userinput = Console.ReadLine (); string trimmedInput = userinput.Replace(" ","").ToLower ();
int n = trimmedInput.Length;
for (int i = 0; i <= n / 2; i++) {
   if (trimmedInput[i] != trimmedInput[n - 1 - i]) {
      Console.WriteLine ("The given input is not a palindrome");
      break;
   } else {if (i == n / 2) Console.WriteLine ("The given input is a palindrome."); }
}