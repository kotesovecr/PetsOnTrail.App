using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace PetsOnTrail.Authentication.Providers;

public class TokenProvider : ITokenProvider
{
    private string _token;
    private IAccessTokenProvider _tokenProvider;

    public TokenProvider(IAccessTokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task<string> GetTokenAsync()
    {
        if (_token == null)
        {
            var tokenResult = await _tokenProvider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token))
            {
                _token = token.Value;
            }
        }

        return _token;
    }

    public void Set(string token)
    {
        ;
    }
}