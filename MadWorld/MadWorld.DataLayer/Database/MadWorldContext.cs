using System;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using MadWorld.DataLayer.Database.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MadWorld.DataLayer.Database
{
    public class MadWorldContext : IdentityDbContext<IdentityUser>, IPersistedGrantDbContext
    {
        private readonly OperationalStoreOptions storeOptions;

        public MadWorldContext(DbContextOptions options, OperationalStoreOptions storeOptions) : base(options) 
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeviceFlowCodes>().HasKey(dfc => dfc.UserCode);
            modelBuilder.ConfigurePersistedGrantContext(storeOptions);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
    }
}
