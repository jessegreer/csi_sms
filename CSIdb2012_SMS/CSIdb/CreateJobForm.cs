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
    public partial class CreateJobForm : Form
    {
        public string suggestJobNum { get; set; }
        string userName = "";
            string emailHeader = "";
            string emailMsg = "";

        public CreateJobForm()
        {
            InitializeComponent();
            // Customer Name:
            string sql = "Select CustName From JobsDB Group By CustName Order By CustName";
            setComboDefaults(0, sql);
                         string[] emailList = { "Leslie@controlsysinc.com", "HarryM@controlsysinc.com",
                        "jeffs@controlsysinc.com", "MattB@controlsysinc.com", "RobbieB@controlsysinc.com",
                    "StevenH@controlsysinc.com", "ToddW@controlsysinc.com" };
            // Backlog Manager:
            sql = "Select Salesman From JobsDB Group By Salesman Order By Salesman";
            setComboDefaults(1, sql);

            // Project Engineer
            sql = "Select ProjEng From JobsDB Group By ProjEng Order By ProjEng";
            setComboDefaults(2, sql);

            // Set Order Create Date:
            textBox_EntryDate.Enabled = true;
            textBox_EntryDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            textBox_EntryDate.Enabled = false;

            userName = Environment.UserName; //  System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            textBox_CurrUser.Text = "USER:"+userName.ToUpper();
          //  textBox_CurrUser.Enabled = false;

        }
        private void setComboDefaults(int comboIndex, string sql)
        {
             //  string sql = "Select  Job_No, Location, State, Rqstd_shpg from JobsDB Order by Job_No DESC";
          //  string sql = "Select  Job_No, Location, State from JobsDB Order by Job_No DESC";

            List<string[]> combolist = Database.SQLquery(sql);

            if (comboIndex == 0)
                comboBox_CustName.Items.Clear();
            else if (comboIndex == 1)
                comboBox_BacklogMgr.Items.Clear();
            else if (comboIndex == 2)
                comboBox_ProgEng.Items.Clear();
            else
                return;

           // int count = 0;
            foreach (string[] row in combolist)
            {
                int ilen = row.Length;
                ilen = (ilen > 1000) ? 1000 : ilen;

                // string rowstring = "";
                // for (int i = 0; i < ilen; i++)
                // {

                //     rowstring += row[i];
                //     count++;

                // }

                string testStr = row[0].Trim();

                if (testStr != null && testStr.Length != 0 && testStr != "" && testStr != " " && !testStr.Contains("cancel"))
                {
                    if (comboIndex == 0)
                    {
                        comboBox_CustName.Items.Add(testStr);
                    }
                    else if (comboIndex == 1)
                    {
                        comboBox_BacklogMgr.Items.Add(testStr);
                    }
                    else if (comboIndex == 2)
                    {
                        comboBox_ProgEng.Items.Add(testStr);
                    }
                }
   
            }
        }
        public void SetEstJobNumber(string job)
        {
            textBox_jobnumber.Text = job;
            // Fill in the comboBoxes:

  
        }

        private void OnDateChange(object sender, EventArgs e)
        {
            textBox_reqShipDate.Text = dateTimePicker_ReqShip.Value.ToString("MM/dd/yyyy");
        }

        private void button_ExitNoSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_AddRecToDB_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            string xFields = "";
            string xVals = "";
          // Check that Request Job Number is entered, and not already in Database
             if(textBox_jobnumber.Text.Length <=2) // Error
             {
                 MessageBox.Show("Invalid Job Number field, please re-enter and try again.", "WARNING");
                 return;
             }


            // Create SQL Insert String:
        
        xFields = "(Job_No";
         xVals = "(" + textBox_jobnumber.Text;
    if( textBox_jobname.Text != "" ) {
        xFields +=  ",Location";
      //  Text2.Text = Replace(Text2.Text, "'", "''", 1) {
        xVals += ",'" + textBox_jobname.Text + "'";
    }
    // State 
    if(textBox_state.Text != "" ) {
        xFields += ",State";
        textBox_state.Text = textBox_state.Text.Replace( "'", "''");
        xVals += ",'" + textBox_state.Text + "'";
    }

    // Job Name
    if(textBox_jobname.Text != "" ) {
       xFields += ",Name";
        textBox_jobname.Text = textBox_jobname.Text.Replace( "'", "''");
        xVals += ",'" + textBox_jobname.Text + "'";
    }

    // Combo Customer Name
    if(comboBox_CustName.Text != "" ) {
       xFields += ",CustName";
        comboBox_CustName.Text = comboBox_CustName.Text.Replace( "'", "''");
        xVals +=  ",'" + comboBox_CustName.Text + "'";
    }

    // Combo Backlog Manager
    if(comboBox_BacklogMgr.Text != "" ) {
       xFields += ",Salesman";
        comboBox_BacklogMgr.Text = comboBox_BacklogMgr.Text.Replace( "'", "''");
        xVals +=  ",'" + comboBox_BacklogMgr.Text + "'";
    }

    // Order Entry Date
    if(textBox_EntryDate.Text != "" ) {
       xFields += ",[Date]";
        textBox_EntryDate.Text = textBox_EntryDate.Text.Replace( "'", "''");
        xVals +=  ",'" + textBox_EntryDate.Text  + "'";
    }

    // Customer PO 
    if(textBox_custPO.Text != "" ) {
       xFields +=  ",Cust_PO";
        textBox_custPO.Text = textBox_custPO.Text.Replace( "'", "''");
        xVals +=  ",'" + textBox_custPO.Text + "'";
    }

    // Combo Project Eng
        
    if(comboBox_ProgEng.Text != "" ) {
       xFields +=  ",ProjEng";
        comboBox_ProgEng.Text = comboBox_ProgEng.Text.Replace( "'", "''");
        xVals +=  ",'" + comboBox_ProgEng.Text + "'";
    }

    // Est Production Time
      numericUpDn_EstProdHours.Value.ToString("0");
      if (numericUpDn_EstProdHours.Value > 0)
      {
          xFields += ",Est_Time_";
          //  Text10.Text = Replace(Text10.Text, "'", "''", 1);
          xVals += ",'" + numericUpDn_EstProdHours.Value.ToString("0") + "'";
      }

    // CSI Components
        
    if(textBox_CSIprods.Text != "" ) {
       xFields +=  ",CSIComponents";
        textBox_CSIprods.Text = textBox_CSIprods.Text.Replace("'", "''");
        xVals +=  ",'" + textBox_CSIprods.Text + "'";
    }

    // Approval Required
    if(checkBox_aprovReq.Checked == true ) {
       xFields +=  ",Aprvl_Rqd";
        xVals +=  ",-1";
    }

    // Req Shipping Date
    
    if(textBox_reqShipDate.Text != "" ) {
       xFields +=  ",Rqstd_Shpg";
        textBox_reqShipDate.Text = textBox_reqShipDate.Text.Replace( "'", "''");
        xVals +=  ",'" + textBox_reqShipDate.Text  + "'";
    }

    // SCADA Req
    
    if(checkBox_SCADAreq.Checked == true) {
       xFields +=  ",DEVREQUIRED";
        xVals +=  ",-1";
       xFields +=  ",SCADACheckoutReady";    //'added 8/31/12
        xVals +=  ",0";
       xFields +=  ",SCADACheckoutComplete"; //'added 8/31/12
        xVals +=  ",0";
    }
    else {
       xFields +=  ",SCADACheckoutReady";    //'added 8/31/12
        xVals +=  ",0";
       xFields +=  ",SCADACheckoutComplete"; //'added 8/31/12
        xVals +=  ",0";
    }

    // HMI Required
    if(checkBox_HMIreq.Checked == true) {
       xFields +=  ",HMIReq";
        xVals +=  ",-1";
       xFields +=  ",HMIType";
        xVals +=  ",'" + comboBox_HMItype.Text + "'";
       xFields +=  ",HMIDateAssigned";
        xVals +=  ",'" + textBox_EntryDate.Text + "'";
       xFields +=  ",HMIActive";
        xVals +=  ",-1";
       xFields +=  ",HMIAuthor";
        xVals +=  ",'" + userName + "'";
       xFields +=  ",HMIPriority";
        xVals +=  ",-1";
       xFields +=  ",HMIComplete";
        xVals +=  ",0";
       xFields +=  ",CTUComplete";  //'added 8/31/12
        xVals +=  ",0";
       xFields +=  ",RTUComplete";  //'added 8/31/12
        xVals +=  ",0";
       xFields +=  ",PLCComplete" ;// 'added 8/31/12
        xVals +=  ",0";
    } else {
       xFields +=  ",HMIComplete";
        xVals +=  ",0";
       xFields +=  ",CTUComplete";  //'added 8/31/12
        xVals +=  ",0";
       xFields +=  ",RTUComplete";  //'added 8/31/12
        xVals +=  ",0";
       xFields +=  ",PLCComplete";  //'added 8/31/12
        xVals +=  ",0";
    }

   // Radio Required
    if(checkBox_radioReq.Checked == true ) {
       xFields +=  ",RADIOReq";
        xVals +=  ",-1";
    }

     // CSI Installation Req   
    if(checkBox_CSIinstReq.Checked == true) {
       xFields +=  ",CSIInstall";
        xVals +=  ",-1";
    }

    // CSI Startup Req   
    if(checkBox_CSIstartup.Checked == true) {
       xFields +=  ",CSIStartup";
        xVals +=  ",-1";
    }
    
   xFields +=  ")";
    xVals +=  ")";

    //'''
    //''' Begin addition 08-07-2018
    //'''
    strSQL = "Select Count(*) from JobsDB Where Job_NO = " + textBox_jobnumber.Text;
     List<string[]> sqlResults0 = Database.SQLquery(strSQL);
            // Append to test file for analysis. Remove 
     if (sqlResults0.Count > 0)
     {
         string[] xr = sqlResults0[0].ToArray();
         // Database.AppendTextToFile(sqldebug, @"C:\CSI_DEV\CSIdb\testsql.txt");
         if (xr[0].Length > 0)
         {
             int iret = -1;
             if(int.TryParse(xr[0], out iret))
             {
                 if (iret != 0)
                 {
                     MessageBox.Show("This job alread exists. Try again. N=" + iret, "WARNING"); // REMOVE DEBUG
                     return;
                 }
             }
             else
             {
                  MessageBox.Show("Error reading this job, or does not exist. Try again.", "WARNING"); // REMOVE DEBUG
             }
         }
            
     }
    //Set CmbCd = New ADODB.Command
    //Set CmbRs = New ADODB.Recordset
    
    //CmbCd.ActiveConnection = frmMain.MSCnn
    //CmbCd.CommandType = adCmdText
    //CmbCd.CommandText = strSQL
    //CmbRs.Open CmbCd
    //if(CmbRs.RecordCount > 0 ) {
    //    MsgBox "Given Job Number " + Text1.Text + " is already in use. Please choose another job number for this job!", vbOKOnly
    //    CmbRs.Close
    //    Set CmbRs = Nothing
    //    Set CmbCd = Nothing
    //    Exit Sub
    //}
    //CmbRs.Close
    //Set CmbRs = Nothing
    //Set CmbCd = Nothing
    //'''
    //''' End addition 08-07-2018
    //'''


  //  Screen.MousePointer = vbHourglass
    strSQL = "Insert Into JobsDB " + xFields + " values " + xVals;
            MessageBox.Show(strSQL, "DEBUG"); // REMOVE DEBUG
            Database.AppendTextToFile("\n "+DateTime.Now.ToString()+"\n" + strSQL + "\n", @"C:\CSI_DEV\CSIdb\testsql.txt");

            List<string[]> sqlResults1 = Database.SQLquery(strSQL);
            if (sqlResults1.Count > 0)
            {
                string[] xr = sqlResults1[0].ToArray();
                // Database.AppendTextToFile(sqldebug, @"C:\CSI_DEV\CSIdb\testsql.txt");
                if (xr.Length > 0)
                {

                    string ret = "";
                    for (int i = 0; i < xr.Length; i++)
                        ret += xr[i] + "\n";
                    MessageBox.Show("Query Results=" + ret, "WARNING"); // REMOVE DEBUG

                }
            }
        return;
    //'MsgBox strSql
    //frmMain.MSCnn.BeginTrans
    //frmMain.MSCnn.Execute strSQL
    //frmMain.MSCnn.CommitTrans
    

    // HMI Required: Send Email Notificaitons

            
         // Base Header   
        emailHeader = "New Job Number Added:" + textBox_jobnumber.Text + ", " + textBox_location.Text;
        emailMsg = "Job Number: " + textBox_jobnumber.Text + "\n" +
                 "Job Name: " +  textBox_jobname.Text + "\n" +
                 "Job Location: " + textBox_location.Text + ", " + textBox_state.Text + "\n" +
                 "Customer Name: " + comboBox_CustName.Text + "\n";
             MessageBox.Show("BASE:"+emailHeader + "\n MESSAGE:\n"+emailMsg, "DEBUG"); // REMOVE DEBUG
            
    if( checkBox_HMIreq.Checked == true || checkBox_SCADAreq.Checked == true ) 
    {

        emailHeader += ", Requires SCADA/HMI";
        emailMsg +=  "\n Has been designated as requiring SCADA Development by " + userName + ".";
         MessageBox.Show("SCADA:"+emailHeader + "\n MESSAGE:\n"+emailMsg, "DEBUG"); // REMOVE DEBUG

        //varHeader = "Job Number " + textBox_jobnumber.Text + ", " + textBox_location.Text + " Requires SCADA Development";
        //varMsg = "Job Number: " + textBox_jobnumber.Text + "\n" +
        //         "Job Name: " +  textBox_jobname.Text + "\n" +
        //         "Job Location: " + textBox_location.Text + ", " + textBox_state.Text + "\n" +
        //         "Customer Name: " + comboBox_CustName.Text + "\n" +
        //         "Has been designated as requiring SCADA Development by " + userName + ".";


    }
           
            
    // HMI Required: Send Emails
    if(checkBox_HMIreq.Checked == true ) 
    {

        
     //   emailHeader = "Job Number " + textBox_jobnumber.Text + ", " + textBox_location.Text + " Requires HMI Development";
//'        varMsg = "Job Number " + textBox_jobnumber.Text + ", " + textBox_location.Text + " has been designated as requiring HMI Development by " + userName + ".\n" +
//'           "  The HMI type is requested to be " + comboBox_HMItype.Text + ".";

        emailMsg += "\nHas been designated as requiring SCADA Development by " + userName + "." +
           "\n The HMI type requested: " + comboBox_HMItype.Text + ".";
                 MessageBox.Show("SCADA:"+emailHeader + "\n MESSAGE:\n"+emailMsg, "DEBUG"); // REMOVE DEBUG

        //        varMsg = "Job Number: " + textBox_jobnumber.Text + "\n" +
        //         "Job Name: " +  textBox_jobname.Text + "\n" +
        //         "Job Location: " + textBox_location.Text + ", " + textBox_state.Text + "\n" +
        //         "Customer Name: " + comboBox_CustName.Text + "\n" +
        //         "Has been designated as requiring SCADA Development by " + userName + ".";

        //varMsg = "Job Number: " + textBox_jobnumber.Text + "\n" +
        //         "Job Name: " + Text4.Text + "\n" +
        //         "Job Location: " + Text2.Text + ", " + Text3.Text + "\n" +
        //         "Customer Name: " + Combo1.Text + "\n" +
        //         "Has been designated as requiring HMI Development by " + varCurrentUser + "." +
        //         "The HMI type is requested to be " + Combo4.Text + ".";
                 

    }


    // Radio(s) Required: Add info to email
            
    if(checkBox_radioReq.Checked == true )
    {

       emailMsg +=  "\n Has been designated as requiring RF RADIO(s) by " + userName + ".";
    }
        //varHeader = "Job Number " + Text1.Text + ", " + Text2.Text + " Requires Radio"
        //varMsg = "Job Number " + Text1.Text + ", " + Text2.Text + " has been designated as requiring a RADIO by " + varCurrentUser + "."
        
        //varMsg = "Job Number: " + Text1.Text + "\m" + _
        //         "Job Name: " + Text4.Text + "\m" + _
        //         "Job Location: " + Text2.Text + ", " + Text3.Text + "\m" + _
        //         "Customer Name: " + Combo1.Text + "\m" + _
             
                 

    

  // CSI Installation Required
       
    if(checkBox_CSIinstReq.Checked == true )
    {
          emailMsg += "\n Has been designated as requiring installation by " + userName + ".";
    }
    //    varHeader = "Job Number " + Text1.Text + ", " + Text2.Text + " Requires CSI Installation"
    //    varMsg = "Job Number " + Text1.Text + ", " + Text2.Text + " has been designated as requiring installation by " + varCurrentUser + "."
        
    //    varMsg = "Job Number: " + Text1.Text + "\m" + _
    //             "Job Name: " + Text4.Text + "\m" + _
    //             "Job Location: " + Text2.Text + ", " + Text3.Text + "\m" + _
    //             "Customer Name: " + Combo1.Text + "\m" + _
    //             "Has been designated as requiring installation by " + varCurrentUser + "."
        
    //    MailNotify CLng(Text1.Text) {, varCurrentUser, varHeader, varMsg, "HarryM@controlsysinc.com"
    //    MailNotify CLng(Text1.Text) {, varCurrentUser, varHeader, varMsg, "Phillip@controlsysinc.com"
//    }
    
//'    strMsg = MsgBox("Does this job require SCADA development?  Please choose Yes or No.", vbYesNo, "SCADA Development Required")
//'    if(strMsg = vbYes ) {
//'        strSql = "Update JobsDB set DEVREQUIRED=1 where Job_No=" + Text1.Text
//'        frmMain.MSCnn.BeginTrans
//'        frmMain.MSCnn.Execute strSql
//'        frmMain.MSCnn.CommitTrans
//'        Screen.MousePointer = vbHourglass
//'        varHeader = "Job Number " + Text1 + ", " + Text2 + " Requires SCADA Development"
//'        varMsg = "Job Number " + Text1 + ", " + Text2 + " has been designated as requiring SCADA Development by " + varCurrentUser
//'        'Debug.Print Text1.Text, varCurrentUser, varHeader, varMsg
//'
//'        MailNotify CLng(Text1.Text), varCurrentUser, varHeader, varMsg, "ScadaDevelopement@controlsysinc.com"
//'    }
    

 //  MessageBox.Show("An error has occurred.  Please check to make sure all information if valid and that "
 //   + "the job does not already exist.  Click Cancel if you do not wish to correct this job entry.",  "Error In Job Creation")
          string[] sendList = { "jtgreer@controlsysinc.com" };
          CEmail.SendEmail(sendList, "NoReply@controlsysinc.com", emailHeader, emailMsg, false);
   
        }  // End Submit New Job to DB

        private void textBox_CurrUser_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] sendList = { "jtgreer","richards","leslie","danielb","davidb","robbieb","jeffs","mattb","williamp","stevenh","toddw","phillips","bobe",
                                "bobbyt","installation","graywilliams"};
            string subject = "CSI AUTOMATED EMAIL: MESSAGE ALERT";
            string body = "You are on our CSI/SMS notification list to receive an automated alert when a new CSI Job is created.\n";
            body += "I am currently re-writing the old VB6 program and creating an equivilent C# program.\n";
            body += " This will allow us to maintain, modify, and fix issues with our CSI SMS fairly easy.\n\n";
            body += " As we get the system up and running, we will add USER PERMISSIONS, mainly controlled by USER PROFILES\n";
            body += " and DEPARTMENTS.\n";
            body += "For example, Managers usually receive full reports, while others, based upon DEPT, etc. (with unsubscribe option).\n";
            body += "Current Email list catagories: ENGINEERING, PRODUCTION, SCADA, INSTALLATION, SERVICE, PLC, HMI, etc.\n";
            body += "Note: Our testing will be limited to Job Numbers 150 to 199, therefore, if you get a test email in this range,\n";
            body += " you know this is for testing and review only.\n\n";
            body += " Thanks, JT Greer\n";
            body += " PS: You can respond to CSI_NoReply@controlsysinc.com during our testing period for comments, email list requests, etc.\n";
            bool OK = CEmail.SendEmail(sendList, "NoReply@controlsysinc.com", subject, body, false);
            if (OK == false)
                MessageBox.Show("EMAIL FAILED");
            else
            {
                MessageBox.Show(subject);
                MessageBox.Show(body);
            }
               
        } 
    }
}
