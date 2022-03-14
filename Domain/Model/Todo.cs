using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Todo
{
    public Todo() { }

    public int Id { get; set; }
  
    
    [Required, MaxLength(128)] 
    public  string Title { get; set; }
    
    [Range(1,int.MaxValue,ErrorMessage = "Please Enter a Value bigger than {1} ")]
    public  int OwnerId { get; set; }
    public bool IsCompleted { get; set; }

    public Todo(int ownerId, string title)
    {
        OwnerId = ownerId;
        Title = title;
        IsCompleted = false;
    }
    
}