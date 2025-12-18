using System;
namespace ForeachExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Tạo mảng tên các bạn
            string[] friends = { "DuyAnh", "Thế", "Đức", "Khánh" };
            // TODO: In danh sách bạn bè
            //  Dùng foreach
            int index = 1;
            foreach (string friend in friends)
            {
                Console.WriteLine($"{index}. {friend}");
                index++;
            }
        }
    }
}