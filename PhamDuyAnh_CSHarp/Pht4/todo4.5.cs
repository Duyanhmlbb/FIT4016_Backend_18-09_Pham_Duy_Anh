using System;
namespace Recursion
{
    class Program
    {
        // TODO: Viết phương thức tính giai thừa
        // Phương thức nhận vào số nguyên n
        // Nếu n = 0 thì trả về 1 (điều kiện dừng)
        // Nếu n > 0 thì gọi lại chính nó với n - 1
        // Trả về kết quả n * Factorial(n - 1)
        static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1; // Điều kiện dừng
            }

            return n * Factorial(n - 1); // Gọi đệ quy
        }
        static void Main(string[] args)
        {
            // TODO: Tính 5! bằng Factorial(5) và in kết quả
            long result5 = Factorial(5);
            Console.WriteLine($"5! = {result5}");

            // TODO: Tính 10! bằng Factorial(10) và in kết quả
            long result10 = Factorial(10);
            Console.WriteLine($"10! = {result10}");
        }
    }
}