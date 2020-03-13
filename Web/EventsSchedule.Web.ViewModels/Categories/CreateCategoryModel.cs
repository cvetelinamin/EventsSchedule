namespace EventsSchedule.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class CreateCategoryModel : IMapTo<EventCategory>, IMapFrom<EventCategory>
    {
        public string Name { get; set; }
    }
}
