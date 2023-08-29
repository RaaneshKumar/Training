// Convert decimal to hexadecimal and binary
//string hexvalue = input.ToString ("X") ----> in-built function for reference

Console.Write ("Enter a decimal value: ");
if (int.TryParse (Console.ReadLine (), out int input)) {
   //To hexadecimal
   int input1 = input;
   string[] hexdigits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
   string hexvalue = "";
   if (input == 0) hexvalue = "0";
   while (input1 > 0) {
      hexvalue = hexdigits[input1 % 16] + hexvalue;
      input1 /= 16;
   }
   Console.WriteLine ($"Hexadecimal: {hexvalue}");
   //To binary
   input1 = input;
   string binarynumber = "";
   if (input == 0) binarynumber = "0";
   while (input1 > 0) {
      binarynumber = (input1 % 2) + binarynumber;
      input1 /= 2;
   }
   Console.Write ($"Binary: {binarynumber}");
}
else Console.WriteLine ("Invalid input");