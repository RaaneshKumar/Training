// Convert decimal to hexadecimal and binary

// To Hexadecimal

Console.Write ("Enter a decimal value: ");
int input = int.Parse (Console.ReadLine ());
string hexvalue = input.ToString ("X");
Console.WriteLine (hexvalue);

// To binary 

string binarynumber = "";
while (input > 0) {
   int remainder = input % 2;
   binarynumber = Convert.ToString (remainder) + binarynumber;
   input = input / 2;
}
foreach (var item in binarynumber) Console.Write (item);
