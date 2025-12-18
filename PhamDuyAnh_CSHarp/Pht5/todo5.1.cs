using System;
namespace BasicClass
{
    class Student
    {
        public int StudentId;
        public string Name;
        public double GPA;
        public void Display()
        {
            Console.WriteLine($"ID: {StudentId}, Name: {Name}, GPA: {GPA}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student();
            s1.StudentId = 1;
            s1.Name = "Duy Anh";
            s1.GPA = 3.5;
            s2.StudentId = 2;
            s2.Name = "Thế";
            s2.GPA = 3.5;
            s1.Display();
            s2.Display();
        }
    }
}