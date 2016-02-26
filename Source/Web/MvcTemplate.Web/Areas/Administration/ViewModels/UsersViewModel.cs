namespace MvcTemplate.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using App_GlobalResources.Users;

    public class UsersViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings,IMapTo<ApplicationUser>
    {
        public string Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(UserInfo))]
        public string AuthorName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(UserInfo))]
        public string Email { get; set; }
        
        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UsersViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));
        }
    }
}