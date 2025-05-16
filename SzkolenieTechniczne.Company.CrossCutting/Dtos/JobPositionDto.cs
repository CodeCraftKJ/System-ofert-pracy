using System;
using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class JobPositionDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public short? WorkingHours { get; set; }

        [Required]
        public decimal GrossSalary { get; set; }

        [Required]
        public short WorkingWeekHours { get; set; }

        public LocalizedString Description { get; set; }
        
        public LocalizedString Responsibilities { get; set; }
    }
} 