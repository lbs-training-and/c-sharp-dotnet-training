using ToDo.Functions.Models;

namespace ToDo.Functions.Services;

public class ToDoService : IToDoService
{
    public IEnumerable<ToDoItem> GetToDos()
    {
        return new List<ToDoItem>
        {
            new ToDoItem
            {
                Title = "First ToDo",
                CreatedAt = DateTime.UtcNow,
                Description = "This is the first ToDo item",
                CompletedAt = null
            },
            new ToDoItem
            {
                Title = "Second ToDo",
                CreatedAt = DateTime.UtcNow,
                Description = "This is the second ToDo item",
                CompletedAt = DateTime.UtcNow
            }
        };
    }

    public void CreateToDo(ToDoItem toDoItemToCreate)
    {
    }

    public void DeleteToDo(string id)
    {
    }

    public ToDoItem UpdateToDoItem(ToDoItem updatedToDoItem)
    {
        return updatedToDoItem;
    }
}