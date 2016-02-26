namespace MvcTemplate.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel;
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
        [DisplayName("Краен срок")]
        public DateTime? Deadline { get; set; }

        [StringLength(500)]
        [AllowHtml]
        [UIHint("FormString")]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [Required]
        [AllowHtml]
        [DisplayName("Стойност на поръчката")]
        public decimal OrderPrice { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("Платен аванс")]
        public decimal PaidInAdvance { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("Фактура в брой")]
        public decimal BillInCash { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("Касова бележка")]
        public decimal Receipt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("Платено с карта")]
        public decimal PaidWithCard { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("С еконт")]
        public decimal Econt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("В брой без документ")]
        public decimal PaidInCashWithoutReceipt { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("Фактура по банка")]
        public decimal PaidBankTransaction { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("Доплащане")]
        public decimal LeftToBePaid { get; set; }

        [UIHint("FormDateTime")]
        [DisplayName("Платено на")]
        public DateTime? PaidAt { get; set; }

        [UIHint("FormDateTime")]
        [DisplayName("Изпълнена дата")]
        public DateTime? DateOfComplition { get; set; }

        [AllowHtml]
        [UIHint("FormDecimal")]
        [DisplayName("Бонуси")]
        public decimal Bonuses { get; set; }

        [AllowHtml]
        [DisplayName("Име на клиент")]
        public string ClientName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderCreateViewModel>()
                .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.Client.Name));
        }
    }
}