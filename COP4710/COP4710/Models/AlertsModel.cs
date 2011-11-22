using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using COP4710.Models.Enumerations;


namespace COP4710.Models
{
    public class AlertsModel
    {
        [Display(Name="Trauma Alert")]
        public Boolean TraumaAlert { get; set; }

        [Display(Name = "Stroke Alert")]
        public Boolean StrokeAlert { get; set; }

        [Display(Name = "First Incident of Stroke")]
        public string onSet { get; set; }

        [Display(Name = "STEMI")]
        public Boolean STEMI { get; set; }

        [Display(Name = "Time Issued by Rescuer")]
        public string TIBR { get; set; }

        [Display(Name = "Logging Dispatcher")]
        public string DISP { get; set; }

        public History History { get; set; }

        public Treatment Treatment { get; set; }

        public string Notified { get; set; }

        public int ETA { get; set; }

    }
}