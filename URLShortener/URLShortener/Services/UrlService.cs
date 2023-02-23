using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using URLShortener.Entities;
using URLShortener.Exceptions;
using URLShortener.Models;

namespace URLShortener.Services
{
    public class UrlService : IUrlService
    {
        private readonly ShortUrlDbContext _shortURLDbContext;
        private readonly IUrlConverterService _uRLConverterService;
        private readonly IMapper _mapper;

        public UrlService(ShortUrlDbContext shortURLDbContext, IUrlConverterService uRLConverterService, IMapper mapper)
        {
            _shortURLDbContext = shortURLDbContext;
            _uRLConverterService = uRLConverterService;
            _mapper = mapper;
        }
        public string CreateShortURL(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                throw new InvalidDataException("Incorrect url");
            }

            var shortUrl = new ShortUrl()
            {
                LongUrl = url
            };

            _shortURLDbContext.ShortUrls.Add(shortUrl);
            _shortURLDbContext.SaveChanges();

            var convertedURL = _uRLConverterService.GenerateShortString(shortUrl.Id);

            return convertedURL;
        }

        public IEnumerable<UrlDto> GetAllUrls()
        {
            var urls = _shortURLDbContext.ShortUrls.ToList();

            var urlsDtos = _mapper.Map<List<UrlDto>>(urls);

            return urlsDtos;
        }

        public string GetUrlByShortUrl(string shortUrl)
        {
            var id = _uRLConverterService.RestoreSeedFromString(shortUrl);

            var urlRecord = _shortURLDbContext
                .ShortUrls
                .FirstOrDefault(u => u.Id == id);

            if (urlRecord is null)
            {
                throw new NotFoundException("URL not found");
            }

            var result = urlRecord.LongUrl;

            return result;
        }
    }
}
