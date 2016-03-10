using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OredersTracker.Web.Areas.Administration.ViewModels
{
    public class IncomeViewModel
    {
        public decimal TotalForMonth { get; set; }

        public decimal TotalForKornelia { get; set; }

        public decimal TotalForMitko { get; set; }

        public decimal TotalForNikola { get; set; }

        public decimal TotalForStaiko { get; set; }
    }
}