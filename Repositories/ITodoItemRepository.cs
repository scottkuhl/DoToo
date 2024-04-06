namespace DoToo.Repositories;

public interface ITodoItemRepository
{
    event EventHandler<TodoItem> OnItemAdded;
    event EventHandler<TodoItem> OnItemUpdated;
    Task AddItemAsync(TodoItem item);
    Task AddOrUpdateAsync(TodoItem item);
    Task<List<TodoItem>> GetItemsAsync();
    Task UpdateItemAsync(TodoItem item);
}
