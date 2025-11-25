using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.SqlServer;
using my_books.Data;
using my_books.Data.Services;
using my_books.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "my_books_updated_title",
        Version = "v2",
        Description = "Updated Swagger configuration in .NET 8"
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<my_books.Data.AppDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublishersService>();



//BUILDING THE APP
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "my_books_updated v2");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

//Exception Middleware configuration
app.ConfigureBuildInExceptionHandler();
//app.ConfigureCustomExceptionHandler();

app.MapControllers();


//Call seeding here
//AppDbInitializer.Seed(app);

app.Run();
