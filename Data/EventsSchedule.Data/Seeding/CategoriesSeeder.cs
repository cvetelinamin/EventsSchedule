namespace EventsSchedule.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using Microsoft.Extensions.DependencyInjection;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.EventCategories.Any())
            {
                return;
            }

            var categoryTitles = new string[]
            {
                "Концерти",
                "Култура",
                "Спорт",
                "Семейство",
                "Парти",
                "Други",
            };

            foreach (var title in categoryTitles)
            {
                await dbContext.EventCategories.AddAsync(new EventCategory { Name = title });
            }
        }
    }
}
