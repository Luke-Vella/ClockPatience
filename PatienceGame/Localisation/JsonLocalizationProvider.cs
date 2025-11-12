using System.Text.Json;

namespace ClockPatience.ConsoleApp.Localisation
{
    public class JsonLocalizationProvider : ILocalizationProvider
    {
        private readonly Dictionary<string, string> _strings;


        public JsonLocalizationProvider(Language language)
        {
            /* Dev note: All localisation options are currently not proofread and have been automatically generated with AI tools.
            * Kindly remove this comment should documentation team liaise with suitable translators.
            * Apologies for any butchering of these beautiful languages. I am sure they deserve better. */

            string langFolder = language switch
            {
                Language.English => "Localisation/en/strings.json",
                Language.Maltese => "Localisation/mt/strings.json",
                _ => throw new ArgumentException("Unsupported language"),
            };
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
