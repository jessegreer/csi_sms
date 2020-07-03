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
    public partial class SQLtestForm : Form
    {
        public SQLtestForm()
        {
            InitializeComponent();
            textBox_EnterSQL.Text = "SELECT * FROM Production";
        }

        private void button_SQLsubmit_Click(object sender, EventArgs e)
        {
           
          
         List<string[]> results = ExeSQLandReturnListResults(textBox_EnterSQL.Text);
         string SQLresults = "";

         richText_SQLresults.Text = results.Count.ToString() ;

          //foreach(string[] row in results)
          //{
          //    int ilen = row.Length;

          //    for (int i = 0; i < ilen; i++)
          //    {
          //        SQLresults += row[i] + ",";
          //    }

          //    SQLresults += "\n"; // End of row
             
          //}
          //richText_SQLresults.Text = SQLresults;
        }

        private List<string[]> ExeSQLandReturnListResults(string sql)
        {
            List<string[]> Results = new List<string[]>();

            try
            {
                Results = Database.SQLquery(textBox_EnterSQL.Text);
            }
            catch (Exception ex)
            {
            }
            return Results;
        }

        private void button_SubmitCannedSQL_Click(object sender, EventArgs e)
        {
            int isel =(int)comboBox1.SelectedIndex+1;
            switch (isel)
            {
                case 1:
                    textBox_EnterSQL.Text = "Select * sys.Tables";
                    break;

                case 2:
                     System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("Select ProdTech, ProdOrder, Job_No, Rel_to_pro, Rqstd_shpg, PROJ_SHPG, Est_Time_, ACT_TIME, PERCENT_CO, Mtl_Comple, DevRequired, CSIInstall from ");
            sb.Append("JobsDB where ProdOrder<>'' AND ProdTech<>'' Order by ProdTech,ProdOrder");
                    textBox_EnterSQL.Text = sb.ToString();
                    break;

                case 3:
                    textBox_EnterSQL.Text = "Select  Job_No, Location, CSIInstall from JobsDB Order by Job_No DESC";
                    break;
                case 4: 
                    textBox_EnterSQL.Text = "Delete from JobsDB where Job_No=150";
                    break;
                default:
                    textBox_EnterSQL.Text = "ERROR";
                    break;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
         
        }

        private void button_ClearResults_Click(object sender, EventArgs e)
        {
            richText_SQLresults.Text = "";
        }
    }
}
