namespace UrlShortener.Api.Models
{
    public class UrlResponse
    {
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}