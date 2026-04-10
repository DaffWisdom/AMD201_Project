using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.Controllers;
using UrlShortener.Api.Data;
using UrlShortener.Api.Models;
using Xunit;
// Các thư viện cần thiết:
namespace UrlShortener.Tests
{
    public class UrlControllerTests
    {
        // Hàm hỗ trợ tạo CSDL ảo cho mỗi lần test
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        // Hàm hỗ trợ tạo Controller và giả lập Request (để lấy domain)
        private UrlController GetController(AppDbContext context)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost", 5000);

            return new UrlController(context)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };
        }

        [Fact]
        public void ShortenUrl_ValidUrl_ReturnsOkWithShortUrl()
        {
            // Arrange (Chuẩn bị dữ liệu)
            var context = GetInMemoryDbContext();
            var controller = GetController(context);
            var request = new UrlRequest { OriginalUrl = "https://google.com" };

            // Act (Thực thi hành động)
            var result = controller.ShortenUrl(request) as OkObjectResult;

            // Assert (Kiểm tra kết quả)
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            
            var response = result.Value as UrlResponse;
            Assert.NotNull(response);
            Assert.Equal("https://google.com", response.OriginalUrl);
            Assert.Contains("http://localhost:5000/", response.ShortUrl);
            
            // Đảm bảo dữ liệu đã được lưu vào DB ảo
            Assert.Equal(1, context.UrlMappings.Count());
        }

        [Fact]
        public void ShortenUrl_EmptyUrl_ReturnsBadRequest()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = GetController(context);
            var request = new UrlRequest { OriginalUrl = "" };

            // Act
            var result = controller.ShortenUrl(request) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("URL cannot be empty.", result.Value);
        }

        [Fact]
        public void RedirectUrl_ValidCode_ReturnsRedirect()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            // Cấy sẵn 1 link vào DB ảo
            context.UrlMappings.Add(new UrlMapping { OriginalUrl = "https://github.com", ShortCode = "github" });
            context.SaveChanges();
            
            var controller = GetController(context);

            // Act
            var result = controller.RedirectUrl("github") as RedirectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("https://github.com", result.Url);
        }

        [Fact]
        public void RedirectUrl_InvalidCode_ReturnsNotFound()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = GetController(context);

            // Act
            var result = controller.RedirectUrl("notexist") as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
            Assert.Equal("Short URL not found.", result.Value);
            
        }
    }
}
// Các test trên đã kiểm tra các tình huống chính của API:
// 1. Rút gọn URL hợp lệ.