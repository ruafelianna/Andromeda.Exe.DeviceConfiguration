using Andromeda.Data.Context.Abstractions;

namespace Andromeda.Exe.DeviceConfiguration.Data.Context.Abstractions
{
    public interface IAndromedaDbContextFactory :
        IDbContextFactory<IAndromedaDbContext>
    {
    }
}
