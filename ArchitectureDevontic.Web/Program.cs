using ArchitectureDevontic.Database.Context;
using ArchitectureDevontic.Model.Mapping;

using ArchitectureDevontic.Service.Iservices.Clientes;
using ArchitectureDevontic.Service.Iservices.Pedidos;
using ArchitectureDevontic.Service.Iservices.Productos;
using ArchitectureDevontic.Service.Services.Clientes;
using ArchitectureDevontic.Service.Services.Pedidos;
using ArchitectureDevontic.Service.Services.Productos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfiles());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddCors();

builder.Services.AddDbContext<MyContext>(
    (DbContextOptionsBuilder options) =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
    });
// configuracion basica de swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Rest",
        Version = "v1.0.0",

    });   
}); 
builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
object p = builder.Services.AddControllers().AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IPedidoServices, PedidoServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// configuración de cors
app.UseCors(options =>
{
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.SetIsOriginAllowed(origin => true);
    options.AllowCredentials();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
