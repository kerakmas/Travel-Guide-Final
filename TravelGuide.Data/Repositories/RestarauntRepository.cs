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
    public class RestarauntRepository : IRestarauntRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> DeleteAsync(long Id)
        {
            Restaraunt entity = await this.appDbContext.Restaraunts.FirstOrDefaultAsync(restaraunt => restaraunt.Id.Equals(Id));
            if (entity is null)
            {
                return false;
            }
            this.appDbContext.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<Restaraunt> InsertAsync(Restaraunt restaraunt)
        {
            EntityEntry<Restaraunt> entity = await this.appDbContext.Restaraunts.AddAsync(restaraunt);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<Restaraunt> SelectAllAsync(Predicate<Restaraunt> predicate = null)
        {
            if (predicate is null)
            {
                return this.appDbContext.Restaraunts;
            }
            return this.appDbContext.Restaraunts.AsEnumerable().Where(restaraunt => predicate(restaraunt)).AsQueryable();
        }

        

        public async Task<Restaraunt> SelectAsync(Predicate<Restaraunt> predicate)
        {
            var restaraunts = await this.appDbContext.Restaraunts.ToListAsync();
            return restaraunts.FirstOrDefault(restaraunt => predicate(restaraunt));
        }

        public async Task<Restaraunt> UpdateAsync(Restaraunt restaraunt)
        {
            EntityEntry<Restaraunt> entity = this.appDbContext.Restaraunts.Update(restaraunt);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
