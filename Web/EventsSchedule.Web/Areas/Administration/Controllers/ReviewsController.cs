namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    public class ReviewsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Review> reviewsRepository;

        public ReviewsController(IDeletableEntityRepository<Review> reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }

        public async Task<IActionResult> Delete(string id, string eventId)
        {
            var review = this.reviewsRepository.All().FirstOrDefault(r => r.Id == id);

            if (review == null)
            {
                return this.BadRequest();
            }

            this.reviewsRepository.Delete(review);
            await this.reviewsRepository.SaveChangesAsync();

            return this.RedirectToAction("EventById", "Events", new { eventId, Area = string.Empty });
        }
    }
}
