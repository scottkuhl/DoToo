namespace DoToo.Repositories;

public interface ITodoItemRepository
{
    Task AddItemAsync(TodoItem item);
    Task AddOrUpdateAsync(TodoItem item);
    Task<TodoItem?> GetItemAsync(int id);
    Task<List<TodoItem>> GetItemsAsync();
    Task UpdateItemAsync(TodoItem item);
}
