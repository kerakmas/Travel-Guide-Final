using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Data.Repositories;
using TravelGuide.Domain.Entities;
using TravelGuide.Service.DTOs;
using TravelGuide.Service.Helpers;

namespace TravelGuide.Service.Repositories
{
    public class TodolistService
    {
        private readonly GenericRepository<ToDoList> genericRepository = new GenericRepository<ToDoList>();
        private long lastId;
        public async Task<Responce<ToDoList>> CreateAsync(ToDoListCreationDto list)
        {
            var models = await this.genericRepository.GetAllAsync(x => x.Id > 0);
            if (models.Count == 0)
                lastId = 1;
            else
                lastId = (models[models.Count - 1].Id) + 1;

            var model = models.FirstOrDefault(x => x.NumberOfDay == list.NumberOfDay);
            if (model is null)
            {
                var mappedModel = new ToDoList()
                {
                    Id = lastId,
                    UserId = lastId,
                    HoursSpend = list.HoursSpend,
                    PlaceType = list.PlaceType,
                    TripStatus = list.TripStatus,
                    CityName = list.CityName,
                    Comment = list.Comment,
                    DayOfWeek = list.DayOfWeek,
                    NumberOfDay = list.NumberOfDay,
                    CreatedAt = DateTime.UtcNow
                };
                var result = await this.genericRepository.CreateAsync(mappedModel);
                return new Responce<ToDoList>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = result
                };
            }

            return new Responce<ToDoList>()
            {
                StatusCode = 403,
                Message = "Already exists",
                Value = null
            };
        }

        public async Task<Responce<bool>> DeleteAsync(Predicate<ToDoList> predicate)
        {
            var model = await this.genericRepository.GetByIdAsync(predicate);
            if (model is null)
                return new Responce<bool>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = false
                };

            await this.genericRepository.DeleteAysnc(predicate);
            return new Responce<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async Task<Responce<List<ToDoList>>> GetAllAsync(Predicate<ToDoList> predicate)
        {
            var models = await this.genericRepository.GetAllAsync(predicate);
            return new Responce<List<ToDoList>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = models
            };
        }

        public async Task<Responce<ToDoList>> GetByIdAsync(Predicate<ToDoList> predicate)
        {
            var model = await this.genericRepository.GetByIdAsync(predicate);
            if (model is null)
            {
                return new Responce<ToDoList>()
                {
                    StatusCode = 404,
                    Message = "NotFound",
                    Value = null
                };
            }
            return new Responce<ToDoList>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }



        public async Task<Responce<ToDoList>> UpdateAsync(Predicate<ToDoList> predicate, ToDoListCreationDto list)
        {

            var model = await this.genericRepository.GetByIdAsync(predicate);
            if (model is null)
            {
                return new Responce<ToDoList>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            var mappedToDoList = new ToDoList()
            {
                HoursSpend = list.HoursSpend,
                PlaceType = list.PlaceType,
                TripStatus = list.TripStatus,
                CityName = list.CityName,
                Comment = list.Comment,
                DayOfWeek = list.DayOfWeek,
                NumberOfDay = list.NumberOfDay,
                UpdatedAt = DateTime.UtcNow
            };
            var result = await this.genericRepository.UpdateAsync(predicate, mappedToDoList);
            return new Responce<ToDoList>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    }
}

