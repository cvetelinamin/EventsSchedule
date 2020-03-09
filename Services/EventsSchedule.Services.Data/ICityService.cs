namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventsSchedule.Data.Models;

    public interface ICityService
    {
        City CreateCity(string name);
    }
}
