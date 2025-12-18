using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Chương trình Xếp loại Sinh viên ===\n");
        string hoVaTen = "Phạm Duy Anh";
        double diem = 9;
        Console.WriteLine($"Họ tên: {hoVaTen}");
        Console.WriteLine($"Điểm: {diem}\n");
        if (diem >= 8.5)
            Console.WriteLine("Xếp loại: Giỏi");
        else if (diem > 6)
            Console.WriteLine("Xếp loại: Trung bình");
        else
            Console.WriteLine("Xếp loại: Yếu");
        string[] tenSV = { "Lê Sỹ Mạnh Cường", "Mai Trọng Thế", "Nguyễn Trung Đức" };
        double[] diemSV = { 8, 7, 5 };
        Console.WriteLine("\n=== Bảng Điểm ===");
        for (int i = 0; i < tenSV.Length; i++)
        {
            string xepLoai;
            if (diemSV[i] >= 8.5)
                xepLoai = "Giỏi";
            else if (diemSV[i] > 6)
                xepLoai = "Trung bình";
            else
                xepLoai = "Yếu";
            Console.WriteLine($"{tenSV[i]} - {diemSV[i]} - {xepLoai}");
        }
        double tongDiem = 0;
        int j = 0;
        while (j < diemSV.Length)
        {
            tongDiem += diemSV[j];
            j++;
        }
        Console.WriteLine($"\nTổng điểm: {tongDiem}");
        Console.WriteLine($"Điểm trung bình: {tongDiem / diemSV.Length:F2}");
    }
}