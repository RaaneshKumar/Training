Console.Write ("Enter a decimal value: ");
string userinput = Console.ReadLine ();
int input = int.Parse (userinput);
string hexvalue = input.ToString ("X");
Console.WriteLine (hexvalue);