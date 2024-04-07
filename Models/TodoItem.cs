using System.Text.Json.Serialization;

namespace DoToo.Models;

public class TodoItem
{
    public bool Completed { get; set; }

    public DateTime Due { get; set; } = DateTime.Today.AddDays(1);

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }

    public string Title { get; set; } = "";
}
