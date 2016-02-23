namespace MvcTemplate.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class OrderCreateViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTime? Deadline { get; set; }

        [StringLength(500)]
        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [AllowHtml]
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

        [AllowHtml]
        public string ClientName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderCreateViewModel>()
                .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client.Name));
        }
    }
}