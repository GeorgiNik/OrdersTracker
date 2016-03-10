namespace OredersTracker.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OredersTracker.Data.Common.Models;

    public class Client : BaseModel<int>
    {
        public Client()
        {
            this.Orders = new HashSet<Order>();
        }

        [MaxLength(9)]
        public string EIK { get; set; }

        [MaxLength(70)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(15)]
        [Phone]
        public string Telephone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}