
namespace DoToo.Pages;

public partial class Home
{
    private List<TodoItem>? todoItems;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        todoItems = await Repository.GetItemsAsync();
    }

    private void Add()
    {
        NavigationManager.NavigateTo("/item");
    }

    private void GoTo(int id)
    {
        NavigationManager.NavigateTo($"/item/{id}");
    }
}
