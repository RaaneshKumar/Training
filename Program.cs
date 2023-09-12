﻿// Fibonacci series
// Given an input eg:n=10, print fibonacci series for f(10)

int firstNumber = 0, secondNumber = 1;
Console.Write ("Write the number of elements required for this fibonacci series: ");
if (int.TryParse (Console.ReadLine (), out int input)) {
   Console.WriteLine (firstNumber + "\n" + secondNumber);
   for (int i = 0; i < input; i++) {
      int nextNumber = firstNumber + secondNumber;
      Console.WriteLine (nextNumber);
      (firstNumber, secondNumber) = (secondNumber, nextNumber);
   }
} else Console.WriteLine ("Invalid input.");