using System.Text.Json.Serialization;

namespace DoToo.Models;

public class TodoItem
{
    public bool Completed { get; set; }

    public DateTime Due { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }

    public string Title { get; set; } = "";
}
