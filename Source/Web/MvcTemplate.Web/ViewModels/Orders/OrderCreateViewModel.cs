namespace MvcTemplate.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class OrderCreateViewModel : IMapFrom<Order>,IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

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

        public string ClientName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderCreateViewModel>()
             .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client.Name));
        }
    }
}