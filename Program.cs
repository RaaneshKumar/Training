// Fibonacci series
// Given an input eg:n=10, print fibonacci series for f(10)

int first_number = 0;
int second_number = 1;
Console.Write ("Write the number of elements required for this fibonacci series: ");
int n = int.Parse (Console.ReadLine ());
Console.WriteLine (first_number + "\n" + second_number);
for (int i = 0; i < n; i++) {
   int next_number = first_number + second_number;
   Console.WriteLine (next_number);
   first_number = second_number; second_number = next_number;
}
