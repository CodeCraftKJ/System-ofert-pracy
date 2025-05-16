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
    public class CityService
    {
        private GeoDbContext _geoDbContext;

        public CityService(GeoDbContext geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CityDto> GetById(Guid id)
        {
            var city = await _geoDbContext
                .Set<City>()
                .Include(c => c.Translations)
                .AsNoTracking()
                .Where(c => c.Id.Equals(id))
                .SingleOrDefaultAsync();

            return city.ToDto();
        }

        public async Task<IEnumerable<CityDto>> Get()
        {
            var cities = await _geoDbContext
                .Set<City>()
                .Include(c => c.Translations)
                .AsNoTracking()
                .ToListAsync();

            return cities.Select(c => c.ToDto());
        }

        public async Task<CrudOperationResult<CityDto>> Create(CityDto dto)
        {
            var entity = dto.ToEntity();

            _geoDbContext
                .Set<City>()
                .Add(entity);

            await _geoDbContext.SaveChangesAsync();

            var newDto = await GetById(entity.Id);

            return new CrudOperationResult<CityDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}