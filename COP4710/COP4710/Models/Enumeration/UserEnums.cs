using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace COP4710.Models.Enumerations
{
    [Serializable]
    [Flags]
    public enum AccountType
    {
        Dispatcher = 1,
        Administrator = 2 

    }


}