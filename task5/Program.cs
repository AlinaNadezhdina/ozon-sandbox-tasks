// See https://aka.ms/new-console-template for more information

internal class Program
{
	private static void Main(string[] args)
	{
		 var testCount = Convert.ToInt32(Console.ReadLine());
		for (int i = 0; i < testCount; i++)
		{
			var taskCount = Convert.ToInt32(Console.ReadLine());
			var taskStr = Console.ReadLine();
			if (taskStr is null) return;
			var taskArr = taskStr.Split(' ').Select(x => int.Parse(x))
			.Select((value, index) => new { value, index })
            .ToDictionary(pair => pair.index + 1,  pair => pair.value)
			.OrderBy(pair=> pair.Value)
			.ToDictionary(pair => pair.Key, pair => pair.Value);
			
			var isWrongReport = false;
			for(int k = 0; k < taskArr.Count() - 1 && isWrongReport == false; k++)
			{
				KeyValuePair<int, int> elem = taskArr.ElementAt(k);
				KeyValuePair<int, int> next = taskArr.ElementAt(k + 1);
				if (elem.Value == next.Value  && elem.Key != (next.Key - 1))
				{	
					isWrongReport = true;
					Console.WriteLine("NO");
					//Console.WriteLine($"k = {k} elem.Key={elem.Key} next.Key - 1 = {elem.Key - 1}");
				}
			}
			if (isWrongReport == false)
				Console.WriteLine("Yes");

		}
	}
}