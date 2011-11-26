using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using COP4710.Models;


namespace COP4710.DataAccess
{
    public static class ReportDAO
    {

        private static SqlConnection cn;

        public static DataSet ExecuteReport(ReportModel report)
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("RunReport", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("StartDate", report.StartDate);
                cmd.Parameters.AddWithValue("EndDate", report.EndDate);
                cmd.Parameters.AddWithValue("Unit", report.Unit);
                cmd.Parameters.AddWithValue("StartAge", report.StartAge);
                cmd.Parameters.AddWithValue("EndAge", report.EndAge);
                cmd.Parameters.AddWithValue("AgeType", report.AgeType);
                cmd.Parameters.AddWithValue("Sex", report.Gender);
                cmd.Parameters.AddWithValue("Category", report.Category);
                cmd.Parameters.AddWithValue("CC", report.CC);
                cmd.Parameters.AddWithValue("Destination", report.Destination);
                cmd.Parameters.AddWithValue("Level", report.Level);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds= new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch
            {
                //implement error logging
            }
            finally
            {
                cn.Close();
            }

            return new DataSet();

        }

    }
}
