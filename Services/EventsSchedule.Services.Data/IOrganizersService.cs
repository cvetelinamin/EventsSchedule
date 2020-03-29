namespace EventsSchedule.Services.Data
{
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

    public interface IOrganizersService
    {
        Task<Organizer> CreateOrganizer(string name, string contactName, string webSite, string description);
    }
}
