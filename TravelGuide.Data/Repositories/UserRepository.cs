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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> DeleteAsync(long Id)
        {
            User entity = await this.appDbContext.Users.FirstOrDefaultAsync(user => user.Id.Equals(Id));
            if(entity is null)
            {
                return false;
            }
            this.appDbContext.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public  async Task<User> InsertAsync(User user)
        {
            EntityEntry<User> entity = await this.appDbContext.Users.AddAsync(user);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
 
        public IQueryable<User> SelectAllAsync(Predicate<User> predicate = null)
        {
            if (predicate is null)
            {
                return this.appDbContext.Users;
            }
            return this.appDbContext.Users.AsEnumerable().Where(restaraunt => predicate(restaraunt)).AsQueryable();
        }

        
        public async Task<User> SelectAsync(Predicate<User> predicate)
        {
            var users = await this.appDbContext.Users.ToListAsync();
            return users.FirstOrDefault(user => predicate(user));
        }



        public async Task<User> UpdateAsync(User user)
        {
            EntityEntry<User> entity = this.appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

    }
}
