namespace Training {
   #region Class ----------------------------------------------------------------------------------
   /// <summary>Exception class for evaluator errors</summary>
   class EvalException : Exception {
      public EvalException (string message) : base (message) { }
   }

   /// <summary>Expression Evaluator</summary>
   public class Evaluator {
      #region Method ------------------------------------------------
      /// <summary>Evaluates the expression if there is no error in the expression</summary>
      /// <returns>Returns the result of the expression</returns>
      public double Evaluate (string input) {
         // Resets everything, everytime the evaluator is newly called.
         mOperands.Clear (); mOperators.Clear ();
         mBasePriority = 0;
         mTokens.Clear ();
         var tokenizer = new Tokenizer (this, input);

         for (; ; ) { // Gets each token
            var token = tokenizer.GetNext ();
            if (token is TEnd) break;
            mTokens.Add (token);
         }

         TVariable var = null; // For assignment expression
         if (mTokens.Count > 1 && mTokens[0] is TVariable varName
             && mTokens[1] is TOpBinary bin && bin.Op == '=') {
            var = varName;
            mTokens.RemoveRange (0, 2);
         }

         //Evaluation Part
         foreach (var token in mTokens) Process (token);
         while (mOperators.Count > 0) ApplyOperator ();

         // Possible Errors
         if (mBasePriority != 0) Error ("Mismatched parantheses");
         if (mOperands.Count > 1) Error ("Too many operands");
         if (mOperators.Count > 0) Error ("Too many operators");

         double f = mOperands.Pop ();
         if (var != null) mVariables[var.Name] = f; // For assignment expression
         return f;
      }

      /// <summary>Applies the operator and does the necessary calculation</summary>
      void ApplyOperator () {
         var op = mOperators.Pop ();
         if (op is TOpBinary bin) { // Binary Operation
            if (mOperands.Count < 2) Error ("Too few operands");
            double f1 = mOperands.Pop (), f2 = mOperands.Pop ();
            mOperands.Push (bin.Apply (f2, f1));
         }
         if (op is TOpFunction func) { // Applying Functions
            if (mOperands.Count < 1) Error ("Too few operands");
            mOperands.Push (func.Apply (mOperands.Pop ()));
         }
         if (op is TOpUnary sign) { // Unary Operation
            mOperands.Push (sign.Apply (mOperands.Pop ()));
         }
      }

      /// <summary>Processes each token 
      /// and pushes them in appropriate stacks by determining priority</summary>
      /// <param name="token">Each token from the expression</param>
      /// <exception cref="NotImplementedException">For handling anything not yet implemented</exception>
      void Process (Token token) {
         switch (token) {
            case TNumber num:
               mOperands.Push (num.Value);
               break;
            case TOperator op:
               op.FinalPriority = mBasePriority + op.Priority;
               while (!OkToPush (op)) ApplyOperator ();
               mOperators.Push (op);
               break;
            case TPunctutation punct:
               mBasePriority += (punct.Punct == '(') ? 10 : -10;
               break;
            default: throw new NotImplementedException ();
         }
      }

      /// <summary>Checks priority conditions to push an operator into the stack</summary>
      /// <param name="op">Operator</param>
      /// <returns>Returns true if it is OK to push</returns>
      bool OkToPush (TOperator op) {
         if (mOperators.Count == 0 || // First Operator
             mOperators.Peek ().FinalPriority < op.FinalPriority || // Higher Priority
             op is TOpUnary) return true; // Unary Operator
         return false;
      }

      /// <summary>Gets the value of a variable from the dictionary
      /// if the variable is assigned to some value</summary>
      /// <param name="var">variable name</param>
      /// <returns>Returns the value of the variable</returns>
      /// <exception cref="EvalException">Thrown when unknown variable is called</exception>
      public double GetVariable (string var) {
         if (mVariables.TryGetValue (var, out double f)) return f;
         else throw new EvalException ($"Unknown variable {var}");
      }

      /// <summary>Throws exception when an error is found in the expression</summary>
      /// <param name="message">Error message</param>
      void Error (string message) => throw new EvalException (message);

      /// <summary>Gets the previously added token</summary>
      public Token GetPreviousToken () => mTokens[^1];
      #endregion

      #region Members -----------------------------------------------
      Stack<double> mOperands = new ();
      Stack<TOperator> mOperators = new ();
      Dictionary<string, double> mVariables = new ();
      List<Token> mTokens = new ();
      int mBasePriority = 0; // Parantheses Priority
      #endregion
   }
   #endregion
}