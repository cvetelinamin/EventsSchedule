namespace EventsSchedule.Web.ViewModels.Categories
{
    using System.Linq;

    public class GetAllCategoriesVIewModel
    {
        public IQueryable<CategoriesViewModel> Categories { get; set; }
    }
}
