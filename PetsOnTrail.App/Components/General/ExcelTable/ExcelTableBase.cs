using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using PetsOnTrail.App.Components.General.EditableInput;
using PetsOnTrail.Translation;

namespace PetsOnTrail.App.Components.General.ExcelTable;

public class ExcelTableBase : ComponentBase
{
    private static Guid _column1Id = Guid.Parse("fa17345a-8acb-47d6-aa40-31924c176641");
    private static Guid _column2Id = Guid.Parse("18d833aa-0ef8-4f6a-9e31-18586ebb5569");
    private static Guid _column3Id = Guid.Parse("e72e1802-2ef0-4a0c-8a02-ef2c7991a87e");
    private static Guid _column4Id = Guid.Parse("9720f620-8f3c-4837-ae82-b2c2907e78d9");

    [Inject] protected IJSRuntime JSRuntime { get; set; }
    [Inject] protected ITranslationService T { get; set; }

    protected virtual List<ColumnDefinition> Columns { get; set; } = new List<ColumnDefinition>
    {
        new ColumnDefinition { Id = _column1Id, Header = "Name", Width = 150, Type = EditableInputBase.InputType.Text },
        new ColumnDefinition { Id = _column2Id, Header = "Age", Width = 100, Type = EditableInputBase.InputType.Integer },
        new ColumnDefinition { Id = _column3Id, Header = "Country", Width = 200, Type = EditableInputBase.InputType.Text },
        new ColumnDefinition { Id = _column4Id, Header = "Entered", Width = 100, Type = EditableInputBase.InputType.Date }
    };

    protected virtual List<Dictionary<Guid, object>> Data { get; set; } = new List<Dictionary<Guid, object>>
    {
        new Dictionary<Guid, object> { { _column1Id, "Johnie Doe" }, { _column2Id, 30 }, { _column3Id, "USA" }, { _column4Id, DateTimeOffset.Now } },
        new Dictionary<Guid, object> { { _column1Id, "Janie Smith" }, { _column2Id, 25 }, { _column3Id, "UK" }, { _column4Id, DateTimeOffset.Now.AddDays(-1) } },
        new Dictionary<Guid, object> { { _column1Id, "Samuel Jackson" }, { _column2Id, 35 }, { _column3Id, "Canada" }, { _column4Id, DateTimeOffset.Now.AddDays(-2) } }
    };

    private bool isResizing = false;
    private ColumnDefinition resizingColumn;
    private double startX;
    private double startWidth;

    protected void OnMouseDown(MouseEventArgs e, ColumnDefinition column)
    {
        isResizing = true;
        resizingColumn = column;
        startX = e.ClientX;
        startWidth = column.Width;
        StateHasChanged();
    }

    protected void OnMouseMove(MouseEventArgs e)
    {
        if (isResizing && resizingColumn != null)
        {
            var newWidth = startWidth + (e.ClientX - startX);
            if (newWidth > 30) // Minimum column width
            {
                resizingColumn.Width = newWidth;
                StateHasChanged();
            }
        }
    }

    protected void OnMouseUp(MouseEventArgs e)
    {
        isResizing = false;
        resizingColumn = null;
        StateHasChanged();
    }

    protected void HideColumn(ColumnDefinition column)
    {
        column.Hidden = true;

        StateHasChanged();
    }

    protected void ShowColumn(ColumnDefinition column)
    {
        column.Hidden = false;

        StateHasChanged();
    }

    protected void SortBy(ColumnDefinition column)
    {
        var currentSortByDescendingValue = column.SortByDescending;

        foreach (var col in Columns)
        {
            col.SortBy = false;
            col.SortByDescending = false;
        }

        column.SortBy = true;
        column.SortByDescending = !currentSortByDescendingValue;

        Data = column.SortByDescending
            ? Data.OrderByDescending(row => row[column.Id]).ToList()
            : Data.OrderBy(row => row[column.Id]).ToList();

        StateHasChanged();
    }

    public void Dispose()
    {
        // Unsubscribe from mouse events
        // Ensure proper cleanup
    }

    protected override async Task OnInitializedAsync()
    {
        await T.SetLanguage("en-US");

        base.OnInitialized();
        // Subscribe to mouse events
        var dotNetRef = DotNetObjectReference.Create(this);
        JSRuntime.InvokeVoidAsync("addMouseEvents", dotNetRef);
    }

    protected Task OnValueChange(Dictionary<Guid, object> row, Guid columnId, object? value)
    {
        row[columnId] = value;

        // TODO: send data to server

        return Task.CompletedTask;
    }

    [JSInvokable]
    public void OnMouseMoveJS(MouseEventArgs e) => OnMouseMove(e);

    [JSInvokable]
    public void OnMouseUpJS(MouseEventArgs e) => OnMouseUp(e);

    public class ColumnDefinition
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Header { get; set; }
        public double Width { get; set; }
        public bool Hidden { get; set; } = false;
        public bool SortBy { get; set; } = false;
        public bool SortByDescending { get; set; } = false;
        public EditableInputBase.InputType Type { get; set; } = EditableInputBase.InputType.Text;
    }
}
