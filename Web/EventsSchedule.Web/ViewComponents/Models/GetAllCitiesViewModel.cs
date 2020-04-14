namespace EventsSchedule.Web.ViewComponents.Models
{
    using System.Collections.Generic;

    public class GetAllCitiesViewModel
    {
        public IEnumerable<CitiesViewModel> Cities { get; set; }
    }
}
