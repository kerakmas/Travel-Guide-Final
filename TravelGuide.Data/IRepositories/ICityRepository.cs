using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface ICityRepository
    {
        Task<City> InsertAsync(City city);
        Task<City> UpdateAsync(City city);
        Task<bool> DeleteAsync(long Id);
        Task<City> SelectAsync(Predicate<City> predicate);
        IQueryable<City> SelectAllAsync(Predicate<City> predicate);
    }
}
