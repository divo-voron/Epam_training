using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sales.MVCClient.Helper;

namespace Sales.MVCClient.Models.CreateEdit
{
    public class UserCreate
    {
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

        [Display(Name = MagicString.DisplayPassword)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = MagicString.DisplayConfirmPassword)]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = MagicString.DisplayUserAddress)]
        [Required]
        public string Address { get; set; }

        [Display(Name = MagicString.DisplayUserRoles)]
        [Required]
        public IEnumerable<string> Roles { get; set; }
    }
}