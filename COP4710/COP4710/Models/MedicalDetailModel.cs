using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using COP4710.Models.Enumerations;


namespace COP4710.Models
{
    public class MedicalDetailModel
    {
        public string Detail { get; set; }

        public string Level { get; set; }

        [Display(Name="Destination")]
        public DispatchDestination TC_ER__PEDS { get; set; }

        
    }
}