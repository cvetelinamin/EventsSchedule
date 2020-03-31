namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;

    public class BlogsService : IBlogsService
    {
        private readonly IDeletableEntityRepository<Blog> blogRepository;

        public BlogsService(IDeletableEntityRepository<Blog> blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<string> CreateAsync(string title, string content, string userId)
        {
            var blog = new Blog
            {
                ApplicationUserId = userId,
                Title = title,
                Content = content,
            };

            await this.blogRepository.AddAsync(blog);
            await this.blogRepository.SaveChangesAsync();

            return blog.Id;
        }
    }
}
