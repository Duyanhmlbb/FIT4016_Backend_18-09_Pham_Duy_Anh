using System;
namespace StudentManagementSystem
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        // Constructor
        public Student(string id, string name, double score)
        {
            // StudentId không được rỗng
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("StudentId không được rỗng");

            // Name không được rỗng
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name không được rỗng");

            // Score phải từ 0 đến 10
            if (score < 0 || score > 10)
                throw new Exception("Score phải từ 0 đến 10");

            StudentId = id;
            Name = name;
            Score = score;
        }
        // Phương thức in thông tin
        public void Display()
        {
            // In ra "ID: [StudentId] | Tên: [Name] | Điểm: [Score]"
            Console.WriteLine($"ID: {StudentId} | Tên: {Name} | Điểm: {Score}");
        }
    }
}