
namespace LevrnScripts
{
	public class Function
	{
		public FunctionType type;
		public string functionName;

		public FunctionType Type
		{
			get { return type; }
		}

		public string FunctionName
		{
			get { return functionName; }
		}

		public Function(string name, FunctionType type)
		{
			name = this.functionName;
			type = this.type;
		}


		public enum FunctionType { moveForward, moveLeft, moveRight, moveBack }
	}
}
