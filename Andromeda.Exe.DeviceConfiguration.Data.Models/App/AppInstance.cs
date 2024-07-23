using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Andromeda.Exe.DeviceConfiguration.Data.Models.App
{
    [Index(nameof(Guid), IsUnique = true)]
    public class AppInstance : EntityBase
    {
        #region Constructors

        private AppInstance() { }

        #endregion

        #region Properties

        [Required]
        public Guid Guid { get; private set; }

        [Required]
        public string Name { get; private set; } = null!;

        [Required]
        public DateTime Created { get; private set; }

        #endregion

        #region Related collections

        private readonly List<LoginRecord> _loginRecords = [];
        public virtual IReadOnlyCollection<LoginRecord> LoginRecords
            => _loginRecords.AsReadOnly();

        #endregion

        #region Static factory methods

        public static AppInstance CreateNew(
            string name,
            Guid? guid = null,
            DateTime? created = null
        ) => CreateExisting(
            name,
            guid ?? Guid.NewGuid(),
            created ?? DateTime.UtcNow,
            default
        );

        public static AppInstance CreateExisting(
            string name, Guid guid, DateTime created, long id
        )
        {
            var appInstance = new AppInstance
            {
                Guid = guid,
                Created = created,
                Id = id,
            };
            appInstance.ChangeName(name);
            return appInstance;
        }

        #endregion

        #region Methods to change properties

        public void ChangeName(string name)
            => Name = name;

        #endregion

        #region Methods to add related objects

        public LoginRecord AddLoginRecord(LoginRecord.Builder builder)
        {
            builder.AddAppInstance(this);
            var record = builder.Build();
            _loginRecords.Add(record);
            return record;
        }

        #endregion
    }
}
