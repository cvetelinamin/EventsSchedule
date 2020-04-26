namespace EventsSchedule.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class NewsEditViewModel : IMapTo<News>, IMapFrom<News>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [StringLength(AttributesConstraints.NewsTitleMaxLenght, MinimumLength = AttributesConstraints.NewsTitleMinLenght)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [StringLength(AttributesConstraints.NewsContentMaxLenght, MinimumLength = AttributesConstraints.NewsContentMinLenght)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        public IFormFile Image { get; set; }

        public string ApplicationUserId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<News, NewsEditViewModel>()
                .ForMember(destination => destination.Image, opts => opts.Ignore());
        }
    }
}
