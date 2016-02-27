namespace MvcTemplate.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    using Client = MvcTemplate.Web.App_GlobalResources.Clients.Client;

    public class OrdersViewModel : IMapTo<Order>, IMapFrom<Order>, IHaveCustomMappings
    {
        [UIHint("Id")]
        public int Id { get; set; }

        [UIHint("DateDisabled")]
        [Display(Name = "Deadline", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime CreatedOn { get; set; }

        [AllowHtml]
        [UIHint("StringDisabled")]
        [Display(Name = "Creator", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public string Creator { get; set; }

        [AllowHtml]
        [Display(Name = "ClientEIK", ResourceType = typeof(Client))]
        public string ClientEIK { get; set; }

        [MaxLength(500)]
        [Display(Name = "Description", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Deadline", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime? Deadline { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "OrderPrice", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal OrderPrice { get; set; }

        [AllowHtml]
        [Display(Name = "PaidInAdvance", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidInAdvance { get; set; }

        [AllowHtml]
        [Display(Name = "BillInCash", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal BillInCash { get; set; }

        [Display(Name = "Receipt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        [AllowHtml]
        public decimal Receipt { get; set; }

        [AllowHtml]
        [Display(Name = "PaidWithCard", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidWithCard { get; set; }

        [AllowHtml]
        [Display(Name = "Econt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal Econt { get; set; }

        [AllowHtml]
        [Display(Name = "PaidInCashWithouotReceipt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidInCashWithoutReceipt { get; set; }

        [AllowHtml]
        [Display(Name = "PaidBankTransaction", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal PaidBankTransaction { get; set; }

        [AllowHtml]
        [Display(Name = "LeftToBePaid", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal LeftToBePaid { get; set; }

        [Display(Name = "PaidAt", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime? PaidAt { get; set; }

        [Display(Name = "DateOfComplition", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime? DateOfComplition { get; set; }

        [AllowHtml]
        [Display(Name = "Bonuses", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public decimal Bonuses { get; set; }

        [Display(Name = "IsComplited", ResourceType = typeof(App_GlobalResources.Orders.Order))]
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