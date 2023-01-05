using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Workers.Pix.GeneratePixOut.Service;

namespace Osb.Core.Workers.Pix.GeneratePixOut.Starter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerService _workerService;
        private readonly Settings _settings;

        public Worker(ILogger<Worker> logger, WorkerService workerService, Settings settings)
        {
            _logger = logger;
            _workerService = workerService;
            _settings = settings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _workerService.Generate();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
