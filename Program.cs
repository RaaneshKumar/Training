// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to implement a double ended queue, otherwise called as deque.
// The deque can enqueue as well as dequeue elements from both ends.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      static void Main () { }
   }

   /// <summary>Double Ended Queue class</summary>
   public class TDeque<T> {
      #region Property ----------------------------------------------
      /// <summary>Gets the count of the TDeque</summary>
      public int Count => mCount;

      /// <summary>Gets the size of the TDeque</summary>
      public int Capacity => mDeque.Length;

      /// <summary>Checks whether the TDeque is empty</summary>
      public bool IsEmpty => mCount == 0;
      #endregion

      #region Method ------------------------------------------------
      /// <summary>Adds the element at the rear end of the TDeque</summary>
      /// <param name="item">Element to be added</param>
      public void EnqueueRear (T item) {
         if (Count == Capacity) Resize ();
         if (IsEmpty) AddFirstElement (item);
         else { // Setting tail pointer to free space in the start if it is at the last index.
            mRear = (mRear == Capacity - 1) ? mRear % (Capacity - 1) : mRear + 1;
            mDeque[mRear] = item;
            mCount++;
         }
      }

      /// <summary>Adds the element at the front end of the TDeque</summary>
      /// <param name="item">Element to be added</param>
      public void EnqueueFront (T item) {
         if (Count == Capacity) Resize ();
         if (IsEmpty) AddFirstElement (item);
         else { // Setting head pointer to free space in the last if it is at the first index.
            mFront = (mFront == 0) ? Capacity - 1 : mFront - 1;
            mDeque[mFront] = item;
            mCount++;
         }
      }

      /// <summary>Removes an element from the rear end of the TDeque</summary>
      public T DequeueRear () {
         T dequeItem;
         if (IsEmpty) throw new InvalidOperationException ();
         (dequeItem, mDeque[mRear]) = (mDeque[mRear], default);
         mCount--; // Setting back tail pointer after dequeue according to previous positions. 
         mRear = (mRear == 0) ? Capacity - 1 : mRear - 1;
         return dequeItem;
      }

      /// <summary>Removes an element from the front end of the TDeque</summary>
      public T DequeueFront () {
         T dequeItem;
         if (IsEmpty) throw new InvalidOperationException ();
         (dequeItem, mDeque[mFront]) = (mDeque[mFront], default);
         mCount--; // Setting back head pointer after dequeue according to previous positions. 
         mFront = (mFront == Capacity - 1) ? 0 : mFront + 1;
         return dequeItem;
      }

      /// <summary>Resizes the array by increasing the capacity by 2 times 
      /// when the array is full</summary>
      void Resize () {
         if (mRear < mFront) // Rearranging the elements in linear way
            mDeque = mDeque.TakeLast (Capacity - mFront).Concat (mDeque.Take (mRear + 1)).ToArray ();
         Array.Resize (ref mDeque, Capacity * 2);
         mFront = 0; mRear = Capacity / 2 - 1; // Setting back head and tail pointers in linear way.
      }

      /// <summary>Adds the first element in the TDeque</summary>
      /// <param name="item"></param>
      void AddFirstElement (T item) {
         mDeque[0] = item;
         mCount++;
         mFront = mRear = 0;
      }
      #endregion

      #region Members -----------------------------------------------
      T[] mDeque = new T[4];
      int mCount = 0, mFront = -1, mRear = -1;
      #endregion
   }
   #endregion
}