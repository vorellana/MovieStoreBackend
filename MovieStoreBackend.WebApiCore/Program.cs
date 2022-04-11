using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.DataAccess.EFCore;
using MovieStoreBackend.DataAccess.EFCore.Repositories;
using MovieStoreBackend.Services;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.Services.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
string MyCors = "MyCors";

// Add services to the container.

builder.Services.AddDbContext<MovieStoreDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("movie_store_db_connection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyCors, builder =>
    {
        builder.WithOrigins("*");
    });
});

// Dependency injection
builder.Services.AddTransient<IStudentRepository, StudentRepository>(); // vorellana
builder.Services.AddScoped<IStudentService, StudentService>(); // vorellana

builder.Services.AddTransient<IMovieRepository, MovieRepository>(); // vorellana
builder.Services.AddScoped<IMovieService, MovieService>(); // vorellana


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyCors);

app.MapControllers();

app.Run();
