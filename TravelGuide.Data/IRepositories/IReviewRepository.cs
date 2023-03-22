using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface IReviewRepository
    {
        Task<bool> DeleteAsync(long Id);
        Task<Review> InsertAsync(Review review);
        IQueryable<Review> SelectAllAsync(Predicate<Review> predicate);
        Task<Review> SelectAsync(Predicate<Review> predicate);
        Task<Review> UpdateAsync(Review review);
    }
}
