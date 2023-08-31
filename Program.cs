// Convert decimal to hexadecimal and binary
//string hexvalue = input.ToString ("X") ----> in-built function for reference

Console.Write ("Enter a decimal value: ");
if (int.TryParse (Console.ReadLine (), out int input)) {
   if (input == 0) Console.WriteLine ("Hexadecimal: 0 \nBinary: 0");
   else {
      Console.WriteLine ($"Hexadecimal: {hexadecimal ()}");
      Console.WriteLine ($"Binary: {binary ()}");
   }
}else Console.WriteLine ("Invalid input");

//To hexadecimal
string hexadecimal () {
   int input1 = input;
   string[] hexdigits = { "A", "B", "C", "D", "E", "F" };
   string hexvalue = "";
   while (input1 > 0) {
      if (input1 <= 9) hexvalue = (input1 % 16) + hexvalue;
      else hexvalue = hexdigits[(input1%16) - 10] + hexvalue;
      input1 /= 16;
   }
   return hexvalue;
}

//To binary
string binary () {
   int input1 = input;
   string binarynumber = "";
   if (input == 0) binarynumber = "0";
   while (input1 > 0) {
      binarynumber = (input1 % 2) + binarynumber;
      input1 /= 2;
   }
   return binarynumber;
}