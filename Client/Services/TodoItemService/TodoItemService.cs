using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace TodoListApp.Client.Services.TodoItemService
{
    public class TodoItemService : ITodoItemService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public TodoItemService(HttpClient http,NavigationManager navigationManager)
        {
           _http = http;
           _navigationManager = navigationManager;
        }

        public List<TodoItem> TodoItems { get ; set ; } = new List<TodoItem>();

        public async Task CreateTodoItem(TodoItem item)
        {
            var result = await _http.PostAsJsonAsync("api/todoitem", item);
            var response = await result.Content.ReadFromJsonAsync<List<TodoItem>>();
            TodoItems = response;
            _navigationManager.NavigateTo("todo");
        }

        public async Task DeleteTodoItem(int id)
        {
            var result = await _http.DeleteAsync($"api/todoitem/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<TodoItem>>();
            TodoItems = response;
        }

        public async Task<TodoItem> GetSingleTodoItem(int id)
        {
            var result = await _http.GetFromJsonAsync<TodoItem>($"api/TodoItem/{id}");
            if (result != null)
                return result;
            throw new Exception("Item Not Found!");
        }

        public async Task GetTodoItems()
        {
            var result = await _http.GetFromJsonAsync<List<TodoItem>>("api/TodoItem");
            if (result != null)
                TodoItems = result;
        }

        public async Task UpdateTodoItem(TodoItem item)
        {
            var result = await _http.PutAsJsonAsync($"api/todoitem/{item.Id}", item);
            var response = await result.Content.ReadFromJsonAsync<List<TodoItem>>();
            TodoItems = response;
            _navigationManager.NavigateTo("todo");
        }
    }
}
