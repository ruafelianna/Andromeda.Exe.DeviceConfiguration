using Andromeda.Exe.DeviceConfiguration.Data.Context.Abstractions;
using Microsoft.EntityFrameworkCore.Design;
using Andromeda.Data.Context.Abstractions;

namespace Andromeda.Exe.DeviceConfiguration.Data.Context
{
    public abstract class AndromedaDbContextFactoryBase<TDbContext> :
        IDesignTimeDbContextFactory<TDbContext>,
        IAndromedaDbContextFactory
        where TDbContext : AndromedaDbContextBase
    {
        public abstract TDbContext CreateDbContext(
            string[] args);

        IAndromedaDbContext IDbContextFactory<IAndromedaDbContext>.CreateDbContext(
            string[] args)
            => CreateDbContext(args);
    }
}
