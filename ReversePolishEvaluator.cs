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
					int r_value = values.Pop ();
					int l_value = values.Pop ();
					// Do calculation:
                    int res = (symbol as ExpressionOperation).Evaluate(l_value, r_value);
                    values.Push (res);

                    Console.WriteLine("\tEvaluating: {0} {1}{2} = {3}", l_value, symbol, r_value, res);
				}
			}
			return values.Pop ();
		}

	}
}

