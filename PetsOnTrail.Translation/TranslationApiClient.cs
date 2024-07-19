namespace PetsOnTrail.Translation;

internal class TranslationApiClient
{
    private HttpClient _httpClient { get; set; } = null!;

    public TranslationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetTranslationAsync(string language)
    {
        var response = await _httpClient.GetAsync($"Translations/{language}.json");
        response.EnsureSuccessStatusCode();

        var ret = await response.Content.ReadAsStringAsync();

        return ret;
    }
}
