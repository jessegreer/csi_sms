namespace CSIdb
{
    partial class SQLtestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLtestForm));
            this.textBox_EnterSQL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_SQLsubmit = new System.Windows.Forms.Button();
            this.richText_SQLresults = new System.Windows.Forms.RichTextBox();
            this.button_SubmitCannedSQL = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_ClearResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_EnterSQL
            // 
            this.textBox_EnterSQL.Location = new System.Drawing.Point(55, 39);
            this.textBox_EnterSQL.Multiline = true;
            this.textBox_EnterSQL.Name = "textBox_EnterSQL";
            this.textBox_EnterSQL.Size = new System.Drawing.Size(536, 78);
            this.textBox_EnterSQL.TabIndex = 0;
            this.textBox_EnterSQL.Text = "SELECT * FROM SYS.TABLES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter SQL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "SQL Results:";
            // 
            // button_SQLsubmit
            // 
            this.button_SQLsubmit.Location = new System.Drawing.Point(516, 123);
            this.button_SQLsubmit.Name = "button_SQLsubmit";
            this.button_SQLsubmit.Size = new System.Drawing.Size(75, 26);
            this.button_SQLsubmit.TabIndex = 4;
            this.button_SQLsubmit.Text = "Submit SQL";
            this.button_SQLsubmit.UseVisualStyleBackColor = true;
            this.button_SQLsubmit.Click += new System.EventHandler(this.button_SQLsubmit_Click);
            // 
            // richText_SQLresults
            // 
            this.richText_SQLresults.Location = new System.Drawing.Point(55, 155);
            this.richText_SQLresults.Name = "richText_SQLresults";
            this.richText_SQLresults.Size = new System.Drawing.Size(536, 178);
            this.richText_SQLresults.TabIndex = 5;
            this.richText_SQLresults.Text = "";
            // 
            // button_SubmitCannedSQL
            // 
            this.button_SubmitCannedSQL.Location = new System.Drawing.Point(620, 77);
            this.button_SubmitCannedSQL.Name = "button_SubmitCannedSQL";
            this.button_SubmitCannedSQL.Size = new System.Drawing.Size(161, 49);
            this.button_SubmitCannedSQL.TabIndex = 6;
            this.button_SubmitCannedSQL.Text = "Submit Canned SQL";
            this.button_SubmitCannedSQL.UseVisualStyleBackColor = true;
            this.button_SubmitCannedSQL.Click += new System.EventHandler(this.button_SubmitCannedSQL_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1) select * from sys.tables",
            "2) Select All Production tables",
            "3) Select  Job_No, Location, CSIInstall from JobsDB Order by Job_No",
            "4) Delete Job"});
            this.comboBox1.Location = new System.Drawing.Point(620, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button_ClearResults
            // 
            this.button_ClearResults.Location = new System.Drawing.Point(467, 339);
            this.button_ClearResults.Name = "button_ClearResults";
            this.button_ClearResults.Size = new System.Drawing.Size(124, 26);
            this.button_ClearResults.TabIndex = 8;
            this.button_ClearResults.Text = "Clear Results";
            this.button_ClearResults.UseVisualStyleBackColor = true;
            this.button_ClearResults.Click += new System.EventHandler(this.button_ClearResults_Click);
            // 
            // SQLtestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 386);
            this.Controls.Add(this.button_ClearResults);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_SubmitCannedSQL);
            this.Controls.Add(this.richText_SQLresults);
            this.Controls.Add(this.button_SQLsubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_EnterSQL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SQLtestForm";
            this.Text = "SQLtestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_EnterSQL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_SQLsubmit;
        private System.Windows.Forms.RichTextBox richText_SQLresults;
        private System.Windows.Forms.Button button_SubmitCannedSQL;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_ClearResults;
    }
}