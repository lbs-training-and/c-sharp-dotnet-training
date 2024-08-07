namespace ToDo.Functions;

public interface IToDoService
{
    Task CreateAsync(OrderDto orderDto);
    Task UpdateAsync(int id, OrderDto orderDto);
}