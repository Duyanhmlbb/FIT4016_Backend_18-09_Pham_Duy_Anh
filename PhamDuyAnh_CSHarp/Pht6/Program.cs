using System;
using System.Text.RegularExpressions;
namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool running = true;
            while (running)
            {
                // TODO: In menu
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xóa sinh viên");
                Console.WriteLine("3. Cập nhật điểm");
                Console.WriteLine("4. In danh sách");
                Console.WriteLine("5. Tính điểm trung bình");
                Console.WriteLine("6. Tìm điểm cao nhất");
                Console.WriteLine("7. Tìm sinh viên");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("========================");
                Console.Write("Chọn: ");
                // TODO: Thêm try-catch để xử lý lỗi
                try
                {
                    // TODO: Nhận lựa chọn từ người dùng
                    string choiceInput = Console.ReadLine() ?? "";
                    if (!int.TryParse(choiceInput, out int choice))
                    {
                        Console.WriteLine("❌ Lỗi nhập liệu: Vui lòng nhập một số nguyên để chọn menu!");
                        continue;
                    }

                    // TODO: Dùng switch xử lý từng lựa chọn
                    switch (choice)
                    {
                        case 1:
                            {
                                string id = "";
                                bool validId = false;
                                while (!validId)
                                {
                                    Console.Write("ID: ");
                                    id = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(id))
                                    {
                                        Console.WriteLine("❌ ID không được để trống! Vui lòng nhập lại.");
                                    }
                                    else if (manager.FindStudentById(id) != null)
                                    {
                                        Console.WriteLine("❌ ID này đã tồn tại! Vui lòng nhập ID khác.");
                                    }
                                    else
                                    {
                                        validId = true;
                                    }
                                }

                                string name = "";
                                bool validName = false;
                                while (!validName)
                                {
                                    Console.Write("Tên: ");
                                    name = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(name))
                                    {
                                        Console.WriteLine("❌ Tên không được để trống! Vui lòng nhập lại.");
                                    }
                                    else if (name.Any(char.IsDigit))
                                    {
                                        Console.WriteLine("❌ Tên không được chứa số! Vui lòng nhập lại.");
                                    }
                                    else
                                    {
                                        validName = true;
                                    }
                                }
                                double score = 0;
                                bool validScore = false;
                                while (!validScore)
                                {
                                    Console.Write("Điểm: ");
                                    string scoreInput = Console.ReadLine() ?? "";
                                    if (!double.TryParse(scoreInput, out score))
                                    {
                                        Console.WriteLine("❌ Điểm phải là một số hợp lệ! Vui lòng nhập lại.");
                                    }
                                    else if (score < 0 || score > 10)
                                    {
                                        Console.WriteLine("❌ Điểm phải từ 0 đến 10! Vui lòng nhập lại.");
                                    }
                                    else
                                    {
                                        validScore = true;
                                    }
                                }

                                manager.AddStudent(id, name, score);
                                Console.WriteLine("✓ Thêm sinh viên thành công!");
                                break;
                            }

                        case 2:
                            {
                                string removeId = "";
                                bool validId = false;
                                while (!validId)
                                {
                                    Console.Write("Nhập ID cần xóa (Enter để bỏ qua): ");
                                    removeId = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(removeId))
                                    {
                                        validId = true;
                                        break;
                                    }
                                    else if (manager.FindStudentById(removeId) == null)
                                    {
                                        Console.WriteLine("❌ ID này không tồn tại! Vui lòng nhập ID khác.");
                                    }
                                    else
                                    {
                                        validId = true;
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(removeId))
                                {
                                    manager.RemoveStudent(removeId);
                                    Console.WriteLine("✓ Xóa sinh viên thành công!");
                                }
                                break;
                            }

                        case 3:
                            {
                                string uid = "";
                                bool validId = false;
                                while (!validId)
                                {
                                    Console.Write("Nhập ID: ");
                                    uid = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(uid))
                                    {
                                        Console.WriteLine("❌ ID không được để trống! Vui lòng nhập lại.");
                                    }
                                    else if (manager.FindStudentById(uid) == null)
                                    {
                                        Console.WriteLine("❌ ID này không tồn tại! Vui lòng nhập ID khác.");
                                    }
                                    else
                                    {
                                        validId = true;
                                    }
                                }

                                double newScore = 0;
                                bool validScore = false;
                                while (!validScore)
                                {
                                    Console.Write("Điểm mới: ");
                                    string newScoreInput = Console.ReadLine() ?? "";
                                    if (!double.TryParse(newScoreInput, out newScore))
                                    {
                                        Console.WriteLine("❌ Điểm phải là một số hợp lệ! Vui lòng nhập lại.");
                                    }
                                    else if (newScore < 0 || newScore > 10)
                                    {
                                        Console.WriteLine("❌ Điểm phải từ 0 đến 10! Vui lòng nhập lại.");
                                    }
                                    else
                                    {
                                        validScore = true;
                                    }
                                }

                                manager.UpdateScore(uid, newScore);
                                Console.WriteLine("✓ Cập nhật điểm thành công!");
                                break;
                            }

                        case 4:
                            manager.DisplayAllStudents();
                            break;

                        case 5:
                            Console.WriteLine($"Điểm trung bình của {manager.GetStudentCount()} học sinh: {manager.GetAverageScore()}");
                            break;
                        case 6:
                            {
                                Student? topStudent = manager.GetStudentWithMaxScore();
                                if (topStudent != null)
                                {
                                    Console.WriteLine($"Sinh viên có điểm cao nhất:");
                                    topStudent.Display();
                                }
                                break;
                            }

                        case 7:
                            {
                                string searchId = "";
                                bool validId = false;
                                while (!validId)
                                {
                                    Console.Write("Nhập ID cần tìm: ");
                                    searchId = Console.ReadLine() ?? "";
                                    if (string.IsNullOrWhiteSpace(searchId))
                                    {
                                        Console.WriteLine("❌ ID không được để trống! Vui lòng nhập lại.");
                                    }
                                    else
                                    {
                                        validId = true;
                                    }
                                }
                                Student? s = manager.FindStudentById(searchId);
                                if (s == null)
                                    Console.WriteLine("❌ Không tìm thấy sinh viên với ID này");
                                else
                                    s.Display();
                                break;
                            }

                        case 0:
                            running = false;
                            break;

                        default:
                            Console.WriteLine("❌ Lựa chọn không hợp lệ, vui lòng chọn từ 0 đến 7!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Lỗi: " + ex.Message);
                }
            }
        }
    }
}