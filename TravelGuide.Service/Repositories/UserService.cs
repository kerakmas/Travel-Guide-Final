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
    public class UserService
    {
        private readonly GenericRepository<User> genericRepository = new GenericRepository<User>();
        private long lastId;

        public async Task<Responce<User>> CreateAsync(UserCreationDto user)
        {
            var models = await this.genericRepository.GetAllAsync(x => x.Id > 0);
            if (models.Count == 0)
                lastId = 1;
            else
                lastId = (models[models.Count - 1].Id) + 1;

            var model = models.FirstOrDefault(x => x.Email == user.Email);
            if (model is null)
            {
                var mappedModel = new User()
                {
                    Id = lastId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    CityName = user.CityName,
                    CountOfDays = user.CountOfDays,
                    CountOfMembers = user.CountOfMembers,
                    Password = user.Password,
                    CreatedAt = DateTime.UtcNow
                };
                var result = await this.genericRepository.CreateAsync(mappedModel);
                return new Responce<User>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = result
                };
            }

            return new Responce<User>()
            {
                StatusCode = 403,
                Message = "Already exists",
                Value = null
            };
        }

        public async Task<Responce<bool>> DeleteAsync(Predicate<User> predicate)
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

        public async Task<Responce<List<User>>> GetAllAsync(Predicate<User> predicate)
        {
            var models = await this.genericRepository.GetAllAsync(predicate);
            return new Responce<List<User>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = models
            };
        }

        public async Task<Responce<User>> GetByIdAsync(Predicate<User> predicate)
        {
            var model = await this.genericRepository.GetByIdAsync(predicate);
            if (model is null)
            {
                return new Responce<User>()
                {
                    StatusCode = 404,
                    Message = "NotFound",
                    Value = null
                };
            }
            return new Responce<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }



        public async Task<Responce<User>> UpdateAsync(Predicate<User> predicate, UserCreationDto user)
        {
            var model = await this.genericRepository.GetByIdAsync(predicate);
            if (model is null)
            {
                return new Responce<User>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            var mappedUser = new User()
            {
                Id = model.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CityName = user.CityName,
                Password = user.Password,
                CountOfDays = user.CountOfDays,
                CountOfMembers = user.CountOfMembers,
                UpdatedAt = DateTime.UtcNow,

            };
            var result = await this.genericRepository.UpdateAsync(predicate, mappedUser);
            return new Responce<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    }
}
