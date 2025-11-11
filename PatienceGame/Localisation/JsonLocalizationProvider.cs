using ClockPatience.ConsoleApp.Localisation;
using System.Text.Json;

namespace ConsoleApp.Localization
{
    public class JsonLocalizationProvider : ILocalizationProvider
    {
        private readonly Dictionary<string, string> _strings;

        public JsonLocalizationProvider(Language language)
        {
            // Firstly, we're loading 
            string langFolder;
            switch(language)
            {
                case Language.English:
                    langFolder = "Localisation/en/strings.json";
                    break;
                case Language.Maltese:
                    langFolder = "Localisation/mt/strings.json";
                    break;
                default:
                    throw new ArgumentException("Unsupported language");
            }

            var json = File.ReadAllText(langFolder);
            _strings = JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;
        }

        public string Get(string key)
        {
            return _strings.TryGetValue(key, out var value)
                ? value
                : $"[MISSING:{key}]";
        }
    }
}
