using Microsoft.AspNetCore.Components;
using PetsOnTrail.Persistence.Repositories.ActionsRepository;
using PetsOnTrail.Persistence.Repositories.ActionsRepository.Models;

namespace PetsOnTrail.App.Pages.ActionsList;

public class ActionsListBase : ComponentBase
{
    protected IEnumerable<ActionDto> Actions { get; set; } = new List<ActionDto>(0);

    [Inject] protected IActionsRepository ActionsRepository { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Actions = await ActionsRepository.GetActionsAsync(new List<Guid>(0), CancellationToken.None);

        StateHasChanged();
    }
}
