
using BlazorDexie.JsModule;
using Microsoft.JSInterop;

namespace DoToo.Repositories;

public class TodoItemRepository : ITodoItemRepository, IAsyncDisposable
{
    private readonly AppDb db;

    public event EventHandler<TodoItem>? OnItemAdded;
    public event EventHandler<TodoItem>? OnItemUpdated;

    public TodoItemRepository(IJSRuntime jsRuntime)
    {
        var moduleFactory = new EsModuleFactory(jsRuntime);
        db = new AppDb(moduleFactory);
    }

    private async Task InitializeAsync()
    {
        if (await db.TodoItems.Count() == 0)
        {
            await db.TodoItems.Add(new TodoItem
            {
                Title = "Welcome to DoToo",
                Due = DateTime.Now
            });
        }
    }

    public async Task AddItemAsync(TodoItem item)
    {
        await InitializeAsync();
        await db.TodoItems.Add(item);
        OnItemAdded?.Invoke(this, item);
    }

    public async Task AddOrUpdateAsync(TodoItem item)
    {
        if (item.Id == 0)
        {
            await AddItemAsync(item);
        }
        else
        {
            await UpdateItemAsync(item);
        }
    }

    public async Task<List<TodoItem>> GetItemsAsync()
    {
        await InitializeAsync();
        return await db.TodoItems.ToList();
    }

    public async Task UpdateItemAsync(TodoItem item)
    {
        await InitializeAsync();
        await db.TodoItems.Put(item);
        OnItemUpdated?.Invoke(this, item);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        await db.DisposeAsync();
        await db.Close();
    }
}
