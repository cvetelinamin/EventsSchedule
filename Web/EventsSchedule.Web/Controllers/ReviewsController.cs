namespace EventsSchedule.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Events;
    using EventsSchedule.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReviewsService reviewsService;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly ApplicationDbContext dbContext;

        public ReviewsController(IEventsService eventsService, UserManager<ApplicationUser> userManager, IReviewsService reviewsService, IDeletableEntityRepository<Event> eventRepository, ApplicationDbContext dbContext)
        {
            this.eventsService = eventsService;
            this.userManager = userManager;
            this.reviewsService = reviewsService;
            this.eventRepository = eventRepository;
            this.dbContext = dbContext;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewCreateInputModel reviewCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            var userId = this.userManager.GetUserId(this.User);
            var eventToReview = await this.eventRepository.GetByIdWithDeletedAsync(reviewCreateInputModel.EventId);
            var review = await this.reviewsService.Create(reviewCreateInputModel, userId, eventToReview.Id);

            this.dbContext.Reviews.Add(review);
            int result = this.dbContext.SaveChanges();

            return this.Redirect($"/Products/Details/{reviewCreateInputModel.EventId}");
        }
    }
}
