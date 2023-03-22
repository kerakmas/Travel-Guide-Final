using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Data.Repositories;
using TravelGuide.Domain.Entities;
using TravelGuide.Service.DTOs;
using TravelGuide.Service.Helpers;
using TravelGuide.Service.Interfaces;

namespace TravelGuide.Service.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly AttractionRepository attractionRepository = new AttractionRepository();
        private readonly RestarauntRepository restarauntRepository = new RestarauntRepository();
        private readonly TravelTipRepository travelTipRepository = new TravelTipRepository();
        public async Task<Responce<List<Attraction>>> GetAllAttractionsAsync(Predicate<Attraction> predicate = null,long CityId)
        {
            return new Responce<List<Attraction>>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = this.attractionRepository.SelectAllAsync().ToList()
            };
        }

        public async Task<Responce<List<Restaraunt>>> GetAllRestarauntsAsync(Predicate<Restaraunt> predicate = null)
        {
            return new Responce<List<Restaraunt>>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = this.restarauntRepository.SelectAllAsync().ToList()
            };
        }

        public async Task<Responce<List<TravelTip>>> GetAllTravelTipsAsync(Predicate<Restaraunt> predicate = null)
        {
            return new Responce<List<TravelTip>>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = this.travelTipRepository.SelectAllAsync().ToList()
            };
        }

    }
}

