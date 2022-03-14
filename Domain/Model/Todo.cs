namespace Domain.Model;

public class Todo
{
    public int Id { get; set; }
    public  string Title { get; set; }
    public  int OwnerId { get; set; }
    public bool IsCompleted { get; set; }

    public Todo(int ownerId, string title)
    {
        OwnerId = ownerId;
        Title = title;
        IsCompleted = false;
    }
    
}