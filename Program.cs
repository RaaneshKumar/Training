//Generate all string character permutations

Console.Write ("Enter a string: ");
string input = Console.ReadLine();
char[] word = input.ToCharArray ();
Permutation (word, 0, input.Length);
void Permutation (char[] array, int a, int l) {
   if (a == l) Console.WriteLine (array);
   else {
      for (int i = a; i < l; i++) {
         Swap (ref array[a], ref array[i]);
         Permutation (array, a + 1, l);
      }
   }

}

void Swap (ref char a, ref char b) { (a, b) = (b, a); }