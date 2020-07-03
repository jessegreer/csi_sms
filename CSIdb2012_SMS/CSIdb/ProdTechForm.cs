using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIdb
{
    public partial class ProdTechForm : Form
    {
        public ProdTechForm()
        {
            InitializeComponent();
        }

        private void goToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CopyDataGridView(DataGridView newView)
        {
            dataGridView1 = newView;
        }
        public void DisplayTechReportDataGrid(List<ProductionJobInfo> sqlresults)
        {
            //   DataTable tmptable = new DataTable();

            dataGridView1.Rows.Clear();




            if (dataGridView1.ColumnCount == 0)
            {
                string[] colLabels = { "TECH", "ORDER", "JOB #", "RFP", "RQSD SHPMT", "PROJ SHIPMT", "HOURS EST", 
                                    "HOURS SPENT", "% Complete", "MATL LOC", "MATL CMPLT", "SCADA?", "INSTALL?", "DaysToShip", "Status" };
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

            //  uint rowIndex = 0;

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
                    strDaysToShip, // Days to ship "CORRUPT", // 13
                    " "// Status // 14};
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

            return;
        }
        private void DisplayProdTechReport(List<ProductionJobInfo> prodTechRecords)
        {
            List<ProductionJobInfo> x = Database.GetProdTechRecords();
            foreach (ProductionJobInfo record in prodTechRecords)
            {

            }

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
                    int dayslate = 0;
                    if (int.TryParse(grd.Rows[RowIndex].Cells[13].Value.ToString(), out dayslate) == true)
                    {
                        if (dayslate < 0) // Warning: Expected Delivery < week
                        {
                            grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Red;
                            grd.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.White;
                        }
                        else if (dayslate < 7) // Less than one week
                        {
                            grd.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                            grd.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }

                }
            }
            catch (Exception etry)
            {
            }
        }
    }
}
