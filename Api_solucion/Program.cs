using dao_library;
using dao_library.entity_framework;
using Microsoft.EntityFrameworkCore;
using Api_solucion.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias de los DAO
builder.Services.AddScoped<StudentDAO>();
builder.Services.AddScoped<CourseDAO>();
builder.Services.AddScoped<ActivityDAO>();
builder.Services.AddScoped<PlayerDAO>();
builder.Services.AddScoped<TeamDAO>();
builder.Services.AddScoped<TrainerDAO>();
builder.Services.AddScoped<UserDAO>();
builder.Services.AddScoped<JwtTokenService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Antes de var app = builder.Build();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();