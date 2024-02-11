using Application.Interface.ClientInterface;
using Application.Interface.RecurringJob;
using Application.Interface.StockInterface;
using Application.Service.ClientService;
using Application.Service.RecurringJobService;
using Application.Service.StockService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using Hangfire;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add services to the container.
builder.Services.AddScoped<ICreateClient, CreateClientService>();
builder.Services.AddScoped<IUpdateClient, UpdateClientService>();
builder.Services.AddScoped<IDeleteClient, DeleteClientService>();
builder.Services.AddScoped<IGetClients, GetClientsService>();
builder.Services.AddScoped<IGetClient, GetClientService>();
builder.Services.AddScoped<ICreateStock, CreateStockService>();
builder.Services.AddSingleton<IRecurringJobHandler, RecurringJobService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
// Add Hangfire services.
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
// Add the processing server as IHostedService
builder.Services.AddHangfireServer();
var app = builder.Build();
app.UseHangfireDashboard();
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    var hangfire = scope.ServiceProvider.GetRequiredService<IRecurringJobHandler>();
    var IsCreated = Configuration.GetValue<string>("HangfireConfiguration:IsCreated");
    if (!bool.Parse(IsCreated))
    {
        hangfire.ExecuteJob();
    }

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.Run();
