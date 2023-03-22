using TravelGuide.Data.Repositories;
using TravelGuide.Domain.Entities;
using TravelGuide.Service.DTOs;
using TravelGuide.Service.Helpers;
using TravelGuide.Service.Interfaces;

namespace TravelGuide.Service.Repositories
{
    public class UserService : IUserService
    {
        private readonly UserRepository userRepository = new UserRepository();

        public async Task<Responce<User>> CreateAsync(UserCreationDto user)
        {
            var model = await userRepository.SelectAsync(x => x.Email == user.Email);
            if (model is null)
            {
                var mappedModel = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    CityName = user.CityName,
                    CountOfDays = user.CountOfDays,
                    CountOfMembers = user.CountOfMembers,
                    Password = user.Password,
                    CreatedAt = DateTime.UtcNow
                };
                var result = await this.userRepository.InsertAsync(mappedModel);
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
            var model = await this.userRepository.SelectAsync(predicate);
            if (model is null)
                return new Responce<bool>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = false
                };

            await this.userRepository.DeleteAsync(model.Id);
            return new Responce<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async Task<Responce<List<User>>> GetAllAsync(Predicate<User> predicate)
        {
            var models = this.userRepository.SelectAllAsync(predicate).ToList();
            return new Responce<List<User>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = models
            };
        }

        public async Task<Responce<User>> GetAsync(Predicate<User> predicate)
        {
            var model = await this.userRepository.SelectAsync(predicate);
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
            var model = await this.userRepository.SelectAsync(predicate);
            if (model is null)
            {
                return new Responce<User>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Password = user.Password;
            model.CountOfDays = user.CountOfDays;
            model.CityName = user.CityName;
            model.CountOfMembers = user.CountOfMembers;
            model.UpdatedAt = DateTime.UtcNow;
          
            var result = await this.userRepository.UpdateAsync(model);
            return new Responce<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    }
}
