namespace MvcTemplate.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class OrderCreateViewModel : IMapTo<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [UIHint("FormDateTime")]
        public DateTime? Deadline { get; set; }

        [StringLength(500)]
        [AllowHtml]
        [UIHint("FormString")]
        public string Description { get; set; }

        [Required]
        [AllowHtml]
        public decimal OrderPrice { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal PaidInAdvance { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal BillInCash { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal Receipt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal PaidWithCard { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal Econt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal PaidInCashWithoutReceipt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal PaidBankTransaction { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal LeftToBePaid { get; set; }

        [UIHint("FormDateTime")]
        public DateTime? PaidAt { get; set; }

        [UIHint("FormDateTime")]
        public DateTime? DateOfComplition { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        public decimal Bonuses { get; set; }

        [AllowHtml]
        public string ClientName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderCreateViewModel>()
                .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client.Name));
        }
    }
}