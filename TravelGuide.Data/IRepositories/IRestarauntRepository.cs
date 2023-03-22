using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface IRestarauntRepository
    {
        Task<bool> DeleteAsync(long Id);
        Task<Restaraunt> InsertAsync(Restaraunt restaraunt);
        IQueryable<Restaraunt> SelectAllAsync(Predicate<Restaraunt> predicate);
        Task<Restaraunt> SelectAsync(Predicate<Restaraunt> predicate);
        Task<Restaraunt> UpdateAsync(Restaraunt restaraunt);
    }
}
