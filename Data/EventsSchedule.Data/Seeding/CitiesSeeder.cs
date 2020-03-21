namespace EventsSchedule.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var citiesNames = new string[]
            {
                "София",
                "Варна",
                "Пловдив",
                "Бургас",
                "Русе",
                "Добрич",
                "Благоевград",
                "Враца",
                "Велико Търново",
                "Монтана",
                "Видин",
                "Плевен",
                "Ямбол",
                "Габрово",
                "Кърджали",
                "Кюстендил",
                "Ловеч",
                "Пазарджик",
                "Перник",
                "Разград",
                "Силистра",
                "Сливен",
                "Смолян",
            };

            foreach (var name in citiesNames)
            {
                await dbContext.Cities.AddAsync(new City { Name = name });
            }
        }
    }
}
