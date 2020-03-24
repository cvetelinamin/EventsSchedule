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

        [Route("Reviews/Add/{eventId}")]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Reviews/Add/{eventId}")]
        public async Task<IActionResult> Add(ReviewCreateInputModel reviewCreateInputModel, [FromRoute] string eventId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(reviewCreateInputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.reviewsService.CreateAsync(reviewCreateInputModel.Comment, reviewCreateInputModel.Rating, user.Id, eventId);

            return this.View();
        }
    }
}
