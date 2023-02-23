namespace URLShortener.Services
{
    public interface IUrlConverterService
    {
        string GenerateShortString(int seed);
        int RestoreSeedFromString(string str);
    }
}