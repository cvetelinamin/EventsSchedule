namespace EventsSchedule.Services.Data
{
    public interface IAddressesService
    {
        T GetById<T>(string id);
    }
}
