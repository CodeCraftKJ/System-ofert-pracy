using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyAddressExtensions
    {
        public static CompanyAddressDto ToDto(this CompanyAddress entity)
        {
            if (entity == null) return null;

            return new CompanyAddressDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                CountryId = entity.CountryId,
                Post = entity.Post,
                Province = entity.Province,
                District = entity.District,
                Community = entity.Community,
                City = entity.City,
                Street = entity.Street,
                FlatNumber = entity.FlatNumber,
                HouseNumber = entity.HouseNumber
            };
        }

        public static CompanyAddress ToEntity(this CompanyAddressDto dto)
        {
            if (dto == null) return null;

            return new CompanyAddress
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                CountryId = dto.CountryId,
                Post = dto.Post,
                Province = dto.Province,
                District = dto.District,
                Community = dto.Community,
                City = dto.City,
                Street = dto.Street,
                FlatNumber = dto.FlatNumber,
                HouseNumber = dto.HouseNumber
            };
        }
    }
} 