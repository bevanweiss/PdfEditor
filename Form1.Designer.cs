namespace PDFCleaner
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbRemoveJavascript = new System.Windows.Forms.CheckBox();
            this.cbReplaceText = new System.Windows.Forms.CheckBox();
            this.tbReplaceMatch = new System.Windows.Forms.TextBox();
            this.tbReplaceReplace = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbRedactMatch = new System.Windows.Forms.TextBox();
            this.cbRedactText = new System.Windows.Forms.CheckBox();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 175);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(534, 263);
            this.dataGridView1.TabIndex = 1;
            // 
            // cbRemoveJavascript
            // 
            this.cbRemoveJavascript.AutoSize = true;
            this.cbRemoveJavascript.Checked = true;
            this.cbRemoveJavascript.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveJavascript.Location = new System.Drawing.Point(15, 38);
            this.cbRemoveJavascript.Name = "cbRemoveJavascript";
            this.cbRemoveJavascript.Size = new System.Drawing.Size(119, 17);
            this.cbRemoveJavascript.TabIndex = 2;
            this.cbRemoveJavascript.Text = "Remove JavaScript";
            this.cbRemoveJavascript.UseVisualStyleBackColor = true;
            // 
            // cbReplaceText
            // 
            this.cbReplaceText.AutoSize = true;
            this.cbReplaceText.Location = new System.Drawing.Point(15, 82);
            this.cbReplaceText.Name = "cbReplaceText";
            this.cbReplaceText.Size = new System.Drawing.Size(90, 17);
            this.cbReplaceText.TabIndex = 3;
            this.cbReplaceText.Text = "Replace Text";
            this.cbReplaceText.UseVisualStyleBackColor = true;
            this.cbReplaceText.CheckedChanged += new System.EventHandler(this.cbReplaceText_CheckedChanged);
            // 
            // tbReplaceMatch
            // 
            this.tbReplaceMatch.Location = new System.Drawing.Point(111, 80);
            this.tbReplaceMatch.Name = "tbReplaceMatch";
            this.tbReplaceMatch.Size = new System.Drawing.Size(275, 20);
            this.tbReplaceMatch.TabIndex = 4;
            // 
            // tbReplaceReplace
            // 
            this.tbReplaceReplace.Location = new System.Drawing.Point(111, 103);
            this.tbReplaceReplace.Name = "tbReplaceReplace";
            this.tbReplaceReplace.Size = new System.Drawing.Size(275, 20);
            this.tbReplaceReplace.TabIndex = 5;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(423, 146);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(123, 23);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Process Files";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Path";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(47, 12);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(301, 20);
            this.tbPath.TabIndex = 10;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(355, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbRedactMatch
            // 
            this.tbRedactMatch.Location = new System.Drawing.Point(111, 57);
            this.tbRedactMatch.Name = "tbRedactMatch";
            this.tbRedactMatch.Size = new System.Drawing.Size(275, 20);
            this.tbRedactMatch.TabIndex = 13;
            // 
            // cbRedactText
            // 
            this.cbRedactText.AutoSize = true;
            this.cbRedactText.Location = new System.Drawing.Point(15, 59);
            this.cbRedactText.Name = "cbRedactText";
            this.cbRedactText.Size = new System.Drawing.Size(85, 17);
            this.cbRedactText.TabIndex = 12;
            this.cbRedactText.Text = "Redact Text";
            this.cbRedactText.UseVisualStyleBackColor = true;
            this.cbRedactText.CheckedChanged += new System.EventHandler(this.cbRedactText_CheckedChanged);
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 450);
            this.Controls.Add(this.tbRedactMatch);
            this.Controls.Add(this.cbRedactText);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.tbReplaceReplace);
            this.Controls.Add(this.tbReplaceMatch);
            this.Controls.Add(this.cbReplaceText);
            this.Controls.Add(this.cbRemoveJavascript);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "PDF Cleaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbRemoveJavascript;
        private System.Windows.Forms.CheckBox cbReplaceText;
        private System.Windows.Forms.TextBox tbReplaceMatch;
        private System.Windows.Forms.TextBox tbReplaceReplace;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbRedactMatch;
        private System.Windows.Forms.CheckBox cbRedactText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
    }
}

