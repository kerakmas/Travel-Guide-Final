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
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> DeleteAsync(long Id)
        {
            Review entity = await this.appDbContext.Reviews.FirstOrDefaultAsync(review => review.Id.Equals(Id));
            if (entity is null)
            {
                return false;
            }
            this.appDbContext.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Review> InsertAsync(Review review)
        {
            EntityEntry<Review> entity = await this.appDbContext.Reviews.AddAsync(review);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<Review> SelectAllAsync(Predicate<Review> predicate = null)
        {
            if (predicate is null)
            {
                return this.appDbContext.Reviews;
            }
            return this.appDbContext.Reviews.AsEnumerable().Where(review => predicate(review)).AsQueryable();
        }
        public async Task<Review> SelectAsync(Predicate<Review> predicate){

            var reviews = await this.appDbContext.Reviews.ToListAsync();
            return reviews.FirstOrDefault(review => predicate(review));
        }

        public Task<Review> UpdateAsync(Review review)
        {
            EntityEntry<Review> entity = this.appDbContext.Reviews.Update(review);
            this.appDbContext.SaveChangesAsync();
            return Task.FromResult(entity.Entity);
        }
    }
}
