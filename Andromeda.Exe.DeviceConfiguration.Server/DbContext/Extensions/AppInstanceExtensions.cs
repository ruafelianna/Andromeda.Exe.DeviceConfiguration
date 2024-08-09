using Andromeda.Exe.DeviceConfiguration.Data.Models.App;
using Andromeda.Exe.DeviceConfiguration.DTOs.App;

namespace Andromeda.Exe.DeviceConfiguration.Server.DbContext.Extensions
{
    public static class AppInstanceExtensions
    {
        public static AppInstance ToDbModel(
            this AppInstanceDTO dtoAppInstance
        ) => AppInstance.CreateNew(
                dtoAppInstance.Name,
                dtoAppInstance.Guid,
                dtoAppInstance.Created
            );

        public static AppInstanceDTO ToDTOModel(
            this AppInstance appInstance
        ) => new(
            appInstance.Name,
            appInstance.Guid,
            appInstance.Created
        );
    }
}
