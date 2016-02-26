namespace MvcTemplate.Web.ViewModels.Client
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class ClientViewModel : IMapTo<Client>
    {
        public int Id { get; set; }

        [MaxLength(9)]
        [MinLength(9)]
        [Required]
        [AllowHtml]
        [UIHint("FormString")]
        public string EIK { get; set; }

        [MaxLength(70)]
        [MinLength(2)]
        [AllowHtml]
        [Required]
        [UIHint("FormString")]
        public string Name { get; set; }

        [MaxLength(100)]
        [AllowHtml]
        [UIHint("FormMultiline")]
        public string Address { get; set; }
    }
}