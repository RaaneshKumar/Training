Console.Write ("Enter a decimal value: ");
string userinput = Console.ReadLine ();
int input = int.Parse (userinput);
string hexvalue = input.ToString ("X");
Console.WriteLine (hexvalue);
string binarynumber = "";
while (input > 0) {
   int remainder = input % 2;
   binarynumber = Convert.ToString (remainder) + binarynumber;
   input = input / 2;
}
foreach (var item in binarynumber) {
   Console.Write (item);
}
