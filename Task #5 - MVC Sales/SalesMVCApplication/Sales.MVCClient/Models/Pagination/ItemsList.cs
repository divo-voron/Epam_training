using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Models.Pagination
{
    public class ItemsList
    {
        public System.Web.Mvc.SelectList Clients { get; set; }
        public System.Web.Mvc.SelectList Managers { get; set; }
        public System.Web.Mvc.SelectList Products { get; set; }
        public System.Web.Mvc.SelectList PriceHistories { get; set; }
        public System.Web.Mvc.SelectList Sessions { get; set; }
    }
}