namespace EventsSchedule.Services.Data
{
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

    public interface IAddressesService
    {
        Task<Address> CreateAddress(string cityId, string street, string additionalInformation);
    }
}
