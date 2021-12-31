using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.DataLayer.Database.Tables
{
    public class Account
    {
        [Key]
        public Guid ID { get; set; }
        public Guid AzureID { get; set; }
        public bool IsAdminstrator { get; set; }
        [MaxLength(100)]
        public string? EmailAdress { get; set; }
    }
}

