namespace ToDo.Functions;

public class ToDoService : IToDoService
{
    public Task CreateAsync(OrderDto orderDto)
    {
        return Task.CompletedTask;
    }

    public Task UpdateAsync(int id, OrderDto orderDto)
    {
        return Task.CompletedTask;
    }
}