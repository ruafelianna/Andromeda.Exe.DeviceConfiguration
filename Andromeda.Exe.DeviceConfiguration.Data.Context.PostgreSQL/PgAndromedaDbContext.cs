using Microsoft.EntityFrameworkCore;

namespace Andromeda.Exe.DeviceConfiguration.Data.Context.PostgreSQL
{
    public class PgAndromedaDbContext : AndromedaDbContextBase
    {
        protected PgAndromedaDbContext() : base()
        {
        }

        public PgAndromedaDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
