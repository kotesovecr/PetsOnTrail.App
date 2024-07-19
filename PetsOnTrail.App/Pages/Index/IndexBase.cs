using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PetsOnTrail.Authentication.Providers;

namespace PetsOnTrail.App.Pages.Index;

public class IndexBase : ComponentBase
{
    [Inject] PetsOnTrail.Authentication.Providers.ITokenProvider TokenProvider { get; set; }
    [Inject] PetsOnTrail.Authentication.Providers.TokenStorage TokenStorage { get; set; }
    [CascadingParameter] protected Task<AuthenticationState> AuthenticationStateTask { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var user = (await AuthenticationStateTask).User;

        if (user.Identity.IsAuthenticated)
        {
            var token = await TokenProvider.GetTokenAsync();
            await TokenStorage.SetTokensAsync(token, "");

            var claims = user.Claims;

            var userId = claims.FirstOrDefault(claim => claim.Type == "sub")?.Value ?? "";
            var firstName = claims.FirstOrDefault(claim => claim.Type == "given_name")?.Value ?? "";
            var lastName = claims.FirstOrDefault(claim => claim.Type == "family_name")?.Value ?? "";
            var emailClaim = claims.FirstOrDefault(claim => claim.Type == "email");
        }

        await base.OnInitializedAsync();
    }
}
