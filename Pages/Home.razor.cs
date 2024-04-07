
namespace DoToo.Pages;

public partial class Home
{
    private List<TodoItem>? todoItems;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        LoadDataAsync();
    }

    private void LoadDataAsync()
    {
        todoItems = [];
    }

    private void Add()
    {
        NavigationManager.NavigateTo("/item");
    }
}
