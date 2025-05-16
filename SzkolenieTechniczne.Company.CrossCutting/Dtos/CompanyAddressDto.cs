using System;
using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class CompanyAddressDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CountryId { get; set; }

        [MaxLength(256)]
        public string Post { get; set; }

        [MaxLength(256)]
        public string Province { get; set; }

        [MaxLength(256)]
        public string District { get; set; }

        [MaxLength(256)]
        public string Community { get; set; }

        [MaxLength(256)]
        public string City { get; set; }

        [MaxLength(256)]
        public string Street { get; set; }

        [MaxLength(10)]
        public string FlatNumber { get; set; }

        [MaxLength(10)]
        public string HouseNumber { get; set; }
    }
} 