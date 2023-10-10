// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to conduct a voting contest.
// Given a string, the character which occurs the most number of times (votes) is the winner.
// If two characters have the same number of votes, the character which occured first is declared the winner.
// ---------------------------------------------------------------------------------------
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method gets a valid string from the user as input and displays the winner along with its number of votes</summary>
      static void Main () {
         Console.Write ("Enter a string (Only alphabets are allowed): ");
         for (; ; ) {
            string input = Console.ReadLine ().Trim ().ToLower ();
            if (String.IsNullOrEmpty (input) || !input.All (char.IsLetter)) {
               Console.WriteLine ("Invalid Input.");
               continue;
            }
            Console.WriteLine ($"(Winner, Votes) = {GetWinnnerAndVotes (input)}");
            break;
         }
      }

      /// <summary>This method calculates which character has occured most number of times and declares the winner</summary>
      /// <param name="word"></param>
      /// <returns>Returns the winner and its number of votes in the form of a tuple</returns>
      static (char, int) GetWinnnerAndVotes (string word) {
         var a = word.GroupBy (x => x)
                     .OrderByDescending (x => x.Count ())
                     .First ();
         return (a.Key, a.Count ());
      }
      #endregion
   }
   #endregion
}