namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly IEventsService eventsService;

        public EventsController(IDeletableEntityRepository<Event> eventsRepository, IEventsService eventsService)
        {
            this.eventsRepository = eventsRepository;
            this.eventsService = eventsService;
        }

        [HttpGet("/Administration/Events/EditEvent")]
        public IActionResult EditEvent(string eventId)
        {
            var eventViewModel = this.eventsService.GetById<EventsEditViewModel>(eventId);

            if (eventViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(eventViewModel);
        }

        [HttpPost("/Administration/Events/EditEvent")]
        public async Task<IActionResult> EditEvent(EventsEditViewModel eventEditViewModel, string eventId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(eventEditViewModel);
            }

            var eventToEdit = this.eventsRepository.AllWithDeleted().Where(n => n.Id == eventEditViewModel.Id).FirstOrDefault();

            await this.eventsService.EditEvent(eventEditViewModel, eventToEdit);

            return this.Redirect($"/Events/EventById?eventId={eventId}");
        }

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
