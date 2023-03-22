using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface ITravelTipRepository
    {
        Task<bool> DeleteAsync(long Id);
        Task<TravelTip> InsertAsync(TravelTip travelTip);
        IQueryable<TravelTip> SelectAllAsync(Predicate<TravelTip> predicate);
        Task<TravelTip> SelectAsync(Predicate<TravelTip> predicate);
        Task<TravelTip> UpdateAsync(TravelTip travelTip);
    }
}
