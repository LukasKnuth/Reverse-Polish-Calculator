using System;

namespace ReversePolishCalculator
{
	public class Calculator
	{
		public static void Main ()
		{
            Console.WriteLine("Enter the space-seperated expression:");
            string expression = Console.ReadLine();
			ReversePolishExpression reverse_polish = ReversePolishExpression.Parse (expression);
			int result = ReversePolishEvaluator.Evaluate (reverse_polish);
			Console.WriteLine ("Expression: {0}\nin RPN: {1}\n= {2}", expression, reverse_polish, result);
		}
	}
}