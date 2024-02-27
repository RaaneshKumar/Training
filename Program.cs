// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Implement a priority queue using the heap data structure.
// This is a binary tree that implements the shape property and ordering property.
// ---------------------------------------------------------------------------------------

namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      #region Method ------------------------------------------------
      static void Main () {
         MyPriorityQueue<int> p = new ();
         var random = new Random ();
         for (int i = 0; i < 10; i++) p.Enqueue (random.Next (100));
         for (int i = 0; i < 10; i++) Console.WriteLine (p.Dequeue ());
      }
      #endregion
   }

   public class MyPriorityQueue<T> where T : IComparable<T> {
      T[] mHeap = new T[4];
      int mCount = 1;

      #region Property ----------------------------------------------
      /// <summary>Gets the maximum capacity of the priority queue</summary>
      int Capacity => mHeap.Length;

      /// <summary>Checks whether the priority queue is empty or not</summary>
      public bool IsEmpty => mCount == 0;
      #endregion

      #region Method ------------------------------------------------
      /// <summary>Adds the given element to the priority queue 
      /// and rearranges the structure if required to maintain the shape and order</summary>
      /// <param name="value">Element to be added</param>
      public void Enqueue (T value) {
         if (mCount == Capacity) Array.Resize (ref mHeap, Capacity * 2);
         mHeap[mCount] = value;
         SiftUp (mCount++);
      }

      /// <summary>Removes and returns the smallest element in the priority queue 
      /// and rearranges the structure if required to maintain the shape and order</summary>
      /// <exception cref="InvalidOperationException">Throws exception if the priority queue is empty</exception>
      public T Dequeue () {
         if (IsEmpty) throw new InvalidOperationException ("Priority queue is empty");
         T root = mHeap[1];
         mHeap[1] = mHeap[--mCount];
         SiftDown (1);
         return root;
      }

      /// <summary>Swaps the child with the parent if the child has greater value than the parent</summary>
      /// <param name="idx">Index of the last element added</param>
      void SiftUp (int idx) {
         while (idx > 1) {
            int parentIdx = idx / 2;
            if (mHeap[idx].CompareTo (mHeap[parentIdx]) < 0) {
               SwapItems (idx, parentIdx);
               idx = parentIdx;
            } else break;
         }
      }

      /// <summary>Swaps the parent with its smaller child 
      /// if the value of the parent is greater than any one of its children</summary>
      /// <param name="index"></param>
      void SiftDown (int index) {
         while (true) {
            int lCIdx = 2 * index, rCIdx = 2 * index + 1, smallChildIdx = index;

            // Picking the smaller child between the left and right children
            if (lCIdx <= mCount && mHeap[lCIdx].CompareTo (mHeap[smallChildIdx]) < 0)
               smallChildIdx = lCIdx;
            if (rCIdx <= mCount && mHeap[rCIdx].CompareTo (mHeap[smallChildIdx]) < 0)
               smallChildIdx = rCIdx;

            if (smallChildIdx != index) {
               SwapItems (index, smallChildIdx);
               index = smallChildIdx;
            } else break;
         }
      }

      /// <summary>Swaps the items in the given indices of the mHeap array</summary>
      void SwapItems (int idx1, int idx2) =>
          (mHeap[idx1], mHeap[idx2]) = (mHeap[idx2], mHeap[idx1]);
      #endregion
   }
   #endregion
}