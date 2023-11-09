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
      #region Properity ---------------------------------------------
      /// <summary>Gets the count of the MyList</summary>
      public int Count => mCount;

      /// <summary>Gets the size of the MyList</summary>
      public int Capacity => mList.Length;

      /// <summary>Gets the element or sets the value in the given index of MyList</summary>
      /// <param name="index">Any index of MyList</param>
      public T this[int index] {
         get {
            IdxOutOfRangeCheck (index);
            return mList[index];
         }
         set {
            IdxOutOfRangeCheck (index);
            mList[index] = value;
         }
      }
      #endregion

      #region Method ------------------------------------------------
      /// <summary>This method adds a new element to the MyList</summary>
      /// <param name="a">New element to be added</param>
      public void Add (T a) {
         CapactityCheck ();
         mList[mCount++] = a;
      }

      /// <summary>Removes the first occurance of the given element</summary>
      /// <param name="a">Any element in MyList</param>
      /// <returns>Returns true if removed successfully else false</returns>
      public bool Remove (T a) {
         int index = Array.IndexOf (mList, a);
         if (index == -1) return false;
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
         ArgOutOfRangeCheck (index, Count + 1);
         CapactityCheck ();
         for (int i = index + 1; i < Capacity; i++) Swap (index, i);
         mList[index] = a;
         mCount++;
      }

      /// <summary>Removes an element from the given index</summary>
      /// <param name="index">Index from which the element is asked to remove</param>
      /// <exception cref="Exception">Throws exception when invalid index is provided</exception>
      public void RemoveAt (int index) {
         ArgOutOfRangeCheck (index, Count);
         Remove (mList[index]);
      }

      /// <summary>Swaps two elements in an array</summary>
      void Swap (int idx1, int idx2) => (mList[idx1], mList[idx2]) = (mList[idx2], mList[idx1]);

      /// <summary>Throws exception when accessing an idx out of valid range</summary>
      void IdxOutOfRangeCheck (int idx) {
         if (!(idx >= 0 && idx < Count)) throw new IndexOutOfRangeException ();
      }

      /// <summary>Throws exception when attempting an Insert or RemoveAt with invalid idx</summary>
      /// <param name="cnt">Maximum limit of Index range</param>
      void ArgOutOfRangeCheck (int idx, int cnt) {
         if (!(idx >= 0 && idx < cnt)) throw new ArgumentOutOfRangeException ();
      }

      /// <summary>Increases capacity of array when needed</summary>
      void CapactityCheck () {
         if (Count == Capacity) Array.Resize (ref mList, Capacity * 2);
      }
      #endregion

      #region Private -----------------------------------------------
      T[] mList = new T[4];
      int mCount = 0;
      #endregion
   }
   #endregion
}