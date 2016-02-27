namespace OrdersTracker.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using OrdersTracker.Data.Models;
    using OrdersTracker.Web.Infrastructure.Mapping;

    using Client = OrdersTracker.Web.App_GlobalResources.Clients.Client;

    public class OrderCreateViewModel : IMapTo<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [UIHint("FormDateTime")]
        [Display(Name = "Deadline", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime? Deadline { get; set; }

        [StringLength(500)]
        [AllowHtml]
        [UIHint("FormString")]
        [Display(Name = "Description", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public string Description { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("FormString")]
        [Display(Name = "OrderPrice", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal OrderPrice { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "PaidInAdvance", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidInAdvance { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "BillInCash", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal BillInCash { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "Receipt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal Receipt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "PaidWithCard", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidWithCard { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "Econt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal Econt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "PaidInCashWithouotReceipt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidInCashWithoutReceipt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "PaidBankTransaction", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidBankTransaction { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "LeftToBePaid", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal LeftToBePaid { get; set; }

        [UIHint("FormDateTime")]
        [Display(Name = "PaidAt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime? PaidAt { get; set; }

        [UIHint("FormDateTime")]
        [Display(Name = "DateOfComplition", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime? DateOfComplition { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [Display(Name = "Bonuses", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal Bonuses { get; set; }

        [AllowHtml]
        [Display(Name = "Name", ResourceType = typeof(Client))]
        public string ClientName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderCreateViewModel>()
                .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client.Name));
        }
    }
}