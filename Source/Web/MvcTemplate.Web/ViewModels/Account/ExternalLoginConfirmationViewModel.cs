namespace MvcTemplate.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using MvcTemplate.Web.App_GlobalResources.Users;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(UserInfo))]
        public string Email { get; set; }
    }
}