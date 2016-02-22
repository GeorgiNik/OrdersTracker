﻿namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MvcTemplate.Data.Common.Models;

    public class Client : BaseModel<int>
    {
        private ICollection<Order> orders; 
        public Client()
        {
            this.orders=new HashSet<Order>();
        }
        
        [StringLength(9)]
        [Required]
        public string EIK { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public ICollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }
    }
}