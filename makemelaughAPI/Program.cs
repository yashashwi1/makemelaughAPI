using makemelaughCore.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//#forDegreed starts
// Below we have implemented Dependency Injection
// Dependency injection is helpful in loose coupling the modules.
// Our API layer is consuming business(core) layer through 'Abstraction'
// We are binding all the necessary services required --
// -- to consume our business layer.
builder.Services.BindServices();
//#forDegreed ends

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
