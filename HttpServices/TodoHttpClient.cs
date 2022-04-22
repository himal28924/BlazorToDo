using System.Text;
using System.Text.Json;
using Domain.Contracts;
using Domain.Model;

namespace HttpServices;

public class TodoHttpClient :ITodoHome

{
    public async Task<ICollection<Todo>> GetAsync()
    {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7180/Todos");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error : {response.StatusCode},{content}");
        }

        ICollection<Todo>? todos = JsonSerializer.Deserialize<ICollection<Todo>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return todos;
    }

    public Task<Todo> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        using HttpClient client = new();

        string toAsJson = JsonSerializer.Serialize(todo);

        StringContent content = new(toAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7180/Todos", content);
        string responseContent = await responseMessage.Content.ReadAsStringAsync();
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception($"Error : {responseMessage.StatusCode},{content}");
        }

        Todo todos = JsonSerializer.Deserialize<Todo>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return todo;
        
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Todo todo)
    {
        throw new NotImplementedException();
    }
}