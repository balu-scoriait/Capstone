using CodeFirst.Models;
using CodeFirst.repo;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<Irepo, repo>();
builder.Services.AddDbContext<ProductDBContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("registerConn")));


builder.Services.AddControllers();
// *********** Added CORS ***********
builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", Options => Options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
// *********** Added CORS ***********
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// *********** Added CORS ***********
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Added CORS
// *********** Added CORS ***********
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();