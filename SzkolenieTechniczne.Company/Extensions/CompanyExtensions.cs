using System.Linq;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyExtensions
    {
        public static CompanyDto ToDto(this Storage.Entities.Company entity)
        {
            if (entity == null) return null;

            return new CompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneDirectional = entity.PhoneDirectional,
                PhoneNumber = entity.PhoneNumber,
                NIP = entity.NIP,
                REGON = entity.REGON,
                Address = entity.Address?.ToDto(),
                JobPositions = entity.JobPositions?.Select(jp => jp.ToDto()).ToHashSet()
            };
        }

        public static Storage.Entities.Company ToEntity(this CompanyDto dto)
        {
            if (dto == null) return null;

            return new Storage.Entities.Company
            {
                Id = dto.Id,
                Name = dto.Name,
                PhoneDirectional = dto.PhoneDirectional,
                PhoneNumber = dto.PhoneNumber,
                NIP = dto.NIP,
                REGON = dto.REGON,
                Address = dto.Address?.ToEntity(),
                JobPositions = dto.JobPositions?.Select(jp => jp.ToEntity()).ToHashSet()
            };
        }
    }

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
                WorkingWeekHours = entity.WorkingWeekHours
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