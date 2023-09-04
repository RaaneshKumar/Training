Console.WriteLine (armstrong ());

string armstrong () {
   Console.Write ("Enter a number to check whether it is an armstrong number or not: ");
   if (int.TryParse(Console.ReadLine(), out int input)){
      int temp = input;
      double sum = 0;
      while (temp > 0) {
         double digit = temp % 10;
         sum += Math.Pow (digit, input.ToString ().Length);
         temp /= 10;
      }
      return (input == sum) ? "It is an armstrong number." : "It is not an armstrong number.";
   }else { return ("Invlaid Input."); }
}