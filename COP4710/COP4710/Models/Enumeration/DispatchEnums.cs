using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace COP4710.Models.Enumerations
{
    public enum AgeType
    {
        [Display(Name = "Years")]
        Years = 0,
        [Display(Name = "Months")]
        Months = 1,
        [Display(Name = "Weeks")]
        Weeks = 2
    }

    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Unknown")]
        Unknown
    }

    public enum DriverRestraintLevel
    {
        [Display(Name = "Unrestrained", Description="Unrestrained")]
        Unrestrained,
        [Display(Name = "Restrained")]
        Restrained
    }

    public enum PassengerRestraintLevel
    {
        [Display(Name = "Front Restrained",  Description = "Front Restrained", AutoGenerateField = true)]
        FrontRestrained,
        [Display(Name = "Rear Restrained")]
        RearRestrained,
        [Display(Name = "Front Unrestrained")]
        FrontUnrestrained,
        [Display(Name = "Rear Unrestrained")]
        RearUnrestrained

    }

    public enum DispatchDestination
    {
        TC, 
        ER,
        PEDS,
        CathLab,
        [Display(Name="L&D")]
        LandD,
        Floor
        
    }

    public enum Treatment
    {
        Oxygen = 1,
        NEB = 2,
        D50 = 3,
        Nitro = 4,
        ASA = 5,
        IV = 6

    }


    public enum History
    {
        Asthma = 1,
        COPD = 2,
        Cardiac = 3,
        HTN = 4,
        DM = 5,
        SZ = 6,
        CVA = 7,
        CA = 8

    }

    public enum County
    {
        Duval = 1,
        Clay = 2, 
        Nassau = 3
    }
}