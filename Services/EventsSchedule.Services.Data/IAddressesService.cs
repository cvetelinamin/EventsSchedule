namespace EventsSchedule.Services.Data
{
    using EventsSchedule.Data.Models;

    public interface IAddressesService
    {
        Address CreateAddress(string cityId, string street, string additionalInformation);

        T GetById<T>(string id);
    }
}
