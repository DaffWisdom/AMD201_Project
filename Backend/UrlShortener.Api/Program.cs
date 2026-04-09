using Microsoft.EntityFrameworkCore; 
using UrlShortener.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// 2. Cấu hình CORS - CHỈ DÙNG MỘT KHỐI DUY NHẤT
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 3. THỨ TỰ MIDDLEWARE (Cực kỳ quan trọng)
// UseCors PHẢI nằm trước MapControllers
app.UseRouting(); 
app.UseCors("AllowAll"); 
app.UseAuthorization();

app.MapControllers();

// 4. Tự động Migrate Database (Gộp lại cho gọn)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); 
        Console.WriteLine("Database migrated successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred migrating the DB: {ex.Message}");
    }
}

app.Run();