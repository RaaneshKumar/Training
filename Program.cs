// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program1
// ---------------------------------------------------------------------------------------
namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      #region Method ------------------------------------------------
      static void Main () {
         var file = File.ReadLines ("C:/etc/input.txt");
         int r = 12, b = 14, g = 13;
         List<int> red = new (), blue = new (), green = new ();
         List<int> validGames = new ();
         foreach (var line in file) {
            var split1 = line.Split (':');
            var tries = split1[1].Split (";");
            foreach (var trial in tries) {
               var colors = trial.Split (",");
               foreach (var color in colors) {
                  var colorParts = color.Trim ().Split (" ");
                  if (colorParts[1] == "red") red.Add (int.Parse (colorParts[0]));
                  if (colorParts[1] == "blue") blue.Add (int.Parse (colorParts[0]));
                  if (colorParts[1] == "green") green.Add (int.Parse (colorParts[0]));
               }
            }
            if (red.All (x => x <= r) && blue.All (x => x <= b) && green.All (x => x <= g))
               validGames.Add (int.Parse (split1[0].Split (' ')[1]));
         }
         Console.WriteLine (validGames.Sum ());
      }
      #endregion
   }
   #endregion
}