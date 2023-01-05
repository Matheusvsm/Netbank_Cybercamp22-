using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Workers.SmsTransfer.Generate.Starter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerService _service;
        private readonly Settings _settings;

        public Worker(ILogger<Worker> logger, WorkerService service, Settings settings)
        {
            _logger = logger;
            _service = service;
            _settings = settings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _service.Generate();

                await Task.Delay(_settings.Timer, stoppingToken);
            }
        }
    }
}
