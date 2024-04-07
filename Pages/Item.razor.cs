using Microsoft.AspNetCore.Components;

namespace DoToo.Pages;

public partial class Item
{
    [Parameter] public int? Id { get; set; }

    private TodoItem todoItem = new();

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (Id.HasValue)
        {
            var item = await Repository.GetItemAsync(Id.Value);
            if (item != null)
            {
                todoItem = item;
            }
        }
    }

    private async Task SaveAsync()
    {
        await Repository.AddOrUpdateAsync(todoItem);
        NavigationManager.NavigateTo("/");
    }
}
