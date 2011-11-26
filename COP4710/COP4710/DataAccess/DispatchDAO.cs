using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using COP4710.Models.Enumerations;
using COP4710.Models;

namespace COP4710.DataAccess
{
    public static class DispatchDAO
    {
        private static SqlConnection cn;


        public static int Insert(DispatchModel form)
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            SqlTransaction tn = null;

            try
            {

                cn.Open();

                tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("CreateForm", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CreateUser", form.CreateUser.UserName);
                cmd.Parameters.AddWithValue("CreateDate", form.CreateDate);
                cmd.Parameters.AddWithValue("UnitNumber", form.Unit > 0 ? form.Unit : 0);
                cmd.Parameters.AddWithValue("County", form.County);
                cmd.Parameters.AddWithValue("Age", form.InitialCondition.Age);
                cmd.Parameters.AddWithValue("AgeType", form.InitialCondition.AgeType);
                cmd.Parameters.AddWithValue("Sex", form.InitialCondition.Gender);
                cmd.Parameters.AddWithValue("AnOx", form.InitialCondition.A_OX);
                cmd.Parameters.AddWithValue("BP", String.IsNullOrEmpty(form.InitialCondition.BP1.ToString()) ? null : form.InitialCondition.BP1.ToString());
                cmd.Parameters.AddWithValue("BP2", String.IsNullOrEmpty(form.InitialCondition.BP2.ToString()) ? null : form.InitialCondition.BP2.ToString());
                cmd.Parameters.AddWithValue("Pulse", form.InitialCondition.Pulse1);
                cmd.Parameters.AddWithValue("Pulse2", form.InitialCondition.Pulse2);
                cmd.Parameters.AddWithValue("Resp", form.InitialCondition.Resp1);
                cmd.Parameters.AddWithValue("Resp2", form.InitialCondition.Resp2);
                cmd.Parameters.AddWithValue("O2Sat", form.InitialCondition.O2Sat);
                cmd.Parameters.AddWithValue("O2Sat2", form.InitialCondition.O2Sat2);
                cmd.Parameters.AddWithValue("Category", form.InitialCondition.Category);
                cmd.Parameters.AddWithValue("CC", form.InitialCondition.ChiefComplaint);
                cmd.Parameters.AddWithValue("LOC", form.InitialCondition.LossOfConciousness);
                cmd.Parameters.AddWithValue("GCS", form.InitialCondition.GSC1);
                cmd.Parameters.AddWithValue("BLG1", form.InitialCondition.BLG1);
                cmd.Parameters.AddWithValue("BLG2", form.InitialCondition.BLG2);
                cmd.Parameters.AddWithValue("DriverRestrained", form.CrashInformation.DriverRestrained);
                cmd.Parameters.AddWithValue("PassengerRestrained", form.CrashInformation.PassengerRestrained);
                cmd.Parameters.AddWithValue("Speed", form.CrashInformation.Speed);
                cmd.Parameters.AddWithValue("Helmet", form.CrashInformation.HasHelmet);
                cmd.Parameters.AddWithValue("Airbag", form.CrashInformation.AirbagDeployed);
                cmd.Parameters.AddWithValue("PKG", form.CrashInformation.isPackaged);
                cmd.Parameters.AddWithValue("Ejected", form.CrashInformation.Ejected);
                cmd.Parameters.AddWithValue("Rollover", form.CrashInformation.Rollover);
                cmd.Parameters.AddWithValue("Entrapped", form.CrashInformation.Entrapped);
                cmd.Parameters.AddWithValue("TraumaAlert", form.Alerts.TraumaAlert);
                cmd.Parameters.AddWithValue("StrokeAlert", form.Alerts.StrokeAlert);
                cmd.Parameters.AddWithValue("Onset", form.Alerts.onSet);
                cmd.Parameters.AddWithValue("Stemi", form.Alerts.STEMI);
                cmd.Parameters.AddWithValue("TIBR", form.Alerts.TIBR);
                cmd.Parameters.AddWithValue("Dispatcher", form.Alerts.DISP);
                cmd.Parameters.AddWithValue("History", form.Alerts.History);
                cmd.Parameters.AddWithValue("Treatment", form.Alerts.Treatment);
                cmd.Parameters.AddWithValue("Notified", form.Alerts.Notified);
                cmd.Parameters.AddWithValue("ETA", form.Alerts.ETA);
                cmd.Parameters.AddWithValue("Rescue", form.MedicalControl.Rescue);
                cmd.Parameters.AddWithValue("Meds", form.MedicalControl.Meds);
                cmd.Parameters.AddWithValue("DrSignature", form.MedicalControl.DrsSignature);
                cmd.Parameters.AddWithValue("DEANumber", form.MedicalControl.DEANumber);
                cmd.Parameters.AddWithValue("Narc", form.MedicalControl.NARC);
                cmd.Parameters.AddWithValue("Detail", form.MedicalDetail.Detail);
                cmd.Parameters.AddWithValue("Level", String.IsNullOrEmpty(form.MedicalDetail.Level) ? null: form.MedicalDetail.Level);
                cmd.Parameters.AddWithValue("Destination", form.MedicalDetail.TC_ER__PEDS);


                int rowsAffected = cmd.ExecuteNonQuery();
                tn.Commit();

                return rowsAffected;
            }
            catch
            {
                tn.Rollback();
            }
            finally
            {
                cn.Close();
            }

            return -1;
        }


        public static int UpdateForm(DispatchModel form)
        {

            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("UpdateFormByID", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("FormID", form.FormID);
                cmd.Parameters.AddWithValue("CreateUser", form.CreateUser.UserName);
                cmd.Parameters.AddWithValue("CreateDate", form.CreateDate);
                cmd.Parameters.AddWithValue("UnitNumber", form.Unit > 0 ? form.Unit : 0);
                cmd.Parameters.AddWithValue("County", form.County);
                cmd.Parameters.AddWithValue("Age", form.InitialCondition.Age);
                cmd.Parameters.AddWithValue("AgeType", form.InitialCondition.AgeType);
                cmd.Parameters.AddWithValue("Sex", form.InitialCondition.Gender);
                cmd.Parameters.AddWithValue("AnOx", form.InitialCondition.A_OX);
                cmd.Parameters.AddWithValue("BP", String.IsNullOrEmpty(form.InitialCondition.BP1.ToString()) ? null : form.InitialCondition.BP1.ToString());
                cmd.Parameters.AddWithValue("BP2", String.IsNullOrEmpty(form.InitialCondition.BP2.ToString()) ? null : form.InitialCondition.BP2.ToString());
                cmd.Parameters.AddWithValue("Pulse", form.InitialCondition.Pulse1);
                cmd.Parameters.AddWithValue("Pulse2", form.InitialCondition.Pulse2);
                cmd.Parameters.AddWithValue("Resp", form.InitialCondition.Resp1);
                cmd.Parameters.AddWithValue("Resp2", form.InitialCondition.Resp2);
                cmd.Parameters.AddWithValue("O2Sat", form.InitialCondition.O2Sat);
                cmd.Parameters.AddWithValue("O2Sat2", form.InitialCondition.O2Sat2);
                cmd.Parameters.AddWithValue("Category", form.InitialCondition.Category);
                cmd.Parameters.AddWithValue("CC", form.InitialCondition.ChiefComplaint);
                cmd.Parameters.AddWithValue("LOC", form.InitialCondition.LossOfConciousness);
                cmd.Parameters.AddWithValue("GCS", form.InitialCondition.GSC1);
                cmd.Parameters.AddWithValue("BLG1", form.InitialCondition.BLG1);
                cmd.Parameters.AddWithValue("BLG2", form.InitialCondition.BLG2);
                cmd.Parameters.AddWithValue("DriverRestrained", form.CrashInformation.DriverRestrained);
                cmd.Parameters.AddWithValue("PassengerRestrained", form.CrashInformation.PassengerRestrained);
                cmd.Parameters.AddWithValue("Speed", form.CrashInformation.Speed);
                cmd.Parameters.AddWithValue("Helmet", form.CrashInformation.HasHelmet);
                cmd.Parameters.AddWithValue("Airbag", form.CrashInformation.AirbagDeployed);
                cmd.Parameters.AddWithValue("Ejected", form.CrashInformation.Ejected);
                cmd.Parameters.AddWithValue("Rollover", form.CrashInformation.Rollover);
                cmd.Parameters.AddWithValue("Entrapped", form.CrashInformation.Entrapped);
                cmd.Parameters.AddWithValue("PKG", form.CrashInformation.isPackaged);
                cmd.Parameters.AddWithValue("TraumaAlert", form.Alerts.TraumaAlert);
                cmd.Parameters.AddWithValue("StrokeAlert", form.Alerts.StrokeAlert);
                cmd.Parameters.AddWithValue("Onset", form.Alerts.onSet);
                cmd.Parameters.AddWithValue("Stemi", form.Alerts.STEMI);
                cmd.Parameters.AddWithValue("TIBR", form.Alerts.TIBR);
                cmd.Parameters.AddWithValue("Dispatcher", form.Alerts.DISP);
                cmd.Parameters.AddWithValue("History", form.Alerts.History);
                cmd.Parameters.AddWithValue("Treatment", form.Alerts.Treatment);
                cmd.Parameters.AddWithValue("Notified", form.Alerts.Notified);
                cmd.Parameters.AddWithValue("ETA", form.Alerts.ETA);
                cmd.Parameters.AddWithValue("Rescue", form.MedicalControl.Rescue);
                cmd.Parameters.AddWithValue("Meds", form.MedicalControl.Meds);
                cmd.Parameters.AddWithValue("DrSignature", form.MedicalControl.DrsSignature);
                cmd.Parameters.AddWithValue("DEANumber", form.MedicalControl.DEANumber);
                cmd.Parameters.AddWithValue("Narc", form.MedicalControl.NARC);
                cmd.Parameters.AddWithValue("Detail", form.MedicalDetail.Detail);
                cmd.Parameters.AddWithValue("Level", form.MedicalDetail.Level);
                cmd.Parameters.AddWithValue("Destination", form.MedicalDetail.TC_ER__PEDS);


                int rowsAffected = cmd.ExecuteNonQuery();
                tn.Commit();
                return rowsAffected;
            }
            catch
            {
                //implement error logging
            }
            finally
            {
                cn.Close();
            }

            return -1;
        }

        public static DispatchModel GetDispatchByID(int dispatchID)
        {

            DispatchModel form = null;

            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }


            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("GetFormByID", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("FormID", dispatchID);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    form = new DispatchModel();



                    form.FormID = Int32.Parse(reader["FormID"].ToString());
                    form.CreateUser = UserDAO.GetUserByUsername(reader["CreateUser"].ToString());
                    form.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());
                    form.Unit = Int32.Parse(reader["UnitNumber"].ToString());
                    form.County = (County)Enum.Parse(typeof(County), reader["County"].ToString());

                    string disp = reader["DISP"].ToString();

                    if (!String.IsNullOrEmpty(disp))
                    {
                        form.LoggingUser = UserDAO.GetUserByUsername(disp);
                    }

                    form.InitialCondition = new InitialDiagnosisModel();


                    form.InitialCondition.Age = Int32.Parse(reader["Age"].ToString());
                    form.InitialCondition.AgeType = (AgeType)Enum.Parse(typeof(AgeType), reader["AgeType"].ToString());
                    form.InitialCondition.Gender = (Gender)Enum.Parse(typeof(Gender), reader["Sex"].ToString());
                    form.InitialCondition.A_OX = Int16.Parse(reader["AnOX"].ToString());
                    form.InitialCondition.BP1 = new BloodPressure(reader["BP"].ToString());
                    form.InitialCondition.BP2 = new BloodPressure(reader["BP2"].ToString());
                    form.InitialCondition.Pulse1 = Int16.Parse(reader["Pulse"].ToString());
                    form.InitialCondition.Pulse2 = Int16.Parse(reader["Pulse2"].ToString());
                    form.InitialCondition.Resp1 = Int16.Parse(reader["Resp"].ToString());
                    form.InitialCondition.Resp2 = Int16.Parse(reader["Resp2"].ToString());
                    form.InitialCondition.O2Sat = Int16.Parse(reader["O2Sat"].ToString());
                    form.InitialCondition.O2Sat2 = Int16.Parse(reader["O2Sat2"].ToString());
                    form.InitialCondition.ChiefComplaint = reader["CC"].ToString();
                    form.InitialCondition.LossOfConciousness = Boolean.Parse(reader["LOC"].ToString());
                    form.InitialCondition.GSC1 = Int32.Parse(reader["GCS"].ToString());
                    form.InitialCondition.BLG1 = Int32.Parse(reader["BGL1"].ToString());
                    form.InitialCondition.BLG2 = Int32.Parse(reader["BLG2"].ToString());

                    form.CrashInformation = new CrashInformationModel()
                    {
                        DriverRestrained = (DriverRestraintLevel)Enum.Parse(typeof(DriverRestraintLevel), reader["Driver_Restrained"].ToString()),
                        PassengerRestrained = (PassengerRestraintLevel)Enum.Parse(typeof(PassengerRestraintLevel), reader["Passenger_Restrained"].ToString()),
                        Speed = Int16.Parse(reader["Speed"].ToString()),
                        HasHelmet = Boolean.Parse(reader["Helmet"].ToString()),
                        AirbagDeployed = Boolean.Parse(reader["Airbag"].ToString()),
                        Ejected = Boolean.Parse(reader["Ejected"].ToString()),
                        Entrapped = Boolean.Parse(reader["Entrapped"].ToString()),
                        isPackaged = Boolean.Parse(reader["PKG"].ToString()),
                        Rollover = Boolean.Parse(reader["Ejected"].ToString()),

                    };

                    form.Alerts = new AlertsModel()
                    {
                        DISP = reader["DISP"].ToString(),
                        ETA = Int32.Parse(reader["ETA"].ToString()),
                        History = (History)Enum.Parse(typeof(History), reader["HX"].ToString()),
                        Notified = Boolean.Parse(reader["Notified"].ToString()),
                        STEMI = Boolean.Parse(reader["STEMI"].ToString()),
                        StrokeAlert = Boolean.Parse(reader["SA"].ToString()),
                        TraumaAlert = Boolean.Parse(reader["TA"].ToString()),
                        TIBR = reader["TIBR"].ToString(),
                        Treatment = (Treatment)Enum.Parse(typeof(Treatment), reader["TX"].ToString()),
                        onSet = reader["Onset"].ToString()
                    };

                    form.MedicalControl = new MedicalControlModel()
                    {
                        DEANumber = Int32.Parse(reader["DEANumber"].ToString()),
                        Meds = reader["MEDS"].ToString(),
                        DrsSignature = reader["DrSign"].ToString(),
                        NARC = Boolean.Parse(reader["NARC"].ToString()),
                        Rescue = reader["Rescue"].ToString()
                    };

                    form.MedicalDetail = new MedicalDetailModel()
                    {
                        Detail = reader["Detail"].ToString(),
                        Level = reader["levels"].ToString(),
                        TC_ER__PEDS = (DispatchDestination)Enum.Parse(typeof(DispatchDestination), reader["Destination"].ToString())
                    };
                }

            }
            catch
            {
                //implement error logging
            }
            finally
            {
                cn.Close();
            }

            return form;

        }

        public static List<DispatchModel> List()
        {
            return List(-1);
        }

        public static List<DispatchModel> List(int page)
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            List<DispatchModel> forms = new List<DispatchModel>();

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("ListForms", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (page >= 0)
                {
                    cmd.Parameters.AddWithValue("Page", page);
                    cmd.Parameters.AddWithValue("PageSize", System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    forms.Add(new DispatchModel()
                    {
                        FormID = Int32.Parse(reader["FormID"].ToString()),
                        CreateUser = UserDAO.GetUserByUsername(reader["CreateUser"].ToString()),
                        CreateDate = DateTime.Parse(reader["CreateDate"].ToString()),
                        Unit = Int32.Parse(reader["UnitNumber"].ToString())
                    });
                }
            }
            catch
            {
                //implement error logging
            }
            finally
            {
                cn.Close();
            }

            return forms;
        }

    }
}