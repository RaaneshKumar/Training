// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Program to create a custom TQueue<T> class.
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

   /// <summary>Custom TQueue<T> class</summary>
   public class TQueue<T> {
      #region Property ----------------------------------------------
      ///<summary>Gets the count of the TQueue</summary>
      public int Count => mCount;

      /// <summary>Gets the size of the TQueue</summary>
      public int Capacity => mQueue.Length;

      /// <summary>Checks whether TQueue is empty</summary>
      public bool IsEmpty => Count == 0;
      #endregion

      #region Method ------------------------------------------------
      /// <summary>Adds an element to the end of the queue</summary>
      /// <param name="a">The element to be added</param>
      public void Enqueue (T a) {
         if (Count == Capacity) Array.Resize (ref mQueue, Capacity * 2);
         mQueue[mCount++] = a;
      }

      /// <summary>Removes and returns the first element from the queue</summary>
      public T Dequeue () {
         InvalidOperationExceptionCheck ();
         (var firstItem, mQueue[mDequeueCount]) = (mQueue[mDequeueCount], default);
         mDequeueCount++; mCount--;
         return firstItem;
      }

      /// <summary>Returns the first element from the queue</summary>
      public T Peek () {
         InvalidOperationExceptionCheck ();
         return mQueue[mDequeueCount];
      }

      /// <summary>Throws exception when attempting to dequeue or peek an empty queue</summary>
      /// <exception cref="InvalidOperationException">Throwed when Dequeue/Peek is called on empty list</exception>
      void InvalidOperationExceptionCheck () {
         if (IsEmpty) throw new InvalidOperationException ();
      }
      #endregion

      #region Private -----------------------------------------------
      T[] mQueue = new T[4];
      int mCount = 0;
      int mDequeueCount = 0;
      #endregion
   }
   #endregion
}