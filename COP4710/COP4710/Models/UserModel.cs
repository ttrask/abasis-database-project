using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using COP4710.Models.Enumerations;
using System.Security.Principal;

namespace COP4710.Models
{
    public class UserModel: IPrincipal
    {

        private IIdentity _identity;

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string FullName
        {
            get
            {
                return this.FirstName.Trim() + " " + this.LastName.Trim();
            }
        }

        [Required]
        [Display(Name = "Is Active")]
        public Boolean IsActive { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }


        public bool IsInRole(string role)
        {
            return (AccountType)Enum.Parse(typeof(AccountType), role) == this.AccountType;
        }

        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

    }
}