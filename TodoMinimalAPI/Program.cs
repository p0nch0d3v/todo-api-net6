using Microsoft.EntityFrameworkCore;
using TodoMinimalAPI;
using TodoMinimalAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoDBContext>(options=> options.UseInMemoryDatabase("TodosDB"));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureAPI();

app.Run();
