namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Reviews;

    public class ReviewsService : IReviewsService
    {
        public async Task<Review> Create(ReviewCreateInputModel model, string userId, string eventId)
        {
            var review = new Review
            {
                ApplicationUserId = userId,
                EventId = eventId,
                Comment = model.Comment,
                Rating = model.Rating,
            };

            return review;
        }
    }
}
