// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// There is a secret 5-letter word you have to guess. 
// Use upperase letters.
// You type in your guess, and different letters in your guess are colored red, green or yellow:
// Red: The given letter is not in the secret word
// Yellow: The letter is found in the word, but not in this position
// Green: The letter is found in the word, and is in the correct position
// You have 6 tries in which the word must be guessed.
// The position at which your next letter will be placed will be printed in circle.
// When you have typed in 5 letters, press ENTER to submit that word. 
// A word is not automatically submitted when you type in 5 letters. You have to press ENTER.
// This gives you a chance to go back and correct some of the letters.
// You can press left-arrow or backspace to ‘delete’ the last character you typed.
// ---------------------------------------------------------------------------------------

using System.Text;
using static System.Console;
using static Training.Program.EColor;

namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Wordle</summary>
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>Launches the game and keeps getting user input</summary>
      static void Main () {
         OutputEncoding = new UnicodeEncoding ();
         CursorVisible = false; WindowWidth = 70; WindowHeight = 35;

         for (char letter = 'A'; letter <= 'Z'; letter++) mKeyboard[letter] = White;
         Random random = new ();
         mWordleWord = sWords[random.Next (sWords.Length - 1)];

         DisplayInitialPos ();
         DisplayCircle ();
         for (; ; ) {
            (mKeyColumn, mKeyRow) = GetCursorPosition (); // Gets the position of the key to be pressed.
            ConsoleKeyInfo key = ReadKey ();
            if (key.Key == ConsoleKey.Escape) { PrintMessage (Black, null); break; }
            UpdateGameState (key);
            if (mUserWord == mWordleWord && CursorLeft == sColumn) {
               PrintMessage (Green, $"You won. You guessed it in {mKeyRow / sRowGap - 1} tries"); // When the word is found.
               break;
            } else if (mKeyRow / sRowGap > 6) { // When the word is not found in 6 tries.
               PrintMessage (Red, $"You lost. The correct word is {mWordleWord}");
               break;
            }
         }
      }

      /// <summary>This method updates the game state after each key pressed</summary>
      /// <param name="key">The key pressed by the user</param>
      static void UpdateGameState (ConsoleKeyInfo key) {
         mUserWord = string.Join ("", mLetters);
         Dictionary<int, int> letterPositions = new () {
            [20] = 0, [25] = 1, [30] = 2, [35] = 3, [40] = 4  // CursorLeft positions as keys and indices as values
         };

         if (key.KeyChar is >= 'A' and <= 'Z')
            mLetters[letterPositions[CursorLeft - 1]] = key.KeyChar;

         if (mKeyColumn >= sColumnMaxLimit) SetCursorPosition (sColumnMaxLimit, mKeyRow);

         switch (key.Key) {
            case ConsoleKey.Backspace or ConsoleKey.LeftArrow:
               if (mKeyColumn > sColumn) {
                  SetCursorPosition (mKeyColumn, mKeyRow); // Seting the current position to dot.
                  Write (sDot);
                  SetCursorPosition (mKeyColumn -= 5, mKeyRow); // Moving back to previous position.
                  Write (sCircle);
                  CursorLeft -= 1;
               } else SetCursorPosition (sColumn, mKeyRow); // Not allowing backspaces before the wordle area.
               break;

            case ConsoleKey.Enter:
               if (sValidWords.Any (x => x == mUserWord)) { // Checks if the user given word is a validword.
                  SetCursorPosition (sColumn, mKeyRow);
                  for (int i = 0; i < 5; i++) {
                     if (mLetters[i] == mWordleWord[i]) PrintEntry (Green, mLetters[i]); // Correct position.
                     else {
                        if (mWordleWord.Contains (mLetters[i]))
                           PrintEntry (Yellow, mLetters[i]); // Wrong position.
                        else PrintEntry (Red, mLetters[i]);  // Letter is not present.
                     }
                     Write (sSpaces);
                  }
                  ResetColor ();
                  DisplayKeyboard ();
                  PrintInvalid (Black); // Since this is a valid word.
                  SetCursorPosition (sColumn, mKeyRow += sRowGap); // Sets cursor to the next row.
                  if (mKeyRow / sRowGap <= 6) DisplayCircle (); // Checks if tries exceeded 6 times.
                  Array.Clear (mLetters); // Clears the array for next user word.
               } else PrintInvalid (Yellow);
               break;
         }

         if (letterPositions.ContainsKey (CursorLeft - 1)) { 
            Write (sSpaces); // Prints spaces after valid key pressed at valid position
            DisplayCircle ();
         }

         // Prints the letters of the user word in corresponding colors.
         void PrintEntry (EColor color, char entry) { ChangeConsoleColor (color); Write (entry); }

         // Prints invalid message in corresponding color.
         void PrintInvalid (EColor color) {
            PrintMessage (color, $"Invalid word");
            SetCursorPosition (mKeyColumn, mKeyRow);
         }
      }

      /// <summary>Displays circle at the immediate user key positions</summary>
      static void DisplayCircle () { Write (sCircle); CursorLeft -= 1; }

      /// <summary>Displays the initial position of the wordle game</summary>
      static void DisplayInitialPos () {
         (int mCurrentColumn, int mCurrentRow) = (sColumn, sRow);
         SetCursorPosition (mCurrentColumn, mCurrentRow);
         for (int i = 0; i < 6; i++) {
            WriteLine (String.Concat (Enumerable.Repeat (sDot + sSpaces, 5)));
            SetCursorPosition (mCurrentColumn, mCurrentRow += sRowGap); // Having three row gaps between lines.
         }
         ChangeConsoleColor (DarkGray);
         SetCursorPosition (sKeyBoardColumn, mCurrentRow); // To print the dividing line.
         WriteLine (new string ('~', sColumnMaxLimit));
         ResetColor ();
         DisplayKeyboard ();
         SetCursorPosition (sColumn, sRow); // Setting back to initial position.
      }

      /// <summary>Displays the keyboard with letters in corresponding colors</summary>
      static void DisplayKeyboard () {
         (int mCurrentColumn, int mCurrentRow) = (sKeyBoardColumn, sKeyBoardRow);
         SetCursorPosition (mCurrentColumn, mCurrentRow);
         for (int i = 0; i < 5; i++) { // Setting the corresponding colors for letters.
            char letter = mLetters[i];
            if (letter == mWordleWord[i])
               mKeyboard[letter] = Green;
            else if (mWordleWord.Contains (letter) && mKeyboard[letter] != Green)
               mKeyboard[letter] = Yellow;
            else if (mLetters.Contains (letter) && !mWordleWord.Contains (letter))
               mKeyboard[letter] = Red;
         }

         for (char letter = 'A'; letter <= 'Z'; letter++) { // Having 9 alphabets in a row.
            if (letter is 'J' or 'S') {
               WriteLine ();
               SetCursorPosition (sKeyBoardColumn, mCurrentRow += 2); // Having keyboard row gap as 2 lines.
            }
            ChangeConsoleColor (mKeyboard[letter]);
            Write (letter + sSpaces);
         }
         ResetColor ();
         WriteLine ();
      }

      /// <summary>Prints the message in corresponding color</summary>
      /// <param name="color">Color of the message</param>
      /// <param name="message">The message to be printed</param>
      static void PrintMessage (EColor color, string message) {
         SetCursorPosition (sKeyBoardColumn, sRow * 10);
         ChangeConsoleColor (color);
         Write (color == Yellow ? $"{message,25}" : $"{message,40}");
         ResetColor ();
      }

      /// <summary>Changes the ForegroundColor as required</summary>
      /// <param name="color">Color to which the ForegroundColor must be changed</param>
      static void ChangeConsoleColor (EColor color) {
         ForegroundColor = color switch {
            Green => ConsoleColor.Green,
            DarkGray => ConsoleColor.DarkGray,
            Red => ConsoleColor.Red,
            Yellow => ConsoleColor.Yellow,
            White => ConsoleColor.White,
            _ => ConsoleColor.Black,
         };
      }
      #endregion

      #region Enum --------------------------------------------------
      public enum EColor { DarkGray, Red, Green, Yellow, White, Black }
      #endregion

      #region Members -----------------------------------------------
      static char[] mLetters = new char[5]; // Entry characters
      static int mKeyColumn, mKeyRow; // Position at which a key is pressed.
      static string mWordleWord, mUserWord; // Random word to be picked by computer, user typed word respectively.
      static Dictionary<char, EColor> mKeyboard = new (); // Keyboard letters and their corresponding colors
      #endregion

      #region Private -----------------------------------------------
      static char sDot = '\u00b7', sCircle = '\u25cc';
      static string sSpaces = "    "; // 4 spaces
      static string[] sWords = File.ReadAllLines ("C:\\WorkGIT\\Training\\puzzle.txt"); // Wordle words
      static string[] sValidWords = File.ReadAllLines ("C:\\WorkGIT\\Training\\dict.txt"); // Valid English Words
      static int sRow = 3, sColumn = 20; // For displaying the initial position of the game.
      static int sKeyBoardRow = 23, sKeyBoardColumn = 10; // Co-ordinates of the initial position of the keyboard.
      static int sRowGap = 3, sColumnMaxLimit = 40; // Lines between rows, max column limit of game area respectively.
      #endregion
   }
   #endregion
}