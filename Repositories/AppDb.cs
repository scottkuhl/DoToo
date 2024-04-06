using BlazorDexie.Database;
using BlazorDexie.JsModule;

namespace DoToo;

public class AppDb(IModuleFactory moduleFactory) : Db("DoTooDatabase", 1, [], moduleFactory)
{
    public Store<TodoItem, int> TodoItems { get; set; } = new($"++{nameof(TodoItem.Id)}");
}
