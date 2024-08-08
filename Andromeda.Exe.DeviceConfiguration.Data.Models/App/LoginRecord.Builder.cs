using Andromeda.Exe.DeviceConfiguration.Data.Models.Builder;
using System;
using System.Runtime.InteropServices;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.App
{
    public partial class LoginRecord
    {
        public sealed class Builder : EntityBuilderBase<LoginRecord>
        {
            public Builder()
            {
                RequiredMethods.Add(nameof(AddAppInstance));
                RequiredMethods.Add(nameof(AddTs));
                RequiredMethods.Add(nameof(AddOSInfo));
                RequiredMethods.Add(nameof(AddProcessor));
                RequiredMethods.Add(nameof(AddMotherboard));
            }

            internal Builder AddAppInstance(AppInstance appInstance)
            {
                ArgumentNullException.ThrowIfNull(appInstance);

                _obj.AppInstance = appInstance;
                _obj.AppInstanceId = appInstance.Id;

                MethodCalled();

                return this;
            }

            public Builder AddTs(
                DateTime? ts = null,
                TimeSpan? tz = null
            )
            {
                _obj.Ts = ts ?? DateTime.UtcNow;
                _obj.Timezone = tz ?? TimeSpan.Zero;

                MethodCalled();

                return this;
            }

            public Builder AddOSInfo(
                OSPlatform osPlatform,
                string osVersion,
                string osAddressWidth,
                string osArchitecture
            )
            {
                var osType = osPlatform.ToString();

                ArgumentException.ThrowIfNullOrWhiteSpace(osType);
                ArgumentException.ThrowIfNullOrWhiteSpace(osVersion);
                ArgumentException.ThrowIfNullOrWhiteSpace(osAddressWidth);
                ArgumentException.ThrowIfNullOrWhiteSpace(osArchitecture);

                _obj.OSType = osType;
                _obj.OSVersion = osVersion;
                _obj.OSAddressWidth = osVersion;
                _obj.OSArchitecture = osVersion;

                MethodCalled();

                return this;
            }

            public Builder AddProcessor(
                string processorName,
                string processorDataWidth,
                string? processorSN = null
            )
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(processorName);
                ArgumentException.ThrowIfNullOrWhiteSpace(processorDataWidth);

                _obj.ProcessorName = processorName;
                _obj.ProcessorDataWidth = processorDataWidth;
                _obj.ProcessorSN = processorSN;

                MethodCalled();

                return this;
            }

            public Builder AddMotherboard(
                string motherboardModel,
                string? motherboardSN = null
            )
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(motherboardModel);

                _obj.MotherboardModel = motherboardModel;
                _obj.MotherboardSN = motherboardSN;

                MethodCalled();

                return this;
            }

            public Builder AddBIOS(string? biosSN = null)
            {
                _obj.BIOSSN = biosSN;

                MethodCalled();

                return this;
            }

            public Builder AddRAM(string? ramSN = null)
            {
                _obj.RAMSN = ramSN;

                MethodCalled();

                return this;
            }

            public Builder AddDisk(string? diskSN = null)
            {
                _obj.DiskSN = diskSN;

                MethodCalled();

                return this;
            }

            public Builder AddNetworkInfo(
                string? macAddress = null,
                string? networkLogin = null,
                string? domainName = null,
                string? machineName = null
            )
            {
                _obj.MACAddress = macAddress;
                _obj.NetworkLogin = networkLogin;
                _obj.DomainName = domainName;
                _obj.MachineName = machineName;

                MethodCalled();

                return this;
            }

            public Builder AddUserInfo(
                string? currentUser = null,
                string? runAs = null
            )
            {
                _obj.CurrentUser = currentUser;
                _obj.RunAs = runAs;

                MethodCalled();

                return this;
            }

            protected override LoginRecord CreateObj()
                => new();
        }
    }
}
