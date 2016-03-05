namespace OredersTracker.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using OredersTracker.Data.Models;
    using OredersTracker.Web.Infrastructure.Mapping;

    using Client = OredersTracker.Web.App_GlobalResources.Clients.Client;

    public class OrdersViewModel : IMapTo<Order>, IMapFrom<Order>, IHaveCustomMappings
    {
        [UIHint("Id")]
        [Display(Name = "Id", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public int Id { get; set; }

        [UIHint("DateDisabled")]
        [Display(Name = "CreatedOn", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public DateTime CreatedOn { get; set; }

        [AllowHtml]
        [UIHint("StringDisabled")]
        [Display(Name = "Creator", ResourceType = typeof(App_GlobalResources.Orders.Order))]
        public string Creator { get; set; }

        [AllowHtml]
        [Display(Name = "Name", ResourceType = typeof(Client))]
        public string ClientName { get; set; }

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
                .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client.Name));
            configuration.CreateMap<Order, OrdersViewModel>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));
        }
    }
}