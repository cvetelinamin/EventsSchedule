namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Reviews;

    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewRepository;

        public ReviewsService(IDeletableEntityRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task CreateAsync(string comment, int raiting, string userId, string eventId)
        {
            var review = new Review
            {
                ApplicationUserId = userId,
                EventId = eventId,
                Comment = comment,
                Rating = raiting,
            };

            await this.reviewRepository.AddAsync(review);
            await this.reviewRepository.SaveChangesAsync();
        }
    }
}
