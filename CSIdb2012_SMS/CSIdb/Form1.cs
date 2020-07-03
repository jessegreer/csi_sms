using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;

using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Mail;
using System.Net;

namespace CSIdb
{
  

    public partial class Form1 : Form
    {
        private System.Threading.Timer updateTimer;
        private string strWeather = "";
        private bool togglescroll = true;
        private Thread workerThread = null;
        private bool workerThreadRunning = false;
        private List<ProductionJobInfo> sqlresults;

        int iviewState = 0;
        long timesecs = 0;
        long timesecsElapsed = 0;


        DataTable table = new DataTable(); // Data Source for DataGrid

        List<string> tags = new List<string>();
        const string CONNECTION_STRING = "Data Source=192.168.100.105;Initial Catalog=CSIDB;Persist Security Info=True;User ID=sa;Password=355csi8594";

        public Form1()
        {
            InitializeComponent();
            Database.GetTagValueUpdates(tags);
            
           
        }
        // On the form
        public void SetBindingSourceDataSource(object newDataSource)
        {
            if (InvokeRequired)
                Invoke(new Action<object>(SetBindingSourceDataSource), newDataSource);
            else
                this.dataGridView1.DataSource = newDataSource;
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DataGridViewRow row = this.dataGridView1.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Bisque;
            row.Height = 30;
            row.MinimumHeight = 20;
            splitContainer1.SplitterDistance = (int)(splitContainer1.Size.Height * 0.08);
            SetCellFontSizes();

            updateTimer = new System.Threading.Timer(timer_Elapsed, null, 0, Timeout.Infinite);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         //  TimerCallback timerDelegate = new TimerCallback(tick);
          //  updateTimer = new System.Threading.Timer(timerDelegate, null, 1000, 1000);
        }

  
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    label_TempF.Text = DateTime.Now.ToString();
        //    // Get Weather
        //            // ========== 15 min loop


        //    try
        //    {
        //        if (timesecs % 3000 == 0)
        //        {
        //            string details = "";
        //            weather w = new weather();
        //            int temperature = w.CheckWeather("Pearl,Mississippi", out details);
        //            //  int tempF = (int)((1.8f * temperature + 32.0f) + 0.5); // F
        //            //  richTextBox1.Text = "   CONTROL SYSTEMS Production Tracking           [Temperature Jackon,MS    " + temperature.ToString("0")+"]";

        //            label_currentTIme.Text = string.Format("{0}\u00B0F", temperature) + "    " + details;
        //        }
        //    }

        //    catch (Exception excp)
        //    {
        //        MessageBox.Show(excp.ToString()); // Remove
        //    }


        //    if (timesecs % 30 == 0)
        //    {
        //        // Get Data
        //        List<ProductionJobInfo> sqlresults = Database.GetProductionInfoData();
        //        DisplayResultsOnDataGrid(sqlresults);

        //        //// GetDataAndCopyToDataGrid();
        //        //if (workerThreadRunning == false)
        //        //{
        //        //    // Initialise and start worker thread
        //        //   this.workerThread = new Thread(new ThreadStart(this.GetDataAndCopyToDataGrid));
        //        //    this.workerThread.Start();
        //        //}
        //    }
         
        //    timesecs++;
        //}

 

        private void GetDataAndCopyToDataGrid()
        {
           // workerThreadRunning = true;
          //  timer1.Stop();


            // Disconnect and reset DataGridView
           // dataGridView1.DataSource = null;
          //  dataGridView1.SuspendLayout();
            this.Invoke((MethodInvoker)delegate
            {
                dataGridView1.Columns.Clear();
            });
          

            // Get data from SQL

            // Get Data
            List<ProductionJobInfo> sqlresults = Database.GetProductionInfoData();
            this.Invoke((MethodInvoker)delegate
            {
                DisplayResultsOnDataGrid(sqlresults);
            });


            this.Invoke((MethodInvoker)delegate
            {
                SetCellFontSizes();
            });

        }

        private void SetCellFontSizes()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {

               //     dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
              //      this.dataGridView1.DefaultCellStyle.Font = new Font("Ariel", 10);

                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                   this.dataGridView1.DefaultCellStyle.Font = new Font("Ariel", 18);

                   int icol = 0;
                   dataGridView1.EnableHeadersVisualStyles = false;
                   foreach (DataGridViewColumn col in dataGridView1.Columns)
                   {
                       col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                       col.HeaderCell.Style.Font = new Font("Ariel", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
                      // col.HeaderCell.Style.BackColor = Color.Yellow;
                       dataGridView1.Columns[icol++].HeaderCell.Style.BackColor = Color.Yellow;
                       // Centre (Column and Row) Headers    
                   }
                
                  
                 //  dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                 //  dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow; 
            }
           
            dataGridView1.ClearSelection();
        }


        private void DisplayResultsOnDataGrid(List<ProductionJobInfo> sqlresults)
        {
        //   DataTable tmptable = new DataTable();

                dataGridView1.Rows.Clear();


            if (dataGridView1.ColumnCount == 0)
            {
                string[] colLabels = { "TECH", "ORDR", "JOB#", "RFP", "RQSD SHPMT", "PROJ SHIPMT", "HRS EST", 
                                    "HRS SPENT", "%HRS_SPENT", "MATL LOC", "MATL CMPLT", "SCADA?", "INSTALL?", "Days2Ship", "Status" };
                int ilen = colLabels.Length;

                    try
                    {
                        dataGridView1.ColumnCount = ilen;
                        for (int i = 0; i < ilen; i++)
                        {
                            dataGridView1.Columns[i].Name = colLabels[i];
                        }
                    }

                    catch (Exception ecol1)
                    {
                        MessageBox.Show("ERROR creating columns.", "ERROR");
                    }

            }


            ProductionJobInfo[] data = sqlresults.ToArray();

            foreach (ProductionJobInfo row in data)
            {
                string strDaysToShip = " ";

             
                //                           0       1         2      3         4             5             6
                //  string[] colLabels = { "TECH", "ORDER", "JOB #", "RFP", "RQSD SHPMT", "PROJ SHIPMT", "HOURS EST", 
                //                        7               8             9           10           11           12        13      14
                //                     "HOURS SPENT", "% Complete", "MATL LOC", "MATL SCADA?", "INSTALL?", "DaysToShip", "Status" };

                try
                {

                    string[] strrow = {  row.TechName, // 0
                    row.Priority.ToString(), // 1
                    row.Job_Number.ToString(), // 2
                    row.Release_For_Production_Date, // 3
                    row.Requested_Shipment_Date, // 4 
                    row.Projected_Shipment_Date, // 5
                    row.Hours_Estimated.ToString(), // 6 
                    row.Hours_Spent.ToString(), // 7
                    row.Percent_Complete.ToString("0.0"), // 8
                    row.Material_Location, // 9
                    row.Material_Complete, // 10
                    row.SCADA_Required, // 11
                    row.Installation_Required,// 12
                    row.ProdDaysToShip, // Days to ship "CORRUPT", // 13
                    row.Status// Status // 14};
                                      };
                    
                    dataGridView1.Rows.Add(strrow);


                   // row.TechName, // 0
                   // row.Priority.ToString(), // 1
                   // row.Job_Number.ToString(), // 2
                   // row.Release_For_Production_Date, // 3
                   // row.Requested_Shipment_Date, // 4 
                   // row.Projected_Shipment_Date, // 5
                   // row.Hours_Estimated.ToString(), // 6 
                   // row.Hours_Spent.ToString(), // 7
                   // row.Percent_Complete.ToString("0.0"), // 8
                   // row.Material_Location, // 9
                   // row.Material_Complete, // 10
                   // row.SCADA_Required, // 11
                   // row.Installation_Required,// 12
                   // strDaysToShip, // Days to ship "CORRUPT", // 13
                   //" " // Status // 14
                   //  );
                }
                catch (Exception exprow)
                {
                  //  MessageBox.Show(exprow.ToString());
                }


            }

            return ;
        }

        private string ExtractPattern(string pattStart, string pattEnd, string inputString)
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

        private DataTable DisplayResultsOnDataTable(List<ProductionJobInfo> sqlresults)
        {
            DataTable tmptable = new DataTable();

            string[] colLabels = { "TECH", "ORDER", "JOB #", "RFP", "RQSD SHPMT", "PROJ SHIPMT", "HOURS EST", 
                                    "HOURS SPENT", "% Complete", "MATL LOC", "MATL CMPLT", "SCADA?", "INSTALL?", "DaysToShip", "Status" };
            int ilen = colLabels.Length;
            if (tmptable.Columns.Count == 0)
            {
                try
                {

                    for (int i = 0; i < ilen; i++)
                    {
                        tmptable.Columns.Add(colLabels[i], typeof(string));
                    }
                }

                catch (Exception ecol1)
                {
                    MessageBox.Show("ERROR creating columns.", "ERROR");
                }
            }



            ProductionJobInfo[] data = sqlresults.ToArray();

            uint rowIndex = 0;



            foreach (ProductionJobInfo row in data)
            {
                string strDaysToShip = " ";

                try
                {
                    if (row.Requested_Shipment_Date != null)
                    {
                        DateTime parsedDate = DateTime.Parse(row.Requested_Shipment_Date);
                        strDaysToShip = parsedDate.Subtract(DateTime.Now).Days.ToString();
                    }
                }
                catch (Exception ext)
                {
                }

                //                           0       1         2      3         4             5             6
                //  string[] colLabels = { "TECH", "ORDER", "JOB #", "RFP", "RQSD SHPMT", "PROJ SHIPMT", "HOURS EST", 
                //                        7               8             9           10           11           12        13      14
                //                     "HOURS SPENT", "% Complete", "MATL LOC", "MATL SCADA?", "INSTALL?", "DaysToShip", "Status" };

                try
                {
                    rowIndex = (uint)tmptable.Rows.Count;
                    tmptable.Rows.Add(
                    row.TechName, // 0
                    row.Priority.ToString(), // 1
                    row.Job_Number.ToString(), // 2
                    row.Release_For_Production_Date, // 3
                    row.Requested_Shipment_Date, // 4 
                    row.Projected_Shipment_Date, // 5
                    row.Hours_Estimated.ToString(), // 6 
                    row.Hours_Spent.ToString(), // 7
                    row.Percent_Complete.ToString("0.0"), // 8
                    row.Material_Location, // 9
                    row.Material_Complete, // 10
                    row.SCADA_Required, // 11
                    row.Installation_Required,// 12
                    strDaysToShip, // Days to ship "CORRUPT", // 13
                   " " // Status // 14
                     );
                }
                catch (Exception exprow)
                {
                    //  MessageBox.Show(exprow.ToString());
                }
            }

            return tmptable;
        }

        private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridView grd = sender as DataGridView;
            int RowIndex = e.RowIndex;
            try
            {
                if (RowIndex % 2 == 0)
                {
                    grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.LightBlue; // ColorFromHex("f0f4c3");
                }
                else
                {
                    grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.LightSteelBlue; //  ColorFromHex("050505");
                    
                }

                if (grd.Rows[RowIndex].Cells[13].Value != null)
                {
                    int days2ship = 0;
                    if(int.TryParse(grd.Rows[RowIndex].Cells[13].Value.ToString(), out days2ship)==true)
                    {
                                if (days2ship <= -20 ) // Warning: Delayed past 10 days
                                {
                                    grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Red;
                                    grd.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.White;
                                }
                                else if (days2ship > -20 && days2ship < -8 ) // Less than one week
                                {
                                    grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                                    grd.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.Black;

                                }
                    }
                
                }


                //if (grd.Rows[RowIndex].Cells[13].Value.ToString().ToUpper().Contains("CORR") == true) // Black Corrupt
                //{
                //    grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Black;
                //    grd.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.White;
                //}
                //else if (grd.Rows[RowIndex].Cells[13].Value.ToString().ToUpper().Contains("FAIL") == true && // Red = Good packet, but bad CRC
                //   (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("READREQ") == true || grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("READRESP") == true ||
                //     grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("WRITEREQ") == true || grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("WRITERESP") == true ||
                //    grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("PINGREQ") == true || grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("PINGRESP") == true))
                //{
                //    grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Red;
                //    grd.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.White;
                //}
                //else if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("READREQ") == true)
                //{
                //    grd.Rows[RowIndex].DefaultCellStyle.BackColor = ColorFromHex("d4e157");
                //}
                //else if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("READRESP") == true)
                //{
                //    grd.Rows[RowIndex].DefaultCellStyle.BackColor = ColorFromHex("f0f4c3");
                //}
                //else if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("WRITE") == true)
                //{
                //    if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("REQ") == true)
                //    {
                //        grd.Rows[RowIndex].DefaultCellStyle.BackColor = ColorFromHex("e3f2fd");
                //    }
                //    else if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("RESP") == true)
                //    {
                //        grd.Rows[RowIndex].DefaultCellStyle.BackColor = ColorFromHex("7986cb");
                //    }
                //}
                //else if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("PING") == true)
                //{
                //    if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("REQ") == true)
                //    {
                //        grd.Rows[RowIndex].DefaultCellStyle.BackColor = ColorFromHex("ffff8d");
                //    }
                //    else if (grd.Rows[RowIndex].Cells[8].Value.ToString().ToUpper().Contains("RESP") == true)
                //    {
                //        grd.Rows[RowIndex].DefaultCellStyle.BackColor = ColorFromHex("ffff00");
                //    }
                //}
                //else
                //{
                //    grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Black;
                //    grd.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.White;
                //}
            }
            catch (Exception etry)
            {
            }
        }
               private Color   ColorFromHex(string hexColor)
        {
         Color color = new Color();
         color = Color.White;
         if (hexColor.Length == 6)
         {
             byte a = byte.Parse(hexColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
             byte b = byte.Parse(hexColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
             byte c = byte.Parse(hexColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
             color = Color.FromArgb(a, b, c);
         }
         return color;

     }

               private void label1_Click(object sender, EventArgs e)
               {
                   // Debug code
                 //  SendEmailwithAttachment("jtgreer@controlsysinc.com", "CSI_NoReply@controlsysinc.com", "Test", "Body");


                   string htmlreport = "<H1> THIS IS A TEST OF THE CSI AUTOMATED EMAIL SYSTEM</H1>";// getHtml(dataGridView1);
                   Email(htmlreport);

                 //  List<ProductionJobInfo> sqlresults = Database.GetProductionInfoData();
                 //DisplayResultsOnDataGrid(sqlresults);
                 //  // SetBindingSourceDataSource(table);
                 
              
                 //  //this.Invoke((MethodInvoker)delegate
                 //  //{
                 //  //    dataGridView1.DataSource = table; // DEBUG REMOVE THESE TWO LINES
                 //  //    //   dataGridView1.Invalidate();
                 //  //    //  dataGridView1.Show();
                 //  //    // Thread.Sleep(1000);
                 //  //});

                 //  this.Invoke((MethodInvoker)delegate
                 //  {
                 //      SetCellFontSizes();
                 //  });





                 //  GetDataAndCopyToDataGrid();
                   // GetDataAndCopyToDataGrid();
                   //if (workerThreadRunning == false)
                   //{
                   //    // Initialise and start worker thread
                   //    this.workerThread = new Thread(new ThreadStart(this.GetDataAndCopyToDataGrid));
                   //    this.workerThread.Start();
                   //}

               }

               void timer_Elapsed(object state)
               {
                  // Thread.Sleep(1000);

                   try
                   {
                       if (timesecsElapsed % 300 == 0)  // Get weather every 5 mins:  
                       {
                           string details = "";
                           weather w = new weather();
                           int temperature = w.CheckWeather("Pearl,Mississippi", out details);
                           //  int tempF = (int)((1.8f * temperature + 32.0f) + 0.5); // F
                           //  richTextBox1.Text = "   CONTROL SYSTEMS Production Tracking           [Temperature Jackon,MS    " + temperature.ToString("0")+"]";

                           strWeather = string.Format("{0}\u00B0F", temperature) + "    " + details;
                       }
                   }

                   catch (Exception excp)
                   {
                       //  MessageBox.Show(excp.ToString()); // Remove
                   }


                   this.Invoke((MethodInvoker)delegate
                   {
                       label_TempF.Text = DateTime.Now.ToString();
                       label_currentTIme.Text = strWeather;
                   });


                   // =============================== Update: SQL Query every 15 mins
                   if (timesecsElapsed % 900 == 0)
                   {
                       GetDataAndCopyToDataGrid();
                   }

                   // Scroll top and bottom (in case we have over 30 rows)
                   if (timesecsElapsed % 15 == 0)
                   {
                        this.Invoke((MethodInvoker)delegate
                        {

                          //  if (dataGridView1.DataSource != null)
                         //   {
                                if (dataGridView1.Rows.Count > 28) // Use scroll control:
                                {
                                    if (togglescroll == true)
                                    {
                                        dataGridView1.FirstDisplayedScrollingRowIndex = 1;
                                        togglescroll = false;
                                    }
                                    else
                                    {
                                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                                        togglescroll = true;
                                    }
                                   
                                }
                           // }
                        });
             
                   }
                   timesecsElapsed++;

                   updateTimer.Change(1000, Timeout.Infinite);
               }


        // ================================== One Second Timer:
               private void timer1_Tick_1(object sender, EventArgs e)
               {
                     //    label_TempF.Text = DateTime.Now.ToString();
            // Get Weather
                    // ========== 15 min loop


            try
            {
                if (false) //timesecs % 3000 == 0)
                {
                    string details = "";
                    weather w = new weather();
                    int temperature = w.CheckWeather("Pearl,Mississippi", out details);
                    //  int tempF = (int)((1.8f * temperature + 32.0f) + 0.5); // F
                    //  richTextBox1.Text = "   CONTROL SYSTEMS Production Tracking           [Temperature Jackon,MS    " + temperature.ToString("0")+"]";

                    label_currentTIme.Text = string.Format("{0}\u00B0F", temperature) + "    " + details;
                }
            }

            catch (Exception excp)
            {
              //  MessageBox.Show(excp.ToString()); // Remove
            }

            if (timesecs % 30 == 0)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    GetDataAndCopyToDataGrid();
                });
               
            }

            //if (timesecs % 30 == 0)
            //{
            //    // Get Data
            //    List<ProductionJobInfo> sqlresults = Database.GetProductionInfoData();
            //    DisplayResultsOnDataGrid(sqlresults);

            //    //// GetDataAndCopyToDataGrid();
            //    //if (workerThreadRunning == false)
            //    //{
            //    //    // Initialise and start worker thread
            //    //    this.workerThread = new Thread(new ThreadStart(this.GetDataAndCopyToDataGrid));
            //    //    this.workerThread.Start();
            //    //}
            //}
         
            timesecs++;



                   //label_TempF.Text = DateTime.Now.ToString();
                   //// Get Weather
                   //// ========== 15 min loop

                   //try
                   //{
                   //    if (timesecs % 3000 == 0)
                   //    {
                   //        string details = "";
                   //        weather w = new weather();
                   //        int temperature = w.CheckWeather("Pearl,Mississippi", out details);
                   //        //  int tempF = (int)((1.8f * temperature + 32.0f) + 0.5); // F
                   //        //  richTextBox1.Text = "   CONTROL SYSTEMS Production Tracking           [Temperature Jackon,MS    " + temperature.ToString("0")+"]";

                   //        label_currentTIme.Text = string.Format("{0}\u00B0F", temperature) + "    " + details;
                   //    }
                   //}

                   //catch (Exception excp)
                   //{
                   //    MessageBox.Show(excp.ToString()); // Remove
                   //}


                   ////if (timemins % 30 == 0)
                   ////{
                   ////    // GetDataAndCopyToDataGrid();
                   ////    if (workerThreadRunning == false)
                   ////    {
                   ////        // Initialise and start worker thread
                   ////        this.workerThread = new Thread(new ThreadStart(this.GetDataAndCopyToDataGrid));
                   ////        this.workerThread.Start();
                   ////    }
                   ////}

                   //timesecs++;
               }

               private void updateEvent()
               {
                   label_TempF.Text = DateTime.Now.ToString();
               }


               public void Email(string htmlString)
               {
                   try
                   {
                       MailMessage message = new MailMessage();
                       SmtpClient smtp = new SmtpClient();
                       message.From = new MailAddress("CSI_NoReply@controlsysinc.com");
                     //  message.To.Add(new MailAddress("leslie@controlsysinc.com"));
                      // message.To.Add(new MailAddress("jtgreer@controlsysinc.com"));

                       message.Subject = "AUTOMATED EVENT: CSI Production Tracking Report" + ", Created:"+DateTime.Now.ToString();
                       message.IsBodyHtml = true; //to make message body as html  
                       message.Body = htmlString;
                       smtp.Port = 25; //SSL 465; //TLS 587;
                       smtp.Host = "smtp.gmail.com"; //for gmail host  
                       smtp.EnableSsl = true;
                       smtp.UseDefaultCredentials = false;
                       smtp.Credentials = new NetworkCredential("CSI_NoReply@controlsysinc.com", "6013558594");

                    //   Mail Server DNS = relay-hosting.secureserver.net
                    //    Mail Server TCP Port = 25
                     //  smtp.DeliveryMethod = SmtpDeliveryFormat.SevenBit;

                       smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                       smtp.Send(message);
                   }
                   catch (Exception ex) {
                       string error = ex.ToString();
                    //   MessageBox.Show(error);
                   }
               }

               public static string getHtml(DataGridView grid)
               {
                   try
                   {
                       string item = "";
                       string messageBody = "<font>CSI Automated Email Report for Production Tracking: </font><br><br>";
                       if (grid.RowCount == 0) return messageBody;
                       string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                       string htmlTableEnd = "</table>";
                       string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                       string htmlHeaderRowEnd = "</tr>";
                       string htmlTrStart = "<tr style=\"color:#555555;\">";
                       string htmlTrEnd = "</tr>";
                       string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                       string htmlTdEnd = "</td>";
                       messageBody += htmlTableStart;
                       messageBody += htmlHeaderRowStart;
                       //                        0       1       2        3        4              5             6 
                       string[] colLabels = { "TECH", "ORDER", "JOB #", "RFP", "RQSD SHPMT", "PROJ SHIPMT", "HOURS EST", 
                                    "HOURS SPENT", "% Complete", "MATL LOC", "MATL CMPLT", "SCADA?", "INSTALL?", "DaysToShip", "Status" };
                                     //    7             8           9           10           11         12          13           14
                       int ilen = colLabels.Length;
                       for (int i = 0; i < ilen; i++)
                       {
                           messageBody += htmlTdStart + colLabels[i] + htmlTdEnd;
                       }
 
                       messageBody += htmlHeaderRowEnd;
                       //Loop all the rows from grid vew and added to html td  
                       for (int i = 0; i <= grid.RowCount - 1; i++)
                       {
                           messageBody += htmlTrStart;
                           item = "";
                           if(grid.Rows[i].Cells[11].Value != null)
                            item = (string)grid.Rows[i].Cells[11].Value;

                           if (item.ToUpper().Contains("X") == true)
                           {
                               for (int j = 0; j < ilen; j++)
                               {
                                   messageBody += htmlTdStart + grid.Rows[i].Cells[j].Value + htmlTdEnd;
                               }
                           }

                           messageBody += htmlTrEnd;
                       }
                       messageBody += htmlTableEnd;
                       return messageBody; // return HTML Table as string from this function  
                   }
                   catch (Exception ex)
                   {
                       string error = ex.ToString();
                       return null;
                   }
               }


               private void SendEmailwithAttachment(string to, string from, string subject, string body)
               {
                   using (MailMessage mm = new MailMessage(from, to))
                   {
                       mm.Subject = subject;
                       mm.Body = body;
                       //if (postedFile.ContentLength > 0)
                       //{
                       //    string fileName = Path.GetFileName(postedFile.FileName);
                       //    mm.Attachments.Add(new Attachment(postedFile.InputStream, fileName));
                       //}
                       mm.IsBodyHtml = false;
                       SmtpClient smtp = new SmtpClient();
                       smtp.Host = "smtp.gmail.com";
                       smtp.EnableSsl = true;
                       NetworkCredential NetworkCred = new NetworkCredential("CSI_NoReply@controlsysinc.com", "6013558594");
                       smtp.UseDefaultCredentials = true;
                       smtp.Credentials = NetworkCred;
                       smtp.Port = 587;
                       try
                       {
                           smtp.Send(mm);
                       }
                       catch (Exception ex)
                       {
                           string error = ex.ToString();
                       }
                   }
               } // End send email

  } // End Form Class


    public class ProductionJobInfo
    {
        public string TechName;
        public int Priority;
        public int Job_Number;
        public string Release_For_Production_Date;
        public string Requested_Shipment_Date;
        public string Projected_Shipment_Date;
        public string ProdDaysToShip;
        public string ReqDaysToShip;
        public int Hours_Estimated;
        public int Hours_Spent;
        public float Percent_Complete;
        public string Material_Location;
        public string Material_Complete;
        public string SCADA_Required;
        public string Installation_Required;
        public string Production_Notes;
        public string Status;
    }
}
