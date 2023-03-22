using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.IRepositories
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(long Id);
        Task<User> SelectAsync(Predicate<User> predicate);
        IQueryable<User> SelectAllAsync(Predicate<User> predicate = null);

   }
}
