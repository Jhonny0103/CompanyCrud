using CompanyCrud.Data;
using CompanyCrud.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1.Añadimos la conexión.
builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//2. Añadimos un servicio de tipo RepositoryCompany, que es el que se va a inyectar en el controlador.
builder.Services.AddScoped<RepositoryCompany>();

//3. Configuramos los CORS para permitir peticiones desde Angular, que normalmente se ejecuta en un puerto diferente al de la API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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

// 4. Usamos la política de CORS que hemos definido. ** Recuerda ponerlo antes de MapControllers y UseAuthorization para que se aplique a todas las rutas.
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
