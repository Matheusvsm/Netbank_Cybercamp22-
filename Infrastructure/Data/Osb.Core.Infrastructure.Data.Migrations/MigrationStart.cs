using FluentMigrator.Runner;
using Microsoft.Extensions.Logging;
using Osb.Core.Infrastructure.Data.Migrations.Models;
using System;

namespace Osb.Core.Infrastructure.Data.Migrations
{
    public class MigrationStart
    {
        private readonly ILogger<MigrationStart> _logger;
        private readonly IMigrationRunner _migrationRunner;
        private string option;
        private int OPTION_UP_SELECTED = 1;
        private int OPTION_DOWN_SELECTED = 2;
        private long VERSION_MIGRATION;
        private int OPTION_SELECTED;
        private Settings _settings;

        public MigrationStart(
            ILogger<MigrationStart> logger,
            IMigrationRunner migrationRunner,
            Settings settings
            )
        {
            _logger = logger;
            _migrationRunner = migrationRunner;
            _settings = settings;
        }

        public void Run()
        {
            _logger.LogInformation("Iniciando a execucao das Migrations...");

            VERSION_MIGRATION = _settings.VersionMigration;

            try
            {
                Console.WriteLine("Pressione 1 para Up ou 2 para Down:");

                option = Console.ReadLine();

                OPTION_SELECTED = Int16.Parse(option);

                if (OPTION_SELECTED == OPTION_UP_SELECTED)
                {
                    _migrationRunner.MigrateUp(VERSION_MIGRATION);
                }
                else if (OPTION_SELECTED == OPTION_DOWN_SELECTED)
                {
                    _migrationRunner.MigrateDown(VERSION_MIGRATION);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Erro durante a execucao das Migrations: {ex.Message} | {ex.GetType().Name}");
            }

            _logger.LogInformation("Verificacao das Migrations concluida.");
        }
    }
}
//"core":"Server=0.tcp.sa.ngrok.io; Port=11848; User Id=postgres; Password=3nip79zh; Database=postgres;"