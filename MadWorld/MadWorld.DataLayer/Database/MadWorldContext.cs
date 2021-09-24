using System;
using MadWorld.DataLayer.Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace MadWorld.DataLayer.Database
{
    public class MadWorldContext : DbContext
    {
        public MadWorldContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Resume> Resumes { get; set; }
    }
}
