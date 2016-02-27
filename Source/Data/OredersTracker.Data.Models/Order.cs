namespace OredersTracker.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OredersTracker.Data.Common.Models;

    public class Order : BaseModel<int>
    {
        public Order()
        {
            if (this.DateOfComplition != null)
            {
                this.IsComplited = true;
            }
        }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

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
    }
}