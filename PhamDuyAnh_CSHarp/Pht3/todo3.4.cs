using System;
namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Tạo số bí mật
            int secretNumber = 50;
            // TODO: Tạo mảng chứa các lần đoán (giả lập nhập: 40, 60, 50)
            int[] guesses = { 40, 60, 50 };
            // TODO: Khởi tạo biến đếm
            int index = 0;
            // TODO: Dùng vòng lặp while để đoán số
            while (index < guesses.Length)
            {
                int guess = guesses[index];

                if (guess < secretNumber)
                {
                    Console.WriteLine($"{guess}: Quá thấp");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine($"{guess}: Quá cao");
                }
                else
                {
                    Console.WriteLine($"{guess}: Chính xác!");
                    break;
                }

                index++;
            }
        }
    }
}