// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to sort and swap special characters.
// Given a char array, a special character S and sort order (default order Ascending), print sorted array keeping elements matching S at the last.
// ---------------------------------------------------------------------------------------
namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Sort and Swap Array</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method displays the sorted and swapped array</summary>
      static void Main () {
         string letters = GetValidInput ("Enter the characters (only alphabets) to be sorted (as string): ");
         char splChar = GetValidInput ("Enter the special character to be swapped to the end: ", false)[0];
         Console.Write ("Enter the order of sorting (D for descending, anything else ascending): ");
         Console.Write ($"After Sorting and Swapping: {(Console.ReadLine () is "D" or "d" ?
            SortAndSwapSplChar (letters, splChar, 'd') : SortAndSwapSplChar (letters, splChar))}");
      }

      /// <summary>This method sorts and swaps the spl char to the end from the given array</summary>
      /// <param name="letters">The sequence which has to be sorted and swapped</param>
      /// <param name="splChar">Spl char to be swapped</param>
      /// <param name="order">Ascending or descending</param>
      /// <returns>Returns sorted and swapped array as string</returns>
      static string SortAndSwapSplChar (string letters, char splChar, char order = 'a') {
         var sortedList = order == 'd' ? letters.Where (x => x != splChar).OrderDescending ().ToList ()
                                       : letters.Where (x => x != splChar).Order ().ToList ();
         sortedList.AddRange (Enumerable.Repeat (splChar, letters.Length - sortedList.Count));
         return String.Join ("", sortedList);
      }

      /// <summary>This method gets the valid input from the user</summary>
      /// <param name="command">Asks user the input needed</param>
      /// <param name="isLenAlso">Passed when input is checked for length condition</param>
      /// <returns>Reurns the valid Input</returns>
      static string GetValidInput (string command, bool isLenAlso = true) {
         for (; ; ) {
            Console.Write (command);
            string input = Console.ReadLine ().Trim ().ToLower ();
            if (String.IsNullOrEmpty (input) || input.Any (x => !char.IsLetter (x))) { Console.WriteLine ("Invalid Input."); continue; }
            if (!isLenAlso && input.Length != 1) { Console.WriteLine ("Invalid Input."); continue; }
            return input;
         }
      }
      #endregion
   }
   #endregion
}