using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;
using TravelGuide.Service.DTOs;
using TravelGuide.Service.Helpers;

namespace TravelGuide.Service.Interfaces
{
    public interface IUserService
    {
        Task<Responce<User>> CreateAsync(UserCreationDto user);
        Task<Responce<User>> UpdateAsync(Predicate<User> predicate, UserCreationDto user);
        Task<Responce<bool>> DeleteAsync(Predicate<User> predicate);
        Task<Responce<User>> GetAsync(Predicate<User> predicate);
        Task<Responce<List<User>>> GetAllAsync(Predicate<User> predicate);
    }
}
