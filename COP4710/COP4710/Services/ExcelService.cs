using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using COP4710.DataAccess;
using COP4710.Models;
using COP4710.Models.Enumerations;

namespace COP4710.Services
{
    public class ExcelService
    {
        public static void CreateWorkbook(DataSet ds, String path)
        {
            XmlDataDocument xmlDataDoc = new XmlDataDocument(ds);
            XslTransform xt = new XslTransform();
            StreamReader reader = new StreamReader(typeof(ExcelService).Assembly.GetManifestResourceStream(typeof(ExcelService), "Excel.xsl"));
            XmlTextReader xRdr = new XmlTextReader(reader);
            xt.Load(xRdr, null, null);
            StringWriter sw = new StringWriter();
            xt.Transform(xmlDataDoc, null, sw, null); 
            StreamWriter myWriter = new StreamWriter (path);
            myWriter.Write (sw.ToString());
            myWriter.Close ();
        }

        public static void ExportDataSetToExcel(DataSet ds, string filename)
        {
            HttpResponse response = HttpContext.Current.Response;

            // first let's clean up the response.object
            response.Clear();
            response.Charset = "";

            // set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");

            // create a string writer
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid
                    DataGrid dg = new DataGrid();
                    dg.DataSource = ds.Tables[0];
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }
        }
        

        /*
        DataSet ds = new DataSet(); 
        SqlConnection cn = new SqlConnection("server=(local);database=Northwind;user id=sa;password=;"); 
        SqlCommand cmd = new SqlCommand("Select * from customers;Select * from employees",cn) ; 
        cn.Open(); SqlDataAdapter da = new SqlDataAdapter(cmd); 
        da.Fill(ds); 
        ds.WriteXml(Server.MapPath("Customers.xml")) ;  
        ds.ReadXml(Server.MapPath("Customers.xml")); 
        string xml = WorkbookEngine.CreateWorkbook(ds); 
        Response.ContentType = "application/vnd.ms-excel"; 
        Response.Charset = ""; 
        Response.Write(xml); 
        Response.Flush(); 
        Response.End();
        */


        public string ExportToExcel(List<DispatchModel> model)
        {
            return "";
        }


        public int ImportFromExcel(string xlsFile, UserModel user)
        {

            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");

            String strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + xlsFile + ";" +
                "Extended Properties=Excel 8.0;";

            DataSet ds = new DataSet();
            //You must use the $ after the object
            //you reference in the spreadsheet
            OleDbDataAdapter da = new OleDbDataAdapter
            ("SELECT * FROM [Sheet1$]", strConn);

            //da.TableMappings.Add("Table", "ExcelTest");

            da.Fill(ds);

            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                {
                    try
                    {

                        DispatchModel model = new DispatchModel();
                        model.CreateUser = user;

                        try
                        {
                            string time = dr[ExcelMap["Time"]].ToString().Substring(0, 2) + ":" + dr[ExcelMap["Time"]].ToString().Substring(2, 2);
                            string date = dr[ExcelMap["Date"]].ToString().Split(' ')[0];
                            model.CreateDate = DateTime.Parse(time + " " + date);
                        }
                        catch
                        {
                            throw;
                        }

                        model.Unit = StringToNumber(dr[ExcelMap["Unit"]].ToString());
                        InitialDiagnosisModel ic = new InitialDiagnosisModel();


                        string[] ageString = dr[ExcelMap["Age"]].ToString().Split(' ');
                        if (ageString.Length > 1)
                        {


                            var match = numAlpha.Match(dr[ExcelMap["Age"]].ToString());

                            ic.Age = StringToNumber(match.Groups["Numeric"].ToString());

                            string alpha = "";

                            if (match.Groups["Alpha"].Length == 0)
                                alpha = dr[ExcelMap["Age"]].ToString().Replace(match.Groups["Numeric"].ToString(), "");

                            switch (alpha.ToLower().Trim())
                            {
                                case "mos":
                                    ic.AgeType = AgeType.Months;
                                    break;
                                default:
                                    ic.AgeType = AgeType.Years;
                                    break;
                            }
                        }
                        else
                        {
                            ic.Age = StringToNumber(dr[ExcelMap["Age"]].ToString());
                            ic.AgeType = AgeType.Years;
                        }

                        switch (dr[ExcelMap["Sex"]].ToString().ToUpper().Trim())
                        {
                            case "M":
                                ic.Gender = Gender.Male;
                                break;
                            case "F":
                                ic.Gender = Gender.Female;
                                break;
                            default:
                                ic.Gender = Gender.Unknown;
                                break;
                        }

                        try
                        {
                            ic.Category = (Category)Enum.Parse(typeof(Category), dr[ExcelMap["Category"]].ToString());
                        }
                        catch
                        {
                            ic.Category = Category.OTHER;
                        }


                        ic.ChiefComplaint = dr[ExcelMap["CC"]].ToString();

                        string[] bp = dr[ExcelMap["BP"]].ToString().Split(' ');

                        if (bp.Length > 0)
                        {
                            ic.BP1 = new BloodPressure(bp[0]);
                            if (bp.Length > 1)
                            {
                                ic.BP2 = new BloodPressure(bp[1]);
                            }
                        }

                        string[] pulse = dr[ExcelMap["Pulse"]].ToString().Split('-');

                        if (pulse.Length > 0)
                        {
                            ic.Pulse1 = StringToNumber(pulse[0]);


                            if (pulse.Length > 1)
                            {
                                ic.Pulse2 = StringToNumber(pulse[1].Trim());
                            }
                        }

                        string[] Resp = dr[ExcelMap["Resp"]].ToString().Split('-');

                        if (Resp.Length > 0)
                        {
                            ic.Resp1 = StringToNumber(Resp[0]);

                            if (Resp.Length > 1)
                            {
                                ic.Resp2 = StringToNumber(Resp[1].Trim());
                            }
                        }
                        string[] O2Sat = dr[ExcelMap["O2"]].ToString().Split('-');

                        if (O2Sat.Length > 0)
                        {
                            ic.O2Sat = StringToNumber(O2Sat[0]);

                            if (O2Sat.Length > 1)
                            {
                                ic.O2Sat2 = StringToNumber(O2Sat[1].Trim());
                            }
                        }


                        string[] BLG = dr[ExcelMap["BLG"]].ToString().Split('-');

                        if (BLG.Length > 0)
                        {
                            ic.BLG1 = StringToNumber(BLG[0]);

                            if (BLG.Length > 1)
                            {
                                ic.BLG2 = StringToNumber(BLG[1].Trim());
                            }
                        }

                        switch (dr[ExcelMap["LOC"]].ToString().Trim().ToLower())
                        {
                            case "y":
                                ic.LossOfConciousness = true;
                                break;
                            default:
                                ic.LossOfConciousness = false;
                                break;
                        }

                        ic.GSC1 = StringToNumber(dr[ExcelMap["GSC"]].ToString());

                        AlertsModel alerts = new AlertsModel();

                        switch (dr[ExcelMap["Trauma"]].ToString().ToLower().Trim())
                        {
                            case "y":
                                alerts.TraumaAlert = true;
                                break;
                            default:
                                alerts.TraumaAlert = false;
                                break;
                        }

                        switch (dr[ExcelMap["Stroke"]].ToString().ToLower().Trim())
                        {
                            case "y":
                                alerts.StrokeAlert = true;
                                break;
                            default:
                                alerts.StrokeAlert = false;
                                break;
                        }

                        switch (dr[ExcelMap["Stemi"]].ToString().ToLower().Trim())
                        {
                            case "y":
                                alerts.STEMI = true;
                                break;
                            default:
                                alerts.STEMI = false;
                                break;
                        }


                        alerts.ETA = StringToNumber(numAlpha.Match(dr[ExcelMap["ETA"]].ToString()).Groups["Numeric"].ToString());

                        MedicalDetailModel md = new MedicalDetailModel();

                        try
                        {
                            md.TC_ER__PEDS = (DispatchDestination)Enum.Parse(typeof(DispatchDestination), dr[ExcelMap["Destination"]].ToString());
                        }
                        catch
                        {
                        }
                        md.Level = dr[ExcelMap["Level"]].ToString();

                        model.InitialCondition = ic;
                        model.Alerts = alerts;
                        model.MedicalDetail = md;

                        DispatchDAO.Insert(model);

                    }
                    catch
                    {
                    }
                }
            }


            return 1;
        }

        public int StringToNumber(string str)
        {
            int i = 0;

            Int32.TryParse(str, out i);

            return i;
        }

        public Dictionary<string, int> ExcelMap = new Dictionary<string, int>()
        {
            {"Date", 0},
            {"Time", 1},
            {"Unit", 2},
            {"Age", 3},
            {"Sex", 4},
            {"Category", 5},
            {"CC", 6},
            {"BP", 7},
            {"Pulse", 8},
            {"Resp", 9},
            {"O2", 10},
            {"BLG", 11},
            {"LOC", 12},
            {"GSC", 13},
            {"Trauma", 14},
            {"Stroke", 15},
            {"Stemi", 16},
            {"Destination",17},
            {"Level", 18},
            {"ACS", 19},
            {"ETA", 20}
        };

    }

}


