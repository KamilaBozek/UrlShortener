using URLShortener.Models;

namespace URLShortener.Services
{
    public interface IUrlService
    {
        string CreateShortURL(string url);

        IEnumerable<UrlDto> GetAllUrls();

        string GetUrlByShortUrl(string shortUrl);
    }
}
