// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to print a chess board using unicode values
// ---------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training {
   #region class Program ------------------------------------------------------------------------
   /// <summary>Chess Board</summary>
   internal class Program {
      #region Method ----------------------------------------------
      /// <summary>This method prints the chess board with all pieces</summary>
      static void Main () {
         OutputEncoding = Encoding.UTF8;
         string blRook = "\u265C", blKnight = "\u265E", blBishop = "\u265D", vLine = "\u2502",
                whRook = "\u2656", whKnight = "\u2658", whBishop = "\u2657", hLine = "\u2500";
         // Black : 265F - pawn, 265C - rook, 265E - knight, 265D - bishop, 265B - queen, 265A - king
         // White : 2659 - pawn, 2656 - rook, 2658 - knight, 2657 - bishop, 2655 - queen, 2654 - king

         for (int i = 0; i < 10; i++) {
            switch (i) {
               case 0: WriteLine ("\u250C" + string.Concat (Enumerable.Repeat ($"{hLine}{hLine}{hLine}\u252C", 7)) + $"{hLine}{hLine}{hLine}\u2510"); continue;
               case 1: WriteLine ("{0} {1} {0} {2} {0} {3} {0} \u265B {0} \u265A {0} {3} {0} {2} {0} {1} {0}", vLine, blRook, blKnight, blBishop); continue;
               case 2 or 4 or 7: WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ($"{hLine}{hLine}{hLine}\u253C", 7)) + $"{hLine}{hLine}{hLine}\u2524"); continue;
               case 3: WriteLine (string.Concat (Enumerable.Repeat ($"{vLine} \u265F ", 8)) + $"{vLine}"); continue;
               case 5:
                  for (int j = 0; j < 4; j++) {
                     WriteLine (string.Concat (Enumerable.Repeat ($"{vLine}   ", 8)) + $"{vLine}");
                     WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ($"{hLine}{hLine}{hLine}\u253C", 7)) + $"{hLine}{hLine}{hLine}\u2524");
                  }
                  continue;
               case 6: WriteLine (string.Concat (Enumerable.Repeat ($"{vLine} \u2659 ", 8)) + $"{vLine}"); continue;
               case 8: WriteLine ("{0} {1} {0} {2} {0} {3} {0} \u2655 {0} \u2654 {0} {3} {0} {2} {0} {1} {0}", vLine, whRook, whKnight, whBishop); continue;
               case 9: WriteLine ("\u2514" + string.Concat (Enumerable.Repeat ($"{hLine}{hLine}{hLine}\u2534", 7)) + $"{hLine}{hLine}{hLine}\u2518"); continue;
            }
         }
      }
      #endregion
   }
   #endregion
}