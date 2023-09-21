// To check whether the given input is a palindrome or not

Console.Write ("Enter something to check whether it is a palindrome or not: ");
string userInput = Console.ReadLine (), trimmedInput = userInput.Replace (" ", "").ToLower ();
int length = trimmedInput.Length;
Console.WriteLine ((length > 0) ? $"The given input is {(IsPalindrome () ? "" : "not ")}a palindrome" : "Input cannot be empty");

bool IsPalindrome () {
   for (int i = 0; i <= length / 2; i++)
      if (trimmedInput[i] != trimmedInput[length - 1 - i]) return false;
   return true;
}