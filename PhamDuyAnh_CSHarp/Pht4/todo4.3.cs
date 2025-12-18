using System;
namespace ArrayMethods
{
    class Program
    {
        // TODO: Viết phương thức tính tổng các phần tử trong mảng
        // Phương thức nhận vào mảng số nguyên numbers
        // Duyệt từng phần tử trong mảng và cộng dồn vào biến sum
        // Trả về tổng các phần tử
        static int SumArray(int[] numbers)
        {
            int sum = 0; // Biến lưu tổng
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i]; // Cộng từng phần tử vào tổng
            }
            return sum; // Trả về kết quả
        }
        // TODO: Viết phương thức tìm số lớn nhất trong mảng
        // Phương thức nhận vào mảng số nguyên numbers
        // Giả sử phần tử đầu tiên là lớn nhất
        // So sánh với các phần tử còn lại để tìm giá trị lớn nhất
        // Trả về số lớn nhất
        static int FindMax(int[] numbers)
        {
            int max = numbers[0]; // Giả sử phần tử đầu tiên là lớn nhất

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i]; // Cập nhật giá trị lớn nhất
                }
            }
            return max; // Trả về kết quả
        }
        static void Main(string[] args)
        {
            int[] scores = { 85, 92, 78, 90, 88 };

            // TODO: Gọi SumArray và in kết quả
            int total = SumArray(scores);
            Console.WriteLine($"Tổng các phần tử: {total}");
            // TODO: Gọi FindMax và in kết quả
            int maxScore = FindMax(scores);
            Console.WriteLine($"Giá trị lớn nhất: {maxScore}");
        }
    }
}