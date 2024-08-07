namespace ToDo.Functions.Models;

public class ToDoItem
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public bool IsComplete => CompletedAt.HasValue;
    
    public DateTime CreatedAt { get; set; }
    
    public string Description { get; set; }
    
    public DateTime? CompletedAt { get; set; }

}