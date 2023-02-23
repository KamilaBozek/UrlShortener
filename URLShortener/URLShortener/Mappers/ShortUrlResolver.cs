using AutoMapper;
using URLShortener.Entities;
using URLShortener.Models;
using URLShortener.Services;

namespace URLShortener.Mappers
{
    public class ShortUrlResolver : IValueResolver<ShortUrl, UrlDto, string>
    {
        private readonly IUrlConverterService _uRLConverterService;

        public ShortUrlResolver(IUrlConverterService uRLConverterService)
        {
            _uRLConverterService = uRLConverterService;
        }
        public string Resolve(ShortUrl source, UrlDto destination, string destMember, ResolutionContext context)
        {
            var convertedUrl = _uRLConverterService.GenerateShortString(source.Id);

            return convertedUrl;
        }
    }
}
