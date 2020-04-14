namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        // GET: Administration/Categories
        public async Task<IActionResult> Index()
        {
            return this.View(await this.dbContext.EventCategories.ToListAsync());
        }

        // GET: Administration/Categories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var eventCategory = await this.dbContext.EventCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventCategory == null)
            {
                return this.NotFound();
            }

            return this.View(eventCategory);
        }

        // GET: Administration/Categories/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] EventCategory eventCategory)
        {
            if (eventCategory.Name.Length < 5)
            {
                return this.View(eventCategory);
            }

            if (this.ModelState.IsValid)
            {
                this.dbContext.Add(eventCategory);
                await this.dbContext.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(eventCategory);
        }

        // GET: Administration/Categories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var eventCategory = await this.dbContext.EventCategories.FindAsync(id);
            if (eventCategory == null)
            {
                return this.NotFound();
            }

            return this.View(eventCategory);
        }

        // POST: Administration/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] EventCategory eventCategory)
        {
            if (id != eventCategory.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dbContext.Update(eventCategory);
                    await this.dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.EventCategoryExists(eventCategory.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(eventCategory);
        }

        // GET: Administration/Categories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var eventCategory = await this.dbContext.EventCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventCategory == null)
            {
                return this.NotFound();
            }

            return this.View(eventCategory);
        }

        // POST: Administration/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var eventCategory = await this.dbContext.EventCategories.FindAsync(id);
            this.dbContext.EventCategories.Remove(eventCategory);
            await this.dbContext.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool EventCategoryExists(string id)
        {
            return this.dbContext.EventCategories.Any(e => e.Id == id);
        }
    }
}
