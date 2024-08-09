using Andromeda.Exe.DeviceConfiguration.Data.Models.App;
using Andromeda.Exe.DeviceConfiguration.DTOs.App;
using System.Runtime.InteropServices;

namespace Andromeda.Exe.DeviceConfiguration.Server.DbContext.Extensions
{
    public static class LoginRecordExtensions
    {
        public static LoginRecord.Builder ToDbModelBuilder(
            this LoginRecordDTO_Create dtoLoginRecord
        ) => new LoginRecord.Builder()
            .AddTs(
                dtoLoginRecord.Ts,
                dtoLoginRecord.Timezone
            )
            .AddNetworkInfo(
                dtoLoginRecord.MACAddress,
                dtoLoginRecord.NetworkLogin,
                dtoLoginRecord.DomainName,
                dtoLoginRecord.MachineName
            )
            .AddProcessor(
                dtoLoginRecord.ProcessorName,
                dtoLoginRecord.ProcessorDataWidth,
                dtoLoginRecord.ProcessorSN
            )
            .AddDisk(
                dtoLoginRecord.DiskSN
            )
            .AddBIOS(
                dtoLoginRecord.BIOSSN
            )
            .AddRAM(
                dtoLoginRecord.RAMSN
            )
            .AddMotherboard(
                dtoLoginRecord.MotherboardModel,
                dtoLoginRecord.MotherboardSN
            )
            .AddOSInfo(
                OSPlatform.Create(dtoLoginRecord.OSPlatform),
                dtoLoginRecord.OSVersion,
                dtoLoginRecord.OSAddressWidth,
                dtoLoginRecord.OSArchitecture
            )
            .AddUserInfo(
                dtoLoginRecord.CurrentUser,
                dtoLoginRecord.RunAs
            );

        public static LoginRecordDTO ToDTOModel(
            this LoginRecord loginRecord
        ) => new(
            loginRecord.AppInstance.Guid,
            loginRecord.Id,
            loginRecord.OSType,
            loginRecord.OSVersion,
            loginRecord.OSAddressWidth,
            loginRecord.OSArchitecture,
            loginRecord.ProcessorName,
            loginRecord.ProcessorDataWidth,
            loginRecord.MotherboardModel,
            loginRecord.Ts,
            loginRecord.Timezone,
            loginRecord.ProcessorSN,
            loginRecord.MotherboardSN,
            loginRecord.BIOSSN,
            loginRecord.RAMSN,
            loginRecord.DiskSN,
            loginRecord.MACAddress,
            loginRecord.NetworkLogin,
            loginRecord.DomainName,
            loginRecord.MachineName,
            loginRecord.CurrentUser,
            loginRecord.RunAs
        );
    }
}
