namespace MvcTemplate.Web.ViewModels.Client
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class ClientViewModel : IMapFrom<Client>
    {
        public int Id { get; set; }

        [MaxLength(9)]
        [MinLength(9)]
        [Required]
        [AllowHtml]
        public string EIK { get; set; }

        [MaxLength(70)]
        [MinLength(2)]
        [AllowHtml]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [AllowHtml]
        public string Address { get; set; }
    }
}