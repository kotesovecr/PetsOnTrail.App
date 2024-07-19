using Blazored.LocalStorage;

namespace PetsOnTrail.Authentication.Providers;

public class TokenStorage
{
    private readonly ILocalStorageService _localStorageService;

    public TokenStorage(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task SetTokensAsync(string accessToken, string refreshToken)
    {
        await _localStorageService.SetItemAsStringAsync("accessToken", accessToken);
        await _localStorageService.SetItemAsStringAsync("refreshToken", refreshToken);
    }

    public async Task<string> GetAccessToken()
    {
        return await _localStorageService.GetItemAsStringAsync("accessToken");
    }

    public async Task<string> GetRefreshToken()
    {
        return await _localStorageService.GetItemAsStringAsync("refreshToken");
    }

    public async Task RemoveTokens()
    {
        await _localStorageService.RemoveItemAsync("accessToken");
        await _localStorageService.RemoveItemAsync("refreshToken");
    }
}
