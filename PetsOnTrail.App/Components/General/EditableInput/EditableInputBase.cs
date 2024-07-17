using Microsoft.AspNetCore.Components;

namespace PetsOnTrail.App.Components.General.EditableInput;

public class EditableInputBase : ComponentBase
{
    [Parameter] public object? Value { get; set; }
    [Parameter] public InputType Type { get; set; } = InputType.Text;
    [Parameter] public EventCallback<object?> OnValueChange { get; set; }

    protected DateTimeOffset? DateValue 
    {
        get
        {
            return Type == InputType.Date ? Value as DateTimeOffset? : null;
        }
        set
        {
            Value = value;

            if (OnValueChange.HasDelegate)
                OnValueChange.InvokeAsync(Value);
        }
    }

    protected string TextValue
    {
        get
        {
            return (Type == InputType.Text && Value != null) ? (string)Value.ToString() : string.Empty;
        }
        set
        {
            Value = value;

            if (OnValueChange.HasDelegate)
                OnValueChange.InvokeAsync(Value);
        }
    }

    protected int IntegerValue
    {
        get
        {
            return (Type == InputType.Integer && Value != null) ? (int)Value : 0;
        }
        set
        {
            Value = value;

            if (OnValueChange.HasDelegate)
                OnValueChange.InvokeAsync(Value);
        }
    }

    protected double DoubleValue
    {
        get
        {
            return (Type == InputType.Double && Value != null) ? (double)Value : 0;
        }
        set
        {
            Value = value;

            if (OnValueChange.HasDelegate)
                OnValueChange.InvokeAsync(Value);
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    public enum InputType
    {
        Text,
        Integer,
        Double,
        Date
    }
}
