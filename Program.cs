// Convert decimal to hexadecimal and binary
//string hexvalue = input.ToString ("X") ----> in-built function for reference

Console.Write ("Enter a decimal value: ");
if (int.TryParse (Console.ReadLine (), out int input)) {
   Console.WriteLine ((input == 0) ? "Hexadecimal: 0 \nBinary: 0" : $"Hexadecimal: {Hexadecimal ()} \nBinary: {Binary ()}");
} else Console.WriteLine ("Invalid input");

//To hexadecimal
string Hexadecimal () {
   int input1 = input;
   string[] hexDigits = { "A", "B", "C", "D", "E", "F" };
   string hexValue = "";
   while (input1 > 0) {
      if (input1 <= 9) hexValue = (input1 % 16) + hexValue;
      else hexValue = hexDigits[(input1 % 16) - 10] + hexValue;
      input1 /= 16;
   }
   return hexValue;
}

//To binary
string Binary () {
   int input1 = input;
   string binaryNumber = "";
   if (input == 0) binaryNumber = "0";
   while (input1 > 0) {
      binaryNumber = (input1 % 2) + binaryNumber;
      input1 /= 2;
   }
   return binaryNumber;
} 