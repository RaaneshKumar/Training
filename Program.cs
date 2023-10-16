// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to print a chess board using unicode values
// ---------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Chess Board</summary>
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>This method prints the chess board with all pieces</summary>
      static void Main () {
         OutputEncoding = Encoding.UTF8;

         // Black : 265F - pawn, 265C - rook, 265E - knight, 265D - bishop, 265B - queen, 265A - king
         // White : 2659 - pawn, 2656 - rook, 2658 - knight, 2657 - bishop, 2655 - queen, 2654 - king
         for (int i = 0; i < 10; i++) {
            switch (i) {
               case 0: PrintHLines (hLine, "\u250C", "\u252C", "\u2510"); break;
               case 1: PrintPieces (vLine, "\u265C", "\u265E", "\u265D", "\u265B", "\u265A"); break;
               case 2 or 4 or 7: PrintHLines (hLine, "\u251C", "\u253C", "\u2524"); break;
               case 3: PrintPawnsOrSpaces (vLine, "\u265F"); break;
               case 5:
                  for (int j = 0; j < 4; j++) {
                     PrintPawnsOrSpaces (vLine, " ");
                     PrintHLines (hLine, "\u251C", "\u253C", "\u2524");
                  }
                  break;
               case 6: PrintPawnsOrSpaces (vLine, "\u2659"); break;
               case 8: PrintPieces (vLine, "\u2656", "\u2658", "\u2657", "\u2655", "\u2654"); break;
               case 9: PrintHLines (hLine, "\u2514", "\u2534", "\u2518"); break;
            }
         }
      }

      /// <summary>Prints the horizontal lines</summary>
      /// <param name="hLine">Horizontal Line</param>
      /// <param name="start">Left joint</param>
      /// <param name="mid">Mid Joint</param>
      /// <param name="end">Right Joint</param>
      static void PrintHLines (string hLine, string start, string mid, string end)
         => WriteLine ($"{start}" + string.Concat (Enumerable.Repeat ($"{hLine}{hLine}{hLine}{mid}", 7))
                                                                    + $"{hLine}{hLine}{hLine}{end}");

      /// <summary>Prints the black and white pieces</summary>
      /// <param name="vLine">Vertical Line</param>
      /// <param name="rook"></param>
      /// <param name="knight"></param>
      /// <param name="bishop"></param>
      /// <param name="queen"></param>
      /// <param name="king"></param>
      static void PrintPieces (string vLine, string rook, string knight, string bishop, string queen, string king)
         => WriteLine ("{0} {1} {0} {2} {0} {3} {0} {4} {0} {5} {0} {3} {0} {2} {0} {1} {0}",
                                                   vLine, rook, knight, bishop, queen, king);

      /// <summary>Prints black and white pawns or empty spaces</summary>
      /// <param name="vLine">Vertical Line</param>
      /// <param name="pawn"></param>
      static void PrintPawnsOrSpaces (string vLine, string pawn)
         => WriteLine (string.Concat (Enumerable.Repeat ($"{vLine} {pawn} ", 8)) + $"{vLine}");
      #endregion

      #region Private -----------------------------------------------
      static string vLine = "\u2502", hLine = "\u2500";
      #endregion
   }
   #endregion
}