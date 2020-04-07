namespace EventsSchedule.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

    public interface ICategoriesService
    {
        Task<bool> CreateAllAsync(string[] titles);

        Task<IEnumerable<string>> GetAllTitlesAsync();

        // Task<CreateCategoryModel> GetByIdAsync(int id);

        Task<EventCategory> CreateAsync(string name);

       // Task<bool> EditAsync(CreateCategoryModel categoryServiceModel);

        // Task<bool> DeleteByIdAsync(int id);

        // Task SetCategoryToRecipeAsync(string categoryTitle, Recipe recipe);

        // IQueryable<CreateCategoryModel> GetAll();

        Task<string> GetIdByTitleAsync(string categoryTitle);
    }
}
