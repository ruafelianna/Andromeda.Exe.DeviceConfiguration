using Andromeda.Data.Context.Abstractions;
using Andromeda.Exe.DeviceConfiguration.Data.Models.App;
using Microsoft.EntityFrameworkCore;

namespace Andromeda.Exe.DeviceConfiguration.Data.Context.Abstractions
{
    public interface IAndromedaDbContext : IDbContext
    {
        DbSet<AppInstance> AppInstances { get; }
        DbSet<LoginRecord> LoginRecords { get; }
        DbSet<HttpErrorRecord> HttpErrorRecords { get; }
    }
}
