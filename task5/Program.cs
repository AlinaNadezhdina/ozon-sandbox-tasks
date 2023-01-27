// See https://aka.ms/new-console-template for more information
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		var testCount = Convert.ToInt32(Console.ReadLine());
		//var resultString = new StringBuilder();
		for (int i = 0; i < testCount; i++)
		{
			var taskCount = Convert.ToInt32(Console.ReadLine());
			var taskStr = Console.ReadLine();
			if (taskStr is null) return;
			var taskArr = taskStr.Split(' ').Select(x => int.Parse(x)).ToArray();
			bool isWrongReport = false;
			int continuousOperationFlag = 0;//флаг непрерывной работы соторудника над одной задачей
			for (int j = 0; j < taskArr.Length && isWrongReport == false; j++)
			{
				for (int k = j + 1; k < taskArr.Length && isWrongReport == false; k++)
				{
					if (taskArr[j] == taskArr[k] && k == j + 1)
					{
						continuousOperationFlag++;
					}
					else if (taskArr[j] == taskArr[k] && k != j + 1)
					{
						if (continuousOperationFlag > 0)
							continuousOperationFlag ++;
						else
						{
							Console.WriteLine("NO");
							//resultString.Append("NO\n");
							isWrongReport = true;
						}
					}
					if (taskArr[j] != taskArr[k])
						continuousOperationFlag = 0;
				}
				continuousOperationFlag = 0;
			}
			if (isWrongReport == false)
			{
				Console.WriteLine("YES");
				//resultString.Append("YES\n");
			}

		}
		// string text = resultString.ToString();
		// Console.Write(text);
	}
}