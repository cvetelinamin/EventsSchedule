namespace EventsSchedule.Services.Data
{
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

    public interface IAddressesService
    {
        Task<Address> CreateAddress(City city, string street, string additionalInformation);
    }
}
