using System;
using System.Collections.Generic;

/*
В магазине акция: «купи три одинаковых товара и заплати только за два». 
Конечно, каждый купленный товар может участвовать лишь в одной акции. Акцию можно использовать многократно.

Например, если будут куплены 7товаров одного вида по цене 2 за штуку и 5 товаров другого вида по цене 3
за штуку, то вместо 7⋅2+5⋅3 = 22

Считая, что одинаковые цены имеют только одинаковые товары, найдите сумму к оплате.

Входные данные
В первой строке записано целое число 𝑡
t(1≤𝑡≤10(в степени 4) -  количество наборов входных данных.
Далее записаны наборы входных данных. Каждый начинается строкой, которая содержит 𝑛
(1≤𝑛≤2⋅10(в степени 5) — количество купленных товаров. Следующая строка содержит их цены 𝑝1,𝑝2,…,𝑝𝑛 (1≤𝑝𝑖≤10 (ст 4)

 Если цены двух товаров одинаковые, то надо считать, что это один и тот товар.

Гарантируется, что сумма значений 𝑛
 по всем тестам не превосходит 2⋅105

Выходные данные
Выведите 𝑡 целых чисел — суммы к оплате для каждого из наборов входных данных.
*/
namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int totalCount  = Convert.ToInt32(Console.ReadLine());
			int [] sum = new int[totalCount];
			for (int i = 0; i < totalCount; i++)
			{	
				int setCount = Convert.ToInt32(Console.ReadLine());
				string ? input = Console.ReadLine();
				if (input is  null) 
					return;
				string[] splitString = input.Split(' ');
				List<int> dataList = new List<int> (setCount);
				for (int j = 0; j < setCount; j++)
				{
					dataList.Add(Convert.ToInt32(splitString[j]));
				}
				dataList.Sort();
				Dictionary<int, int> nums = new Dictionary<int, int>();
				var tempCount = 1;
				int k = 1;
				for (; k < setCount; k++)
				{
					if (dataList[k - 1] == dataList[k])
						tempCount++;
					else 
					{
						nums.Add(dataList[k - 1], tempCount);
						tempCount = 1;
					}
					
				}
				nums.Add(dataList[k - 1], tempCount);
				
				foreach (var num in nums)
				{
					int baseNum = num.Value / 3;
					sum[i] += (num.Value - baseNum) * num.Key;
				}
			}
			for (int i = 0; i < sum.Length; i++)
				Console.WriteLine(sum[i]);
        }
    }
}
/*
6
12
2 2 2 2 2 2 2 3 3 3 3 3
12
2 3 2 3 2 2 3 2 3 2 2 3
1
10000
9
1 2 3 1 2 3 1 2 3
6
10000 10000 10000 10000 10000 10000
6
300 100 200 300 200 300
*/