using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COP4710.Models.Enumerations;

namespace COP4710.Models
{
    public class InitialDiagnosisModel
    {
        public int Age { get; set; }

        public AgeType AgeType { get; set; }

        public Gender Gender { get; set; }

        public int A_OX { get; set; }

        public BloodPressure BP1 { get; set; }

        public BloodPressure BP2 { get; set; }

        public int Resp1 { get; set; }

        public int Resp2 { get; set; }

        public int O2Sat { get; set; }

        public int O2Sat2 { get; set; }

        public string ChiefComplaint { get; set; }

        public Boolean LossOfConciousness { get; set; }

        public int GSC1 { get; set; }

        public int Pulse1 { get; set; }
        
        public int Pulse2 { get; set; }

        public int BLG1 { get; set; }

        public int BLG2 { get; set; }
    }
}