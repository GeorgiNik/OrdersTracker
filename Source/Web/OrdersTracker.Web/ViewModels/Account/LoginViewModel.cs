namespace OrdersTracker.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using OrdersTracker.Web.App_GlobalResources.Users;

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username", ResourceType = typeof(UserInfo))]
        [MaxLength(70)]
        [MinLength(2)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(UserInfo))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(UserInfo))]
        public bool RememberMe { get; set; }
    }
}