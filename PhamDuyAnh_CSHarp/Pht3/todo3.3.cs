using System;
namespace SumCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Tính tổng các số từ 1 đến 100
            //  Dùng vòng lặp for
            int sum = 0;

            for (int i = 1; i <= 100; i++)
            {
                sum += i;
            }
            // TODO: In kết quả
            // "Tổng các số từ 1 đến 100: [kết quả]"
            Console.WriteLine($"Tổng các số từ 1 đến 100: {sum}");
        }
    }
}