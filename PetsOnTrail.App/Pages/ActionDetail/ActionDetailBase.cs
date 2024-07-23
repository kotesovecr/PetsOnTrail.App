using Microsoft.AspNetCore.Components;
using PetsOnTrail.Persistence.Repositories.ActionsRepository;
using PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

namespace PetsOnTrail.App.Pages.ActionDetail;

public class ActionDetailBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; }

    protected ActionDto Action { get; set; } = null;

    [Inject] protected IActionsRepository ActionsRepository { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Action = await ActionsRepository.GetActionAsync(Guid.Parse(ActionId), CancellationToken.None);

        await base.OnInitializedAsync();
    }
}
