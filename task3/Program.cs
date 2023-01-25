
public class Developer
{
   public int Num {get;set;}//порядковый номер проггера
   public int Level {get;set;}//его уровень мастерства

   public Developer(int num, int level)
   {
      Num = num;
      Level = level;
   }
}

internal class Program
{
	private static void Main(string[] args)
	{
		List<Developer> resultList = new List<Developer>();
		var testCount = Convert.ToInt32(Console.ReadLine());
		for (int i = 0; i < testCount; i++)
		{
			var devCount = Convert.ToInt32(Console.ReadLine());
			string ? temp = Console.ReadLine();
			if (temp is null) return; 
			int [] dataSet = temp.Split(' ').Select(x => int.Parse(x)).ToArray();
			
			var	devList = new List<Developer>(devCount);// 1 - номер, 2 - ранг проггера

			for (int h = 0; h < dataSet.Length; h++)
			{
				devList.Add(new Developer(h + 1, dataSet[h]));
			}
			int myCount = devList.Count/2;
			for (int j = 0; j < myCount && devList.Count != 0; )
			{
				var minDict = new Dictionary<int, int>();
				for (int k = j + 1; k < devList.Count; k++)
				{
					minDict.Add(devList[k].Num, Math.Abs(devList[j].Level - devList[k].Level));
				}
				var val = minDict.OrderBy(k => k.Value).First();

				resultList.Add(new Developer(devList[j].Num, val.Key));
				devList.Remove(devList[j]);
				devList.Remove(devList.Select(x => x).Where(x =>x.Num == val.Key).First());
			}
			resultList.Add(new Developer(0, 0));//  для пустой строки
		}
		foreach(var result in resultList)
		{
			if (result.Num == 0)
				Console.WriteLine();
			else
				Console.WriteLine($"{result.Num} {result.Level}");
		}
	}
}
/*
3
6
2 1 3 1 1 4
2
5 5
8
1 4 2 5 4 2 6 3
*/
