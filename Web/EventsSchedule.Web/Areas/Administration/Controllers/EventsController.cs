namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : AdministrationController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly IEventsService eventsService;

        public EventsController(ApplicationDbContext dbContext, IDeletableEntityRepository<Event> eventsRepository, IEventsService eventsService)
        {
            this.dbContext = dbContext;
            this.eventsRepository = eventsRepository;
            this.eventsService = eventsService;
        }

        [HttpGet("/Administration/Events/Edit")]
        public async Task<IActionResult> Edit(string eventId)
        {
            var eventViewModel = this.eventsService.GetById<EventsEditViewModel>(eventId);

            if (eventViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(eventViewModel);
        }

        //[HttpPost("/Administration/Events/Edit")]
        //public async Task<IActionResult> Edit(EventsEditViewModel eventEditViewModel)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(eventEditViewModel);
        //    }

        //    var newsToEdit = this.eventsRepository.AllWithDeleted().Where(n => n.Id == eventEditViewModel.Id).FirstOrDefault();

        //    newsToEdit.Title = newsEditViewModel.Title;
        //    newsToEdit.Content = newsEditViewModel.Content;
        //    newsToEdit.ModifiedOn = DateTime.UtcNow;

        //    this.newsRepository.Update(newsToEdit);
        //    await this.newsRepository.SaveChangesAsync();

        //    var newsId = newsToEdit.Id;

        //    return this.RedirectToAction("NewsDetails", "News", new { newsId, Area = "User" });
        //}

        public async Task<IActionResult> Delete(string eventId)
        {
            var eventToDelete = this.eventsRepository.All().FirstOrDefault(r => r.Id == eventId);

            if (eventToDelete == null)
            {
                return this.BadRequest();
            }

            this.eventsRepository.Delete(eventToDelete);
            await this.eventsRepository.SaveChangesAsync();

            return this.RedirectToAction("GetLastEvents", "Events", new { Area = "User" });
        }
    }
}
