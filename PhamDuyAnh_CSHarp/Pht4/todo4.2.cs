using System;
namespace VoidMethods
{
    class Program
    {
        // TODO: Viết phương thức in hộp trang trí
        // Phương thức nhận vào một chuỗi text
        // Không trả về giá trị (void)
        // Nhiệm vụ: in ra chuỗi được bao bởi ký tự *
        static void PrintBox(string text)
        {
            // In nội dung theo định dạng hộp
            Console.WriteLine($"* {text} *");
        }
        static void Main(string[] args)
        {
            // TODO: Gọi phương thức PrintBox với các giá trị khác nhau
            PrintBox("Hello");
            PrintBox("C# Programming");
            PrintBox("TODO 4.2");
        }
    }
}