// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// There is a secret 5-letter word you have to guess. 
// Use uppercase letters.
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

using System.Reflection;
using System.Text;
using static System.Console;
using static System.ConsoleKey;
using static Training.Program.EColor;

namespace Training {
   #region class Program --------------------------------------------------------------------------
   /// <summary>Wordle</summary>
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>Launches the game and keeps getting user input</summary>
      static void Main () {
         OutputEncoding = new UnicodeEncoding ();
         CursorVisible = false;
         WindowHeight = LargestWindowHeight;

         ReadFile ("puzzle");
         ReadFile ("dict");
         for (char letter = 'A'; letter <= 'Z'; letter++) mKeyboard[letter] = White;
         Random random = new ();
         mWordleWord = sWords[random.Next (sWords.Count - 1)];

         DisplayInitialPos ();
         DisplayCircle ();
         for (; ; ) {
            (mKeyColumn, mKeyRow) = GetCursorPosition (); // Gets the position of the key to be pressed.
            ConsoleKeyInfo key = ReadKey (true);
            if (key.Key == Escape) { PrintMessage (Black, null); break; }
            if (Char.IsLetter (key.KeyChar) || key.Key is Escape or Backspace or Enter or LeftArrow) {
               UpdateGameState (key);
               if (mUserWord == mWordleWord && CursorLeft == sColumn) {
                  PrintMessage (Green, $"You found the word in {mKeyRow / sRowGap - 1} tries"); // When the word is found.
                  break;
               } else if (mKeyRow / sRowGap > 6) { // When the word is not found in 6 tries.
                  PrintMessage (Yellow, $"Sorry - the word was {mWordleWord}");
                  break;
               }
            }
         }
      }

      /// <summary>This method updates the game state after each key pressed</summary>
      /// <param name="key">The key pressed by the user</param>
      static void UpdateGameState (ConsoleKeyInfo key) {
         mUserWord = string.Join ("", mLetters);
         char entry = Char.ToUpper (key.KeyChar);
         if (entry is >= 'A' and <= 'Z') {
            if (mLetterCount == 5) return; // Prevents changing the fifth letter without pressing backspace.
            mLetters[mLetterCount] = entry;
            PrintEntry (White, entry);
            mLetterCount++;
            if (mLetterCount < 5) {
               Write (sSpaces); // Prints spaces after valid key pressed at valid position
               DisplayCircle ();
            }
            int columnMaxLimit = sColumn + 20;
            if (mKeyColumn >= columnMaxLimit) SetCursorPosition (columnMaxLimit, mKeyRow);
         }

         switch (key.Key) {
            case Backspace or LeftArrow:
               if (mKeyColumn > sColumn) {
                  if (mLetterCount == 5) {
                     SetCursorPosition (mKeyColumn, mKeyRow);
                     DisplayCircle ();
                  } else {
                     SetCursorPosition (mKeyColumn, mKeyRow); // Seting the current position to dot.
                     Write (sDot);
                     SetCursorPosition (mKeyColumn -= 5, mKeyRow); // Moving back to previous position.
                     DisplayCircle ();
                  }
               } else SetCursorPosition (sColumn, mKeyRow); // Not allowing backspaces before the wordle area.
               if (mLetterCount > 0) mLetters[--mLetterCount] = default;
               break;
            case Enter:
               if (mLetterCount != 5) { SetCursorPosition (mKeyColumn, mKeyRow); return; }
               if (sValidWords.Any (x => x == mUserWord)) { // Checks if the user given word is a validword.
                  SetCursorPosition (sColumn, mKeyRow);
                  for (int i = 0; i < 5; i++) {
                     if (mLetters[i] == mWordleWord[i]) PrintEntry (Green, mLetters[i]); // Correct position.
                     else {
                        if (mWordleWord.Contains (mLetters[i]))
                           PrintEntry (Blue, mLetters[i]); // Wrong position.
                        else PrintEntry (DarkGray, mLetters[i]);  // Letter is not present.
                     }
                     Write (sSpaces);
                  }
                  ResetColor ();
                  DisplayKeyboard ();
                  PrintInvalid (Black); // Since this is a valid word.
                  SetCursorPosition (sColumn, mKeyRow += sRowGap); // Sets cursor to the next row.
                  if (mKeyRow / sRowGap <= 6) DisplayCircle (); // Checks if tries exceeded 6 times.
                  Array.Clear (mLetters); // Clears the array for next user word.
                  mLetterCount = 0;
               } else PrintInvalid (Yellow);
               break;
         }

         // Prints the letters of the user word in corresponding colors.
         void PrintEntry (EColor color, char entry) { SetConsoleColor (color); Write (entry); }

         // Prints invalid message in corresponding color.
         void PrintInvalid (EColor color) {
            PrintMessage (color, $"   {mUserWord} is not a word   ");
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
         SetConsoleColor (DarkGray);
         SetCursorPosition (sColumn - 10, mCurrentRow); // To print the dividing line.
         WriteLine (new string ('~', 40));
         ResetColor ();
         DisplayKeyboard ();
         SetCursorPosition (sColumn, sRow); // Setting back to initial position.
      }

      /// <summary>Displays the keyboard with letters in corresponding colors</summary>
      static void DisplayKeyboard () {
         int keyboardColumn = sColumn - 10;
         (int mCurrentColumn, int mCurrentRow) = (keyboardColumn, sRow + 20);
         SetCursorPosition (mCurrentColumn, mCurrentRow);
         for (int i = 0; i < 5; i++) { // Setting the corresponding colors for letters.
            char letter = mLetters[i];
            bool isCorrectLetter = mWordleWord.Contains (letter);
            if (letter == mWordleWord[i])
               mKeyboard[letter] = Green;
            else if (isCorrectLetter && mKeyboard[letter] != Green)
               mKeyboard[letter] = Blue;
            else if (mLetters.Contains (letter) && !isCorrectLetter)
               mKeyboard[letter] = DarkGray;
         }

         for (char letter = 'A'; letter <= 'Z'; letter++) { // Having 9 alphabets in a row.
            if (letter is 'J' or 'S') {
               WriteLine ();
               SetCursorPosition (keyboardColumn, mCurrentRow += 2); // Having keyboard row gap as 2 lines.
            }
            SetConsoleColor (mKeyboard[letter]);
            Write (letter + sSpaces);
         }
         ResetColor ();
         WriteLine ();
      }

      /// <summary>Prints the message in corresponding color</summary>
      /// <param name="color">Color of the message</param>
      /// <param name="message">The message to be printed</param>
      static void PrintMessage (EColor color, string message) {
         SetCursorPosition (sColumn - 10, sRow * 10);
         SetConsoleColor (color);
         Write (color == Yellow ? $"{message,33}" : $"{message,35}");
         ResetColor ();
      }

      /// <summary>Changes the ForegroundColor as required</summary>
      /// <param name="color">Color to which the ForegroundColor must be changed</param>
      static void SetConsoleColor (EColor color) {
         ForegroundColor = color switch {
            Green => ConsoleColor.Green,
            DarkGray => ConsoleColor.DarkGray,
            Yellow => ConsoleColor.Yellow,
            White => ConsoleColor.White,
            Blue => ConsoleColor.Blue,
            _ => ConsoleColor.Black,
         };
      }

      /// <summary>This method reads the given file and stores the lines in the corresponding list</summary>
      /// <param name="file">File name</param>
      static void ReadFile (string file) {
         var stream = Assembly.GetExecutingAssembly ().GetManifestResourceStream ($"Training.data.{file}.txt");
         using var reader = new StreamReader (stream);
         while (!reader.EndOfStream)
            (file == "puzzle" ? sWords : sValidWords).Add (reader.ReadLine ());
      }
      #endregion

      #region Enum --------------------------------------------------
      public enum EColor { DarkGray, Green, Yellow, White, Black, Blue }
      #endregion

      #region Private -----------------------------------------------
      static char[] mLetters = new char[5]; // Entry characters
      static int mKeyColumn, mKeyRow, mLetterCount = 0; // Position at which a key is pressed.
      static string mWordleWord, mUserWord; // Random word to be picked by computer, user typed word respectively.
      static Dictionary<char, EColor> mKeyboard = new (); // Keyboard letters and their corresponding colors

      static char sDot = '\u00b7', sCircle = '\u25cc';
      static string sSpaces = "    "; // 4 spaces
      static List<string> sWords = new (), sValidWords = new (); // Wordle words and Valid English words.
      static int sRow = 3, sColumn = WindowWidth / 2 - 10, // For displaying the initial position of the game.
                 sRowGap = 3; // Lines between rows, max column limit of game area respectively.
      #endregion
   }
   #endregion
}