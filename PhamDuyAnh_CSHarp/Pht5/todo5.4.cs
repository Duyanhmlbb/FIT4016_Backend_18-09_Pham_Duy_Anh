using System;

namespace Inheritance
{
    // TODO: Tạo lớp Animal (cha)
    // Thuộc tính: Name
    // Phương thức: MakeSound() (in ra "Animal makes a sound")
    class Animal
    {
        public string Name { get; set; }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    // TODO: Tạo lớp Dog (con) kế thừa từ Animal
    // Override phương thức MakeSound() (in ra "Woof! Woof!")
    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Tạo đối tượng Animal và Dog
            Animal a = new Animal();
            Dog d = new Dog();

            // TODO: Gọi MakeSound() của cả hai
            a.MakeSound();
            d.MakeSound();
        }
    }
}
