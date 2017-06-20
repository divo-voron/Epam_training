using System;
using System.Collections.Generic;

namespace Sales.Model.Models
{
    public partial class PriceHistory
    {
        public PriceHistory()
        {
            this.Operations = new List<Operation>();
        }

        public int ID { get; set; }
        public int Product_ID { get; set; }
        public System.DateTime Date { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual Product Product { get; set; }
    }
}
