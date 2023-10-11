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
      /// <summary>This method gets valid user input and displays the sorted and swapped array</summary>
      static void Main () {
         char[] letters;
         string splCharInput;
         for (; ; ) {
            Console.Write ("Enter the characters (only alphabets) to be sorted (as string): ");
            letters = Console.ReadLine ().ToLower ().ToCharArray ();
            Console.Write ("Enter the special character to be swapped to the end: ");
            splCharInput = Console.ReadLine ();
            if (letters.Length == 0
                   || letters.Any (x => !char.IsLetter (x))
                   || splCharInput.Length != 1
                   || splCharInput.Any (x => !char.IsLetter (x))) {
               Console.Write ("Invalid Input.\n");
               continue;
            }
            break;
         }
         char splChar = splCharInput[0];
         Console.Write ("Enter the order of sorting (D for descending, anything else ascending): ");
         Console.Write ($"After Sorting and Swapping: {(Console.ReadLine () is "D" or "d" ?
            SortAndSwapSplChar (letters, splChar, 'd') : SortAndSwapSplChar (letters, splChar))}");
      }

      /// <summary>This method sorts and swaps the spl char to the end from the given array</summary>
      /// <param name="letters"></param>
      /// <param name="splChar"></param>
      /// <param name="order"></param>
      /// <returns>Returns sorted and swapped array as string</returns>
      static string SortAndSwapSplChar (char[] letters, char splChar, char order = 'a') {
         var sortedList = order == 'd' ? letters.Where (x => x != splChar).OrderDescending ().ToList ()
                                       : letters.Where (x => x != splChar).Order ().ToList ();
         sortedList.AddRange (Enumerable.Repeat (splChar, letters.Length - sortedList.Count));
         return String.Join ("", sortedList);
      }
      #endregion
   }
   #endregion
}