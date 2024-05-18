using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
//add services...
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblies = typeof(Program).Assembly;
//add mediatR and validation behavior
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assemblies);
    config.AddOpenBehavior(typeof(ValidationBehaviors<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssemblies([assemblies]);

//add Carter
builder.Services.AddCarter();
//add marten
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("DatabaseConnection")!);
    config.AutoCreateSchemaObjects = AutoCreate.All;
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("DatabaseConnection")!);

var app = builder.Build();

//add middlewares...
app.MapCarter();
app.UseExceptionHandler(opt => { });
app.UseHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();