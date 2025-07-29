var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.


var todos = new List<Todo>();

app.MapGet("/todos/{id}", (int id) => {
    var targetTodo = todos.FirstOrDefault(todo => todo.Id == id);
    if (targetTodo == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(targetTodo);
});

app.MapPost("/todos", (Todo task)=> {
    todos.Add(task);
    return TypedResults.Created("/todos/{id}", task);

});

app.Run();

public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted);
