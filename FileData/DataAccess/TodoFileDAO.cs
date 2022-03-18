using Domain.Contracts;
using Domain.Model;

namespace FileData.DataAccess;

public class TodoFileDAO: ITodoHome
{
    private FileContext fileContext;

    public TodoFileDAO(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public async Task<ICollection<Todo>> GetAsync()
    {
        ICollection<Todo> todos = fileContext.Todos;
        return todos;
    }

    public async Task<Todo> GetById(int id)
    {
        return fileContext.Todos.First(t => t.Id == id);
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        int largestId = fileContext.Todos.Max(t => t.Id);
        int nextId = largestId + 1;
        todo.Id = nextId;
        fileContext.Todos.Add(todo);
        fileContext.SaveChanges();
        return todo;
    }

    public  Task DeleteAsync(int id)
    {
        Todo toDelete = fileContext.Todos.First(t => t.Id == id);
        fileContext.Todos.Remove(toDelete);
        fileContext.SaveChanges();
        return Task.CompletedTask;
    }

    public  Task UpdateAsync(Todo todo)
    {
        Todo toUpdate = fileContext.Todos.First(t => t.Id == todo.Id);
        toUpdate.IsCompleted = todo.IsCompleted;
        toUpdate.OwnerId = todo.OwnerId;
        toUpdate.Title = todo.Title;
        fileContext.SaveChanges();
        return Task.CompletedTask;
    }
}