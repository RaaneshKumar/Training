namespace Training {
   internal class Program {
      static void Main (string[] args) {
         if (args.Length > 0) {
            if (!int.TryParse (args[0], out int input)) Console.WriteLine ("Invalid Input.");
            else Console.WriteLine (NthArmstrong (input));
         } else Console.WriteLine (Armstrong ());
      }
      static int NthArmstrong (int input) {
         int count = 0;
         for (int i = 1; ; i++) {
            double sum = 0;
            int iDuplicate = i;
            double length = i.ToString ().Length;
            while (iDuplicate > 0) {
               double digit = iDuplicate % 10;
               sum += Math.Pow (digit, length);
               iDuplicate /= 10;
            }
            if (sum == i) count++;
            if (count == input) return i;
         }
      }
      static string Armstrong () {
         Console.Write ("Enter a number to check whether it is an armstrong number or not: ");
         if (!int.TryParse (Console.ReadLine (), out int input)) return "Invlaid Input.";
         else {
            int inputCopy = input;
            double sum = 0;
            int length = input.ToString ().Length;
            while (inputCopy > 0) {
               double digit = inputCopy % 10;
               sum += Math.Pow (digit, length);
               inputCopy /= 10;
            }
            return $"{input} is{((input == sum) ? "" : " not")} an armstrong number.";
         }
      }
   }
}