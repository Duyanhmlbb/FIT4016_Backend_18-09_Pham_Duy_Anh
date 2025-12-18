using System;
namespace MethodOverloading
{
    class Program
    {
        // TODO: Viết phương thức Print phiên bản 1
        // Nhận vào một số nguyên
        // Nhiệm vụ: in ra giá trị số đó
        static void Print(int x)
        {
            Console.WriteLine($"Số nguyên: {x}");
        }

        // TODO: Viết phương thức Print phiên bản 2
        // Nhận vào một chuỗi
        // Nhiệm vụ: in ra nội dung chuỗi đó
        static void Print(string text)
        {
            Console.WriteLine($"Chuỗi: {text}");
        }
        // TODO: Viết phương thức Add phiên bản 1
        // Nhận vào hai số nguyên a và b
        // Thực hiện phép cộng a + b
        // Trả về tổng hai số nguyên
        static int Add(int a, int b)
        {
            int sum = a + b;
            return sum;
        }
        // TODO: Viết phương thức Add phiên bản 2
        // Nhận vào hai số thực a và b
        // Thực hiện phép cộng a + b
        // Trả về tổng hai số thực
        static double Add(double a, double b)
        {
            double sum = a + b;
            return sum;
        }

        static void Main(string[] args)
        {
            // TODO: Gọi Print với int
            Print(10);

            // TODO: Gọi Print với string
            Print("Hello Method Overloading");

            // TODO: Gọi Add(int, int)
            int sumInt = Add(5, 7);
            Console.WriteLine($"Tổng số nguyên: {sumInt}");

            // TODO: Gọi Add(double, double)
            double sumDouble = Add(2.5, 3.5);
            Console.WriteLine($"Tổng số thực: {sumDouble}");
        }
    }
}