namespace EventsSchedule.Web.ViewModels.Events
{
    using EventsSchedule.Web.ViewModels.Organizers;

    public class CreateEventInputModel
    {
        public EventInputModel EventInputModel { get; set; }

        public OrganizerInputModel OrganizerInputModel { get; set; }

        public AdressInputModel AdressInputModel { get; set; }
    }
}
