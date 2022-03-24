using System.Text.Json;

using Domain.Model;

namespace FileData.DataAccess;

public class FileContext
{
    private string todoFilePath = "todo.json";
    private ICollection<Todo>? todos;

    public FileContext()
    {
        if (!File.Exists(todoFilePath))
        {
            Seed();
        }
    }

    private void Seed()
    {
        Todo[] ts =
        {
            new Todo(1, "Dishes") {Id = 1}, 
            new Todo(1, "Walk the dog") {Id = 1},
            new Todo(2, "Do Dnp Exercise") {Id = 3}, 
            new Todo(3, "Eat breakfast") {Id = 4},
            new Todo(4, "Mow lawn") {Id = 5}
        };
        todos = ts.ToList();
        SaveChanges();
    }

    public void SaveChanges()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string serialize = JsonSerializer.Serialize(Todos,options);
        File.WriteAllText(todoFilePath,serialize);
        todos = null;
    }

    public ICollection<Todo> Todos
    {
        get
        {
            if (todos == null)
            {
                LoadData();
            }
            return todos!;
        }
        

    }

    private void LoadData()
    {
        string content = File.ReadAllText(todoFilePath);
        todos = JsonSerializer.Deserialize<List<Todo>>(content);
    }
}