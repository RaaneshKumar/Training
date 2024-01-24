// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------------------
// Program.cs                                                                     
// Complex Number Class Implementation.
// Overload + and - operators.
// Implement property Norm to find the magnitude
// ---------------------------------------------------------------------------------------
using System.ComponentModel;

namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      #region Method ------------------------------------------------
      static void Main () { }
      #endregion
   }

   public class ComplexNumber {
      public ComplexNumber (int real, int img) {
         mReal = real; mImg = img;
      }
      int mReal, mImg;

      public int RealPart {
         get { return mReal; }
         set { mReal = value; }
      }

      public int ImgPart {
         get { return mImg; }
         set { mImg = value; }
      }

      public double Norm => Math.Sqrt ((mReal * mReal) + (mImg * mImg));

      public static ComplexNumber operator + (ComplexNumber m1, ComplexNumber m2) => Add (m1, m2);

      public static ComplexNumber operator - (ComplexNumber m1, ComplexNumber m2) => Subtract (m1, m2);

      static ComplexNumber Add (ComplexNumber m1, ComplexNumber m2)
         => new (m1.RealPart + m2.RealPart, m1.ImgPart + m2.ImgPart);

      static ComplexNumber Subtract (ComplexNumber m1, ComplexNumber m2)
         => new (m1.RealPart - m2.RealPart, m1.ImgPart - m2.ImgPart);

      public override string ToString () => $"{RealPart} + i{ImgPart}";
   }
   #endregion
}