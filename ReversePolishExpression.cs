using System;
using ReversePolishCalculator;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishCalculator
{
	public class ReversePolishExpression{

		public static ReversePolishExpression Parse(string expression){
			string[] tokens = expression.Split (' ');
			Queue<ExpressionSymbol> rev_pol_expr = new Queue<ExpressionSymbol> ();
			Stack<ExpressionOperation> operations = new Stack<ExpressionOperation> ();
			foreach (string token in tokens) {
				if (token == "+" || token == "-" || token == "/" || token == "*"){
					// If there is an operator on the stack, pop it off:
					if (operations.Count > 0 && operations.Peek () != ExpressionOperation.LEFT_PARENTHESIS) {
						rev_pol_expr.Enqueue (operations.Pop ());
					}
					// Push the new operation on the stack:
					operations.Push (ExpressionOperation.Parse (token));
				} else if (token == "("){
					// Left parenthesis get pushed on the stack:
					operations.Push (ExpressionOperation.LEFT_PARENTHESIS);
				} else if (token == ")"){
					// Pop all operations belonging to the parenthesis:
					while (operations.Peek () != ExpressionOperation.LEFT_PARENTHESIS) {
						rev_pol_expr.Enqueue (operations.Pop ());
					}
					// We don't need the patenthesis itself...
					operations.Pop ();
				} else {
					// Numbers are put into the queue directly.
					rev_pol_expr.Enqueue (new ExpressionOperand (int.Parse (token)) );
				}
			}
			// Now the remaining operations:
			foreach (ExpressionOperation operation in operations) {
				rev_pol_expr.Enqueue(operation);
			}
			// Done:
			return new ReversePolishExpression (rev_pol_expr);
		}

		public Queue<ExpressionSymbol> Expression {
			get;
			private set;
		}
		private ReversePolishExpression (Queue<ExpressionSymbol> parsed_expr){
			Expression = parsed_expr;
		}

		/// <summary>
		/// Return the string-representtion for the entire Reverse Polish expression.
		/// </summary>
		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();
			foreach (ExpressionSymbol symbol in Expression) {
				builder.Append (symbol);
			}
			return builder.ToString ();
		}
	}
}

