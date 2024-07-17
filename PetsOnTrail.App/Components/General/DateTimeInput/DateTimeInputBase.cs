using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PetsOnTrail.App.Components.General.DateTimeInput;

public class DateTimeInputBase : ComponentBase
{
    [Parameter] public DateTimeOffset? Value { get; set; } = null;
    [Parameter] public bool WithSeconds { get; set; } = false;
    [Parameter] public EventCallback<DateTimeOffset?> OnTimeUpdate { get; set; }

    [Inject] protected IJSRuntime JSRuntime { get; set; }

    

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected string inputValue;
    protected string inputId = Guid.NewGuid().ToString();

    protected void FormatInput(ChangeEventArgs e)
    {
        if (WithSeconds == false)
        { 
            if (inputValue.Length == 4 && int.TryParse(inputValue, out int parsedValueHhMm))
            {
                int hours = parsedValueHhMm / 100;
                int minutes = parsedValueHhMm % 100;

                DateTime now = DateTime.Now;
                Value = new DateTimeOffset(new DateTime(now.Year, now.Month, now.Day, hours, minutes, 0, DateTimeKind.Local).ToUniversalTime());

                OnTimeUpdate.InvokeAsync(Value);
            }
            else if (inputValue.Length == 6 && int.TryParse(inputValue, out int parsedValueDdHhMm))
            {
                int day = parsedValueDdHhMm / 10000;
                int hours = (parsedValueDdHhMm % 10000) / 100;
                int minutes = parsedValueDdHhMm % 100;

                DateTime now = DateTime.Now;
                Value = new DateTimeOffset(new DateTime(now.Year, now.Month, day, hours, minutes, 0, DateTimeKind.Local).ToUniversalTime());

                OnTimeUpdate.InvokeAsync(Value);
            }
            else
            {
                // Handle invalid input or reset the formatted date
                Value = DateTimeOffset.MinValue;
                OnTimeUpdate.InvokeAsync(null);
            }
        }
        else
        {
            if (inputValue.Length == 6 && int.TryParse(inputValue, out int parsedValueHhMmSs))
            {
                int hours = parsedValueHhMmSs / 10000;
                int minutes = (parsedValueHhMmSs % 10000) / 100;
                int seconds = parsedValueHhMmSs % 100;

                DateTime now = DateTime.Now;
                Value = new DateTimeOffset(new DateTime(now.Year, now.Month, now.Day, hours, minutes, seconds, DateTimeKind.Local).ToUniversalTime());

                OnTimeUpdate.InvokeAsync(Value);
            }
            else if (inputValue.Length == 8 && int.TryParse(inputValue, out int parsedValueDdHhMmSs))
            {
                int day = parsedValueDdHhMmSs / 1000000;
                int hours = (parsedValueDdHhMmSs % 1000000) / 100;
                int minutes = (parsedValueDdHhMmSs % 10000) / 100;
                int seconds = parsedValueDdHhMmSs % 100;

                DateTime now = DateTime.Now;
                Value = new DateTimeOffset(new DateTime(now.Year, now.Month, day, hours, minutes, seconds, DateTimeKind.Local).ToUniversalTime());

                OnTimeUpdate.InvokeAsync(Value);
            }
            else
            {
                // Handle invalid input or reset the formatted date
                Value = DateTimeOffset.MinValue;
                OnTimeUpdate.InvokeAsync(null);
            }
        }
    }
}
