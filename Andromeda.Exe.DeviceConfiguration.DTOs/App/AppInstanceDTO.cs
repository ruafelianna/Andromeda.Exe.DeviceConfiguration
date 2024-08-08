using System;

namespace Andromeda.Exe.DeviceConfiguration.DTOs.App
{
    public record AppInstanceDTO(
        string Name,
        Guid Guid,
        DateTime Created
    );

    public record AppInstanceDTO_Register(
        string Name
    );

    public record AppInstanceDTO_ReportAlive(
        Guid Guid,
        long? Token = null
    );

    public record AppInstanceDTO_ConfirmAlive(
        long Token
    );
}
