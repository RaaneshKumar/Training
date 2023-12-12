namespace Training {
   #region Class ----------------------------------------------------------------------------------
   /// <summary>Token class</summary>
   public class Token { }

   /// <summary>TNumber class derived from Token class</summary>
   class TNumber : Token {
      public virtual double Value { get; }
   }

   /// <summary>TLiteral class derived from TNumber class</summary>
   class TLiteral : TNumber {
      public TLiteral (double f) => mValue = f;
      public override double Value => mValue;
      readonly double mValue;
   }

   /// <summary>TVariable class derived from TNumber class</summary>
   class TVariable : TNumber {
      public TVariable (Evaluator eval, string name) {
         mName = name; mEval = eval;
      }
      public override double Value => mEval.GetVariable (Name);
      public string Name => mName;
      readonly Evaluator mEval; readonly string mName;
   }

   /// <summary>TOperator class derived from Token class</summary>
   class TOperator : Token {
      public virtual int Priority { get; }
      public int FinalPriority { get; set; }
   }

   /// <summary>TOpFunction class derived from TOperator class</summary>
   class TOpFunction : TOperator {
      public TOpFunction (string func) => mFunc = func;
      public override int Priority => 4;
      public double Apply (double a) {
         return Func switch {
            "sin" => Math.Sin (D2R (a)),
            "cos" => Math.Cos (D2R (a)),
            "tan" => Math.Tan (D2R (a)),
            "log" => Math.Log (a),
            "exp" => Math.Exp (a),
            "sqrt" => Math.Sqrt (a),
            "asin" => R2D (Math.Asin (a)),
            "acos" => R2D (Math.Acos (a)),
            "atan" => R2D (Math.Atan (a)),
            _ => throw new NotImplementedException (),
         };

         double D2R (double f) => f * Math.PI / 180;
         double R2D (double f) => f * 180 / Math.PI;
      }
      public string Func => mFunc;
      readonly string mFunc;
   }

   /// <summary>TOpUnary class derived from TOperator class</summary>
   class TOpUnary : TOperator {
      public TOpUnary (char sign) => mSign = sign;
      public override int Priority => 1;
      public double Apply (double a) {
         return Sign switch {
            '-' => -a,
            '+' => a,
            _ => throw new NotImplementedException (),
         };
      }
      public char Sign => mSign;
      readonly char mSign;
   }

   /// <summary>TOpBinary class derived from TOperator class</summary>
   class TOpBinary : TOperator {
      public TOpBinary (char op) => mOp = op;
      public override int Priority
         => Op switch {
            '+' or '-' => 1,
            '*' or '/' => 2,
            '^' => 3,
            _ => throw new NotImplementedException (),
         };
      public double Apply (double a, double b)
         => Op switch {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => a / b,
            '^' => Math.Pow (a, b),
            _ => throw new NotImplementedException (),
         };
      public char Op => mOp;
      readonly char mOp;
   }

   /// <summary>TPunctuation class derived from Token class</summary>
   class TPunctutation : Token {
      public TPunctutation (char punct) => mPunct = punct;
      public char Punct => mPunct;
      readonly char mPunct;
   }

   /// <summary>TEnd class derived from Token class</summary>
   class TEnd : Token { }

   /// <summary>TError class derived from Token class</summary>
   class TError : Token {
      public TError (string message) => mMessage = message;
      public string Message => mMessage;
      readonly string mMessage;
   }
   #endregion
}