using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage;
using SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.Company.Extensions;

namespace SzkolenieTechniczne.Company.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext _companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }

        public async Task<CompanyDto> GetById(Guid id)
        {
            var company = await _companyDbContext
                .Set<Storage.Entities.Company>()
                .Include(c => c.Address)
                .Include(c => c.JobPositions)
                .AsNoTracking()
                .Where(c => c.Id.Equals(id))
                .SingleOrDefaultAsync();

            return company.ToDto();
        }

        public async Task<IEnumerable<CompanyDto>> Get()
        {
            var companies = await _companyDbContext
                .Set<Storage.Entities.Company>()
                .Include(c => c.Address)
                .Include(c => c.JobPositions)
                .AsNoTracking()
                .ToListAsync();

            return companies.Select(c => c.ToDto());
        }

        public async Task<CrudOperationResult<CompanyDto>> Create(CompanyDto dto)
        {
            var entity = dto.ToEntity();

            _companyDbContext
                .Set<Storage.Entities.Company>()
                .Add(entity);

            await _companyDbContext.SaveChangesAsync();

            var newDto = await GetById(entity.Id);

            return new CrudOperationResult<CompanyDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CompanyDto>> Update(CompanyDto dto)
        {
            var entity = await _companyDbContext
                .Set<Storage.Entities.Company>()
                .Include(c => c.Address)
                .Include(c => c.JobPositions)
                .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (entity == null)
            {
                return new CrudOperationResult<CompanyDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound
                };
            }

            // Update basic properties
            entity.Name = dto.Name;
            entity.PhoneDirectional = dto.PhoneDirectional;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.NIP = dto.NIP;
            entity.REGON = dto.REGON;

            // Update address if exists
            if (dto.Address != null)
            {
                if (entity.Address == null)
                {
                    entity.Address = new CompanyAddress();
                }

                entity.Address.CountryId = dto.Address.CountryId;
                entity.Address.Post = dto.Address.Post;
                entity.Address.Province = dto.Address.Province;
                entity.Address.District = dto.Address.District;
                entity.Address.Community = dto.Address.Community;
                entity.Address.City = dto.Address.City;
                entity.Address.Street = dto.Address.Street;
                entity.Address.FlatNumber = dto.Address.FlatNumber;
                entity.Address.HouseNumber = dto.Address.HouseNumber;
            }

            await _companyDbContext.SaveChangesAsync();

            var updatedDto = await GetById(entity.Id);

            return new CrudOperationResult<CompanyDto>
            {
                Result = updatedDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CompanyDto>> Delete(Guid id)
        {
            var entity = await _companyDbContext
                .Set<Storage.Entities.Company>()
                .Include(c => c.Address)
                .Include(c => c.JobPositions)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
            {
                return new CrudOperationResult<CompanyDto>
                {
                    Status = CrudOperationResultStatus.RecordNotFound
                };
            }

            _companyDbContext.Remove(entity);
            await _companyDbContext.SaveChangesAsync();

            return new CrudOperationResult<CompanyDto>
            {
                Status = CrudOperationResultStatus.Success
            };
        }
    }
} 