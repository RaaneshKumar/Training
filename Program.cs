// To check whether the given input is a palindrome or not

Console.Write ("Enter something to check whether it is a palindrome or not: ");
string userinput = Console.ReadLine (); string trimmedInput = userinput.Replace (" ", "").ToLower ();
int length = trimmedInput.Length;
Console.WriteLine ($"The given input is {(IsPalindrome () ? "" : "not ")}a palindrome");

bool IsPalindrome () {
   for (int i = 0; i <= length / 2; i++)
      if (trimmedInput[i] != trimmedInput[length - 1 - i]) return false;
   return true;
}