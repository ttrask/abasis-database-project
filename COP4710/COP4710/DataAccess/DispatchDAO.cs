using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Sql;
using System.Data.SqlClient;

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

        public static int Insert(DispatchModel form){
              if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("CreateForm", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CreateUser", form.CreateUser.UserName);
                cmd.Parameters.AddWithValue("CreateDate", form.CreateDate);
                cmd.Parameters.AddWithValue("UnitNumber", form.Unit>0?form.Unit:0);
                
                return cmd.ExecuteNonQuery();
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


        public static List<DispatchModel> List()
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

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    forms.Add(new DispatchModel()
                    {
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