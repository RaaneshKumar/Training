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
         Console.Write ("Enter the characters to be sorted (as string): ");
         char[] letters = Console.ReadLine ().ToCharArray ();
         Console.Write ("Enter the special character to be swapped to the end: ");
         string splCharInput = Console.ReadLine ();
         if (splCharInput.Length != 1) {
            Console.Write ("Invalid Input.");
            return;
         }
         char splChar = splCharInput.ToCharArray ()[0];
         Console.Write ("Enter the order of sorting (D for descending, anything else ascending): ");
         Console.Write ($"After Sorting and Swapping: {(Console.ReadLine () is "D" or "d" ? SortAndSwapSplChar (letters, splChar, 'd') : SortAndSwapSplChar (letters, splChar))}");
      }

      /// <summary>This method sorts the char array in desired order and swaps the spl char to the end</summary>
      /// <param name="letters"></param>
      /// <param name="splChar"></param>
      /// <param name="order"></param>
      /// <returns>Returns sorted and swapped array as string</returns>
      static string SortAndSwapSplChar (char[] letters, char splChar, char order = 'a') {
         var list = letters.ToList ();
         int count = list.Count (x => x == splChar);
         list.RemoveAll (x => x == splChar);
         if (order == 'd') list = list.OrderDescending ().ToList ();
         else list.Sort ();
         for (int i = 0; i < count; i++) list.Add (splChar);
         return String.Join ("", list);
      }
      #endregion
   }
   #endregion
}