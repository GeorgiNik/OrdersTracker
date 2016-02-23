namespace MvcTemplate.Web.ViewModels.Orders
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Glimpse.AspNet.Controls;

    public class OrderCreatePageViewModel
    {
        public IEnumerable<SelectListItem> Clients { get; set; }

        public OrderCreateViewModel OrdersCreate { get; set; }
    }
}