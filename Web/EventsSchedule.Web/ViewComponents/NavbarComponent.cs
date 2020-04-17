namespace UniShop.Web.Components
{
    using System.Collections.Generic;
    using System.Linq;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "Navbar")]
    public class NavbarComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<EventCategory> categoriesRepository;

        public NavbarComponent(IDeletableEntityRepository<EventCategory> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = this.categoriesRepository.AllAsNoTracking().Select(c => new CategoriesViewModel
            {
                Id = c.Id,
                Name = c.Name,
            })
                .ToList();

            if (categories.Count() == 0)
            {
                return this.View(new List<CategoriesViewModel>());
            }

            return this.View(categories);
        }
    }
}
