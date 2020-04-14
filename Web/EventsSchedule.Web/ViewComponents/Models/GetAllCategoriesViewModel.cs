namespace EventsSchedule.Web.ViewComponents.Models
{
    using System.Collections.Generic;

    public class GetAllCategoriesViewModel
    {
        public IEnumerable<CategoriesViewModel> Categories { get; set; }
    }
}
