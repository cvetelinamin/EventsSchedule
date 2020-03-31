namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("/Administration/Categories/Create")]
        public IActionResult Create()
        {
            return this.View("Create");
        }

        [HttpPost("/Administration/ParentCategories/Create")]
        public IActionResult Create(CreateCategoryInputModel categoriesInputModel)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.RedirectToAction("All");
        }
    }
}
