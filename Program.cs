// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to implement double.Parse method that takes a string and returns a double.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Double.Parse</summary>
   public class DoubleParse {
      #region Method ------------------------------------------------
      /// <summary>Gets the user input and prints the desired output</summary>
      static void Main () {
         Console.Write ("Enter a value to be converted into double: ");
         string input = Console.ReadLine ().ToLower ();
         Console.WriteLine (IsValid (input) ? Parse (input) : "Invalid Input");
      }

      /// <summary>Checks if the user input is valid</summary>
      /// <param name="s">user input</param>
      /// <returns>Returns true if the input is valid</returns>
      public static bool IsValid (string s) {
         var validChars = new char[4] { '+', '-', '.', 'e' };
         if (s.Any (x => !validChars.Contains (x)             // Checks if all are valid characters.
                      && !char.IsDigit (x))) return false;
         if (s[0] == 'e' || s[^1] is 'e') return false;       // Checks if first and last characters are valid.
         if ((s.Count (x => x == '.') > 1) ||                 // Checks if multiple decimal points are present.
             (s.Count (x => x == 'e') > 1)) return false;     // Checks if multiple E's are present.
         if (!ExpressionCheck ('+')                           // Checks if '+' and '-' are in their valid positions.
             || !ExpressionCheck ('-')) return false;
         if (!char.IsDigit (s[s.IndexOf ('e') - 1])           // Checks if values before or after 'e' is valid.
            || s[^2] == 'e' && !char.IsDigit (s[^1])) return false;
         return true;

         /// <summary>Checks if the '+' or '-' in user input is unary</summary>
         /// <param name="a">char '+' or '-'</param>
         bool ExpressionCheck (char a) {
            switch (s.Count (x => x == a)) {
               case 1:
                  if (s[0] != a && s[s.IndexOf ('e') + 1] != a) return false;
                  break;
               case 2:
                  if (ContainsE (s) && (s[0] != a || s[s.IndexOf ('e') + 1] != a)) return false;
                  break;
               case > 2: return false;
            }
            return true;
         }
      }

      /// <summary>Coverts the string to a double based on the type of input</summary>
      /// <returns>Returns the converted double value</returns>
      public static double Parse (string s) {
         if (ContainsE (s)) return GetSolvedE (s);
         if (!ContainsPoint (s)) return int.Parse (s); // Means an integer
         return GetSolvedPoint (s);
      }

      /// <summary>Checks if the input has 'e' in it</summary>
      /// <returns>Returns true if 'e' is present</returns>
      static bool ContainsE (string s) => s.Any (x => x == 'e');

      /// <summary>Converts the string to double if E is present</summary>
      /// <returns>Returns the converted double value</returns>
      static double GetSolvedE (string s) {
         double firstPart, secPart;
         string[] parts = s.Split ('e');
         firstPart = ContainsPoint (parts[0]) ? GetSolvedPoint (parts[0]) : int.Parse (parts[0]);
         secPart = ContainsPoint (parts[1]) ? GetSolvedPoint (parts[1]) : int.Parse (parts[1]);
         return firstPart * Math.Pow (10, secPart);
      }

      /// <summary>Checks if the input has a decimal point in it</summary>
      /// <returns>Returns true if decimal point is present</returns>
      static bool ContainsPoint (string s) => s.Any (x => x == '.');

      /// <summary>Converts the string to double if decimal point is present</summary>
      /// <returns>Returns the converted double value</returns>
      static double GetSolvedPoint (string s) {
         string[] parts = s.Split ('.');
         int integral = 0, fractional = 0;
         if (s[0] == '.' ||                       // Checks for values like .2 and -.2
             (parts[0] == "-" && s[1] == '.')) fractional = int.Parse (parts[1]);
         else if (s[^1] == '.') integral = int.Parse (parts[0]); // Checks for values ending with a decimal point.
         else { integral = int.Parse (parts[0]); fractional = int.Parse (parts[1]); }
         double parsedDouble = Math.Abs (integral) + (fractional / Math.Pow (10, parts[1].Length));
         return s[0] == '-' ? -parsedDouble : parsedDouble;
      }
      #endregion
   }
   #endregion
}