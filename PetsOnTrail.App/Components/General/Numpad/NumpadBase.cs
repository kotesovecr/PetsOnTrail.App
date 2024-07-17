using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PetsOnTrail.App.Components.General.Numpad;

public class NumpadBase : ComponentBase
{
    [Inject] protected IJSRuntime JSRuntime { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private ElementReference currentInput;
    private string currentInputId;
    private string currentValue;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("initializeNumpad", DotNetObjectReference.Create(this));
        }
    }

    [JSInvokable]
    public void ShowNumpad(string inputId)
    {
        currentInputId = inputId;
        currentValue = "";
        StateHasChanged();
    }

    protected void AppendNumber(string number)
    {
        currentValue += number;
        JSRuntime.InvokeVoidAsync("updateInputValue", currentInputId, currentValue);
    }

    protected void Cancel()
    {
        currentValue = "";
        JSRuntime.InvokeVoidAsync("updateInputValue", currentInputId, currentValue);
        CloseNumpad();
    }

    protected void OK()
    {
        JSRuntime.InvokeVoidAsync("updateInputValue", currentInputId, currentValue);
        JSRuntime.InvokeVoidAsync("submitInputValue", currentInputId);

        CloseNumpad();
    }

    protected void CloseNumpad()
    {
        JSRuntime.InvokeVoidAsync("hideNumpad");
    }
}
