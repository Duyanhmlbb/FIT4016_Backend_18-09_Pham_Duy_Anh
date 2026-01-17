using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;
using OrderManagementApp.Models.ViewModels;
using OrderManagementApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrderManagementApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Orders (With pagination and search)
        public async Task<IActionResult> Index(string search = "", int page = 1, int pageSize = 10)
        {
            try
            {
                var (orders, totalCount) = await _orderService.GetOrdersAsync(search, page, pageSize);

                var viewModel = new OrderListViewModel
                {
                    Orders = orders.Select(o => new OrderViewModel
                    {
                        Id = o.Id,
                        OrderNumber = o.OrderNumber,
                        CustomerName = o.CustomerName,
                        CustomerEmail = o.CustomerEmail,
                        ProductId = o.ProductId,
                        ProductName = o.Product?.Name,
                        ProductPrice = o.Product?.Price,
                        ProductStock = o.Product?.StockQuantity,
                        Quantity = o.Quantity,
                        OrderDate = o.OrderDate,
                        DeliveryDate = o.DeliveryDate,
                        Status = o.DeliveryDate.HasValue ? "Delivered" : "Pending"
                    }).ToList(),
                    
                    SearchTerm = search,
                    CurrentPage = page,
                    TotalCount = totalCount,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading orders: {ex.Message}";
                return View(new OrderListViewModel());
            }
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Order ID is required.";
                return RedirectToAction(nameof(Index));
            }

            var order = await _orderService.GetOrderByIdAsync(id.Value);
            if (order == null)
            {
                TempData["ErrorMessage"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new OrderViewModel
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                ProductId = order.ProductId,
                ProductName = order.Product?.Name,
                ProductPrice = order.Product?.Price,
                ProductStock = order.Product?.StockQuantity,
                Quantity = order.Quantity,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Status = order.DeliveryDate.HasValue ? "Delivered" : "Pending"
            };

            return View(viewModel);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new OrderViewModel
            {
                OrderNumber = _orderService.GenerateOrderNumber(),
                OrderDate = DateTime.Today,
                Products = await GetProductSelectList()
            };

            return View(viewModel);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = new Order
                    {
                        OrderNumber = viewModel.OrderNumber,
                        CustomerName = viewModel.CustomerName,
                        CustomerEmail = viewModel.CustomerEmail,
                        ProductId = viewModel.ProductId,
                        Quantity = viewModel.Quantity,
                        OrderDate = viewModel.OrderDate,
                        DeliveryDate = viewModel.DeliveryDate
                    };

                    var (success, message) = await _orderService.CreateOrderAsync(order);
                    
                    if (success)
                    {
                        TempData["SuccessMessage"] = message;
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = message;
                    }
                }

                // If we got here, something went wrong
                viewModel.Products = await GetProductSelectList();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error creating order: {ex.Message}";
                viewModel.Products = await GetProductSelectList();
                return View(viewModel);
            }
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Order ID is required.";
                return RedirectToAction(nameof(Index));
            }

            var order = await _orderService.GetOrderByIdAsync(id.Value);
            if (order == null)
            {
                TempData["ErrorMessage"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new OrderViewModel
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Products = await GetProductSelectList(),
                ProductName = order.Product?.Name,
                ProductPrice = order.Product?.Price,
                ProductStock = order.Product?.StockQuantity
            };

            return View(viewModel);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                TempData["ErrorMessage"] = "Order ID mismatch.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var order = new Order
                    {
                        Id = viewModel.Id,
                        OrderNumber = viewModel.OrderNumber,
                        CustomerName = viewModel.CustomerName,
                        CustomerEmail = viewModel.CustomerEmail,
                        ProductId = viewModel.ProductId,
                        Quantity = viewModel.Quantity,
                        OrderDate = viewModel.OrderDate,
                        DeliveryDate = viewModel.DeliveryDate
                    };

                    var (success, message) = await _orderService.UpdateOrderAsync(order);
                    
                    if (success)
                    {
                        TempData["SuccessMessage"] = message;
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = message;
                    }
                }

                // If we got here, something went wrong
                viewModel.Products = await GetProductSelectList();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating order: {ex.Message}";
                viewModel.Products = await GetProductSelectList();
                return View(viewModel);
            }
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Order ID is required.";
                return RedirectToAction(nameof(Index));
            }

            var order = await _orderService.GetOrderByIdAsync(id.Value);
            if (order == null)
            {
                TempData["ErrorMessage"] = "Order not found.";
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new OrderViewModel
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                ProductName = order.Product?.Name,
                Quantity = order.Quantity,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Status = order.DeliveryDate.HasValue ? "Delivered" : "Pending"
            };

            return View(viewModel);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var (success, message) = await _orderService.DeleteOrderAsync(id);
                
                if (success)
                {
                    TempData["SuccessMessage"] = message;
                }
                else
                {
                    TempData["ErrorMessage"] = message;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting order: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // Helper method to get product dropdown
        private async Task<List<SelectListItem>> GetProductSelectList()
        {
            var products = await _orderService.GetAllProductsAsync();
            return products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Name} (Stock: {p.StockQuantity}, Price: ${p.Price})"
            }).ToList();
        }
    }
}