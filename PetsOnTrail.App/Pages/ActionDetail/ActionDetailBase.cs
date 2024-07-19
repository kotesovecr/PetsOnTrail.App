using Microsoft.AspNetCore.Components;

namespace PetsOnTrail.App.Pages.ActionDetail;

public class ActionDetailBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }
}
