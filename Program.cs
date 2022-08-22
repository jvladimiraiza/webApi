using webapi.Services;
using webapi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// configurando entityFramework
var serverVersion = new MySqlServerVersion(new Version(6, 0, 2));
builder.Services.AddDbContext<TareasContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("cnTareas"), serverVersion));
//
// builder.Services.AddScoped<IHelloWorldService, HelloworldService>(); // llamando a la inyeccion de dependencia(recomendado)
builder.Services.AddScoped<IHelloWorldService>(p => new HelloworldService()); // otra manera de inyectar dependencia sin interfaz
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage();
app.UseTimeMiddleware();

app.MapControllers();

app.Run();
