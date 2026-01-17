using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrderManagementApp.Models.ViewModels
{
    public class OrderViewModel
    {
        // For display/edit
        public int Id { get; set; }

        [Required(ErrorMessage = "Order number is required")]
        [Display(Name = "Order Number")]
        [RegularExpression(@"^ORD-\d{8}-\d{4}$", ErrorMessage = "Format must be ORD-YYYYMMDD-XXXX")]
        [StringLength(50, ErrorMessage = "Order number cannot exceed 50 characters")]
        public string OrderNumber { get; set; } = "";

        [Required(ErrorMessage = "Customer name is required")]
        [Display(Name = "Customer Name")]
        [MinLength(2, ErrorMessage = "Customer name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Customer name cannot exceed 100 characters")]
        public string CustomerName { get; set; } = "";

        [Required(ErrorMessage = "Customer email is required")]
        [Display(Name = "Customer Email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(100, ErrorMessage = "Customer email cannot exceed 100 characters")]
        public string CustomerEmail { get; set; } = "";

        [Required(ErrorMessage = "Please select a product")]
        [Display(Name = "Product")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        public DateTime? DeliveryDate { get; set; }

        // For dropdown
        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>();

        // For display only
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
        public string? Status { get; set; }
        public decimal? TotalPrice => Quantity * (ProductPrice ?? 0);
    }

    public class OrderListViewModel
    {
        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
        public string SearchTerm { get; set; } = "";
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 10;
    }
}