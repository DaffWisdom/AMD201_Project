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
            if (string.IsNullOrWhiteSpace(request.OriginalUrl))
                return BadRequest("URL cannot be empty.");

            // Sinh mã ngẫu nhiên 6 ký tự
            string shortCode = Guid.NewGuid().ToString().Substring(0, 6);

            // 1. Tạo đối tượng lưu vào DB
            var urlMapping = new UrlMapping
            {
                OriginalUrl = request.OriginalUrl,
                ShortCode = shortCode
            };

            // 2. Thêm vào DB và lưu lại
            _context.UrlMappings.Add(urlMapping);
            _context.SaveChanges();

            var baseUrl = $"{Request.Scheme}://{Request.Host}";
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