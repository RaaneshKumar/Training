// To print a chessboard using unicode

using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine (" \u265C \u265E \u265D \u265B \u265A \u265D \u265E \u265C \n");
Console.WriteLine (string.Concat (Enumerable.Repeat (" \u265F", 8)) + "\n");
Console.WriteLine (string.Concat (Enumerable.Repeat ("\n", 4)));
Console.WriteLine (string.Concat (Enumerable.Repeat (" \u2659", 8)) + "\n");
Console.WriteLine (" \u2656 \u2658 \u2657 \u2655 \u2654 \u2657 \u2658 \u2656 \n");