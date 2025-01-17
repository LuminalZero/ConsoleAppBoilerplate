﻿using ConsoleAppBoilerplate.ConsoleApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleAppBoilerplate.ConsoleApp.HostedServices
{
    internal class HostedService : BackgroundService
    {
        private readonly IHostApplicationLifetime _hostLifetime;
        private readonly IHostEnvironment _hostingEnv;
        private readonly IConfiguration _configuration;
        private readonly IExampleService _exampleService;
        private readonly ILogger<HostedService> _logger;

        public HostedService(
            IHostApplicationLifetime hostLifetime, 
            IHostEnvironment hostingEnv, 
            IConfiguration configuration, 
            IExampleService exampleService,
            ILogger<HostedService> logger)
        {
            _hostLifetime = hostLifetime;
            _hostingEnv = hostingEnv;
            _configuration = configuration;
            _exampleService = exampleService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Executing");

            _logger.LogDebug($"Working dir is {_hostingEnv.ContentRootPath}");
            _logger.LogInformation($".NET environment is {_configuration["DOTNET_ENVIRONMENT"]}");

            var result = await _exampleService.DoWork(stoppingToken);
            _logger.LogInformation($"Example service returned {result}");

            _logger.LogInformation("Finished executing. Exiting.");
            _hostLifetime.StopApplication();
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting up");
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping");
            await base.StopAsync(cancellationToken);
        }
    }
}
