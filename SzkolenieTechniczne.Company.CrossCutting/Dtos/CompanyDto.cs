using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        public CompanyAddressDto Address { get; set; }

        [MaxLength(9)]
        public string PhoneDirectional { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        [MaxLength(32)]
        [Required]
        public string NIP { get; set; }

        [MaxLength(16)]
        public string REGON { get; set; }

        public ICollection<JobPositionDto> JobPositions { get; set; } = new HashSet<JobPositionDto>();
    }
} 