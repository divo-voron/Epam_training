using System;
using System.Collections.Generic;

namespace Sales.Model.Models
{
    public partial class Product
    {
        public Product()
        {
            this.Operations = new List<Operation>();
            this.PriceHistories = new List<PriceHistory>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<PriceHistory> PriceHistories { get; set; }
    }
}
