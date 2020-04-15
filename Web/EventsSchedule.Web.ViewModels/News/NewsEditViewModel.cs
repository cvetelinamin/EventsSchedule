namespace EventsSchedule.Web.ViewModels.News
{
    using AutoMapper;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class NewsEditViewModel : IMapTo<Blog>, IMapFrom<Blog>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile Image { get; set; }

        public string ApplicationUserId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Blog, NewsEditViewModel>()
                .ForMember(destination => destination.Image, opts => opts.Ignore());
        }
    }
}
