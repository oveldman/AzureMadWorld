using System;
using Microsoft.EntityFrameworkCore;

namespace MadWorld.DataLayer.Database
{
    public class MadWorldContextDev : MadWorldContext
    {
        public MadWorldContextDev(DbContextOptions options) : base(options)
        {
        }
    }
}
