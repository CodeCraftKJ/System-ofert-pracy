using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Extensions
{
    public static class CityExtension
    {
        public static CityDto ToDto(this City entity)
        {
            var result = new CityDto
            {
                Id = entity.Id,
                Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                CountryId = entity.CountryId,
                PostalCode = entity.PostalCode
            };
            return result;
        }
    }
}
