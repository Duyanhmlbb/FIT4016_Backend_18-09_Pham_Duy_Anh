using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;

namespace OrderManagementApp.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL ORDERS WITH PAGINATION
        public async Task<(List<Order> Orders, int TotalCount)> GetOrdersAsync(
            string search = "", 
            int page = 1, 
            int pageSize = 10)
        {
            var query = _context.Orders
                .Include(o => o.Product)
                .AsQueryable();

            // Search functionality
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(o => 
                    o.OrderNumber.Contains(search) || 
                    o.CustomerName.Contains(search));
            }

            // Get total count for pagination
            var totalCount = await query.CountAsync();

            // Apply pagination
            var orders = await query
                .OrderByDescending(o => o.OrderDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (orders, totalCount);
        }

        // GET ORDER BY ID
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        // CREATE NEW ORDER
        public async Task<(bool Success, string Message)> CreateOrderAsync(Order order)
        {
            try
            {
                // Check if order number already exists
                if (await _context.Orders.AnyAsync(o => o.OrderNumber == order.OrderNumber))
                {
                    return (false, "Order number already exists.");
                }

                // Check if customer email already exists
                if (await _context.Orders.AnyAsync(o => o.CustomerEmail == order.CustomerEmail))
                {
                    return (false, "Customer email already exists.");
                }

                // Check if product exists
                var product = await _context.Products.FindAsync(order.ProductId);
                if (product == null)
                {
                    return (false, "Product not found.");
                }

                // Check quantity vs stock
                if (order.Quantity > product.StockQuantity)
                {
                    return (false, $"Quantity exceeds available stock. Available: {product.StockQuantity}");
                }

                // Check order date
                if (order.OrderDate > DateTime.Today)
                {
                    return (false, "Order date cannot be in the future.");
                }

                // Check delivery date
                if (order.DeliveryDate.HasValue && order.DeliveryDate < order.OrderDate)
                {
                    return (false, "Delivery date must be after order date.");
                }

                // Set timestamps
                order.CreatedAt = DateTime.UtcNow;
                order.UpdatedAt = DateTime.UtcNow;

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return (true, "Order created successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error creating order: {ex.Message}");
            }
        }

        // UPDATE ORDER
        public async Task<(bool Success, string Message)> UpdateOrderAsync(Order order)
        {
            try
            {
                var existingOrder = await _context.Orders.FindAsync(order.Id);
                if (existingOrder == null)
                {
                    return (false, "Order not found.");
                }

                // Check if customer email already exists (excluding current order)
                if (await _context.Orders.AnyAsync(o => 
                    o.CustomerEmail == order.CustomerEmail && o.Id != order.Id))
                {
                    return (false, "Customer email already exists.");
                }

                // Check if product exists
                var product = await _context.Products.FindAsync(order.ProductId);
                if (product == null)
                {
                    return (false, "Product not found.");
                }

                // Check quantity vs stock
                if (order.Quantity > product.StockQuantity)
                {
                    return (false, $"Quantity exceeds available stock. Available: {product.StockQuantity}");
                }

                // Check order date (should not be changed)
                if (order.OrderDate != existingOrder.OrderDate)
                {
                    return (false, "Order date cannot be changed.");
                }

                // Check delivery date
                if (order.DeliveryDate.HasValue && order.DeliveryDate < order.OrderDate)
                {
                    return (false, "Delivery date must be after order date.");
                }

                // Update fields (except OrderNumber and ProductId which are keys)
                existingOrder.CustomerName = order.CustomerName;
                existingOrder.CustomerEmail = order.CustomerEmail;
                existingOrder.Quantity = order.Quantity;
                existingOrder.DeliveryDate = order.DeliveryDate;
                existingOrder.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return (true, "Order updated successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error updating order: {ex.Message}");
            }
        }

        // DELETE ORDER
        public async Task<(bool Success, string Message)> DeleteOrderAsync(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    return (false, "Order not found.");
                }

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                return (true, "Order deleted successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error deleting order: {ex.Message}");
            }
        }

        // GET ALL PRODUCTS FOR DROPDOWN
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        // GENERATE NEXT ORDER NUMBER
        public string GenerateOrderNumber()
        {
            var today = DateTime.Today;
            var count = _context.Orders
                .Count(o => o.OrderDate.Date == today) + 1;
            
            return $"ORD-{today:yyyyMMdd}-{count:0000}";
        }
    }
}