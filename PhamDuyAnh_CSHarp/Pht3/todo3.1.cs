using System;
namespace GradeClassification
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Nhập điểm (giả sử: 75)
            int score = 75; // Thay đổi giá trị để test khác
            // TODO: Khai báo biến lưu kết quả phân loại
            string result;
            // TODO: Phân loại điểm
            if (score >= 90 && score <= 100)
            {
                result = "A (Xuất sắc)";
            }
            else if (score >= 80)
            {
                result = "B (Khá)";
            }
            else if (score >= 70)
            {
                result = "C (Trung bình)";
            }
            else if (score >= 60)
            {
                result = "D (Yếu)";
            }
            else
            {
                result = "F (Không đạt)";
            }
            // TODO: In kết quả
            Console.WriteLine($"Điểm: {score} → Xếp loại: {result}");
        }
    }
}