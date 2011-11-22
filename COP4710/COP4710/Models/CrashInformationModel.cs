using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COP4710.Models.Enumerations;
using COP4710.Models;

namespace COP4710.Models
{
    public class CrashInformationModel
    {
        public DriverRestraintLevel DriverRestrained;
        public PassengerRestraintLevel PassengerRestrained;
        public int Speed;
        public Boolean Ejected;
        public Boolean Entrapped;
        public Boolean Rollover;
        public Boolean HasHelmet;
        public Boolean AirbagDeployed;
        public Boolean isPackaged;
    }
}