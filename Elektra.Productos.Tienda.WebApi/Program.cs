using Elektra.Productos.Tienda.ApplicationServices;
using Elektra.Productos.Tienda.Persistence;
using Elektra.Productos.Tienda.Persistence.DataAccess.Config;
using Elektra.Productos.Tienda.Persistence.DataAccess.Repository;
using Microsoft.Extensions.Options;
using Elektra.Productos.Tienda.WebApi.Core.Extensions;
using Sample.MediatR.WebApi.Core.Extensions;
using Elektra.Productos.Tienda.WebApi.Core.Middlewares;
using Elektra.Productos.Tienda.DomainServices.Repositories;
using Elektra.Productos.Tienda.Persistence.Repositories;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilog("Elektra.Productos.Tienda",builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings")); 
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
   serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value
);
builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

builder.Services.AddApplicationService()
                 .AddPersistences()
                 .AddElasticsearch(builder.Configuration);

//builder.Services.AddMassTransitExtension(builder.Configuration);

var app = builder.Build();
app.UseElasticApm(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
