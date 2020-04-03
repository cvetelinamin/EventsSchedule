namespace EventsSchedule.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReviewsService reviewsService;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<Review> reviewRepository;
        private readonly ApplicationDbContext dbContext;

        public ReviewsController(IEventsService eventsService, UserManager<ApplicationUser> userManager, IReviewsService reviewsService, IDeletableEntityRepository<Event> eventRepository, IDeletableEntityRepository<Review> reviewRepository, ApplicationDbContext dbContext)
        {
            this.eventsService = eventsService;
            this.userManager = userManager;
            this.reviewsService = reviewsService;
            this.eventRepository = eventRepository;
            this.reviewRepository = reviewRepository;
            this.dbContext = dbContext;
        }

        [Route("Reviews/Add/{eventId}")]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewCreateInputModel reviewCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(reviewCreateInputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.reviewsService.CreateAsync(reviewCreateInputModel.Comment, reviewCreateInputModel.Rating, user.Id, reviewCreateInputModel.EventId);

            return this.RedirectToAction("EventById", "Events", new { reviewCreateInputModel.EventId });
        }

        [Route("Reviews/ListLastReviews/{eventId}")]
        public async Task<IActionResult> ListLastReviews([FromRoute]string eventId)
        {
            var viewModel = new ListReviewsViewModel
            {
                Reviews = this.reviewRepository.AllAsNoTracking()
                    .Where(r => r.EventId == eventId)
                    .OrderByDescending(e => e.CreatedOn)
                    .Take(3)
                    .To<EventReviewViewModel>()
                    .ToList(),
            };

            return this.View(viewModel);
        }

        [Route("Reviews/ListAllReviews/{eventId}")]
        public async Task<IActionResult> ListAllReviews([FromRoute]string eventId)
        {
            var viewModel = new ListReviewsViewModel
            {
                Reviews = this.reviewRepository.AllAsNoTracking()
                          .Where(r => r.EventId == eventId)
                          .OrderByDescending(e => e.CreatedOn)
                          .To<EventReviewViewModel>()
                          .ToList(),
            };

            return this.View(viewModel);
        }
    }
}
