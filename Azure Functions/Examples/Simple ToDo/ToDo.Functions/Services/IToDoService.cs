using ToDo.Functions.Models;

namespace ToDo.Functions.Services;

public interface IToDoService
{
    IEnumerable<ToDoItem> GetToDos();
    void CreateToDo(ToDoItem toDoItemToCreate);
    void DeleteToDo(string id);
    ToDoItem UpdateToDoItem(ToDoItem updatedToDoItem);
}