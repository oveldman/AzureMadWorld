using System;
namespace MadWorld.API.Models
{
    public class StartupSettings
    {
        public bool ForgePostgresMigration { get; set; }
        public bool ForgeMsSqlMigration { get; set; }
    }
}
