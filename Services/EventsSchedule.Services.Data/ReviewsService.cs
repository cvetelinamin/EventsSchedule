namespace EventsSchedule.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

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

        public int GetCountByEventId(string eventId)
        {
            return this.reviewRepository.All().Count(e => e.EventId == eventId);
        }

        public IEnumerable<T> GetEventReviews<T>(string eventId, int? take = null, int skip = 0)
        {
            var query = this.reviewRepository.All()
                          .OrderByDescending(e => e.CreatedOn)
                          .Where(r => r.EventId == eventId)
                          .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
