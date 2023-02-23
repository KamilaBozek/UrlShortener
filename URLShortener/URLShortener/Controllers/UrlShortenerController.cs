using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Entities;
using URLShortener.Services;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlService _urlShortenerService;
        public UrlShortenerController(IUrlService uRLShortenerService)
        {
            _urlShortenerService = uRLShortenerService;
        }

        [HttpPost("api/createShortUrl")]
        public ActionResult<string> CreateShortUrl([FromBody] string url)
        {
            var shortURL = _urlShortenerService.CreateShortURL(url);
            var domain = Request.Host;
            return Ok($"{domain}/{shortURL}");
        }

        [HttpGet("api/getAll")]
        public ActionResult<IEnumerable<UrlDto>> GetAllUrls()
        {
            var allUrls = _urlShortenerService.GetAllUrls();
            
            return Ok(allUrls);
        }

        [HttpGet("urlShortener/{shortUrl}")]
        public ActionResult RedirectToLongUrl( string shortUrl)
        {
            var longUrl = _urlShortenerService.GetUrlByShortUrl(shortUrl);

            return Redirect(longUrl);
        }
    }
}
