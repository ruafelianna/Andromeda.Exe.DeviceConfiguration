using Andromeda.Exe.DeviceConfiguration.Data.Models.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Andromeda.Exe.DeviceConfiguration.Data.Context.PostgreSQL
{
    public class PgAndromedaDbContext : AndromedaDbContextBase
    {
        protected PgAndromedaDbContext() : base()
        {
        }

        public PgAndromedaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var conv = new ValueConverter<byte[], long>(
                v => BitConverter.ToInt64(v, 0),
                v => BitConverter.GetBytes(v)
            );

            modelBuilder.Entity<AppInstance>()
                .Property(x => x.RowVersion)
                .HasColumnName("xmin")
                .HasColumnType("xid")
                .HasConversion(conv);

            base.OnModelCreating(modelBuilder);
        }
    }
}
