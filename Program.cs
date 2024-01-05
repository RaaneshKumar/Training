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
         mDeque[mRear] = item;
         mCount++;
         mRear = (mRear + 1) % Capacity; // Sets the rear pointer to the next position after enqueue.
      }

      /// <summary>Adds the element at the front end of the TDeque</summary>
      /// <param name="item">Element to be added</param>
      public void EnqueueFront (T item) {
         if (Count == Capacity) Resize ();
         mFront = (mFront + Capacity - 1) % Capacity; // Sets the front pointer to the previous position to enqueue.
         mDeque[mFront] = item;
         mCount++;
      }

      /// <summary>Removes an element from the rear end of the TDeque</summary>
      public T DequeueRear () {
         T dequeItem;
         if (IsEmpty) throw new InvalidOperationException ();
         mRear = (mRear + Capacity - 1) % Capacity; // Sets the rear pointer to the previous position to dequeue.
         (dequeItem, mDeque[mRear]) = (mDeque[mRear], default);
         mCount--;
         return dequeItem;
      }

      /// <summary>Removes an element from the front end of the TDeque</summary>
      public T DequeueFront () {
         T dequeItem;
         if (IsEmpty) throw new InvalidOperationException ();
         (dequeItem, mDeque[mFront]) = (mDeque[mFront], default);
         mCount--;
         mFront = (mFront + 1) % Capacity; // Sets the front pointer to the next position after dequeue.
         return dequeItem;
      }

      /// <summary>Resizes the array by increasing the capacity by 2 times 
      /// when the array is full</summary>
      void Resize () {
         T[] resizeArray = new T[mCount * 2];
         for (int i = 0; i < mCount; i++) // Copies elements in order from mFront to mRear.
            resizeArray[i] = mDeque[(mFront + i) % mCount];
         mDeque = resizeArray;
         (mFront, mRear) = (0, mCount); // Setting back pointers.
      }
      #endregion

      #region Members -----------------------------------------------
      T[] mDeque = new T[4];
      int mCount = 0, mFront = 0, mRear = 0;
      #endregion
   }
   #endregion
}