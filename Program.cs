using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;
using OrderManagementApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext với SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký OrderService
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Đã sửa 'controller=Home' thành 'controller=Orders' ở dòng dưới đây
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=Index}/{id?}");

// Tạo và seed database
try
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        // Tạo database nếu chưa có
        dbContext.Database.EnsureCreated();
        
        // Seed dữ liệu mẫu
        SeedData.Initialize(dbContext);
        
        Console.WriteLine("✅ Database seeded successfully!");
        Console.WriteLine($"📦 Products count: {dbContext.Products.Count()}");
        Console.WriteLine($"📋 Orders count: {dbContext.Orders.Count()}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error seeding database: {ex.Message}");
}

app.Run();