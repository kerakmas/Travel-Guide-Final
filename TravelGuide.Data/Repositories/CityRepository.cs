using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Data.Contexts;
using TravelGuide.Data.IRepositories;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> DeleteAsync(long Id)
        {
            City entity = await this.appDbContext.Cities.FirstOrDefaultAsync(city => city.Id.Equals(Id));
            if (entity is null)
            {
                return false;
            }
            this.appDbContext.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<City> InsertAsync(City city)
        {
            EntityEntry<City> entity = await this.appDbContext.Cities.AddAsync(city);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<City> SelectAllAsync(Predicate<City> predicate = null)
        {
            if (predicate is null)
            {
                return this.appDbContext.Cities;
            }
            return this.appDbContext.Cities.AsEnumerable().Where(city => predicate(city)).AsQueryable();
        }

        

        public async Task<City> SelectAsync(Predicate<City> predicate)
        {
            var cities = await this.appDbContext.Cities.ToListAsync();
            return cities.FirstOrDefault(city => predicate(city));
        }

        public async Task<City> UpdateAsync(City city)
        {
            EntityEntry<City> entity = this.appDbContext.Cities.Update(city);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
