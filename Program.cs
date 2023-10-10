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
         Console.Write ("Enter the count (2 - 10) of random numbers to be displayed: ");
         int count = GetValidNumber ();
         if (count < 2 || count > 10) {
            Console.Write ("Count must be between 2 to 10.");
            return;
         }
         int[] numberSeries = new int[count];
         for (int i = 0; i < count; i++) { //Creates a random number series of given count.
            Random random = new ();
            numberSeries[i] = random.Next (1, 10);
         }
         Console.Write ("Before Swapping: ");
         foreach (int number in numberSeries) Console.Write (number + " ");

         Console.Write ("\nEnter the indices to be swapped (Range lies between 0 to count - 1): \nFirst Index: ");
         try {
            int idx1 = GetValidNumber ();
            Console.Write ("Second Index: ");
            int idx2 = GetValidNumber ();
            SwapIndices (numberSeries, idx1, idx2);
            Console.Write ("After Swapping: ");
            foreach (int number in numberSeries) Console.Write (number + " ");
         } catch (IndexOutOfRangeException) { Console.Write ("One or two of the given indices were out of range."); }
      }

      /// <summary>Checks for valid input and converts it to int if valid</summary>
      /// <returns>Returns an the user input as int if valid</returns>
      static int GetValidNumber () {
         for (; ; ) {
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