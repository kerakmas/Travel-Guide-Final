using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface IAttractionRepository
    {
        Task<bool> DeleteAsync(long Id);
        Task<Attraction> InsertAsync(Attraction attraction);
        IQueryable<Attraction> SelectAllAsync(Predicate<Attraction> predicate);
        Task<Attraction> SelectAsync(Predicate<Attraction> predicate);
        Task<Attraction> UpdateAsync(Attraction attraction);
    }
}
