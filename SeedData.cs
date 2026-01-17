using System;
using System.Linq;

namespace OrderManagementApp.Models
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // SEED PRODUCTS (15 sản phẩm)
            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product { Name = "Laptop Dell XPS 13", Sku = "LP-DELL-XPS13", Description = "Premium ultrabook", Price = 1299.99m, StockQuantity = 50, Category = "Electronics" },
                    new Product { Name = "iPhone 15 Pro", Sku = "PH-APPLE-15PRO", Description = "Latest Apple smartphone", Price = 999.99m, StockQuantity = 100, Category = "Electronics" },
                    new Product { Name = "Samsung Galaxy S24", Sku = "PH-SAMSUNG-S24", Description = "Android flagship", Price = 899.99m, StockQuantity = 80, Category = "Electronics" },
                    new Product { Name = "MacBook Air M3", Sku = "LP-APPLE-MBAIR", Description = "Apple lightweight laptop", Price = 1099.99m, StockQuantity = 40, Category = "Electronics" },
                    new Product { Name = "Sony WH-1000XM5", Sku = "HP-SONY-XM5", Description = "Noise cancelling headphones", Price = 349.99m, StockQuantity = 120, Category = "Audio" },
                    new Product { Name = "Logitech MX Master 3", Sku = "MS-LOGI-MX3", Description = "Wireless mouse", Price = 99.99m, StockQuantity = 200, Category = "Accessories" },
                    new Product { Name = "Dell 27 Monitor", Sku = "MN-DELL-27", Description = "4K UHD monitor", Price = 399.99m, StockQuantity = 60, Category = "Monitors" },
                    new Product { Name = "Nike Air Max", Sku = "SH-NIKE-AIRMAX", Description = "Running shoes", Price = 129.99m, StockQuantity = 150, Category = "Footwear" },
                    new Product { Name = "Levi's Jeans", Sku = "CL-LEVIS-501", Description = "Classic jeans", Price = 79.99m, StockQuantity = 200, Category = "Clothing" },
                    new Product { Name = "Python Programming Book", Sku = "BK-PYTHON-PRO", Description = "Learn Python programming", Price = 39.99m, StockQuantity = 300, Category = "Books" },
                    new Product { Name = "Coffee Maker", Sku = "HM-KRUPS-CM", Description = "Automatic coffee machine", Price = 149.99m, StockQuantity = 75, Category = "Home" },
                    new Product { Name = "Backpack", Sku = "BG-TARGUS-BP", Description = "Waterproof backpack", Price = 49.99m, StockQuantity = 180, Category = "Bags" },
                    new Product { Name = "Smart Watch", Sku = "WT-APPLE-SER9", Description = "Fitness tracker", Price = 299.99m, StockQuantity = 90, Category = "Wearables" },
                    new Product { Name = "Gaming Chair", Sku = "FN-RAZER-GC", Description = "Ergonomic gaming chair", Price = 249.99m, StockQuantity = 30, Category = "Furniture" },
                    new Product { Name = "External SSD 1TB", Sku = "ST-SAMSUNG-T7", Description = "Portable SSD", Price = 119.99m, StockQuantity = 150, Category = "Storage" }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
                Console.WriteLine("✅ Seeded 15 products.");
            }

            // SEED ORDERS (30 đơn hàng)
            if (!context.Orders.Any())
            {
                var products = context.Products.ToList();
                var random = new Random();
                var customers = new[]
                {
                    "John Smith", "Emma Johnson", "Michael Brown", "Sarah Davis", "James Wilson",
                    "Lisa Taylor", "Robert Anderson", "Maria Thomas", "David Jackson", "Jennifer White",
                    "Daniel Harris", "Susan Martin", "Paul Thompson", "Karen Garcia", "Mark Martinez",
                    "Nancy Robinson", "Steven Clark", "Betty Rodriguez", "Kevin Lewis", "Dorothy Lee",
                    "Andrew Walker", "Sandra Hall", "Brian Allen", "Ashley Young", "George King",
                    "Donna Wright", "Edward Scott", "Ruth Green", "Joshua Adams", "Sharon Baker"
                };

                for (int i = 1; i <= 30; i++)
                {
                    var product = products[random.Next(products.Count)];
                    var orderDate = DateTime.Today.AddDays(-random.Next(1, 90));
                    var deliveryDate = random.Next(3) > 1 ? orderDate.AddDays(random.Next(1, 10)) : (DateTime?)null;
                    
                    // Đảm bảo quantity không vượt stock
                    var maxQuantity = Math.Min(10, product.StockQuantity);
                    var quantity = random.Next(1, maxQuantity + 1);

                    var order = new Order
                    {
                        OrderNumber = $"ORD-{orderDate:yyyyMMdd}-{i:0000}",
                        CustomerName = customers[i - 1],
                        CustomerEmail = $"customer{i:00}@example.com",  // Format: customer01@example.com
                        ProductId = product.Id,
                        Quantity = quantity,
                        OrderDate = orderDate,
                        DeliveryDate = deliveryDate,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    context.Orders.Add(order);
                    
                    // Giảm stock quantity (tùy chọn - nếu muốn)
                    // product.StockQuantity -= quantity;
                }

                // context.SaveChanges(); // Đã có ở trên
                context.SaveChanges();
                Console.WriteLine("✅ Seeded 30 orders.");
            }
        }
    }
}