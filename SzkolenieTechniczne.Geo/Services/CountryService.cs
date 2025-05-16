using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.Geo.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SzkolenieTechniczne.Geo.Extensions;

namespace SzkolenieTechniczne.Geo.Services
{
    public class CountryService
    {
        private GeoDbContext _geoDbContext;

        public CountryService(GeoDbContext geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CountryDto> GetById(Guid id)
        {
            var country = await _geoDbContext
                .Set<Country>()
                .Include(c => c.Translations)
                .AsNoTracking()
                .Where(c => c.Id.Equals(id))
                .SingleOrDefaultAsync();

            return country.ToDto();
        }

        public async Task<IEnumerable<CountryDto>> Get()
        {
            var countries = await _geoDbContext
                .Set<Country>()
                .Include(c => c.Translations)
                .AsNoTracking()
                .ToListAsync();

            return countries.Select(c => c.ToDto());
        }

        public async Task<CrudOperationResult<CountryDto>> Create(CountryDto dto)
        {
            var entity = dto.ToEntity();

            _geoDbContext
                .Set<Country>()
                .Add(entity);

            await _geoDbContext.SaveChangesAsync();

            var newDto = await GetById(entity.Id);

            return new CrudOperationResult<CountryDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}
