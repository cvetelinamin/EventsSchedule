namespace EventsSchedule.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Web.ViewModels.Categories;

    public interface ICategoryService
    {
        Task<bool> CreateAllAsync(string[] titles);

        Task<IEnumerable<string>> GetAllTitlesAsync();

       // Task<CreateCategoryModel> GetByIdAsync(int id);

       // Task<bool> CreateAsync(CreateCategoryModel categoryServiceModel);

       // Task<bool> EditAsync(CreateCategoryModel categoryServiceModel);

       // Task<bool> DeleteByIdAsync(int id);

       // Task SetCategoryToRecipeAsync(string categoryTitle, Recipe recipe);

        // IQueryable<CreateCategoryModel> GetAll();

        Task<string> GetIdByTitleAsync(string categoryTitle);
    }
}
