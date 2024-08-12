using Andromeda.Exe.DeviceConfiguration.Data.Context.Abstractions;
using Andromeda.Exe.DeviceConfiguration.Data.Models.App;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Andromeda.Exe.DeviceConfiguration.Server.DbContext.Extensions
{
    public static class IAndromedaDbContextExtensions
    {
        public static async Task<AppInstance?> GetAppInstanceByGuid(
            this IAndromedaDbContext dbContext,
            Guid guid
        ) => await dbContext.AppInstances
            .SingleOrDefaultAsync(x => x.Guid == guid);

        public static async Task<LoginRecord?> GetLoginRecordById(
            this IAndromedaDbContext dbContext,
            long id
        ) => await dbContext.LoginRecords
            .Include(x => x.AppInstance)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}
