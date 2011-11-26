using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using COP4710.Models.Enumerations;

namespace COP4710.Models
{
    public class ReportModel
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        
        public string Unit { get; set; }
        public int? StartAge { get; set; }
        public int? EndAge { get; set; }
        public AgeType? AgeType { get; set; }
        public Gender? Gender { get; set; }
        public Category? Category { get; set; }
        public string CC { get; set; }
        public DispatchDestination? Destination { get; set; }
        public string Level { get; set; }


        public ReportModel()
        {
            AgeType = null;
            Category = null;
            Destination = null;
            Level = null;
            StartAge = null;
            EndAge = null;
            Unit = null;
        }
    }
}