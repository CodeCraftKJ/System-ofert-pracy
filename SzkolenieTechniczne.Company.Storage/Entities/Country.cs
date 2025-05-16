using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("Countries", Schema = "Dictionaries")]
    public class Country : BaseEntity, IExternalSourceEntity
    {
        [MaxLength(3)]
        [MinLength(2)]
        [Required]
        public string AlphaCode { get; set; } = null!;

        [MaxLength(5)]
        public string ExternalSourceName { get; set; }

        [MaxLength(30)]
        public string ExternalId { get; set; }

        public System.DateTime? LastSynchronizedOn { get; set; }

        public ICollection<CountryTranslation> Translations { get; set; } = new HashSet<CountryTranslation>();
    }
} 