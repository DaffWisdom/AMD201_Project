using Microsoft.EntityFrameworkCore; 
using UrlShortener.Api.Data;

var builder = WebApplication.CreateBuilder(args);
// Đăng ký AppDbContext với SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm dịch vụ Controller
builder.Services.AddControllers();

// Cấu hình CORS cho phép Frontend gọi API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Cổng mặc định của React Vite
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();

app.Run();