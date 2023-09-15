// Write a program to print a diamond using an asterisk
// The input can be the number of rows (half the height).

Console.Write ("Enter the number of rows: ");
if (!int.TryParse (Console.ReadLine (), out int n)) Console.WriteLine ("Invalid Input.");
else {
   int stars = 1, space = n + 1;
   for (int i = 1; i <= n + 1; i++) {
      Console.WriteLine (new string (' ', space) + new string ('*', stars));
      stars += 2; space -= 1;
   }
   stars -= 4;
   for (int i = 1; i <= n; i++) {
      Console.WriteLine (new string (' ', i + 1) + new string ('*', stars));
      stars -= 2; space += 1;
   }
}