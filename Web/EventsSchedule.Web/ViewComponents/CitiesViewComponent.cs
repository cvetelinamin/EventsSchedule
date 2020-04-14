namespace EventsSchedule.Web.ViewComponents
{
    using System.Linq;
    using System.Threading.Tasks;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewComponents.Models;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "Cities")]
    public class CitiesViewComponent : ViewComponent
    {
        private readonly ICityService cityService;
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesViewComponent(ICityService cityService, IDeletableEntityRepository<City> citiesRepository)
        {
            this.cityService = cityService;
            this.citiesRepository = citiesRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new GetAllCitiesViewModel();
            viewModel.Cities = this.citiesRepository.AllAsNoTracking()
                                .Select(x => new CitiesViewModel
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                });

            return this.View(viewModel);
        }
    }
}
