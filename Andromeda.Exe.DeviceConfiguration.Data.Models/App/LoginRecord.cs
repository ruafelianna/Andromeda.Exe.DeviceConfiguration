using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.App
{
    public partial class LoginRecord : EntityBase
    {
        #region Constructors

        private LoginRecord() { }

        #endregion

        #region Properties

        [Required, ForeignKey(nameof(AppInstance))]
        public long AppInstanceId { get; private set; }

        [Required]
        public DateTime Ts { get; private set; }

        [Required]
        public string OSType { get; private set; } = null!;

        [Required]
        public string OSVersion { get; private set; } = null!;

        [Required]
        public string OSAddressWidth { get; private set; } = null!;

        [Required]
        public string OSArchitecture { get; private set; } = null!;

        [Required]
        public string MotherboardModel { get; private set; } = null!;

        public string? MotherboardSN { get; private set; }

        [Required]
        public string ProcessorName { get; private set; } = null!;

        public string? ProcessorSN { get; private set; }

        [Required]
        public string ProcessorDataWidth { get; private set; } = null!;

        public string? BIOSSN { get; private set; }

        public string? MACAddress { get; private set; }

        public string? RAMSN { get; private set; }

        public string? DiskSN { get; private set; }

        public string? NetworkLogin { get; private set; }

        public string? DomainName { get; private set; }

        public string? MachineName { get; private set; }

        public string? CurrentUser { get; private set; }

        public string? RunAs { get; private set; }

        [Required]
        public TimeSpan Timezone { get; private set; }

        #endregion

        #region Virtual foreign key properties

        public virtual AppInstance AppInstance { get; protected set; } = null!;

        #endregion
    }
}
