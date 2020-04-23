namespace EventsSchedule.Web.ViewComponents
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewComponents.Models;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "Categories")]
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoryService;
        private readonly IDeletableEntityRepository<EventCategory> categoriesRepository;

        public CategoriesViewComponent(ICategoriesService categoryService, IDeletableEntityRepository<EventCategory> categoriesRepository)
        {
            this.categoryService = categoryService;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new GetAllCategoriesViewModel();
            viewModel.Categories = this.categoriesRepository.AllAsNoTracking().Select(x => new CategoriesViewModel
            {
                Id = x.Id,
                Name = x.Name,
            });

            return this.View(viewModel);
        }
    }
}
