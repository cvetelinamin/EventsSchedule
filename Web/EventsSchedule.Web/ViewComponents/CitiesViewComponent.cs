namespace EventsSchedule.Web.ViewComponents
{
    using System.Threading.Tasks;

    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewComponents.Models;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "Cities")]
    public class CitiesViewComponent : ViewComponent
    {
        private readonly ICityService cityService;

        public CitiesViewComponent(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CitiesViewModel();
            viewModel.Cities = await this.cityService.GetAllCitiesAsync();
            return this.View(viewModel);
        }
    }
}
