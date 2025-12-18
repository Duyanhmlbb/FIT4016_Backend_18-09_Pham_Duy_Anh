using System;
namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Nhập số ngày (1-7)
            int day = 3; // Thứ Tư
            // TODO: Khai báo biến lưu tên ngày
            string dayName;
            // TODO: Dùng switch để xác định tên ngày
            switch (day)
            {
                case 1:
                    dayName = "Thứ Hai";
                    break;
                case 2:
                    dayName = "Thứ Ba";
                    break;
                case 3:
                    dayName = "Thứ Tư";
                    break;
                case 4:
                    dayName = "Thứ Năm";
                    break;
                case 5:
                    dayName = "Thứ Sáu";
                    break;
                case 6:
                    dayName = "Thứ Bảy";
                    break;
                case 7:
                    dayName = "Chủ Nhật";
                    break;
                default:
                    dayName = "Ngày không hợp lệ";
                    break;
            }
            // TODO: In kết quả
            Console.WriteLine($"Ngày số {day} là: {dayName}");
        }
    }
}