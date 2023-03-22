using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Data.IRepositories;
using TravelGuide.Data.Repositories;
using TravelGuide.Domain.Entities;
using TravelGuide.Service.DTOs;
using TravelGuide.Service.Helpers;
using TravelGuide.Service.Interfaces;

namespace TravelGuide.Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository = new ReviewRepository();
        public async Task<Responce<Review>> CreateAsync(ReviewCreationDTO review)
        {
            var mappedModel = new Review()
            {
                Comment = review.Comment,
                Rating = review.Rating,
                PlacceType = review.PlacceType
            };
            var result = await this.reviewRepository.InsertAsync(mappedModel);
            return new Responce<Review>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }

        public async Task<Responce<bool>> DeleteAsync(Predicate<Review> predicate)
        {
            var model = await this.reviewRepository.SelectAsync(predicate);
            if (model is null)
                return new Responce<bool>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = false
                };

            await this.reviewRepository.DeleteAsync(model.Id);
            return new Responce<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = true
            };
        }

        public async Task<Responce<List<Review>>> GetAllAsync(Predicate<Review> predicate)
        {
            var models = this.reviewRepository.SelectAllAsync(predicate).ToList();
            return new Responce<List<Review>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = models
            };
        }

        public async Task<Responce<Review>> GetAsync(Predicate<Review> predicate)
        {
            var model = await this.reviewRepository.SelectAsync(predicate);
            if (model is null)
            {
                return new Responce<Review>()
                {
                    StatusCode = 404,
                    Message = "NotFound",
                    Value = null
                };
            }
            return new Responce<Review>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<Responce<Review>> UpdateAsync(Predicate<Review> predicate, ReviewCreationDTO reviewCreation)
        {
            var model = await this.reviewRepository.SelectAsync(predicate);
            if (model is null)
            {
                return new Responce<Review>()
                {
                    StatusCode = 404,
                    Message = "NOT FOUND",
                    Value = null
                };
            }
            model.Comment = reviewCreation.Comment;
            model.Rating = reviewCreation.Rating;
            model.PlacceType = reviewCreation.PlacceType;
            model.UpdatedAt = DateTime.UtcNow;
            var result = await this.reviewRepository.UpdateAsync(model);
            return new Responce<Review>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }
    }
}
