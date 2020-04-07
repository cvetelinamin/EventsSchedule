namespace EventsSchedule.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewComponents.Models;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "Categories")]
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoryService;

        public CategoriesViewComponent(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CategoriesViewModel();
            viewModel.Categories = await this.categoryService.GetAllTitlesAsync();
            return this.View(viewModel);
        }
    }
}
