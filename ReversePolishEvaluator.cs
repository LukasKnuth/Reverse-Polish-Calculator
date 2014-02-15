using System;
using System.Collections.Generic;

namespace ReversePolishCalculator
{
	/// <summary>
	/// Evaluates a Reverse-Polish expression.
	/// </summary>
	public static class ReversePolishEvaluator{

		/// <summary>
		/// Evaluate a Reverse-Polish expression and return it's result.
		/// </summary>
		/// <param name="expression">Expression.</param>
		public static int Evaluate(ReversePolishExpression expression){
			Stack<int> values = new Stack<int> ();
			foreach (ExpressionSymbol symbol in expression.Expression) {
				if (symbol is ExpressionOperand) {
					// Add to the stack:
					values.Push ((symbol as ExpressionOperand).Value);
				} else {
					// Pop and calculate:
					int l_value = values.Pop ();
					int r_value = values.Pop ();
					// Do calculation:
					values.Push ((symbol as ExpressionOperation).Evaluate (r_value, l_value));
				}
			}
			return values.Pop ();
		}

	}
}

