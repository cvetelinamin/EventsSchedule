namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EventsSchedule.Data;
    using EventsSchedule.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    public class ReviewsController : AdministrationController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IReviewsService reviewsService;

        public ReviewsController(ApplicationDbContext dbContext, IReviewsService reviewsService)
        {
            this.dbContext = dbContext;
            this.reviewsService = reviewsService;
        }

        public IActionResult Delete(string id, int eventId)
        {
            var review = this.dbContext.Reviews.FirstOrDefault(r => r.Id == id);

            if (review == null)
            {
                return this.BadRequest();
            }

            this.dbContext.Remove(review);
            this.dbContext.SaveChanges();

            return this.Redirect($"/Reviews/ListAllReviews/{eventId}");
        }
    }
}
