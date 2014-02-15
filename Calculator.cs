using System;

namespace ReversePolishCalculator
{
	public class Calculator
	{
		public static void Main ()
		{
			string expression = "5 + ( ( 1 + 2 ) * 4 ) - 3";
			ReversePolishExpression reverse_polish = ReversePolishExpression.Parse (expression);
			int result = ReversePolishEvaluator.Evaluate (reverse_polish);
			Console.WriteLine ("Expression: {0}\nin RPN: {1}\n= {2}", expression, reverse_polish, result);
		}
	}
}