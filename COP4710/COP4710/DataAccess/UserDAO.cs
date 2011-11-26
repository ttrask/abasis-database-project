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
    static class UserDAO
    {
        #region Insert

        private static SqlConnection cn;

        public static int Insert(UserModel user)
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("CreateUser", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Username", user.UserName);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.Parameters.AddWithValue("Firstname", user.FirstName);
                cmd.Parameters.AddWithValue("Lastname", user.LastName);
                cmd.Parameters.AddWithValue("IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("AccountType", user.AccountType);

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

        public static int Update(UserModel user)
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("UpdateUser", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Username", user.UserName);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.Parameters.AddWithValue("Firstname", user.FirstName);
                cmd.Parameters.AddWithValue("Lastname", user.LastName);
                cmd.Parameters.AddWithValue("IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("AccountType", user.AccountType);

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

        #endregion

        #region List



        public static List<UserModel> ListUsers()
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            List<UserModel> users = new List<UserModel>();

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("ListUsers", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    users.Add(new UserModel()
                    {
                        UserName = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        IsActive = (Boolean)reader["IsActive"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        AccountType = (AccountType)Enum.Parse(typeof(AccountType), reader["AccountType"].ToString())
                    });
                }
            }
            catch
            {
            }
            finally
            {
                cn.Close();
            }

            return users;
        }


        public static UserModel AuthenticateUser(string username, string password)
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            UserModel user = null;

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("AuthenticateUser", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new UserModel()
                    {
                        UserName = (string)reader["Username"].ToString().Trim(),
                        Password = (string)reader["Password"].ToString().Trim(),
                        IsActive = (Boolean)(String.IsNullOrEmpty(reader["IsActive"].ToString()) ? false : Boolean.Parse(reader["IsActive"].ToString())),
                        FirstName = (string)reader["FirstName"].ToString().Trim(),
                        LastName = (string)reader["LastName"].ToString().Trim(),
                        AccountType = (AccountType)Enum.Parse(typeof(AccountType), reader["AccountType"].ToString().ToString().Trim())
                    };
                }

                
            }
            catch
            {
            }
            finally
            {
                cn.Close();
            }

            return user;
        }

        public static UserModel GetUserByUsername(string Username)
        {
            if (cn == null)
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            }

            UserModel user = new UserModel();

            try
            {

                cn.Open();

                SqlTransaction tn = (SqlTransaction)cn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = new SqlCommand("GetUserByUsername", cn, tn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Username", Username);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    user = new UserModel()
                    {
                        UserName = (string)reader["Username"].ToString().Trim(),
                        Password = (string)reader["Password"].ToString().Trim(),
                        IsActive = (Boolean)(String.IsNullOrEmpty(reader["IsActive"].ToString())?false:Boolean.Parse(reader["IsActive"].ToString())),
                        FirstName = (string)reader["FirstName"].ToString().Trim(),
                        LastName = (string)reader["LastName"].ToString().Trim(),
                        AccountType = (AccountType)Enum.Parse(typeof(AccountType), reader["AccountType"].ToString().ToString().Trim())
                    };
                }
            }
            catch
            {
            }
            finally
            {
                cn.Close();
            }

            return user;
        }
        #endregion

    }

}