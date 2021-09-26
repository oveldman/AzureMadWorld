using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace MadWorld.DataLayer.Database
{
    public class MadWorldContextDev : MadWorldContext
    {
        public MadWorldContextDev(DbContextOptions options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
        {
        }
    }
}
