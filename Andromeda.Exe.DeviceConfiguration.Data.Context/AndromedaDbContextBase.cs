using Andromeda.Data.Context;
using Andromeda.Exe.DeviceConfiguration.Data.Context.Abstractions;
using Andromeda.Exe.DeviceConfiguration.Data.Models.App;
using Microsoft.EntityFrameworkCore;

namespace Andromeda.Exe.DeviceConfiguration.Data.Context
{
    public class AndromedaDbContextBase :
        DbContextBase, IAndromedaDbContext
    {
        protected AndromedaDbContextBase() : base()
        {
        }

        public AndromedaDbContextBase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppInstance> AppInstances { get; set; }

        public DbSet<LoginRecord> LoginRecords { get; set; }
    }
}
