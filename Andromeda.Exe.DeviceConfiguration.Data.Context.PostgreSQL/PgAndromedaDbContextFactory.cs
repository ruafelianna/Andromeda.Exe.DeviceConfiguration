using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using System;

namespace Andromeda.Exe.DeviceConfiguration.Data.Context.PostgreSQL
{
    public class PgAndromedaDbContextFactory :
        AndromedaDbContextFactoryBase<PgAndromedaDbContext>
    {
        public override PgAndromedaDbContext CreateDbContext(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException(
                    "One argument is required: connection string",
                    nameof(args)
                );
            }

            var connStringBuilder = new NpgsqlConnectionStringBuilder(args[0]);

            var dbContextBuilder = new DbContextOptionsBuilder()
                .UseNpgsql(
                    connStringBuilder.ConnectionString,
                    x => x.MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        connStringBuilder.SearchPath
                    )
                )
                .EnableSensitiveDataLogging();

            return new PgAndromedaDbContext(dbContextBuilder.Options);
        }
    }
}
