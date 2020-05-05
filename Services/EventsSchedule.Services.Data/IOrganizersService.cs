namespace EventsSchedule.Services.Data
{
    public interface IOrganizersService
    {
        T GetById<T>(string id);
    }
}
