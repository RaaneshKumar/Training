// Write a program to print a diamond using an asterisk
// The input can be the number of rows (half the height).

Console.Write ("Enter the number of rows: ");
int n = int.Parse (Console.ReadLine ());
int stars = 1; int space = n + 1;
for (int i = 1; i <= n + 1; i++) {
   Console.WriteLine (string.Concat (Enumerable.Repeat (" ", space)) + string.Concat (Enumerable.Repeat ("*", stars)));
   stars = stars + 2; space = space - 1;
}
stars = stars - 4;
for (int i = 1; i <= n; i++) {
   Console.WriteLine (string.Concat (Enumerable.Repeat (" ", i + 1)) + string.Concat (Enumerable.Repeat ("*", stars)));
   stars = stars - 2; space = space + 1;
}