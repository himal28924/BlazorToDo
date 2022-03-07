using Domain.Model;

namespace FileData.DataAccess;

public class FileContext
{
    private string todoFilePath = "todo.json";
    private ICollection<Todo> todos;

    public ICollection<Todo> Todos
    {
        get
        {
            if (todos == null)
            {
                LoadData();
            }

            return todos;
        }
    }

    private void LoadData()
    {
        throw new NotImplementedException();
    }
}