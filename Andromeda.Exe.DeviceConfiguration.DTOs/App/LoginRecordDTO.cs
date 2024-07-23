using System;

namespace Andromeda.Exe.DeviceConfiguration.DTOs.App
{
    public record LoginRecordDTO(
        long AppInstanceId,
        string OSPlatform,
        string OSVersion,
        string OSAddressWidth,
        string OSArchitecture,
        string ProcessorName,
        string ProcessorDataWidth,
        string MotherboardModel,
        DateTime? Ts = null,
        TimeSpan? Timezone = null,
        string? ProcessorSN = null,
        string? MotherboardSN = null,
        string? BIOSSN = null,
        string? RAMSN = null,
        string? DiskSN = null,
        string? MACAddress = null,
        string? NetworkLogin = null,
        string? DomainName = null,
        string? MachineName = null,
        string? CurrentUser = null,
        string? RunAs = null,
        long? Id = null
    );
}
