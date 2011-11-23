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
        private string onset;

        [Display(Name = "Trauma Alert")]
        public Boolean TraumaAlert { get; set; }

        [Display(Name = "Stroke Alert")]
        public Boolean StrokeAlert { get; set; }

        [Display(Name = "First Incident of Stroke")]
        public string onSet
        {
            get
            {
                return onset;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && value.Trim().Length > 0)
                    onset = value;
                else
                {
                    onset = null;
                }
            }
        }

        [Display(Name = "STEMI")]
        public Boolean STEMI { get; set; }

        [Display(Name = "Time Issued by Rescuer")]
        public string TIBR { get; set; }

        [Display(Name = "Logging Dispatcher")]
        public string DISP { get; set; }

        public History History { get; set; }

        public Treatment Treatment { get; set; }

        public Boolean Notified { get; set; }

        public int ETA { get; set; }

    }
}