using System;

namespace ReversePolishCalculator
{
	/// <summary>
	/// An abstract expression-symbol, a single part of a Reverse-Polish expression.
	/// </summary>
	public abstract class ExpressionSymbol{
		public override string ToString (){
			return this.GetRepresentation () + " ";
		}
		protected abstract string GetRepresentation ();
	}

	/// <summary>
	/// A static collection of possible operators to make up an expression.
	/// </summary>
	public class ExpressionOperation : ExpressionSymbol{

		public static ExpressionOperation Parse(string symbol){
			switch (symbol){
			case "+":
				return PLUS;
			case "-":
				return MINUS;
			case "*":
				return TIMES;
			case "/":
				return DIVIDE;
			case "(":
				return LEFT_PARENTHESIS;
			}
			throw new FormatException ();
		}

		/// <summary>
		/// Evaluates a single operation for the given L and R values.
		/// </summary>
		public delegate int OperatorEvaluation (int l_value, int r_value);

		public static readonly ExpressionOperation PLUS = new ExpressionOperation ("+", delegate(int r, int l) {
			return r + l;
		});
		public static readonly ExpressionOperation MINUS = new ExpressionOperation ("-", delegate(int r, int l) {
			return r - l;
		});
		public static readonly ExpressionOperation TIMES = new ExpressionOperation ("*", delegate(int r, int l) {
			return r * l;
		});
		public static readonly ExpressionOperation DIVIDE = new ExpressionOperation ("/", delegate(int r, int l) {
			return r / l;
		});
		public static readonly ExpressionOperation LEFT_PARENTHESIS = new ExpressionOperation ("(", null);

		private string representation;
		private OperatorEvaluation eval;

		private ExpressionOperation (string representation, OperatorEvaluation eval){
			this.representation = representation;
			this.eval = eval;
		}

		public int Evaluate (int l_value, int r_value){
			return this.eval (l_value, r_value);
		}

		protected override string GetRepresentation(){
			return this.representation;
		}
	}

	/// <summary>
	/// A single operand in a Reverse-Polish expression (a number).
	/// </summary>
	public class ExpressionOperand : ExpressionSymbol{
		public int Value {
			get;
			private set;
		}
		public ExpressionOperand(int value){
			this.Value = value;
		}
		protected override string GetRepresentation(){
			return Value.ToString ();
		}
	}
}

