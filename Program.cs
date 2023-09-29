// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to swap the indices of a given list of numbers
// A random series of numbers is displayed to the user and the user is asked to provide the two indices to be swapped.
// The number series after swapping the indices is displayed.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Swap Indices</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method prints a series of numbers based on the count given by the user and displays the updated series after swapping the user asked indices</summary>
      static void Main () {
         Console.WriteLine ("Enter the count (2-10) of random numbers to be displayed: ");
         int count = ValidInputCheck ();
         if (count < 2) Console.WriteLine ("You atleast need two numbers to swap indices.");
         else {
            int[] numberSeries = new int[count];
            for (int i = 0; i < count; i++) {
               Random random = new ();
               numberSeries[i] = random.Next (1, 10);
            }
            foreach (int number in numberSeries) Console.Write (number + " ");

            Console.WriteLine ("\nEnter the indices to be swapped: \nFirst Index: ");
            try {
               int firstIndex = ValidInputCheck ();
               Console.WriteLine ("Second Index: ");
               int secondIndex = ValidInputCheck ();
               SwapIndices (numberSeries, firstIndex, secondIndex);
               foreach (int number in numberSeries) Console.Write (number + " ");
            } catch { Console.WriteLine ("One or two of the given indices were out of range."); }
         }
      }

      /// <summary>Checks for valid input and converts it to int if valid</summary>
      /// <returns>Returns an the user input as int if valid</returns>
      static int ValidInputCheck () {
         for (int i = 0; ; i++) {
            if (!int.TryParse (Console.ReadLine (), out int a)) Console.WriteLine ("Invalid Input.");
            else return a;
         }
      }

      /// <summary>This method swaps the required indices in the series</summary>
      /// <param name="arr"></param>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns>Returns the series after swapping the indeces in the form of an array</returns>
      static int[] SwapIndices (int[] arr, int a, int b) {
         (arr[a], arr[b]) = (arr[b], arr[a]);
         return arr;
      }
      #endregion
   }
   #endregion
}