using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public IEnumerable<string> Roles { get; set; }
    }
    public class UserCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public IEnumerable<string> Roles { get; set; }
    }
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
    public class ItemsList
    {
        public System.Web.Mvc.SelectList Clients { get; set; }
        public System.Web.Mvc.SelectList Managers { get; set; }
        public System.Web.Mvc.SelectList Products { get; set; }
        public System.Web.Mvc.SelectList PriceHistories { get; set; }
        public System.Web.Mvc.SelectList Sessions { get; set; }

    }
    public class IndexViewModelPagination
    {
        public IEnumerable<Manager> ManagersPerPages { get; set; }
        public IEnumerable<Operation> OperationsPerPages { get; set; }
        public PageInfo PageInfo { get; set; }
        public ItemsList ItemsList { get; set; }
    }
    public class OperationCreateEdit
    {
        public Operation Operation { get; set; }
        public ItemsList ItemsList { get; set; }
    }

    #region Standart models
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
    #endregion
}