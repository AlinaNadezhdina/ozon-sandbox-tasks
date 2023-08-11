// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

internal class Program
{
	
	private static void Main(string[] args)
	{
		// var sw = new Stopwatch();
		// sw.Start();
		var total = int.Parse(Console.ReadLine());
		int[][] nums = new int[total][];
		for (int i = 0; i < total; i++)
		{
			var count = int.Parse(Console.ReadLine());
			nums[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
		}

		for (int i = 0; i < total; i++)
		{
			var data = new Dictionary<int, int>();
			for (int j = 0; j < nums[i].Length; j++)
			{
				data.Add(j, nums[i][j]);
			}
			var ddata = data.OrderBy(x => x.Value).ToList();
			var flag = 0;
			for (int j = 0; j < data.Count - 1; j++)
			{
				if (ddata[j].Value == ddata[j + 1].Value && ddata[j].Key != ddata[j + 1].Key - 1)
				{
					Console.WriteLine("NO");
					flag = 1;
					break;
				}
			}
			if (flag == 0)
				Console.WriteLine("YES");
		}
		// sw.Stop();
		// var ts = sw.Elapsed;
		// string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
		// 	ts.Hours, ts.Minutes, ts.Seconds,
		// 	ts.Milliseconds / 10);
		// Console.WriteLine(elapsedTime);
	}
}