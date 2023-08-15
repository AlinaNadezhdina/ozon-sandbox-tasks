using System.Diagnostics;

public struct MyStruct
	{
		public TimeOnly start;
		public TimeOnly end;
	}

internal class Program
{
	private static void Main()
	{
// var sw = new Stopwatch();
// sw.Start();
		var total = int.Parse(Console.ReadLine());
		var dates = new string[total][];
		for (int i = 0; i < total; i++)
		{
			var count = int.Parse(Console.ReadLine());
			dates[i] = new string[count];
			for (int j = 0; j < count; j++)
				dates[i][j] = Console.ReadLine();
		}
/*  чтение из файла
		string[] lines = File.ReadAllLines("Ftests/35");
var sw = new Stopwatch();
sw.Start();
		int total = int.Parse(lines[0]);
		var dates = new string[total][];
		for (int k = 1, i = 0; k < lines.Length;  i++)
		{
			int count = int.Parse(lines[k]);
			dates[i] = new string[count];
			for (int j = 0; j < count; j++, k++)
		 		dates[i][j] = lines[k + 1];
			k += 1;
		}
*/
		
		for (int i = 0; i < total; i++)
		{
			MyStruct [] myStruct = new MyStruct[dates[i].Length];
            int flag = 0;       
			for (int j = 0; j < dates[i].Length; j++)
			{
				myStruct[j] = new MyStruct();
				if (!TimeOnly.TryParse(dates[i][j][..8], out myStruct[j].start) || !TimeOnly.TryParse(dates[i][j][9..], out myStruct[j].end))
				{
					flag = 1;
					Console.WriteLine("NO");
					break;
				}
				if (myStruct[j].start > myStruct[j].end)
				{
					flag = 1;
					Console.WriteLine("NO");
					break;
				}
			}	
			if (flag == 0)
			{
				var sortedArr = myStruct.OrderBy(x => x.start).ToArray();
				for (int j = 0; j < sortedArr.Length - 1; j++)
				{ 
					if (sortedArr[j + 1].start <= sortedArr[j].end)
					{	
						Console.WriteLine("NO");
						flag = 1;
						break;
					}
				}
				if (flag == 0)
				Console.WriteLine("YES");
			}
		}
		// sw.Stop();
		// var ts = sw.Elapsed;
		// string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
		// 	ts.Hours, ts.Minutes, ts.Seconds,
		// 	ts.Milliseconds / 10);
		// Console.WriteLine(elapsedTime);
	}
}
