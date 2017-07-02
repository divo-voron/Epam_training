﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.DTO
{
    public class PriceHistoryDto
    {
        public int ID { get; set; }
        public int Product_ID { get; set; }
        public System.DateTime Date { get; set; }
        public int Price { get; set; }
        public ProductDto Product { get; set; }
    }
}