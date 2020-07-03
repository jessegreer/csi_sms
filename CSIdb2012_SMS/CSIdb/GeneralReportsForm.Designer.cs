namespace CSIdb
{
    partial class GeneralReportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralReportsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button_createReport = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "General Reports";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "CSI Jobsheet By Customer",
            "CSI Jobsheet By Job Number",
            "CSI Jobsheet By Location",
            "CSI Jobsheet By Job Name",
            "CSI Jobsheet By Customer",
            "CSI Job By Territory",
            "CSI Customer History Report",
            "Production Tracking (Non-SCADA and Non-Installation)",
            "SCADA Jobs",
            "Job Tracking Installation",
            "CSI Jobsheet By Engineer"});
            this.checkedListBox1.Location = new System.Drawing.Point(25, 49);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(201, 229);
            this.checkedListBox1.TabIndex = 1;
            // 
            // button_createReport
            // 
            this.button_createReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_createReport.Location = new System.Drawing.Point(25, 310);
            this.button_createReport.Name = "button_createReport";
            this.button_createReport.Size = new System.Drawing.Size(201, 38);
            this.button_createReport.TabIndex = 2;
            this.button_createReport.Text = "Create and Show Report";
            this.button_createReport.UseVisualStyleBackColor = true;
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.Location = new System.Drawing.Point(83, 371);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(79, 38);
            this.button_exit.TabIndex = 3;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // GeneralReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 421);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_createReport);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralReportsForm";
            this.Text = "GeneralReportsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button_createReport;
        private System.Windows.Forms.Button button_exit;
    }
}