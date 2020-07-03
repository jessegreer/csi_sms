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
    public partial class FormMain : Form
    {
        public List<string> tags = new List<string>();
        private const string CONNECTION_STRING = "Data Source=192.168.100.105;Initial Catalog=CSIDB;Persist Security Info=True;User ID=sa;Password=355csi8594";
        private string estNextJobNumber = "";
        private string userName = "";

        public FormMain()
        {
            InitializeComponent();
            string sql = "Select  Job_No, Location, State, Rqstd_shpg from JobsDB Order by Job_No DESC";
          //  string sql = "Select  Job_No, Location, State from JobsDB Order by Job_No DESC";

            List<string[]> combolistJobLoc = Database.SQLquery(sql);
            comboBox1.Items.Clear();
            int count = 0;
            foreach (string[] row in combolistJobLoc)
            {
                int ilen = row.Length;
                ilen = (ilen > 1000) ? 1000 : ilen;

                string rowstring = "";
                for (int i = 0; i < ilen; i++)
                {
                    if (i == 0) // Get Max Job Number
                    {
                        if (count == 0 && row[i].Length > 0)
                        {
                            estNextJobNumber = row[0].Trim();
                        }
                    }

                    count++;
                    rowstring += row[i].Replace("12:00:00 AM", "").Trim() +"  ";
                }
                comboBox1.Items.Add(rowstring);

                // Get and display UserName:
                userName = Environment.UserName.ToUpper();
                label_UserName.Text = "USER:"+userName;
            }

            //Dictionary<string,object> x=  Database.GetTagValueUpdates(tags);
          //  string res = "";
          //  foreach( string key in x.Keys)
          //  {
          //      res += key + "\n";
          //  }
          //  MessageBox.Show(res);
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
         //   List<ProductionJobInfo> sqlresults = Database.GetProductionInfoData();

        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox_Time.Text = DateTime.Now.ToString();
        }

      

        private DataGridView CreateProdTechReport()
        {
            DataGridView retView = new DataGridView();

           //List<ProductionJobInfo> recordList =  Database.GetProdTechRecords();

           //// Get Data
           //List<ProductionJobInfo> sqlresults = Database.GetProductionInfoData();
           //this.Invoke((MethodInvoker)delegate
           //{
           //    DisplayResultsOnDataGrid(sqlresults);
           //});
            return retView;
        }

        private void button_CreateNewJob_Click(object sender, EventArgs e)
        {
            // Get Job Number from combobox
            int isel = (int)comboBox1.SelectedIndex;
            
            if (isel < 0) // Error
            {
                string jb = comboBox1.Text;
                if (jb.Length > 0)
                    estNextJobNumber = jb;
            }
            else
            {
                string selectedJob = comboBox1.Items[isel].ToString();
              //  MessageBox.Show(selectedJob);
            }
           

          
            CreateJobForm frm = new CreateJobForm();
            frm.SetEstJobNumber(estNextJobNumber);
            frm.ShowDialog();
        }

        private void button_GeneralReports_Click(object sender, EventArgs e)
        {
            GeneralReportsForm frm = new GeneralReportsForm();
            frm.ShowDialog();
        }

        private void button_SQLtester_Click(object sender, EventArgs e)
        {
            SQLtestForm frm = new SQLtestForm();
            frm.Show();
        }

        private void buttonProdTechForm_Click(object sender, EventArgs e)
        {
            //  DataGridView  newDataTable = CreateProdTechReport();
            //  List<ProductionJobInfo> sqlResults = Database.GetProductionInfoData();
            List<ProductionJobInfo> recordList = Database.GetProdTechRecords();
            ProdTechForm frm = new ProdTechForm();
            frm.DisplayTechReportDataGrid(recordList);
            frm.Show();
        }
        private void button_ProdDashboard_Click(object sender, EventArgs e)
        {
            //  DataGridView  newDataTable = CreateProdTechReport();
            //  List<ProductionJobInfo> sqlResults = Database.GetProductionInfoData();
            List<ProductionJobInfo> recordList = Database.GetProductionInfoData();
            ProdTechForm frm = new ProdTechForm();
            frm.DisplayTechReportDataGrid(recordList);
            frm.Show();
        }

        private void buttonModEditJob_Click(object sender, EventArgs e)
        {
            JobsDB_Form frm = new JobsDB_Form();
            frm.Show();
        }


    }
}
