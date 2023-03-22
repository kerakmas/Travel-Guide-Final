using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface IMenuRepository
    {
        Task<Menu> InsertAsync(Menu menu);
        Task<Menu> UpdateAsync(Menu  menu);
        Task<bool> DeleteAsync(long Id);
        Task<Menu> SelectAsync(Predicate<Menu> predicate);
        IQueryable<Menu> SelectAllAsync(Predicate<Menu> predicate);
    }
}
