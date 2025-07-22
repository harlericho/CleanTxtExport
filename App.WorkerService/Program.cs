using App.Applicacion.Interfaces;
using App.Infraestructura.Services;
using App.WorkerService;

var builder = Host.CreateApplicationBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=db_ejemplo";
builder.Services.AddSingleton<IPersoService>(provider =>
    new PersoService(connectionString));
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
