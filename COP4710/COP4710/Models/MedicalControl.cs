using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP4710.Models
{
    public class MedicalControlModel
    {
        public string Rescue { get; set; }
        public string Meds { get; set; }
        public string DrsSignature { get; set; }
        public int DEANumber { get; set; }
        public bool NARC { get; set; }
    }
}