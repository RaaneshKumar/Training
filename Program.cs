// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Tic Tac Toe Game
// Player 1 is X and Player 2 is O.
// User Input must be 1 to 9 for its corresponding grid positions.
// ---------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      #region Method ------------------------------------------------
      static void Main () {
         CursorVisible = false;
         PrintGrid ();
         char letter;
         List<int> player1 = new (), player2 = new ();

         for (int i = 1; i <= 9; i++) {
            var key = Console.ReadKey (true);

            while (!Char.IsDigit (key.KeyChar)) key = Console.ReadKey (true);
            if (i % 2 == 0) {
               letter = 'O';
               player2.Add ((int)key.KeyChar);
            } else {
               letter = 'X';
               player1.Add ((int)key.KeyChar);
            }
            switch (key.KeyChar) {
               case '1': CursorLeft = 1; CursorTop = 4; break;
               case '2': CursorLeft = 5; CursorTop = 4; break;
               case '3': CursorLeft = 9; CursorTop = 4; break;
               case '4': CursorLeft = 1; CursorTop = 2; break;
               case '5': CursorLeft = 5; CursorTop = 2; break;
               case '6': CursorLeft = 9; CursorTop = 2; break;
               case '7': CursorLeft = 1; CursorTop = 0; break;
               case '8': CursorLeft = 5; CursorTop = 0; break;
               case '9': CursorLeft = 9; CursorTop = 0; break;
               default: i--; break;
            }
            if (key.KeyChar != '0') Console.Write (letter);

            // Checks if the game is over
            List<int> list = i % 2 == 0 ? player2 : player1;
            foreach (var item in list) {
               if ((list.Contains (item + 1) && list.Contains (item + 2))
                  || (list.Contains (item + 3) && list.Contains (item + 6))
                  || (list.Contains (item + 2) && list.Contains (item + 4))
                  || (list.Contains (item + 4) && list.Contains (item + 8))) {
                  CursorTop = 6; CursorLeft = 0;
                  WriteLine ($"Player{(i % 2 == 0 ? "2" : "1")} won");
                  i = 9;
               }
            }
         }
      }

      static void PrintGrid () {
         Console.OutputEncoding = new UnicodeEncoding ();
         string dividerLine = "───┼───┼───"; //253C
         for (int i = 1; i <= 5; i++) {
            switch (i) {
               case 2 or 4: Console.WriteLine (dividerLine); break;
               default: Console.WriteLine ($"   \u2502   \u2502   "); break;
            }
         }
      }
      #endregion
   }
   #endregion
}