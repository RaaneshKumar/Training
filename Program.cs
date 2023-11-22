// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to solve the famous eight queens 
// On a standard chessboard 8 queens have to be placed so that no queen can attack any other.
// No two queens can be on the same row or column or diagonal.
// Part - 1: Find all possible solutions.
// Part - 2: Eliminate the identical solutions.
// A solution is identical to another if it is a 90, 180 or 270 degree rotation of the other
// or a vertical mirror image of the other.
// ---------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Eight Queens problem</summary>
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>This method prints all the required solutions</summary>
      static void Main () {
         WriteLine ("Press U to print unique solutions.\n" +
                    "Else print any other key to print all solutions.");
         bool isUnique = false;
         if (Console.ReadKey (true).Key is ConsoleKey.U) isUnique = true;
         PlaceQueen (isUnique, 0);
         PrintBoard ();
      }

      /// <summary>Prints the chessboard with queens on their positions</summary>
      static void PrintBoard () {
         OutputEncoding = Encoding.UTF8;
         for (int i = 0; i < sAllSlns.Count; i++) {
            CursorTop = 3; CursorLeft = 0; // Sets cursor to the top-left position
            WriteLine ($"Solution {i + 1} of {sAllSlns.Count}");
            var sln = sAllSlns[i];
            for (int j = 0; j < 9; j++) {
               if (j == 0) PrintHLines ("┌", "┬", "┐");
               else if (j == 8) {
                  PrintQueensOrSpaces (sln[j - 1]);
                  PrintHLines ("└", "┴", "┘");
               } else {
                  PrintQueensOrSpaces (sln[j - 1]);
                  PrintHLines ("├", "┼", "┤");
               }
            }
            ReadKey ();
         }

         /// <summary>Prints the grid lines of the chessboard</summary>
         static void PrintHLines (string start, string mid, string end)
            => WriteLine ($"{start}"
               + string.Concat (Enumerable.Repeat ($"───{mid}", 7)) + $"───{end}");

         /// <summary>Prints the queens or spaces in each box of the chessboard</summary>
         static void PrintQueensOrSpaces (int colPos) {
            for (int i = 0; i < 8; i++)
               Write ($"│ {(i == colPos ? "♕" : " ")} ");
            WriteLine ("│");
         }
      }

      /// <summary>Checks whether the solution is unique or not</summary>
      /// <param name="a">solution array</param>
      /// <returns>Returns true if the solution is unique</returns>
      static bool IsUnique (int[] a) {
         if (!IsMirror (a) && !IsRotatedImage (a)) return true;
         return false;

         /// <summary>Checks whether the solution is a mirror image of the previous solutions</summary>
         static bool IsMirror (int[] a) => IsDuplicate (a.Reverse ().ToArray ());

         /// <summary>Checks whether the solution is identical to the previous solutions</summary>
         static bool IsDuplicate (int[] a) => sAllSlns.Any (x => x.SequenceEqual (a));

         /// <summary>Checks whether the solution is a rotated image of the previous solutions</summary>
         static bool IsRotatedImage (int[] a) {
            int[] b = new int[8], c = new int[8];
            CopySolution (a, c);
            for (int i = 0; i < 3; i++) {
               Rotate90 (b, c);
               if (IsMirror (b) || IsDuplicate (b)) return true;
            }
            return false;

            /// <summary>Rotates the solution by 90 degrees</summary>
            static void Rotate90 (int[] b, int[] c) {
               for (int i = 0; i < 8; i++) b[c[i]] = 7 - i;
               CopySolution (b, c);
            }
         }
      }

      /// <summary>Checks whether the given position is safe to place the queen</summary>
      /// <param name="row">Row value of the position to be checked</param>
      /// <param name="col">Column value of the position to be checked</param>
      /// <returns>Returns true if the position is safe</returns>
      static bool IsSafe (int row, int col) {
         for (int prevRow = 0; prevRow < row; prevRow++) {
            var prevCol = sColumns[prevRow];
            if (col == prevCol ||
               Math.Abs (row - prevRow) == Math.Abs (col - prevCol)) return false;
         }
         return true;
      }

      /// <summary>Stores the safe positions of a solution in an array
      /// and stores all the solution arrays in a list</summary>
      /// <param name="row">Fixing the value of row to go through all columns of that row</param>
      static void PlaceQueen (bool isUnique, int row) {
         for (int col = 0; col < 8; col++) {
            if (IsSafe (row, col)) {
               sColumns[row] = col;
               var sln = sColumns.ToArray ();
               if (isUnique ? row == 7 && IsUnique (sln) : row == 7) sAllSlns.Add (sln);
               else PlaceQueen (isUnique, row + 1);
            }
         }
      }

      /// <summary>Creates a copy of the given array</summary>
      static void CopySolution (int[] original, int[] copy) {
         for (int i = 0; i < 8; i++) copy[i] = original[i];
      }
      #endregion

      #region Private -----------------------------------------------
      static int[] sColumns = new int[8];
      static List<int[]> sAllSlns = new ();
      #endregion
   }
   #endregion
}