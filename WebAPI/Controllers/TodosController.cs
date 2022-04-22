using Domain.Contracts;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class TodosController:ControllerBase
{
    private ITodoHome todoHome;

    public TodosController(ITodoHome todoHome)
    {
        this.todoHome = todoHome;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Todo>>> GetAll()
    {
        try
        {
            ICollection<Todo> todos = await todoHome.GetAsync();
            return Ok(todos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> AddTodo ([FromBody]Todo todo)
    {
        try
        {
            Todo addedTodo = await todoHome.AddAsync(todo);
            return Created($"/todo/{addedTodo.Id}", addedTodo);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);

        }
    }
    
}