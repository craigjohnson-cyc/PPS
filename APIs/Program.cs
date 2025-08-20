using Microsoft.EntityFrameworkCore;
using ClientsApi.Data;
using ClientsApi.Controllers;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connect Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException();
builder.Services.AddDbContext<PpsDBContext>(options => options.UseSqlServer(connectionString));
     //.("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;"));
    //(opt => opt.UseInMemoryDatabase("LearnDb"));
//builder.Services.AddDbContext<ApiContext>
//    (opt => opt.EnableSensitiveDataLogging());
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

app.UseAuthorization();

app.MapControllers();

app.Run();
