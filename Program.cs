using PostManagementApp.Services;
var builder = WebApplication.CreateBuilder(args);
// Đăng ký Service
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Post}/{action=Index}/{id?}");
app.Run();