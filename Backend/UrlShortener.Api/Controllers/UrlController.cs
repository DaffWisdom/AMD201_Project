using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.Models;
using UrlShortener.Api.Data;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Tiêm (Inject) Database Context vào Controller
        public UrlController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ShortenUrl([FromBody] UrlRequest request)
        {
            // 1. Kiểm tra URL rỗng
            if (string.IsNullOrWhiteSpace(request.OriginalUrl))
                return BadRequest("URL cannot be empty.");

            // 2. Xác thực định dạng URL (Phải là đường dẫn hợp lệ http/https)
            if (!Uri.TryCreate(request.OriginalUrl, UriKind.Absolute, out _))
            {
                return BadRequest("Invalid URL format. Please include http:// or https://");
            }

            // 3. LOGIC CHỐNG TRÙNG LẶP: Tìm trong DB xem URL này đã từng được rút gọn chưa
            var existingUrl = _context.UrlMappings.FirstOrDefault(u => u.OriginalUrl == request.OriginalUrl);
            
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            // Nếu đã tồn tại, trả về luôn mã cũ (Không tạo thêm dòng mới trong DB)
            if (existingUrl != null)
            {
                var existingResponse = new UrlResponse
                {
                    OriginalUrl = existingUrl.OriginalUrl,
                    ShortUrl = $"{baseUrl}/{existingUrl.ShortCode}",
                    CreatedAt = existingUrl.CreatedAt
                };
                return Ok(existingResponse);
            }

            // 4. Nếu chưa tồn tại, tiến hành sinh mã ngẫu nhiên 6 ký tự như bình thường
            string shortCode = Guid.NewGuid().ToString().Substring(0, 6);

            var urlMapping = new UrlMapping
            {
                OriginalUrl = request.OriginalUrl,
                ShortCode = shortCode
            };

            _context.UrlMappings.Add(urlMapping);
            _context.SaveChanges();

            var response = new UrlResponse
            {
                OriginalUrl = request.OriginalUrl,
                ShortUrl = $"{baseUrl}/{shortCode}",
                CreatedAt = urlMapping.CreatedAt
            };

            return Ok(response);
        }

        [HttpGet("/{shortCode}")]
        public IActionResult RedirectUrl(string shortCode)
        {
            // Tìm URL trong Database
            var urlMapping = _context.UrlMappings.FirstOrDefault(u => u.ShortCode == shortCode);

            if (urlMapping != null)
            {
                return Redirect(urlMapping.OriginalUrl);
            }

            return NotFound("Short URL not found.");
        }
    }
}