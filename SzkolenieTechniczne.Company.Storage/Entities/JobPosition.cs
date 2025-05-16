using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("JobPositions", Schema = "Company")]
    public class JobPosition : BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        [MaxLength(256)]
        public string Name { get; set; } = null!;

        public short? WorkingHours { get; set; }

        [Required]
        public decimal GrossSalary { get; set; }

        [Required]
        public short WorkingWeekHours { get; set; }
    }
} 