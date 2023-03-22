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
    public interface IGeneralService
    {
        Task<Responce<List<Restaraunt>>> GetAllRestarauntsAsync(Predicate<Restaraunt> predicate = null);
        Task<Responce<List<TravelTip>>> GetAllTravelTipsAsync(Predicate<Restaraunt> predicate = null);
        Task<Responce<List<Attraction>>> GetAllAttractionsAsync(Predicate<Attraction> predicate = null,long CityId);


    }
}
