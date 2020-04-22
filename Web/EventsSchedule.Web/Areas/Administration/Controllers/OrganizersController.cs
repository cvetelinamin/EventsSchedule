namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Organizers;
    using Microsoft.AspNetCore.Mvc;

    public class OrganizersController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Organizer> organizersRepository;
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly IOrganizersService organizersService;

        public OrganizersController(IDeletableEntityRepository<Organizer> organizersRepository, IDeletableEntityRepository<Event> eventsRepository, IOrganizersService organizersService)
        {
            this.organizersRepository = organizersRepository;
            this.eventsRepository = eventsRepository;
            this.organizersService = organizersService;
        }

        [HttpGet("/Administration/Organizers/EditOrganizer")]
        public async Task<IActionResult> EditOrganizer(string eventId, string organizerId)
        {
            var eventToChange = this.eventsRepository.AllAsNoTracking().Where(e => e.Id == eventId).FirstOrDefault();

            if (eventToChange.OrganizerId != organizerId)
            {
                return this.NotFound();
            }

            var organizerViewModel = this.organizersService.GetById<OrganizerEditModel>(organizerId);

            if (organizerViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(organizerViewModel);
        }

        [HttpPost("/Administration/Organizers/EditOrganizer")]
        public async Task<IActionResult> EditOrganizer(OrganizerEditModel organizerEditModel, string eventId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(organizerEditModel);
            }

            var organizerToChange = this.organizersRepository.AllWithDeleted().Where(n => n.Id == organizerEditModel.Id).FirstOrDefault();

            organizerToChange.ContactName = organizerEditModel.ContactName;
            organizerToChange.Description = organizerEditModel.Description;
            organizerToChange.ModifiedOn = DateTime.UtcNow;
            organizerToChange.Name = organizerEditModel.Name;
            organizerToChange.WebSite = organizerEditModel.WebSite;

            this.organizersRepository.Update(organizerToChange);
            await this.organizersRepository.SaveChangesAsync();

            return this.RedirectToAction("EventById", "Еvents", new { eventId, Area = "User" });
        }
    }
}
