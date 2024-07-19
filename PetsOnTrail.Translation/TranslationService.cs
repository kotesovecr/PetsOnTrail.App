using System.Text.Json;

namespace PetsOnTrail.Translation;

internal class TranslationService : ITranslationService
{
    private string _language { get; set; } = "en-US";
    private JsonDocument _translationsData { get; set; } = null!;
    private readonly TranslationApiClient _translationApiClient;
    

    public TranslationService(TranslationApiClient translationApiClient)
    {
        _translationApiClient = translationApiClient;
    }

    public async Task SetLanguage(string language)
    {
        _language = language;
        await ReloadAsync();
    }

    public string Translate(string key)
    {
        return GetJsonValue(key);
    }

    private async Task ReloadAsync()
    {
        var jsonString = await _translationApiClient.GetTranslationAsync(_language);

        _translationsData = JsonDocument.Parse(jsonString);
    }

    public string GetJsonValue(string key)
    {
        if (_translationsData == null)
        {
            return key;
        }

        string[] parts = key.Split('.');
        JsonElement currentElement = _translationsData.RootElement;

        foreach (string part in parts)
        {
            if (currentElement.TryGetProperty(part, out JsonElement nextElement))
            {
                currentElement = nextElement;
            }
            else
            {
                return key;
            }
        }

        return currentElement.ToString();
    }
}
