//Pascal's Triangle


Console.Write ("Enter the number of rows: ");
if (int.TryParse (Console.ReadLine (), out int n)) {
   int value = 1;
   for (int i = 0; i < n; i++) {
      Console.Write (string.Concat (Enumerable.Repeat (" ", (n - i))));
      for (int j = 0; j <= i; j++) {
         if (j == 0) {
            Console.Write ("1 ");
            value = 1;
         } else {
            value = value * (i - j + 1) / j;
            Console.Write ($"{value} ");
         }
      }
      Console.WriteLine ();
   }
}else Console.WriteLine ("Invalid Input.");