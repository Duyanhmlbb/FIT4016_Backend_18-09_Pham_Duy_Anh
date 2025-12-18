using System;
namespace BreakContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO 1: In các số lẻ từ 1 đến 20 (dùng continue)
            Console.WriteLine("Các số lẻ từ 1 đến 20:");

            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                    continue;

                Console.Write(i + " ");
            }

            Console.WriteLine("\n");

            // TODO 2: Tìm số 7 trong mảng [2, 5, 7, 1, 9, 7, 3]
            Console.WriteLine("Tìm số 7 trong mảng:");

            int[] numbers = { 2, 5, 7, 1, 9, 7, 3 };

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 7)
                {
                    Console.WriteLine($"Tìm thấy số 7 tại vị trí {i+1}");
                    break;
                }
            }
        }
    }
}