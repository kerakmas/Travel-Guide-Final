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
        private readonly TodolistRepository todolistRepository = new TodolistRepository();
        public async Task<Responce<ToDoList>> CreateAsync(ToDoListCreationDto list)
        {
                var mappedModel = new ToDoList()
                {
                    UserId = list.UserId,
                    HoursSpend = list.HoursSpend,
                    PlaceType = list.PlaceType,
                    TripStatus = list.TripStatus,
                    CityName = list.CityName,
                    Comment = list.Comment,
                    DayOfWeek = list.DayOfWeek,
                    NumberOfDay = list.NumberOfDay,
                    CreatedAt = DateTime.UtcNow
                };
                var result = await this.todolistRepository.InsertAsync(mappedModel);
                return new Responce<ToDoList>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = result
                };

        }

        public async Task<Responce<bool>> DeleteAsync(Predicate<ToDoList> predicate)
        {
            var model = await this.todolistRepository.SelectAsync(predicate);
            if (model is null)
                return new Responce<bool>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = false
                };

            await this.todolistRepository.DeleteAsync(model.Id);
            return new Responce<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async Task<Responce<List<ToDoList>>> GetAllAsync(Predicate<ToDoList> predicate)
        {
            var models =  this.todolistRepository.SelectAllAsync().ToList();
            return new Responce<List<ToDoList>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = models
            };
        }

        public async Task<Responce<ToDoList>> GetAsync(Predicate<ToDoList> predicate)
        {
            var model = await this.todolistRepository.SelectAsync(predicate);
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

            var model = await this.todolistRepository.SelectAsync(predicate);
            if (model is null)
            {
                return new Responce<ToDoList>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            model.HoursSpend = list.HoursSpend;
            model.PlaceType = list.PlaceType;
            model.TripStatus = list.TripStatus;
            model.CityName = list.CityName;
            model.Comment = list.Comment;
            model.DayOfWeek = list.DayOfWeek;
            model.NumberOfDay = list.NumberOfDay;
            model.UpdatedAt = DateTime.UtcNow;
            var result = await this.todolistRepository.UpdateAsync(model);
            return new Responce<ToDoList>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    }
}

