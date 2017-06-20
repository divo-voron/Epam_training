using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Model
{
    public class Operation
    {
        public int ID { get; set; }
        public DateTime DateOfOperation { get; set; }
        public int Manager_ID { get; set; }
        public int Client_ID { get; set; }
        public int Product_ID { get; set; }
        public int PriceHistory_ID { get; set; }
        public int Session_ID { get; set; }


        public Client Client { get; set; }
        public Manager Manager { get; set; }
        public PriceHistory PriceHistory { get; set; }
        public Product Product { get; set; }
        public Session Session { get; set; }
    }
}
