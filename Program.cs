// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Find all the anagrams and sort them based on the anagrams count from the words in the word list.
// ---------------------------------------------------------------------------------------
namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Anagrams</summary>
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>This method finds all anagrams and 
      /// sorts them based on the anagrams count from the words</summary>
      static void Main () {
         var file = File.ReadLines ("C:/etc/words.txt");

         var anagrams = file.GroupBy (x => String.Join ("", x.Order ())) // Groups by anagrams
                            .Where (x => x.Count () > 1) // Removes all words having no anagrams
                            .OrderByDescending (x => x.Count ()); // Sorts based on the count of anagrams

         foreach (var item in anagrams) // Prints the anagrams with their count
            Console.WriteLine (item.Count () + " " + String.Join (" ", item));
      }
      #endregion
   }
   #endregion
}