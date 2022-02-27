namespace TodoListApp.Client.Services.TodoItemService
{
    public interface ITodoItemService
    {

        List<TodoItem> TodoItems { get; set; }

        Task GetTodoItems();

        Task<TodoItem> GetSingleTodoItem(int id);

        Task CreateTodoItem(TodoItem item);
        Task UpdateTodoItem(TodoItem item);
        Task DeleteTodoItem(int id);
    }
}
