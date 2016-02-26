namespace MvcTemplate.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel;
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
        [DisplayName("Дата")]
        public DateTime CreatedOn { get; set; }

        [AllowHtml]
        [UIHint("StringDisabled")]
        [DisplayName("Дизайнер")]
        public string Creator { get; set; }

        [AllowHtml]
        [DisplayName("клиент ЕИК")]
        public string ClientEIK { get; set; }

        [MaxLength(500)]
        [DisplayName("Описание")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("Краен срок")]
        public DateTime? Deadline { get; set; }

        [AllowHtml]
        [Required]
        [DisplayName("Стойност на поръчката")]
        public decimal OrderPrice { get; set; }

        [AllowHtml]
        [DisplayName("Платен аванс")]
        public decimal PaidInAdvance { get; set; }

        [AllowHtml]
        [DisplayName("Фактура в брой")]
        public decimal BillInCash { get; set; }

        [AllowHtml]
        [DisplayName("Касова бележка")]
        public decimal Receipt { get; set; }

        [AllowHtml]
        [DisplayName("Платено с карта")]
        public decimal PaidWithCard { get; set; }

        [AllowHtml]
        [DisplayName("С еконт")]
        public decimal Econt { get; set; }

        [AllowHtml]
        [DisplayName("В брой без документ")]
        public decimal PaidInCashWithoutReceipt { get; set; }

        [AllowHtml]
        [DisplayName("Фактура по банка")]
        public decimal PaidBankTransaction { get; set; }

        [AllowHtml]
        [DisplayName("Доплащане")]
        public decimal LeftToBePaid { get; set; }

        [DisplayName("Платено на")]
        public DateTime? PaidAt { get; set; }

        [DisplayName("Изпълнена дата")]
        public DateTime? DateOfComplition { get; set; }

        [AllowHtml]
        [DisplayName("Бонуси")]
        public decimal Bonuses { get; set; }

        [DisplayName("Завършена")]
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