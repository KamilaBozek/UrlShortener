using System.Text;

namespace URLShortener.Services
{
    public class UrlConverterService : IUrlConverterService
    {
        private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUWXYZ";
        private readonly IDictionary<char, int> AlphabetIndex;
        private readonly int Base = Alphabet.Length;

        public UrlConverterService()
        {
            AlphabetIndex = Alphabet
                .Select((c, i) => new { Index = i, Char = c })
                .ToDictionary(c => c.Char, c => c.Index);
        }

        public string GenerateShortString(int seed)
        {
            if (seed < Base)
            {
                return Alphabet[seed].ToString();
            }

            var str = new StringBuilder();
            var i = seed;

            while (i > 0)
            {
                str.Insert(0, Alphabet[i % Base]);
                i /= Base;
            }

            return str.ToString();
        }

        public int RestoreSeedFromString(string str)
        {
            return str.Aggregate(0, (current, c) => current * Base + AlphabetIndex[c]);
        }
    }
}
