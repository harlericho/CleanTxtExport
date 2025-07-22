using App.Applicacion.Interfaces;

namespace App.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPersoService _persoService;

        public Worker(ILogger<Worker> logger, IPersoService persoService)
        {
            _logger = logger;
            _persoService = persoService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    _logger.LogInformation("Iniciando generación del archivo TXT...");

                    var path = await _persoService.GenerarTxtAsync();

                    _logger.LogInformation("Archivo generado en: {path}", path);
                }
                //await Task.Delay(1000, stoppingToken);
                // Esperar 10 segundos antes del próximo ciclo
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
