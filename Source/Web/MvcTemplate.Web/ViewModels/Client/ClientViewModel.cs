namespace MvcTemplate.Web.ViewModels.Client
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;
    public class ClientViewModel:IMapFrom<Client>
    {
        public int Id { get; set; }

        [MaxLength(9)]
        public string EIK { get; set; }

        [MaxLength(70)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        
    }
}