
namespace LevrnScripts
{
	public class Function
	{
		FunctionType type;
		string functionName;

		public FunctionType Type
		{
			get { return type; }
		}

		public string FunctionName
		{
			get { return functionName; }
		}

		public Function(string thisName, FunctionType type)
		{
			this.functionName = thisName;
			this.type = type;
		}


		public enum FunctionType { moveForward, moveLeft, moveRight, moveBack }
	}
}
