using System;

namespace StudentManagementSystem
{
    public class StudentManager
    {
        private Student?[] students = new Student?[50];
        private int count = 0; // Số lượng sinh viên hiện tại

        // TODO: Phương thức AddStudent(string id, string name, double score)
        // Thêm sinh viên mới, kiểm tra trùng lặp
        public void AddStudent(string id, string name, double score)
        {
            if (count >= 50)
                throw new Exception("Danh sách đã đầy");

            if (FindStudentById(id) != null)
                throw new Exception("Trùng ID sinh viên");

            students[count++] = new Student(id, name, score);
        }

        // TODO: Phương thức RemoveStudent(string id)
        // Xóa sinh viên theo ID
        public void RemoveStudent(string id)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i]?.StudentId == id)
                {
                    for (int j = i; j < count - 1; j++)
                        students[j] = students[j + 1];

                    students[--count] = null;
                    return;
                }
            }
            throw new Exception("Không tìm thấy sinh viên");
        }

        // TODO: Phương thức UpdateScore(string id, double newScore)
        // Cập nhật điểm
        public void UpdateScore(string id, double newScore)
        {
            if (newScore < 0 || newScore > 10)
                throw new Exception("Score phải từ 0 đến 10");

            Student? s = FindStudentById(id);
            if (s == null)
                throw new Exception("Không tìm thấy sinh viên");

            s.Score = newScore;
        }

        // TODO: Phương thức GetAverageScore()
        // Tính điểm trung bình
        public double GetAverageScore()
        {
            if (count == 0)
                throw new Exception("Danh sách rỗng");

            double sum = 0;
            for (int i = 0; i < count; i++)
                sum += students[i]!.Score;

            return sum / count;
        }

        // TODO: Phương thức GetMaxScore()
        // Tìm điểm cao nhất
        public double GetMaxScore()
        {
            if (count == 0)
                throw new Exception("Danh sách rỗng");

            double max = students[0]!.Score;
            for (int i = 1; i < count; i++)
                if (students[i]!.Score > max)
                    max = students[i]!.Score;

            return max;
        }

        // TODO: Phương thức GetStudentWithMaxScore()
        // Tìm sinh viên có điểm cao nhất
        public Student? GetStudentWithMaxScore()
        {
            if (count == 0)
                return null;

            Student? maxStudent = students[0];
            for (int i = 1; i < count; i++)
                if (students[i]!.Score > maxStudent!.Score)
                    maxStudent = students[i];

            return maxStudent;
        }

        // TODO: Phương thức GetStudentCount()
        // Lấy số lượng sinh viên
        public int GetStudentCount()
        {
            return count;
        }

        // TODO: Phương thức FindStudentById(string id)
        // Trả về đối tượng Student hoặc null
        public Student? FindStudentById(string id)
        {
            for (int i = 0; i < count; i++)
                if (students[i]?.StudentId == id)
                    return students[i];

            return null;
        }

        // TODO: Phương thức DisplayAllStudents()
        // In danh sách tất cả sinh viên
        public void DisplayAllStudents()
        {
            if (count == 0)
            {
                Console.WriteLine("Danh sách rỗng");
                return;
            }

            for (int i = 0; i < count; i++)
                students[i]?.Display();
        }
    }
}
