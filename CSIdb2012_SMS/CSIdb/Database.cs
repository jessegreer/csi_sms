using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace CSIdb
{
    public static class Database
    {
        const string CONNECTION_STRING = "Data Source=192.168.100.105;Initial Catalog=CSIDB;Persist Security Info=True;User ID=sa;Password=355csi8594";

        public static Dictionary<string, object> GetTagValueUpdates(List<string> tags)
        {
            Dictionary<string, object> dictTagValuesTemp = new Dictionary<string, object>();

            //var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))//connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();

                    object objValue = 0;
                    foreach (string tag in tags)
                    {
                        if (tag.Contains("("))
                        {
                            string str1 = tag.Replace("(", string.Empty);
                            str1 = str1.Replace(")", string.Empty);
                            string[] str = str1.Split('+');

                            int i = str.Length - 1;
                            double dTotalValue = 0.0;
                            for (int j = 0; j < str.Length; j++, i--)
                            {
                                string str2 = str[j].Trim().ToUpper();
                                SqlCommand sqlCommand = new SqlCommand("SELECT CurrentValue from tblLiveDB Where TagName = '" + str2 + "'", dbConnection);
                                sqlCommand.CommandType = System.Data.CommandType.Text;
                                objValue = sqlCommand.ExecuteScalar();
                                dTotalValue += Convert.ToDouble(objValue) * Math.Pow(10, 3 * i);
                            }
                            objValue = dTotalValue;
                        }
                        else
                        {
                            SqlCommand sqlCommand = new SqlCommand("SELECT CurrentValue from tblLiveDB Where TagName = '" + tag + "'", dbConnection);
                            sqlCommand.CommandType = System.Data.CommandType.Text;
                            objValue = sqlCommand.ExecuteScalar();
                        }

                        if (objValue != null)
                        {
                            if (!dictTagValuesTemp.ContainsKey(tag))
                                dictTagValuesTemp.Add(tag, objValue);
                        }
                    }
                }
                catch (SqlException ex)
                {
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }
            return dictTagValuesTemp;
        }

        //public static bool ValidUser(string user, string pass)
        //{
        //    var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
        //    using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))//connectionFromConfiguration.ConnectionString))
        //    {
        //        conn.Open();
        //        string sql = "select * from tblUsers where LogonName = @LogonName and sPassword = @Password";
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@LogonName", user);
        //        cmd.Parameters.AddWithValue("@Password", pass);
        //        return cmd.ExecuteScalar() is string;
        //    }
        //}
        public static List<string[]> SQLquery(string sqlQueryString)
        {
            List<string[]> resultsList = new List<string[]>();
            List<string> items = new List<string>();

            string results = "";
           // System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //    sb.Append("Select ProdTech, ProdOrder, Job_No, Rel_to_pro, Rqstd_shpg, PROJ_SHPG, Est_Time_, ACT_TIME, PERCENT_CO, Mtl_Comple, DevRequired, CSIInstall from ");
          //  sb.Append("JobsDB where ProdOrder<>'' AND ProdTech<>'' Order by ProdTech,ProdOrder");

            //var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            //List<ProductionJobInfo> ProductionJobInfoList = new List<ProductionJobInfo>();

            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))//connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
               
                    SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbConnection);
                 //   SqlCommand sqlCommand = new SqlCommand(sb.ToString(), dbConnection);
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                    int count = 0;

                    if (sqlReader.HasRows)
                    {
                      //  List<string> rows = new List<string>();

                        //var columns = Enumerable.Range(0, sqlReader.FieldCount).Select(sqlReader.GetName).ToList();
                        //foreach (string row in columns)
                        //{
                           
                        //    if(count++ % 8 == 0)
                        //        results += row + "\n";
                        //    else
                        //        results += row + ",";
                        //}

                        while (sqlReader.Read())
                        {
                            items.Clear();
                            for (int j = 0; j < sqlReader.FieldCount; j++)
                            {
                                try
                                {
                                    results = sqlReader.GetValue(j).ToString();
                                    items.Add(results);
                                }
                                catch(Exception ex){ }
                            }
                            resultsList.Add(items.ToArray());
                        }
                      

                        //while (sqlReader.Read())
                        //{
                        //    ProductionJobInfo pInfo = new ProductionJobInfo();
                        //    pInfo.TechName = sqlReader["ProdTech"].ToString();
                        //    pInfo.Priority = Convert.ToInt32(sqlReader["ProdOrder"]);
                        //    pInfo.Job_Number = Convert.ToInt32(sqlReader["Job_No"]);

                        //    string strRFDateTime = sqlReader["Rel_to_pro"].ToString();
                        //    DateTime RFDateTime = DateTime.Now;
                        //    if (!string.IsNullOrEmpty(strRFDateTime))
                        //    {
                        //        if (DateTime.TryParse(strRFDateTime, out RFDateTime))
                        //        {
                        //            pInfo.Release_For_Production_Date = RFDateTime.ToString("MM/dd/yy");
                        //        }
                        //        else
                        //            pInfo.Release_For_Production_Date = string.Empty;
                        //    }

                        //    string strReqShipmentDateTime = sqlReader["Rqstd_shpg"].ToString();
                        //    DateTime ReqShipmentDateTime = DateTime.Now;
                        //    if (!string.IsNullOrEmpty(strReqShipmentDateTime))
                        //    {
                        //        if (DateTime.TryParse(strReqShipmentDateTime, out ReqShipmentDateTime))
                        //        {
                        //            pInfo.Requested_Shipment_Date = ReqShipmentDateTime.ToString("MM/dd/yy");
                        //        }
                        //        else
                        //            pInfo.Requested_Shipment_Date = string.Empty;
                        //    }


                        //    string strProjShipmentDateTime = sqlReader["PROJ_SHPG"].ToString();
                        //    DateTime ProjShipmentDateTime = DateTime.Now;
                        //    if (!string.IsNullOrEmpty(strProjShipmentDateTime))
                        //    {
                        //        if (DateTime.TryParse(strProjShipmentDateTime, out ProjShipmentDateTime))
                        //        {
                        //            pInfo.Projected_Shipment_Date = ProjShipmentDateTime.ToString("MM/dd/yy");
                        //        }
                        //        else
                        //            pInfo.Projected_Shipment_Date = string.Empty;
                        //    }

                        //    string EstimatedTime = sqlReader["Est_Time_"].ToString();
                        //    if (!string.IsNullOrEmpty(EstimatedTime))
                        //    {
                        //        string match = Regex.Match(EstimatedTime, @"\d+").Value;
                        //        pInfo.Hours_Estimated = int.Parse(match);
                        //    }

                        //    string HoursSpent = sqlReader["ACT_TIME"].ToString();
                        //    if (!string.IsNullOrEmpty(HoursSpent))
                        //    {
                        //        string match = Regex.Match(HoursSpent, @"\d+").Value;
                        //        pInfo.Hours_Spent = int.Parse(match);
                        //    }

                        //    pInfo.Percent_Complete = (pInfo.Hours_Spent * 100.0f) / (pInfo.Hours_Estimated * 1.0f);

                        //    int MaterialComplete = Convert.ToInt32(sqlReader["Mtl_Comple"]);
                        //    pInfo.Material_Complete = MaterialComplete == 1 ? "X" : String.Empty;

                        //    pInfo.Material_Location = "A1";

                        //    int ScadaRequired = Convert.ToInt32(sqlReader["DevRequired"]);
                        //    pInfo.SCADA_Required = ScadaRequired == 1 ? "X" : String.Empty;

                        //    int InstallRequired = Convert.ToInt32(sqlReader["CSIInstall"]);
                        //    pInfo.SCADA_Required = InstallRequired == 1 ? "X" : String.Empty;

                        //    ProductionJobInfoList.Add(pInfo);
                        //} // End While
                    }
                    sqlReader.Close();
                }
                catch (SqlException ex)
                {
                    string error = ex.ToString();
                   // items.Add( ex.ToString());
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();

                    // SessionVars.ProductionJobInfoList = ProductionJobInfoList;
                }
            } // end using
           
            return resultsList;
        }
        public static List<ProductionJobInfo> GetProductionInfoData()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("Select ProdTech, ProdOrder, Job_No, Rel_to_pro, Rqstd_shpg, PROJ_SHPG, Est_Time_, ACT_TIME, PERCENT_CO, Mtl_Comple, Mtl_loc, Prodnotes, DevRequired, CSIInstall from ");
            sb.Append("JobsDB where ProdOrder<>'' AND ProdTech<>'' Order by ProdTech,ProdOrder");

            //var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            List<ProductionJobInfo> ProductionJobInfoList = new List<ProductionJobInfo>();

            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))//connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();

                    // 
                    // Fill in the sites
                    //
                    SqlCommand sqlCommand = new SqlCommand(sb.ToString(), dbConnection);
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            ProductionJobInfo pInfo = new ProductionJobInfo();
                            pInfo.TechName = sqlReader["ProdTech"].ToString();
                            pInfo.Priority = Convert.ToInt32(sqlReader["ProdOrder"]);
                            pInfo.Job_Number = Convert.ToInt32(sqlReader["Job_No"]);

                            string strRFDateTime = sqlReader["Rel_to_pro"].ToString();
                            DateTime RFDateTime = DateTime.Now;
                            if (!string.IsNullOrEmpty(strRFDateTime))
                            {
                                if (DateTime.TryParse(strRFDateTime, out RFDateTime))
                                {
                                    pInfo.Release_For_Production_Date = RFDateTime.ToString("MM/dd/yy");
                                }
                                else
                                    pInfo.Release_For_Production_Date = string.Empty;
                            }

                            string EstimatedTime = sqlReader["Est_Time_"].ToString();
                            if (!string.IsNullOrEmpty(EstimatedTime))
                            {
                                string match = Regex.Match(EstimatedTime, @"\d+").Value;
                                pInfo.Hours_Estimated = int.Parse(match);
                            }

                            string HoursSpent = sqlReader["ACT_TIME"].ToString();
                            if (!string.IsNullOrEmpty(HoursSpent))
                            {
                                string match = Regex.Match(HoursSpent, @"\d+").Value;
                                pInfo.Hours_Spent = int.Parse(match);
                            }

                            pInfo.Percent_Complete = (pInfo.Hours_Spent * 100.0f) / (pInfo.Hours_Estimated * 1.0f);

                            int MaterialComplete = Convert.ToInt32(sqlReader["Mtl_Comple"]);
                            pInfo.Material_Complete = MaterialComplete == 1 ? "X" : String.Empty;

                             string material_loc = sqlReader["MTL_LOC"].ToString();     
                                 pInfo.Material_Location = (material_loc.Length > 15) ? material_loc.Substring(0, 12) : material_loc;
                               

                            int ScadaRequired = Convert.ToInt32(sqlReader["DevRequired"]);
                            pInfo.SCADA_Required = ScadaRequired == 1 ? "X" : String.Empty;

                            int InstallRequired = Convert.ToInt32(sqlReader["CSIInstall"]);
                            pInfo.SCADA_Required = InstallRequired == 1 ? "X" : String.Empty;


                            // ==================================================================================== Update Status Field
                            double reqDaysToship = 0;
                            double prodDaysToship = 0;

                            pInfo.Requested_Shipment_Date = String.Empty;
                            pInfo.Projected_Shipment_Date = "";

                            pInfo.Status = "";

                            // Read Requested Ship Date and calculate Days to ship (based upon this date):
                            try
                            {
                                string strReqShipmentDateTime = sqlReader["Rqstd_shpg"].ToString();
                                DateTime ReqShipmentDateTime = DateTime.Now;
                                if (!string.IsNullOrEmpty(strReqShipmentDateTime))
                                {
                                    if (DateTime.TryParse(strReqShipmentDateTime, out ReqShipmentDateTime))
                                    {
                                        reqDaysToship = ReqShipmentDateTime.Subtract(DateTime.Now).TotalDays;
                                        pInfo.Requested_Shipment_Date = ReqShipmentDateTime.ToString("MM/dd/yy");
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            // Read Production Estimated Shipping Date and calculate days to ship:
                            try
                            {
                                string strProjShipmentDateTime = sqlReader["PROJ_SHPG"].ToString();
                                DateTime ProjShipmentDateTime = DateTime.Now;
                                if (!string.IsNullOrEmpty(strProjShipmentDateTime))
                                {
                                    if (DateTime.TryParse(strProjShipmentDateTime, out ProjShipmentDateTime))
                                    {
                                        prodDaysToship = ProjShipmentDateTime.Subtract(DateTime.Now).TotalDays;
                                        pInfo.Projected_Shipment_Date = ProjShipmentDateTime.ToString("MM/dd/yy");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }


                            // Evaluate which data to use for estimated ship date:
                            if(pInfo.Projected_Shipment_Date != String.Empty) // Production data takes priority
                            {
                                //// If reqDaysToship > 1, then display this value, else display "ON HOLD"
                                //if (prodDaysToship < 10.0) // 10 days to update
                                //{
                                //    pInfo.Status = "ON HOLD"; // No status, assume "ON track and not late"
                                //    pInfo.ProdDaysToShip = "";
                                //}
                                //else
                                //{
                                    pInfo.ProdDaysToShip = prodDaysToship.ToString("0");
                               // }
                            } // Projected Shipment Date == NULL
                            else if (pInfo.Requested_Shipment_Date != String.Empty) // Use this date for estimate
                            {
                                if (reqDaysToship < -8.0) // 8 days to update
                                {
                                    pInfo.Status = "ON HOLD"; // No status, assume "ON track and not late"
                                    pInfo.ProdDaysToShip = "";
                                }
                                else
                                {
                                    pInfo.ProdDaysToShip = reqDaysToship.ToString("0");
                                }
                                
                            }


                            string prodnotes = sqlReader["ProdNotes"].ToString();

                            if (prodnotes.ToUpper().Contains("Status:[") == true)
                            {
                                 pInfo.Status = ExtractPattern("STATUS:[", "]", prodnotes.ToUpper());
                                 if (pInfo.Status.Length > 15)
                                 {
                                     pInfo.Status = pInfo.Status.Substring(0, 15);
                                 }
                            }
                         
                            ProductionJobInfoList.Add(pInfo);
                        }
                    }
                    sqlReader.Close();
                }
                catch (SqlException ex)
                {
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();

                    // SessionVars.ProductionJobInfoList = ProductionJobInfoList;
                }
            } // end using
            return ProductionJobInfoList;
        } // end method

        private static string ExtractPattern(string pattStart, string pattEnd, string inputString)
        {
            string text = "";
            int ilen = inputString.Length;

            inputString = inputString.ToUpper().Trim();

            if (ilen == 0 || pattStart.Length == 0 || pattEnd.Length == 0)
                return text;

            int i0 = inputString.IndexOf(pattStart) + pattStart.Length;
            int i1 = inputString.IndexOf(pattEnd) + pattEnd.Length;

            if (i1 > i0 && i1 <= ilen) // Extract
            {
                text = inputString.Substring(i0, i1 - i0 - 1);
            }

            return text;
        }
        public static List<ProductionJobInfo> GetProdTechRecords()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("Select ProdTech, ProdOrder, Job_No, Rel_to_pro, Rqstd_shpg, PROJ_SHPG, Est_Time_, ACT_TIME, PERCENT_CO, Mtl_Comple, DevRequired, CSIInstall from ");
            sb.Append("JobsDB where ProdOrder<>'' AND ProdTech<>'' Order by ProdTech,ProdOrder");

            //var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];

            List<ProductionJobInfo> ProductionJobInfoList = new List<ProductionJobInfo>();

            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))//connectionFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();

                    // 
                    // Fill in the sites
                    //
                    SqlCommand sqlCommand = new SqlCommand(sb.ToString(), dbConnection);
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            ProductionJobInfo pInfo = new ProductionJobInfo();
                            pInfo.TechName = sqlReader["ProdTech"].ToString();
                            pInfo.Priority = Convert.ToInt32(sqlReader["ProdOrder"]);
                            pInfo.Job_Number = Convert.ToInt32(sqlReader["Job_No"]);

                            string strRFDateTime = sqlReader["Rel_to_pro"].ToString();
                            DateTime RFDateTime = DateTime.Now;
                            if (!string.IsNullOrEmpty(strRFDateTime))
                            {
                                if (DateTime.TryParse(strRFDateTime, out RFDateTime))
                                {
                                    pInfo.Release_For_Production_Date = RFDateTime.ToString("MM/dd/yy");
                                }
                                else
                                    pInfo.Release_For_Production_Date = string.Empty;
                            }

                            string strReqShipmentDateTime = sqlReader["Rqstd_shpg"].ToString();
                            DateTime ReqShipmentDateTime = DateTime.Now;
                            if (!string.IsNullOrEmpty(strReqShipmentDateTime))
                            {
                                if (DateTime.TryParse(strReqShipmentDateTime, out ReqShipmentDateTime))
                                {
                                    pInfo.Requested_Shipment_Date = ReqShipmentDateTime.ToString("MM/dd/yy");
                                }
                                else
                                    pInfo.Requested_Shipment_Date = string.Empty;
                            }


                            string strProjShipmentDateTime = sqlReader["PROJ_SHPG"].ToString();
                            DateTime ProjShipmentDateTime = DateTime.Now;
                            if (!string.IsNullOrEmpty(strProjShipmentDateTime))
                            {
                                if (DateTime.TryParse(strProjShipmentDateTime, out ProjShipmentDateTime))
                                {
                                    pInfo.Projected_Shipment_Date = ProjShipmentDateTime.ToString("MM/dd/yy");
                                }
                                else
                                    pInfo.Projected_Shipment_Date = string.Empty;
                            }

                            string EstimatedTime = sqlReader["Est_Time_"].ToString();
                            if (!string.IsNullOrEmpty(EstimatedTime))
                            {
                                string match = Regex.Match(EstimatedTime, @"\d+").Value;
                                pInfo.Hours_Estimated = int.Parse(match);
                            }

                            string HoursSpent = sqlReader["ACT_TIME"].ToString();
                            if (!string.IsNullOrEmpty(HoursSpent))
                            {
                                string match = Regex.Match(HoursSpent, @"\d+").Value;
                                pInfo.Hours_Spent = int.Parse(match);
                            }

                            pInfo.Percent_Complete = (pInfo.Hours_Spent * 100.0f) / (pInfo.Hours_Estimated * 1.0f);

                            int MaterialComplete = Convert.ToInt32(sqlReader["Mtl_Comple"]);
                            pInfo.Material_Complete = MaterialComplete == 1 ? "X" : String.Empty;

                            pInfo.Material_Location = sqlReader["Mtl_Location"].ToString();

                            int ScadaRequired = Convert.ToInt32(sqlReader["DevRequired"]);
                            pInfo.SCADA_Required = ScadaRequired == 1 ? "X" : String.Empty;

                            int InstallRequired = Convert.ToInt32(sqlReader["CSIInstall"]);
                            pInfo.SCADA_Required = InstallRequired == 1 ? "X" : String.Empty;

                            ProductionJobInfoList.Add(pInfo);
                        }
                    }
                    sqlReader.Close();
                }
                catch (SqlException ex)
                {
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();

                    // SessionVars.ProductionJobInfoList = ProductionJobInfoList;
                }
            } // end using
            return ProductionJobInfoList;

        } // end method

        /// <summary>
        /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file,
        /// writes the specified string to the file, then closes the file.
        /// Creates the full file path if it doesn't exist.
        /// /// </summary>
        /// <param name="text">Text to append to file</param>
        /// <param name="fullFilePath">full file path for writing text including file name</param>
        /// <returns>
        /// Return error in writing, true = error
        /// </returns>
        public static bool AppendTextToFile(string text, string fullFilePath)
        {
            bool errors = false;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullFilePath));
                File.AppendAllText(fullFilePath, text);
            }
            catch (Exception exception)
            {
                errors = true;
            }
            return errors;
        }

    }
}