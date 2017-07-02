using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Models.Visualization
{
    public class PriceHistoryChartData
    {
        public int Product_ID { get; set; }
        public System.Web.Mvc.SelectList Products { get; set; }
    }
}