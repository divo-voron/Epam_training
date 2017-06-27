using System;
using System.Collections.Generic;

namespace Sales.Model.Models
{
    public partial class Operation
    {
        public int ID { get; set; }
        public System.DateTime DateOfOperation { get; set; }
        public int Manager_ID { get; set; }
        public int Client_ID { get; set; }
        public int Product_ID { get; set; }
        public int PriceHistory_ID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual PriceHistory PriceHistory { get; set; }
        public virtual Product Product { get; set; }
    }
}
