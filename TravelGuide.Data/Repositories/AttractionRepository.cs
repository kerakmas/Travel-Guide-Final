using Microsoft.EntityFrameworkCore;
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
    public class AttractionRepository : IAttractionRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        
        public async Task<Attraction> InsertAsync(Attraction attraction)
        {
            var result = await appDbContext.Attractions.AddAsync(attraction);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Attraction> UpdateAsync(Attraction attraction)
        {
            var result = appDbContext.Attractions.Update(attraction);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<bool> DeleteAsync(long Id)
        {
            var entity = await appDbContext.Attractions.FirstOrDefaultAsync(attraction => attraction.Id.Equals(Id));
            if (entity is null)
            {
                return false;
            }
            appDbContext.Attractions.Remove(entity);
            await appDbContext.SaveChangesAsync();
            return true;
        }
        public IQueryable<Attraction> SelectAllAsync(Predicate<Attraction> predicate = null)
        {
            if (predicate is null)
            {
                return this.appDbContext.Attractions;
            }
            return this.appDbContext.Attractions.AsEnumerable().Where(attractioon => predicate(attractioon)).AsQueryable();
        }
        public async Task<Attraction> SelectAsync(Predicate<Attraction> predicate)
        {
            var attractions = await appDbContext.Attractions.ToListAsync();
            return attractions.FirstOrDefault(attraction => predicate(attraction));
        }
        
    }
}
