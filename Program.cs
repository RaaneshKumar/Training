// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to Implement a file parser with state machine.
// Every file name has the components drive letter A to Z, colon, then one or more directory names
// followed by the actual file name which must always have an extension.
// Only uppercase letters allowed and all these components must be there.
// Also submit a state transition diagram for the above file name parser.
// ---------------------------------------------------------------------------------------
using static Training.FileParser.EState;

namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      #region Method ------------------------------------------------
      /// <summary>Gets the user input and prints the path details 
      /// if the file path is valid</summary>
      static void Main () {
         FileParser fileParser = new ();
         for (; ; ) {
            Console.Write (">");
            string input = Console.ReadLine ().Trim () + "~";
            if (input == "") break;
            var pathInfo = fileParser.GetFilePathData (input);
            if (fileParser.IsValidPath (input)) {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine ($"Valid File Path");
               Console.ResetColor ();
               Console.WriteLine ($"Drive : {pathInfo.drive}\n" +
                                  $"Folder: {pathInfo.folder}\n" +
                                  $"File  : {pathInfo.file}");
            } else {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine ("Invalid File Path!");
               Console.ResetColor ();
            }
         }
      }
      #endregion
   }

   /// <summary>File Parser</summary>
   public class FileParser {
      #region Method ------------------------------------------------
      /// <summary>Tells whether the path is valid or not</summary>
      public bool IsValidPath (string path) => GetFilePathData (path).isValid == true;

      /// <summary>Gets all the information about the given file path 
      /// using a state machine</summary>
      /// <param name="path">User Input</param>
      /// <returns>Returns whether the path is valid and the drive, folder and file names
      /// in the form of a tuple</returns>
      public (bool isValid, string drive, string folder, string file) GetFilePathData (string path) {
         path = path.Replace ('\\', '/');
         int slashFIdx = path.IndexOf ('/'), slashLIdx = path.LastIndexOf ('/');
         (bool isValid, string drive, string folder, string file) info = (false, "", "", "");
         EState state = A;
         Action none = () => { }, toDo;
         foreach (var ch in path) {
            (state, toDo) = (state, ch) switch {
               (A, >= 'A' and <= 'Z')
                 => (B, () => info.drive = path[0].ToString ()),
               (B, ':') => (C, none),
               (C, '/') => (D, none),
               (D or E, >= 'A' and <= 'Z') => (E, none),
               (E, '/')
                 => (F, () => info.folder = path.Substring (slashFIdx + 1, slashLIdx - slashFIdx - 1)),
               (F or G, >= 'A' and <= 'Z') => (G, none),
               (G, '/') => (F, none),
               (G, '.') => (H, none),
               (H or I, >= 'A' and <= 'Z') => (I, none),
               (I, '~')
                 => (END, () => {
                    info.file = path.Substring (slashLIdx + 1, path.Length - slashLIdx - 2);
                    info.isValid = true;
                 }
               ),
               _ => (ERROR, none)
            }; ;
            toDo ();
         }
         return info;
      }

      /// <summary>States of the file path.
      /// A state transition diagram is attached for clear understanding.
      /// See file://FileParser_BNF.jpg</summary>
      public enum EState { A, B, C, D, E, F, G, H, I, END, ERROR };
      #endregion
   }
   #endregion
}