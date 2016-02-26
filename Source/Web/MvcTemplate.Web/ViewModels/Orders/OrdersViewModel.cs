namespace MvcTemplate.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class OrdersViewModel : IMapTo<Order>, IMapFrom<Order>, IHaveCustomMappings
    {
        [UIHint("Id")]
        public int Id { get; set; }
        
        [UIHint("DateDisabled")]
        public DateTime CreatedOn { get; set; }

        [AllowHtml]
        [UIHint("StringDisabled")]
        public string Creator { get; set; }

        [AllowHtml]
        public string ClientEIK { get; set; }

        [MaxLength(500)]
        [AllowHtml]
        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        [AllowHtml]
        [Required]
        public decimal OrderPrice { get; set; }

        [AllowHtml]
        public decimal PaidInAdvance { get; set; }

        [AllowHtml]
        public decimal BillInCash { get; set; }

        [AllowHtml]
        public decimal Receipt { get; set; }

        [AllowHtml]
        public decimal PaidWithCard { get; set; }

        [AllowHtml]
        public decimal Econt { get; set; }

        [AllowHtml]
        public decimal PaidInCashWithoutReceipt { get; set; }

        [AllowHtml]
        public decimal PaidBankTransaction { get; set; }

        [AllowHtml]
        public decimal LeftToBePaid { get; set; }

        public DateTime? PaidAt { get; set; }

        public DateTime? DateOfComplition { get; set; }

        [AllowHtml]
        public decimal Bonuses { get; set; }

        public bool IsComplited { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrdersViewModel>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Author.AuthorName));
            configuration.CreateMap<Order, OrdersViewModel>()
                .ForMember(x => x.ClientEIK, opt => opt.MapFrom(x => x.Client.EIK));
            configuration.CreateMap<Order, OrdersViewModel>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));
            
        }
    }
}