namespace DoToo.Pages;

public partial class Home
{
    private List<TodoItem>? todoItems;
    private List<TodoItem>? filteredItems;
    private FilterType filter = FilterType.All;
    private MudBlazor.Color filterColor = MudBlazor.Color.Success;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        todoItems = await Repository.GetItemsAsync();
        if (filter == FilterType.All)
        {
            filteredItems = todoItems;
        }
        else
        {
            filteredItems = todoItems.Where(x => !x.Completed).ToList();
        }
    }

    private void Add()
    {
        NavigationManager.NavigateTo("/item");
    }

    private void GoTo(int id)
    {
        NavigationManager.NavigateTo($"/item/{id}");
    }

    private Task FilterAsync()
    {
        if (filter == FilterType.All)
        {
            filter = FilterType.Active;
            filterColor = MudBlazor.Color.Default;
        }
        else
        {
            filter = FilterType.All;
            filterColor = MudBlazor.Color.Success;
        }
        return LoadDataAsync();
    }
}

public enum FilterType
{
    Active,
    All
}