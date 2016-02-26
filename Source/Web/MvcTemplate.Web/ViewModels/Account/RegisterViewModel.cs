namespace MvcTemplate.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using MvcTemplate.Web.App_GlobalResources.Errors;
    using MvcTemplate.Web.App_GlobalResources.Users;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name", ResourceType = typeof(UserInfo))]
        [MaxLength(70)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Username", ResourceType = typeof(UserInfo))]
        [MaxLength(70)]
        [MinLength(2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(UserInfo))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "InvalidLenght", ErrorMessageResourceType = typeof(Error), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(UserInfo))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(UserInfo))]
        [Compare("Password", ErrorMessageResourceName = "PasswordNotMatch", ErrorMessageResourceType = typeof(Error))]
        public string ConfirmPassword { get; set; }
    }
}