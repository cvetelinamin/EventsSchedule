namespace EventsSchedule.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

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
                "Театър",
                "Фестивали",
                "Конференции",
                "Концерти",
                "Спорт",
                "Семейство",
            };

            foreach (var title in categoryTitles)
            {
                if (title.Length >= 3 && title.Length <= 100)
                {
                    await dbContext.EventCategories.AddAsync(new EventCategory { Name = title });
                }
            }
        }
    }
}
