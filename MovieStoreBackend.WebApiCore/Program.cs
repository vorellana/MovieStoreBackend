using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.DataAccess.EFCore;
using MovieStoreBackend.DataAccess.EFCore.Repositories;
using MovieStoreBackend.Services;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.Services.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var setupCors = "SetupCors";

// Add services to the container.

builder.Services.AddDbContext<MovieStoreDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("movie_store_db_connection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
    options.AddPolicy(name: setupCors, builder =>
    {
        builder.WithOrigins("*");
    });
});

// Dependency injection

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(setupCors);

app.MapControllers();

app.Run();
