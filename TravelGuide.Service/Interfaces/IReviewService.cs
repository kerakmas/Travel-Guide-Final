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
    public interface IReviewService
    {
        Task<Responce<Review>> CreateAsync(ReviewCreationDTO review);
        Task<Responce<Review>> UpdateAsync(Predicate<Review> predicate, ReviewCreationDTO reviewCreation);
        Task<Responce<bool>> DeleteAsync(Predicate<Review> predicate);
        Task<Responce<Review>> GetAsync(Predicate<Review> predicate);
        Task<Responce<List<Review>>> GetAllAsync(Predicate<Review> predicate);
    }
}
