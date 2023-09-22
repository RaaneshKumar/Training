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
         Console.Write ("Enter the count(1-10) of random numbers to be displayed: ");

         if (!int.TryParse (Console.ReadLine (), out int count)) Console.WriteLine ("Invalid Input.");
         else {
            int[] numberSeries = new int[count];
            for (int i = 0; i < count; i++) {
               Random random = new Random ();
               numberSeries[i] = random.Next (1, 10);
            }
            foreach (int number in numberSeries) Console.Write (number + " ");

            Console.Write ("\nEnter the indices to be swapped: \nFirst Index: ");

            try {
               if (!int.TryParse (Console.ReadLine (), out int firstIndex)) Console.WriteLine ("Invalid Input.");
               else {
                  Console.Write ("Second Index: ");
                  if (!int.TryParse (Console.ReadLine (), out int secondIndex)) Console.WriteLine ("Invalid Input.");
                  else {
                     SwapIndices (numberSeries, firstIndex, secondIndex);
                     foreach (int number in numberSeries) Console.Write (number + " ");
                  }
               }
            } catch { Console.WriteLine ("One or two of the given indices were out of range."); }
         }
      }
      /// <summary>This method swaps the required indices in the series</summary>
      /// <param name="array"></param>
      /// <param name="index1"></param>
      /// <param name="index2"></param>
      /// <returns>Returns the series after swapping the indeces in the form of an array</returns>
      static int[] SwapIndices (int[] array, int index1, int index2) {
         (array[index1], array[index2]) = (array[index2], array[index1]);
         return array;
      }
      #endregion
   }
   #endregion
}