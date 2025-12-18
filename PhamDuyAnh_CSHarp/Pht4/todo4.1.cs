using System;
namespace BasicMethods
{
    class Program
    {
        // TODO: Viết phương thức tính tổng 2 số
        // Phương thức nhận vào 2 số nguyên a và b
        // Thực hiện phép cộng a + b
        // Trả về kết quả là tổng của 2 số
        static int Add(int a, int b)
        {
            int sum = a + b;   // Cộng hai số
            return sum;        // Trả về kết quả
        }

        // TODO: Viết phương thức tính tích 2 số
        // Phương thức nhận vào 2 số thực x và y
        // Thực hiện phép nhân x * y
        // Trả về kết quả là tích của 2 số
        static double Multiply(double x, double y)
        {
            double product = x * y; // Nhân hai số
            return product;         // Trả về kết quả
        }

        static void Main(string[] args)
        {
            // TODO: Gọi phương thức Add và in kết quả
            int sum = Add(5, 3); // Gọi phương thức Add
            Console.WriteLine($"Tổng: {sum}");

            // TODO: Gọi phương thức Multiply và in kết quả
            double product = Multiply(2.5, 4); // Gọi phương thức Multiply
            Console.WriteLine($"Tích: {product}");
        }
    }
}