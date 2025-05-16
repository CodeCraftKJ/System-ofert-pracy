using System.Linq;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class JobPositionExtensions
    {
        public static JobPositionDto ToDto(this JobPosition entity)
        {
            if (entity == null) return null;

            return new JobPositionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                WorkingHours = entity.WorkingHours,
                GrossSalary = entity.GrossSalary,
                WorkingWeekHours = entity.WorkingWeekHours,
                Description = new LocalizedString(entity.Translations?.Select(t => 
                    new System.Collections.Generic.KeyValuePair<string, string>(t.LanguageCode, t.Description))),
                Responsibilities = new LocalizedString(entity.Translations?.Select(t => 
                    new System.Collections.Generic.KeyValuePair<string, string>(t.LanguageCode, t.Responsibilities)))
            };
        }

        public static JobPosition ToEntity(this JobPositionDto dto)
        {
            if (dto == null) return null;

            return new JobPosition
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                WorkingHours = dto.WorkingHours,
                GrossSalary = dto.GrossSalary,
                WorkingWeekHours = dto.WorkingWeekHours
            };
        }
    }
} 