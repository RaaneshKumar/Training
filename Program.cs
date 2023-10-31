// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to create a custom MyList<T> class.
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

   /// <summary>Custom MyList<T> class</summary>
   public class MyList<T> {
      T[] mList = new T[4];
      int mCount = 0;

      /// <summary>Gets the count of the MyList</summary>
      public int Count => mCount;

      /// <summary>Gets the size of the MyList</summary>
      public int Capacity => mList.Length;

      /// <summary>Gets the element or sets the value in the given index of MyList</summary>
      /// <param name="index">Any index of MyList</param>
      public T this[int index] {
         get => mList[index];
         set => mList[index] = value;
      }

      /// <summary>This method adds a new element to the MyList</summary>
      /// <param name="a">New element to be added</param>
      public void Add (T a) {
         if (Count == Capacity) Array.Resize (ref mList, Capacity * 2);
         mList[mCount] = a;
         mCount++;
      }

      /// <summary></summary>
      /// <param name="a">Any element in MyList</param>
      /// <returns>Returns true if removed successfully</returns>
      /// <exception cref="Exception">Throws exception when non-existing element is asked to remove</exception>
      public bool Remove (T a) {
         if (!mList.Contains (a)) throw new Exception ("Invalid Operation Exception.");
         int index = Array.IndexOf (mList, a);
         mList[index] = default;
         mCount--;

         for (int i = index; i < Count; i++) Swap (i, i + 1);
         return true;
      }

      /// <summary>Clears the entire MyList</summary>
      public void Clear () {
         Array.Clear (mList, 0, mList.Length);
         Array.Resize (ref mList, 4);
         mCount = 0;
      }

      /// <summary>Inserts the required element in the given index</summary>
      /// <param name="index">Index in which element is to be inserted</param>
      /// <param name="a">Element to be inserted</param>
      /// <exception cref="Exception">Throws exception when invalid index is provided</exception>
      public void Insert (int index, T a) {
         if (!(index >= 0 && index < Count)) throw new Exception ("Index Out of Range Exception.");
         if (Count == Capacity) Array.Resize (ref mList, Capacity * 2);
         for (int i = index + 1; i < Capacity; i++) Swap (index, i);
         mList[index] = a;
         mCount++;
      }

      /// <summary>Removes an element from the given index</summary>
      /// <param name="index">Index from which the element is asked to remove</param>
      /// <exception cref="Exception">Throws exception when invalid index is provided</exception>
      public void RemoveAt (int index) {
         if (!(index >= 0 && index < Count)) throw new Exception ("Index Out of Range Exception.");
         Remove (mList[index]);
      }

      /// <summary>Swaps two elements in an array</summary>
      /// <param name="idx1"></param>
      /// <param name="idx2"></param>
      void Swap (int idx1, int idx2) => (mList[idx1], mList[idx2]) = (mList[idx2], mList[idx1]);
   }
   #endregion
}