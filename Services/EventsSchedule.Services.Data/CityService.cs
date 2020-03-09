namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventsSchedule.Data.Models;

    public class CityService : ICityService
    {
        public City CreateCity(string name)
        {
            var city = new City
            {
                Name = name,
            };

            return city;
        }
    }
}
