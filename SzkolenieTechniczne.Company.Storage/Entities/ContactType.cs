using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("ContactTypes", Schema = "Dictionaries")]
    public class ContactType : BaseEntity
    {
        [MaxLength(50)]
        [MinLength(2)]
        [Required]
        public string Code { get; set; } = null!;

        public ICollection<ContactTypeTranslation> Translations { get; set; } = new HashSet<ContactTypeTranslation>();
    }
} 