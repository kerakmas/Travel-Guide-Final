using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TravelGuide.Data.Contexts;
using TravelGuide.Data.IRepositories;
using TravelGuide.Domain.Entities;
namespace TravelGuide.Data.Repositories
{
    public class TravelTipRepository :  ITravelTipRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> DeleteAsync(long Id)
        {
            var entity = await this.appDbContext.TravelTips.FirstOrDefaultAsync(traveltip => traveltip.Id.Equals(Id));
            if (entity is null)
            {
                return false;
            }
            appDbContext.TravelTips.Remove(entity);
            await appDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<TravelTip> InsertAsync(TravelTip travelTip)
        {
            EntityEntry<TravelTip> entity = await this.appDbContext.TravelTips.AddAsync(travelTip);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
        public IQueryable<TravelTip> SelectAllAsync(Predicate<TravelTip> predicate = null)
        {
            if (predicate is null)
            {
                return this.appDbContext.TravelTips;
            }
            return this.appDbContext.TravelTips.AsEnumerable().Where(traveltip => predicate(traveltip)).AsQueryable();
        }
        public async Task<TravelTip> SelectAsync(Predicate<TravelTip> predicate)
        {
            var travelTips = await this.appDbContext.TravelTips.ToListAsync();
            return travelTips.FirstOrDefault(travelTip => predicate(travelTip));
        }
        public async Task<TravelTip> UpdateAsync(TravelTip travelTip)
        {
            EntityEntry<TravelTip> entity = this.appDbContext.TravelTips.Update(travelTip);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }


    }
}
