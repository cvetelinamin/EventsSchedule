namespace EventsSchedule.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<Blog> newsRepository;

        public NewsService(IDeletableEntityRepository<Blog> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<string> CreateAsync(string title, string content, string userId)
        {
            var blog = new Blog
            {
                ApplicationUserId = userId,
                Title = title,
                Content = content,
            };

            await this.newsRepository.AddAsync(blog);
            await this.newsRepository.SaveChangesAsync();

            return blog.Id;
        }

        public T GetById<T>(string id)
        {
            var newsDetails = this.newsRepository.AllAsNoTracking().Where(x => x.Id == id)
           .To<T>().FirstOrDefault();

            return newsDetails;
        }

        public int CountNews()
        {
            return this.newsRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>(int? take = null, int skip = 0)
        {
            var query = this.newsRepository.All()
                            .OrderByDescending(e => e.CreatedOn)
                            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
