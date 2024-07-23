using System;

namespace Andromeda.Exe.DeviceConfiguration.DTOs.App
{
    public record AppInstanceDTO(
        string Name,
        Guid? Guid = null,
        DateTime? Created = null,
        long? Id = null
    );
}
