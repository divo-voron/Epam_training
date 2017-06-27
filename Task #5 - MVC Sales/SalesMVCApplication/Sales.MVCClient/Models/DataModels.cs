using Sales.MVCClient.Helper;
using Sales.MVCClient.Models.Pagination;
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

        [Display(Name = MagicString.DisplayUserName)]
        [Required]
        public string Name { get; set; }

        [Display(Name = MagicString.DisplayUserUserName)]
        [Required]
        public string UserName { get; set; }

        [Display(Name = MagicString.DisplayUserEmail)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = MagicString.DisplayUserAddress)]
        [Required]
        public string Address { get; set; }

        [Display(Name = MagicString.DisplayUserRoles)]
        [Required]
        public IEnumerable<string> Roles { get; set; }
    }
    public class Client
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = MagicString.DisplayClientName)]
        [Required]
        [StringLength(50, ErrorMessage = MagicString.ErrorNoMore50CharactersInString)]
        public string Name { get; set; }
    }
    public class Manager
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = MagicString.DisplayManagerName)]
        [Required]
        [StringLength(50, ErrorMessage = MagicString.ErrorNoMore50CharactersInString)]
        public string Name { get; set; }
    }
    public class PriceHistory
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = MagicString.DisplayProduct)]
        [Required]
        public int Product_ID { get; set; }
        
        public Product Product { get; set; }

        [Display(Name = MagicString.DisplayDateSetPrice)]
        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime Date { get; set; }

        [Display(Name = MagicString.DisplayProductPrice)]
        [Required]
        public int Price { get; set; }
    }
    public class Product
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = MagicString.DisplayProductName)]
        [Required]
        [StringLength(50, ErrorMessage = MagicString.ErrorNoMore50CharactersInString)]
        public string Name { get; set; }
    }
    public class Operation
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = MagicString.DisplayOperaionDate)]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfOperation { get; set; }
        
        [Required]
        [Display(Name = MagicString.DisplayOperationManager)]
        public int Manager_ID { get; set; }
        
        [Required]
        [Display(Name = MagicString.DisplayOperationClient)]
        public int Client_ID { get; set; }
        
        [Required]
        [Display(Name = MagicString.DisaplyOpertionProduct)]
        public int Product_ID { get; set; }
        
        [Required]
        [Display(Name = MagicString.DisplayOpertionPrice)]
        public int PriceHistory_ID { get; set; }
        

        public Client Client { get; set; }
        public Manager Manager { get; set; }
        public PriceHistory PriceHistory { get; set; }
        public Product Product { get; set; }
    }
}