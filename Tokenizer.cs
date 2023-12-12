namespace Training {
   #region Class ----------------------------------------------------------------------------------
   /// <summary>Tokenizer for the expression evaluator</summary>
   class Tokenizer {
      #region Constructor -------------------------------------------
      /// <summary>Constructs the class only when 
      /// evaluator and expression is provided</summary>
      /// <param name="eval">An evaluator</param>
      /// <param name="input">Given expression</param>
      public Tokenizer (Evaluator eval, string input) {
         mText = input; mN = 0; mEval = eval;
      }
      #endregion

      #region Method ------------------------------------------------
      /// <summary>Gets each token and its type</summary>
      /// <returns>Returns the type of the token</returns>
      public Token GetNext () {
         while (mN < mText.Length) {
            var ch = mText[mN++];
            switch (ch) {
               case ' ': break;
               case '+' or '-':
                  if (mN - 1 is 0 || mEval.GetPreviousToken () is TOperator or TPunctutation)
                     return new TOpUnary (ch);
                  else return new TOpBinary (ch);
               case '*' or '/' or '^' or '=': return new TOpBinary (ch);
               case >= '0' and <= '9': return GetLiteral ();
               case '(' or ')': return new TPunctutation (ch);
               case >= 'a' and <= 'z': return GetVariable ();
               default: return new TError ($"Unexpected Token {ch}");
            }
         }
         return new TEnd ();
      }

      /// <summary>Gets the literal token</summary>
      Token GetLiteral () {
         int start = mN - 1; // Since mN is now the next character's index
         while (mN < mText.Length) {
            var ch = mText[mN++];
            if (ch is (>= '0' and <= '9') or '.') continue;
            mN--; break;
         }
         double f = double.Parse (mText.Substring (start, mN - start));
         return new TLiteral (f);
      }

      /// <summary>Gets the variable token</summary>
      Token GetVariable () {
         int start = mN - 1;
         while (mN < mText.Length) {
            var ch = mText[mN++];
            if (ch is (>= '0' and <= '9') or (>= 'a' and <= 'z')) continue;
            mN--; break;
         }
         string identifier = mText.Substring (start, mN - start);
         if (mFuncs.Contains (identifier)) return new TOpFunction (identifier);
         else return new TVariable (mEval, identifier);
      }
      #endregion

      #region Members -----------------------------------------------
      readonly string mText;
      readonly Evaluator mEval;
      int mN;
      readonly string[] mFuncs = { "sin", "cos", "tan", "asin", "acos", "atan", "sqrt", "log", "exp" };
      #endregion
   }
   #endregion
}