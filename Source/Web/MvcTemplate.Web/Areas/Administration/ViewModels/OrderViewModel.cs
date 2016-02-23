using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;
    public class OrderViewModel:IMapFrom<Order>,IHaveCustomMappings
    {

        public string Creator { get; set; }

        public string ClientEIK { get; set; }

        public DateTime? Deadline { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal OrderPrice { get; set; }

        public decimal PaidInAdvance { get; set; }

        public decimal BillInCash { get; set; }

        public decimal Receipt { get; set; }

        public decimal PaidWithCard { get; set; }

        public decimal Econt { get; set; }

        public decimal PaidInCashWithoutReceipt { get; set; }

        public decimal PaidBankTransaction { get; set; }

        public decimal LeftToBePaid { get; set; }

        public DateTime? PaidAt { get; set; }

        public DateTime? DateOfComplition { get; set; }

        public decimal Bonuses { get; set; }

        public bool IsComplited { get; set; }
        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderViewModel>()
              .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Author.AuthorName));
            configuration.CreateMap<Order, OrderViewModel>()
              .ForMember(x => x.ClientEIK, opt => opt.MapFrom(x => x.Client.EIK));
        }
    }
}