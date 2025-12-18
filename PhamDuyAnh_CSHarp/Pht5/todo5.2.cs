using System;
namespace Constructor
{
    // Tạo lớp Product
    class Product
    {
        public int ProductId;      
        public string ProductName;  
        public double Price;       
        //  Tạo constructor để khởi tạo dữ liệu ban đầu
        public Product(int id, string name, double price)
        {
            ProductId = id;          // gán id
            ProductName = name;      // gán tên
            Price = price;           // gán giá
        }
        //  Tạo phương thức hiển thị thông tin sản phẩm
        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo đối tượng Product bằng constructor
            Product p = new Product(1, "Bàn phím ", 800000);
            // Gọi Display để in thông tin
            p.Display();
        }
    }
}