using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {

        private readonly DataContext _context;

        

        public TodoItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            return Ok(_context.TodoItems);
        } 
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetSingleTodoItem(int id)
        {
            var todoItem= _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if(todoItem == null)
            {
                return NotFound("Sorry not item found");
            }
            return Ok(todoItem);
        } 


        [HttpPost]
        public async Task<ActionResult<List<TodoItem>>> CreateTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok(await GetDBTodoItems());
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<List<TodoItem>>> UpdateTodoItem(TodoItem item ,int id)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if(todoItem == null)
            {
                return NotFound("No Item Found!");
            }
            todoItem.Title = item.Title;
            todoItem.Description = item.Description;
            todoItem.Estimate = item.Estimate;
            todoItem.Done = item.Done;


            await _context.SaveChangesAsync();
            return Ok(await GetDBTodoItems());
        }


         [HttpDelete("{id}")]
        public async Task<ActionResult<List<TodoItem>>> DeleteTodoItem(int id)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if(todoItem == null)
            {
                return NotFound("No Item Found!");
            }
           
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return Ok(await GetDBTodoItems());
        }

        private async  Task<List<TodoItem>> GetDBTodoItems()
        {
            return  _context.TodoItems.ToList();
        }
    }
}
