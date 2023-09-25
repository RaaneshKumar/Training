// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to conduct a voting contest.
// Given a string, the character which occurs the most number of times (votes) is the winner.
// If two characters have the same number of votes, the character which occured first is declared the winner.
// ---------------------------------------------------------------------------------------
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method gets a string from the user as input and displays the winner along with its number of votes</summary>
      static void Main () {
         Console.WriteLine ("Enter a string: ");
         string input = Console.ReadLine ().ToLower ();
         Console.WriteLine (input.Length == 0 ? "Empty string not accepted." : $"(Winner, Votes) = {VotingContest (input)}");
      }
      /// <summary>This method calculates which character has occured most number of times and declares the winner</summary>
      /// <param name="word"></param>
      /// <returns>Returns the winner and its number of votes in the form of a tuple</returns>
      static (char, int) VotingContest (string word) {
         List<char> sortedWordList = word.ToList ();
         sortedWordList.Sort ();
         char winner = ' ';
         int winnerVoteCount = 0, voteCount = 1;

         for (int i = 0; i < sortedWordList.Count - 1; i++) {
            if (sortedWordList[i] == sortedWordList[i + 1]) { //Checks the number of repetition of a character.
               voteCount++;
               if (i == sortedWordList.Count - 2)
                  if (voteCount > winnerVoteCount) { (winnerVoteCount, winner) = (voteCount, sortedWordList[i]); }
            } else {
               if (voteCount == winnerVoteCount)
                  if (word.IndexOf (sortedWordList[i]) < word.IndexOf (winner)) winner = sortedWordList[i]; //Checks which character occured first if two characters have same number of votes.
               if (voteCount > winnerVoteCount) { (winnerVoteCount, winner) = (voteCount, sortedWordList[i]); }
               voteCount = 1;
            }
         }
         return (winner, winnerVoteCount);
      }
      #endregion
   }
   #endregion
}