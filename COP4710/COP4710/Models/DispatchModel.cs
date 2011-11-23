using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using COP4710.Models.Enumerations;

namespace COP4710.Models
{

    public class DispatchModel
    {

        public int FormID{ get; set;}

        [Required]
        public UserModel CreateUser { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int Unit { get; set; }

        [Required]
        public County County { get; set; }

        public AlertsModel Alerts { get; set; }
        public CrashInformationModel CrashInformation { get; set; }
        public InitialDiagnosisModel InitialCondition { get; set; }
        public MedicalDetailModel MedicalDetail { get; set; }
        public MedicalControlModel MedicalControl { get; set; }

        public DispatchModel()
        {

            this.CreateUser = new UserModel() { UserName = "ttrask" };

            this.CreateDate = DateTime.Now;
            this.Alerts = new AlertsModel();
            this.CrashInformation = new CrashInformationModel();
            this.InitialCondition = new InitialDiagnosisModel();
            this.MedicalControl = new MedicalControlModel();
            this.MedicalDetail = new MedicalDetailModel();

            
        }
    }



}