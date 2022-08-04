using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.TelemetryConverters;
using WedoIT.NextGen.Api.Mapper;
using WedoIT.NextGen.Api.ServiceExtensions;
using WedoIT.NextGen.Data.Context;
using WedoIT.NextGen.Data.Repositories.BlockRepository;
using WedoIT.NextGen.Data.Repositories.PersonRepository;
using WedoIT.NextGen.Data.Repositories.ProjectRepository;
using WedoIT.NextGen.Service.Services.CodeRepositoryService;
using WedoIT.NextGen.Service.Services.ProjectService;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration)
    => configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.ApplicationInsights(context.Configuration.GetValue<string>("APPINSIGHTS_INSTRUMENTATIONKEY"),
            new EventTelemetryConverter()));

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddDbContext<NextGenDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddRepositoryLayerServices();
builder.Services.AddServiceLayerServices();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ICodeRepositoryService, CodeRepositoryService>();

builder.Services.AddScoped<IBlockRepository, BlockRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
var Origin = "_origin";
// TODO change origins
builder.Services.AddCors(options =>
{
    options.AddPolicy(Origin,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseCors(Origin);
app.UseHttpsRedirection();
app.AddRouteMappings();

app.Run();