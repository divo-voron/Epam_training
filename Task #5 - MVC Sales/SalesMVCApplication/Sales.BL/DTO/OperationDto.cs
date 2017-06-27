using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.DTO
{
    public class OperationDto
    {
        public int ID { get; set; }
        public DateTime DateOfOperation { get; set; }
        public int Manager_ID { get; set; }
        public int Client_ID { get; set; }
        public int Product_ID { get; set; }
        public int PriceHistory_ID { get; set; }
        public int Session_ID { get; set; }


        public ClientDto Client { get; set; }
        public ManagerDto Manager { get; set; }
        public PriceHistoryDto PriceHistory { get; set; }
        public ProductDto Product { get; set; }
    }
}
