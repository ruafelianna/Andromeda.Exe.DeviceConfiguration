using System;
using System.ComponentModel.DataAnnotations;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.App
{
    public class AppInstance : EntityBase
    {
        private AppInstance() { }

        [Required]
        public Guid Guid { get; private set; }

        [Required]
        public string Name { get; private set; } = null!;

        [Required]
        public DateTime Created { get; private set; }

        public DateTime LocalCreated => Created.ToLocalTime();

        public static AppInstance CreateNew(
            string name
        ) => CreateExisting(name, Guid.NewGuid(), DateTime.UtcNow);

        public static AppInstance CreateExisting(
            string name, Guid guid, DateTime created
        )
        {
            var appInstance = new AppInstance
            {
                Guid = guid,
                Created = created,
            };
            appInstance.ChangeName(name);
            return appInstance;
        }

        public static AppInstance CreateCopy(
            AppInstance old
        ) => CreateExisting(old.Name, old.Guid, old.Created);

        public void ChangeName(string name)
            => Name = name;
    }
}
