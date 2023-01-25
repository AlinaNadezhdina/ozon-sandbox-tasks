using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
			string line = Console.ReadLine();
			int count = Convert.ToInt32(line);
			int [] sumArr = new int[count];
			for (int i = 0; i < count; i++)
			{
				string nums = Console.ReadLine();
				string[] splitString = nums.Split(' ');

				int a = Convert.ToInt32(splitString[0]);
				int b = Convert.ToInt32(splitString[1]);
				sumArr[i] = a + b;
			}
			for (int i = 0; i < count; i++)
			{
				Console.WriteLine("{0}", sumArr[i]);
			}

        }
    }
}
