using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModelPagination
    {
        public IEnumerable<Manager> Managers { get; set; }
        public IEnumerable<Operation> Operations { get; set; }
        public PageInfo PageInfo { get; set; }
        public Manager Manager { get; set; }
    }
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Manager
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class PriceHistory
    {
        public int ID { get; set; }
        public int Product_ID { get; set; }
        public System.DateTime Date { get; set; }
        public int Price { get; set; }
    }
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Session
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
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