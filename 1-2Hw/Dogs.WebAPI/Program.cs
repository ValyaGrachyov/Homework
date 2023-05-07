var builder = WebApplication.CreateBuilder(args);


// Добавил Cors для работы с методами Get, Post
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicity",
        builder =>
        {
            builder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000");
        });
});

// Add services to the container.

builder.Services.AddControllers();
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

// Добавил
app.UseCors("CorsPolicity");

app.UseAuthorization();

app.MapControllers();

app.Run();
