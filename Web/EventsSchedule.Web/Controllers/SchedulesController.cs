namespace EventsSchedule.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SchedulesController : Controller
    {
        private readonly IDeletableEntityRepository<Event> eventRepository;

        public SchedulesController(IDeletableEntityRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        [Authorize]
        public async Task<IActionResult> Schedule()
        {
            var viewModel = new ListTopEvents
            {
                TopEvents = this.eventRepository.AllAsNoTracking()
                                .OrderByDescending(e => e.CreatedOn)
                                .Take(6)
                                .To<TopEventViewModel>()
                .ToList(),
            };

            return this.View(viewModel);
        }
    }
}
