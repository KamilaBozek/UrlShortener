using AutoMapper;
using URLShortener.Entities;
using URLShortener.Models;

namespace URLShortener.Mappers
{
    public class UrlMappingProfile : Profile
    {
        public UrlMappingProfile()
        {
            CreateMap<ShortUrl, UrlDto>()
                .ForMember(m => m.ShortUrl, c => c.MapFrom<ShortUrlResolver>());
        }
    }
}
