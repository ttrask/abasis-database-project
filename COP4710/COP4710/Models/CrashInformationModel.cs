using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COP4710.Models.Enumerations;
using COP4710.Models;
using System.ComponentModel.DataAnnotations;

namespace COP4710.Models
{
    public class CrashInformationModel
    {
        public DriverRestraintLevel DriverRestrained { get; set; }
        public PassengerRestraintLevel PassengerRestrained { get; set; }
        public int Speed{ get; set;}

        [Display(Name="EJECTED")]
        public Boolean Ejected{ get; set;}

        [Display(Name = "ENTRAPPED")]
        public Boolean Entrapped { get; set; }

        [Display(Name = "ROLLOVER")]
        public Boolean Rollover { get; set; }

        [Display(Name = "HELMET")]
        public Boolean HasHelmet { get; set; }

        [Display(Name = "AIRBAG")]
        public Boolean AirbagDeployed { get; set; }

        [Display(Name = "PKG")]
        public Boolean isPackaged { get; set; }
    }
}