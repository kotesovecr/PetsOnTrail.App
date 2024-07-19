namespace PetsOnTrail.Authentication.Providers;

public interface ITokenProvider
{
    public Task<string> GetTokenAsync();

    public void Set(string token);
}
