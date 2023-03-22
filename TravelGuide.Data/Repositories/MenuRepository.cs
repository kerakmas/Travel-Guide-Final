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
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext(); 
        public async Task<bool> DeleteAsync(long Id)
        {
            Menu entity = await this.appDbContext.Menus.FirstOrDefaultAsync(menu => menu.Id.Equals(Id));
            if (entity is null)
            {
                return false;
            }
            this.appDbContext.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<Menu> InsertAsync(Menu menu)
        {
            EntityEntry<Menu> entity = await this.appDbContext.Menus.AddAsync(menu);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;

        }

        public IQueryable<Menu> SelectAllAsync(Predicate<Menu> predicate = null){
            if (predicate is null)
            {
                return this.appDbContext.Menus;
            }
            return this.appDbContext.Menus.AsEnumerable().Where(menu => predicate(menu)).AsQueryable();
        }
        public async Task<Menu> SelectAsync(Predicate<Menu> predicate)
        {
            var menus = await this.appDbContext.Menus.ToListAsync();
            return menus.FirstOrDefault(menu => predicate(menu));

        }

        public async Task<Menu> UpdateAsync(Menu user)
        {
            EntityEntry<Menu> entity = this.appDbContext.Menus.Update(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
