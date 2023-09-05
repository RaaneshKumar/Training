namespace Training {
   internal class Program {
      static void Main (string[] args) {
         if (int.TryParse (args[0], out int input)) {
            int count = 0;
            for (int i = 1; ; i++) {
               double sum = 0;
               int temp = i;
               double len = i.ToString ().Length;
               while (temp > 0) {
                  double digit = temp % 10;
                  sum += Math.Pow (digit, len);
                  temp /= 10;
               }
               if (sum == i) count++;
               if (count == input) {
                  Console.WriteLine (i);
                  break;
               }
            }
         } else Console.WriteLine ("Invalid Input.");
      }
   }
} 