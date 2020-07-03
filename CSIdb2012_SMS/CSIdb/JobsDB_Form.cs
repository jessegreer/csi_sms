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
    public partial class JobsDB_Form : Form
    {
        private string selectedSearcSQL;
        public JobsDB_Form()
        {
            InitializeComponent();
            selectedSearcSQL = "";

        }

        private void button_FindJobs_Click(object sender, EventArgs e)
        {
            if (selectedSearcSQL.Length > 4)
            {
                MessageBox.Show(selectedSearcSQL);

            }
            else
            {
                MessageBox.Show("Plesae select Sort Index and try again.", "WARNING");
            }
        }

        private string GetSearchSQL(int index)
        {
            string sql = "";
        switch(index)
        {
        case  0:
            sql = "Select * from JobsDB order by Job_No Desc";
            break;
        case  1:
            sql = "Select * from JobsDB order by Location,State,Name";
            break;
        case  2:      
            sql = "Select * from JobsDB order by CustName,Location,Name";
        break;       
            sql = "Select * from JobsDB order by Name,Location";
        break;
         case  4:      
            sql = "Select * from JobsDB order by Cust_PO";
        break;
         case  5:     
            sql = "Select * from JobsDB order by Auto";
        break;
         case  6:       
            sql = "Select * from JobsDB order by ProjEng";
        break;
         case  7:
            sql = "Select * from JobsDB where Prodorder > '' order by ProdTech,ProdOrder,Job_No";
            break;
         case  8:
            sql = "Select * from JobsDB order by Mark,Location";
            break;
            default:
         break;
        }
            return sql;
        }

        private void OnListSelectChange(object sender, EventArgs e)
        {
            string sql = "";
            int isel = listBox_SortIndex.SelectedIndex;
            if (isel >= 0)
            {
                sql = GetSearchSQL(isel);
                if(sql.Length > 4)
                {
                    selectedSearcSQL = sql;
                }
               // MessageBox.Show(sql); // DEBUG REMOVE
            }
        }
    }
}
