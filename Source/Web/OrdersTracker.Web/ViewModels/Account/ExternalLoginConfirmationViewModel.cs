namespace OrdersTracker.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using OrdersTracker.Web.App_GlobalResources.Users;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(UserInfo))]
        public string Email { get; set; }
    }
}