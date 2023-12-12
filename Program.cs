// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Construct an expression evaluator and implement unary minus for the expression evaluator
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Unary minus for expression evaluator</summary>
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>Gets the user input and prints the evaluated result</summary>
      static void Main () {
         Evaluator evaluator = new ();
         for (; ; ) {
            Console.Write (">");
            string input = Console.ReadLine ().Trim ().ToLower ();
            if (input == "") break;
            try {
               double result = evaluator.Evaluate (input);
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine (Math.Round (result, 10));
               Console.ResetColor ();
            } catch (Exception e) {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine (e.Message);
               Console.ResetColor ();
            }
         }
      }
      #endregion
   }
   #endregion
}