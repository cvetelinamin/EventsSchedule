namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private const string InvalidCategoryTitleErrorMessage = "Category with Title: {0} does not exist.";

        private readonly IDeletableEntityRepository<EventCategory> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<EventCategory> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateAllAsync(string[] categoryTitles)
        {
            foreach (var categoryTitle in categoryTitles)
            {
                var category = new EventCategory
                {
                    Name = categoryTitle,
                };

                await this.categoryRepository.AddAsync(category);
            }

            var result = await this.categoryRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<EventCategory> CreateAsync(string name)
        {
            var category = new EventCategory
            {
                Name = name,
            };

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();

            return category;
        }

        public ICollection<EventCategory> GetAll()
        {
            return this.categoryRepository
                .AllAsNoTracking()
                .ToList();
        }

        public async Task<IEnumerable<string>> GetAllTitlesAsync()
        {
            return await this.categoryRepository
                .AllAsNoTracking()
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<string> GetIdByTitleAsync(string categoryTitle)
        {
            var category = await this.categoryRepository
                .AllAsNoTracking()
                .SingleOrDefaultAsync(x => x.Name == categoryTitle);

            if (category == null)
            {
                throw new ArgumentNullException(
                    string.Format(InvalidCategoryTitleErrorMessage, categoryTitle));
            }

            return category.Id;
        }
    }
}
