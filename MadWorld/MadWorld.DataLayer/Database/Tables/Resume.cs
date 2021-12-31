using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.DataLayer.Database.Tables
{
    public class Resume
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime? Birthdate { get; set; }
        [MaxLength(100)]
        public string? FullName { get; set; }
        [MaxLength(100)]
        public string? Nationality { get; set; }
        public DateTime? Created { get; set; }
    }
}
