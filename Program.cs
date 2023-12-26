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
      static void Main () => Anagrams ();

      /// <summary>This method finds all anagrams and 
      /// sorts them based on the anagrams count from the words</summary>
      static void Anagrams () {
         var file = File.ReadLines ("C:/etc/words.txt");

         var anagrams = file.GroupBy (x => String.Join ("", x.Order ())) // Groups by anagrams
                            .Where (x => x.Count () > 1) // Removes all words having no anagrams
                            //.Select (x => x.Order ())
                            .OrderByDescending (x => x.Count());

         foreach (var item in anagrams)
            Console.WriteLine (item.Count() + " " + String.Join (" ", item));
      }
      #endregion
   }
   #endregion
}