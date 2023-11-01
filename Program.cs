// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to create a custom TStack<T> class.
// Class is created with arrays as the underlying data structure.
// Must start with an initial capacity of 4 and double its capacity when needed.
// Throw exceptions when necessary. 
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      #region Method ------------------------------------------------
      static void Main () { }
      #endregion
   }

   /// <summary>Custom TStack<T> class</summary>
   public class TStack<T> {
      #region Property ----------------------------------------------
      /// <summary>Gets the count of the TStack</summary>
      public int Count => mCount;

      /// <summary>Gets the size of the TStack</summary>
      public int Capacity => mStack.Length;

      /// <summary>Checks whether TStack is empty</summary>
      public bool IsEmpty => mCount == 0;
      #endregion

      #region Method ------------------------------------------------
      /// <summary>Pushes the element at the top of the stack</summary>
      /// <param name="a">Element to be pushed</param>
      public void Push (T a) {
         if (Count == Capacity) Array.Resize (ref mStack, Capacity * 2);
         mStack[mCount] = a;
         mCount++;
      }

      /// <summary>Removes and returns the topmost element from the stack</summary>
      public T Pop () {
         if (IsEmpty) throw new InvalidOperationException ();
         (var a, mStack[Count - 1]) = (mStack[Count - 1], default);
         mCount--;
         if (Count == Capacity / 2) Array.Resize (ref mStack, Capacity / 2);
         return a;
      }

      /// <summary>Returns the topmost element from the stack</summary>
      public T Peek () => IsEmpty ? throw new InvalidOperationException () : mStack[Count - 1];
      #endregion

      #region Private -----------------------------------------------
      T[] mStack = new T[4];
      int mCount = 0;
      #endregion
   }
   #endregion
}