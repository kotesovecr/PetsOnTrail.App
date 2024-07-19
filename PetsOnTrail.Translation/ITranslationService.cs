namespace PetsOnTrail.Translation;

public interface ITranslationService
{
    Task SetLanguage(string language);
    string Translate(string key);
}
