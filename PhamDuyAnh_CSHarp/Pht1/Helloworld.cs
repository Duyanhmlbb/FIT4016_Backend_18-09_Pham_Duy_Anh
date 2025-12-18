using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Chào mừng đến với C#!");
        string ten = "Phạm Duy Anh";
        int tuoi = 20;
        double diem = 9;
        Console.WriteLine("Tên: " + ten);
        Console.WriteLine("Tuổi: " + tuoi);
        Console.WriteLine("Điểm: " + diem);
        Console.WriteLine($"Thông tin: {ten}, tuổi {tuoi}, điểm {diem}");
    }
}