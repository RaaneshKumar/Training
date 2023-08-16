// To print a chessboard using unicode



using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine ("\u250C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u252C", 7)) + "\u2500\u2500\u2500\u2510");
Console.WriteLine ("\u2502 {0} \u2502 {1} \u2502 {2} \u2502 \u265B \u2502 \u265A \u2502 {2} \u2502 {1} \u2502 {0} \u2502", "\u265C", "\u265E", "\u265D");
// black 265C - rook, 265E-knight, 265D - bishop, 265B - queen, 265A - king
Console.WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524");
Console.WriteLine (string.Concat (Enumerable.Repeat ("\u2502 \u265F ", 8)) + "\u2502"); // 265F-black pawn
Console.WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524");
string empty_blocks1 = string.Concat (Enumerable.Repeat ("\u2502   ", 8)) + "\u2502\n";
string empty_blocks2 = "\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524\n";
string empty_blocks = empty_blocks1 + empty_blocks2;
Console.Write (string.Concat (Enumerable.Repeat (empty_blocks, 4)));
Console.WriteLine (string.Concat (Enumerable.Repeat ("\u2502 \u2659 ", 8)) + "\u2502"); // 2659-white pawn
Console.WriteLine ("\u251C" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u253C", 7)) + "\u2500\u2500\u2500\u2524");
Console.WriteLine ("\u2502 {0} \u2502 {1} \u2502 {2} \u2502 \u2655 \u2502 \u2654 \u2502 {2} \u2502 {1} \u2502 {0} \u2502", "\u2656", "\u2658", "\u2657");
//white 2656-rook, 2658-knight, 2657-bishop, 2655-queen, 2654-king
Console.WriteLine ("\u2514" + string.Concat (Enumerable.Repeat ("\u2500\u2500\u2500\u2534", 7)) + "\u2500\u2500\u2500\u2518");