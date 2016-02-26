namespace MvcTemplate.Web.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    using MvcTemplate.Web.App_GlobalResources.Errors;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "InvalidLenght", ErrorMessageResourceType = typeof(Error), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessageResourceName = "PasswordNotMatch", ErrorMessageResourceType = typeof(Error))]
        public string ConfirmPassword { get; set; }
    }
}