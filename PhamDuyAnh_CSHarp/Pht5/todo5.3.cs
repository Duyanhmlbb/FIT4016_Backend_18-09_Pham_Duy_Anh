using System;
namespace Encapsulation
{
    // TODO 1: Tạo lớp BankAccount
    class BankAccount
    {
        // TODO 2: Tạo field private để che giấu số dư
        private double _balance;
        // TODO 3: Tạo property chỉ đọc (không cho sửa trực tiếp)
        public double Balance
        {
            get { return _balance; }
        }
        // TODO 4: Tạo phương thức Deposit để gửi tiền
        public void Deposit(double amount)
        {
            _balance += amount;
            Console.WriteLine($"Đã gửi: {amount}. Số dư hiện tại: {_balance}");
        }
        // TODO 5: Tạo phương thức Withdraw để rút tiền
        public void Withdraw(double amount)
        {
            if (amount > _balance)
            {
                Console.WriteLine("Không đủ tiền để rút!");
            }
            else
            {
                _balance -= amount;
                Console.WriteLine($"Đã rút: {amount}. Số dư còn lại: {_balance}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // TODO 6: Tạo tài khoản mới
            BankAccount acc = new BankAccount();
            // TODO 7: Gửi tiền và rút tiền để kiểm tra
            acc.Deposit(1000);
            acc.Withdraw(100);
            acc.Withdraw(800);
        }
    }
}