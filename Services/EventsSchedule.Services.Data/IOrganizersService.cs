namespace EventsSchedule.Services.Data
{
    using EventsSchedule.Data.Models;

    public interface IOrganizersService
    {
        Organizer CreateOrganizer(string name, string contactName, string webSite, string description);

        T GetById<T>(string id);
    }
}
