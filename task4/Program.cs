using System.Text;

internal class Program
{
	private static int[]? getIntArr(string ? line)
	{
		if (line is  null) 
			return null;
		int[] arr = line.Split(' ').Select(it => int.Parse(it)).ToArray();
		return arr;
	}

	private static void PrintSortedArr(int [,]array, int[]  tableSizeArr)//, ref StringBuilder result)
	{
		for (int j = 0; j < tableSizeArr[0]; j++)
		{
			for (int k = 0; k < tableSizeArr[1]; k++)
			{
				Console.Write($"{array[j, k]} ");
			}
			Console.WriteLine();
		}
		Console.WriteLine();
	}
	private static int [] getLineFrom2DArr(int [, ] arr, int strIndex, int columns)
	{
		int [] temp = new int[columns];//количество элеметов = количеству столбцов в двумерном массиве
		for (int i = 0; i < columns; i++)//цикл по количеству столбцов
		{
			temp[i] = arr[strIndex, i];
		}
		return temp;
	}


	//поменять местами i и j строки двумерного массива 
	private static void swapStringsInArr(ref int [, ] arr,  int i, int j, int columns)
	{
		int [] temp1 = getLineFrom2DArr(arr, i, columns);
		int [] temp2 = getLineFrom2DArr(arr, j, columns);
		for (int k = 0; k < columns; k++)//цикл по столбцам массива
		{
			arr[i, k] = temp2[k];
			arr[j, k] = temp1[k];
		}
	}

	private static void sortArrayColumn(int [,] arr, int rows, int columns, int column)
	{
		var i = 0;
		while (0 < rows - 1)
		{
			i = 0;
			while (i < rows - 1)
			{
				if (arr[i, column] > arr[i + 1, column])
				{
					swapStringsInArr(ref arr, i, i +  1, columns);
				}
				i++;
			}
			rows--;
		}
	}

	private static void clickColumnsInArray(int [,] arr, int [] sizeArr, int [] columnArr)
	{
		for (int i = 0; i < columnArr.Length; i++)
		{
			if (i > 0 && columnArr[i - 1] == columnArr[i])
				return ;
			sortArrayColumn( arr, sizeArr[0], sizeArr[1], columnArr[i] - 1);
		}
	}

	private static void Main(string[] args)
	{
		var testCount = Convert.ToInt32(Console.ReadLine());
		for (int i = 0; i < testCount; i++)
		{
			Console.ReadLine();// пустая строка 
			int[] ? tableSizeArr = getIntArr( Console.ReadLine());
			if (tableSizeArr is null) return ;
			int[,] array = new int[tableSizeArr[0], tableSizeArr[1]];

			for (int j = 0; j < tableSizeArr[0]; j++)
			{
				int[] ? tempArr = getIntArr(Console.ReadLine());
				if (tempArr is null) return ;
				for (int k = 0; k < tableSizeArr[1]; k++)
				{
					array[j, k] = tempArr[k];
				}
			}
			var changeCount = Convert.ToInt32(Console.ReadLine());
			int[] ? columnChangeArr = getIntArr(Console.ReadLine());
			if (columnChangeArr is null) return ;

			clickColumnsInArray(array, tableSizeArr, columnChangeArr);
			PrintSortedArr(array, tableSizeArr);//, ref result);
			
		}
	}
}
/*
3

4 3
3 4 1
2 2 5
2 4 2
2 2 1
3
2 1 3

3 1
100
9
10
2
1 1

3 3
2 11 72
99 11 13
2 8 13
5
2 3 2 1 2

*/