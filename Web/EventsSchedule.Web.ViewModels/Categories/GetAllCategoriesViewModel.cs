namespace EventsSchedule.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetAllCategoriesVIewModel
    {
        public IQueryable<CategoriesViewModel> Categories { get; set; }
    }
}
