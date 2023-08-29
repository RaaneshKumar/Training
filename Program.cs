//Print multiplication tables from 1 to 10

for (int i = 1; i <= 10; i++) {
   for (int j = 1; j <= 10; j++) Console.WriteLine ($"{i} * {j,2} = {i * j}");
   Console.WriteLine ();
}