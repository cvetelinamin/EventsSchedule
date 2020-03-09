﻿namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Events;
    using EventsSchedule.Web.ViewModels.Organizers;

    public class OrganizersService : IOrganizersService
    {
        public Organizer CreateOrganizer(OrganizerInputModel model)
        {
            var organizer = new Organizer
            {
                 Name = model.Name,
                 ContactName = model.ContactName,
                 WebSite = model.WebSite,
                 Description = model.Description,
            };

            return organizer;
        }
    }
}
