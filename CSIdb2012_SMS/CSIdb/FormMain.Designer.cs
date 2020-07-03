namespace CSIdb
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.textBox_Time = new System.Windows.Forms.TextBox();
            this.label_SMS = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteJob = new System.Windows.Forms.Button();
            this.buttonSearchJob = new System.Windows.Forms.Button();
            this.buttonModEditJob = new System.Windows.Forms.Button();
            this.button_CreateNewJob = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labeljobnum = new System.Windows.Forms.Label();
            this.buttonProdTechForm = new System.Windows.Forms.Button();
            this.buttonUserEdit = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_SCADAreports = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_GeneralReports = new System.Windows.Forms.Button();
            this.button_SQLtester = new System.Windows.Forms.Button();
            this.button_ProdDashboard = new System.Windows.Forms.Button();
            this.label_UserName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Version
            // 
            this.textBox_Version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_Version.Enabled = false;
            this.textBox_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Version.Location = new System.Drawing.Point(3, 14);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.Size = new System.Drawing.Size(180, 22);
            this.textBox_Version.TabIndex = 0;
            this.textBox_Version.Text = "Version A.1.0";
            this.textBox_Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Time
            // 
            this.textBox_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Time.Location = new System.Drawing.Point(752, 15);
            this.textBox_Time.Name = "textBox_Time";
            this.textBox_Time.Size = new System.Drawing.Size(180, 22);
            this.textBox_Time.TabIndex = 1;
            this.textBox_Time.Text = "<time>";
            this.textBox_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_SMS
            // 
            this.label_SMS.AutoSize = true;
            this.label_SMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SMS.Location = new System.Drawing.Point(206, 15);
            this.label_SMS.Name = "label_SMS";
            this.label_SMS.Size = new System.Drawing.Size(524, 25);
            this.label_SMS.TabIndex = 2;
            this.label_SMS.Text = "CONTROL SOFTWARE MANAGEMENT SYSTEM";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Yellow;
            this.groupBox1.Controls.Add(this.buttonDeleteJob);
            this.groupBox1.Controls.Add(this.buttonSearchJob);
            this.groupBox1.Controls.Add(this.buttonModEditJob);
            this.groupBox1.Controls.Add(this.button_CreateNewJob);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.labeljobnum);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(241, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 280);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Job Database";
            // 
            // buttonDeleteJob
            // 
            this.buttonDeleteJob.Location = new System.Drawing.Point(125, 213);
            this.buttonDeleteJob.Name = "buttonDeleteJob";
            this.buttonDeleteJob.Size = new System.Drawing.Size(228, 37);
            this.buttonDeleteJob.TabIndex = 5;
            this.buttonDeleteJob.Text = "Delete A Job";
            this.buttonDeleteJob.UseVisualStyleBackColor = true;
            // 
            // buttonSearchJob
            // 
            this.buttonSearchJob.Location = new System.Drawing.Point(125, 170);
            this.buttonSearchJob.Name = "buttonSearchJob";
            this.buttonSearchJob.Size = new System.Drawing.Size(228, 37);
            this.buttonSearchJob.TabIndex = 4;
            this.buttonSearchJob.Text = "Search For Job";
            this.buttonSearchJob.UseVisualStyleBackColor = true;
            // 
            // buttonModEditJob
            // 
            this.buttonModEditJob.Location = new System.Drawing.Point(125, 127);
            this.buttonModEditJob.Name = "buttonModEditJob";
            this.buttonModEditJob.Size = new System.Drawing.Size(228, 37);
            this.buttonModEditJob.TabIndex = 3;
            this.buttonModEditJob.Text = "Modify / Edit Job";
            this.buttonModEditJob.UseVisualStyleBackColor = true;
            this.buttonModEditJob.Click += new System.EventHandler(this.buttonModEditJob_Click);
            // 
            // button_CreateNewJob
            // 
            this.button_CreateNewJob.Location = new System.Drawing.Point(125, 84);
            this.button_CreateNewJob.Name = "button_CreateNewJob";
            this.button_CreateNewJob.Size = new System.Drawing.Size(228, 37);
            this.button_CreateNewJob.TabIndex = 2;
            this.button_CreateNewJob.Text = "Create New Job";
            this.button_CreateNewJob.UseVisualStyleBackColor = true;
            this.button_CreateNewJob.Click += new System.EventHandler(this.button_CreateNewJob_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(58, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(379, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // labeljobnum
            // 
            this.labeljobnum.AutoSize = true;
            this.labeljobnum.Location = new System.Drawing.Point(6, 31);
            this.labeljobnum.Name = "labeljobnum";
            this.labeljobnum.Size = new System.Drawing.Size(46, 16);
            this.labeljobnum.TabIndex = 0;
            this.labeljobnum.Text = "Job #";
            // 
            // buttonProdTechForm
            // 
            this.buttonProdTechForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProdTechForm.Location = new System.Drawing.Point(60, 370);
            this.buttonProdTechForm.Name = "buttonProdTechForm";
            this.buttonProdTechForm.Size = new System.Drawing.Size(173, 35);
            this.buttonProdTechForm.TabIndex = 4;
            this.buttonProdTechForm.Text = "Production Tech Form";
            this.buttonProdTechForm.UseVisualStyleBackColor = true;
            this.buttonProdTechForm.Click += new System.EventHandler(this.buttonProdTechForm_Click);
            // 
            // buttonUserEdit
            // 
            this.buttonUserEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUserEdit.Location = new System.Drawing.Point(741, 358);
            this.buttonUserEdit.Name = "buttonUserEdit";
            this.buttonUserEdit.Size = new System.Drawing.Size(173, 35);
            this.buttonUserEdit.TabIndex = 5;
            this.buttonUserEdit.Text = "Maintain Users";
            this.buttonUserEdit.UseVisualStyleBackColor = true;
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exit.ForeColor = System.Drawing.Color.White;
            this.button_Exit.Location = new System.Drawing.Point(392, 409);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(173, 35);
            this.button_Exit.TabIndex = 6;
            this.button_Exit.Text = "Exit Program";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_SCADAreports
            // 
            this.button_SCADAreports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SCADAreports.Location = new System.Drawing.Point(741, 399);
            this.button_SCADAreports.Name = "button_SCADAreports";
            this.button_SCADAreports.Size = new System.Drawing.Size(173, 35);
            this.button_SCADAreports.TabIndex = 7;
            this.button_SCADAreports.Text = "SCADA Reports";
            this.button_SCADAreports.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_GeneralReports
            // 
            this.button_GeneralReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_GeneralReports.Location = new System.Drawing.Point(741, 459);
            this.button_GeneralReports.Name = "button_GeneralReports";
            this.button_GeneralReports.Size = new System.Drawing.Size(173, 35);
            this.button_GeneralReports.TabIndex = 8;
            this.button_GeneralReports.Text = "General Reports";
            this.button_GeneralReports.UseVisualStyleBackColor = true;
            this.button_GeneralReports.Click += new System.EventHandler(this.button_GeneralReports_Click);
            // 
            // button_SQLtester
            // 
            this.button_SQLtester.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SQLtester.Location = new System.Drawing.Point(32, 42);
            this.button_SQLtester.Name = "button_SQLtester";
            this.button_SQLtester.Size = new System.Drawing.Size(151, 22);
            this.button_SQLtester.TabIndex = 9;
            this.button_SQLtester.Text = "SQL Tester (DEV ONLY)";
            this.button_SQLtester.UseVisualStyleBackColor = true;
            this.button_SQLtester.Click += new System.EventHandler(this.button_SQLtester_Click);
            // 
            // button_ProdDashboard
            // 
            this.button_ProdDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ProdDashboard.Location = new System.Drawing.Point(60, 424);
            this.button_ProdDashboard.Name = "button_ProdDashboard";
            this.button_ProdDashboard.Size = new System.Drawing.Size(173, 35);
            this.button_ProdDashboard.TabIndex = 10;
            this.button_ProdDashboard.Text = "Production Dashboard";
            this.button_ProdDashboard.UseVisualStyleBackColor = true;
            this.button_ProdDashboard.Click += new System.EventHandler(this.button_ProdDashboard_Click);
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UserName.Location = new System.Drawing.Point(379, 42);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(54, 16);
            this.label_UserName.TabIndex = 11;
            this.label_UserName.Text = "USER:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 521);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.button_ProdDashboard);
            this.Controls.Add(this.button_SQLtester);
            this.Controls.Add(this.button_GeneralReports);
            this.Controls.Add(this.button_SCADAreports);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.buttonUserEdit);
            this.Controls.Add(this.buttonProdTechForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_SMS);
            this.Controls.Add(this.textBox_Time);
            this.Controls.Add(this.textBox_Version);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "CSI Information, Tracking and Data System";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.TextBox textBox_Time;
        private System.Windows.Forms.Label label_SMS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDeleteJob;
        private System.Windows.Forms.Button buttonSearchJob;
        private System.Windows.Forms.Button buttonModEditJob;
        private System.Windows.Forms.Button button_CreateNewJob;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labeljobnum;
        private System.Windows.Forms.Button buttonProdTechForm;
        private System.Windows.Forms.Button buttonUserEdit;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_SCADAreports;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_GeneralReports;
        private System.Windows.Forms.Button button_SQLtester;
        private System.Windows.Forms.Button button_ProdDashboard;
        private System.Windows.Forms.Label label_UserName;
    }
}