namespace KBSRules
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
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_broswe = new System.Windows.Forms.Button();
            this.gv_Data = new System.Windows.Forms.DataGridView();
            this.nud_Support = new System.Windows.Forms.NumericUpDown();
            this.lbl_Support = new System.Windows.Forms.Label();
            this.lbl_Confidence = new System.Windows.Forms.Label();
            this.nud_Confidence = new System.Windows.Forms.NumericUpDown();
            this.btn_Generate = new System.Windows.Forms.Button();
            this.gv_Attributes = new System.Windows.Forms.DataGridView();
            this.lbl_Classify = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lbl_From = new System.Windows.Forms.Label();
            this.lbl_To = new System.Windows.Forms.Label();
            this.lbl_Transition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Support)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Confidence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Attributes)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(116, 47);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(513, 20);
            this.txt_path.TabIndex = 0;
            // 
            // btn_broswe
            // 
            this.btn_broswe.Location = new System.Drawing.Point(21, 45);
            this.btn_broswe.Name = "btn_broswe";
            this.btn_broswe.Size = new System.Drawing.Size(75, 23);
            this.btn_broswe.TabIndex = 1;
            this.btn_broswe.Text = "Browse";
            this.btn_broswe.UseVisualStyleBackColor = true;
            this.btn_broswe.Click += new System.EventHandler(this.btn_broswe_Click);
            // 
            // gv_Data
            // 
            this.gv_Data.AllowUserToAddRows = false;
            this.gv_Data.AllowUserToDeleteRows = false;
            this.gv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Data.Location = new System.Drawing.Point(21, 118);
            this.gv_Data.Name = "gv_Data";
            this.gv_Data.ReadOnly = true;
            this.gv_Data.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gv_Data.RowHeadersVisible = false;
            this.gv_Data.Size = new System.Drawing.Size(437, 240);
            this.gv_Data.TabIndex = 2;
            // 
            // nud_Support
            // 
            this.nud_Support.DecimalPlaces = 2;
            this.nud_Support.Location = new System.Drawing.Point(578, 119);
            this.nud_Support.Name = "nud_Support";
            this.nud_Support.Size = new System.Drawing.Size(100, 20);
            this.nud_Support.TabIndex = 3;
            // 
            // lbl_Support
            // 
            this.lbl_Support.AutoSize = true;
            this.lbl_Support.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Support.Location = new System.Drawing.Point(481, 119);
            this.lbl_Support.Name = "lbl_Support";
            this.lbl_Support.Size = new System.Drawing.Size(63, 17);
            this.lbl_Support.TabIndex = 4;
            this.lbl_Support.Text = "Support:";
            // 
            // lbl_Confidence
            // 
            this.lbl_Confidence.AutoSize = true;
            this.lbl_Confidence.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Confidence.Location = new System.Drawing.Point(481, 160);
            this.lbl_Confidence.Name = "lbl_Confidence";
            this.lbl_Confidence.Size = new System.Drawing.Size(85, 17);
            this.lbl_Confidence.TabIndex = 5;
            this.lbl_Confidence.Text = "Confidence:";
            // 
            // nud_Confidence
            // 
            this.nud_Confidence.DecimalPlaces = 2;
            this.nud_Confidence.Location = new System.Drawing.Point(578, 160);
            this.nud_Confidence.Name = "nud_Confidence";
            this.nud_Confidence.Size = new System.Drawing.Size(100, 20);
            this.nud_Confidence.TabIndex = 6;
            // 
            // btn_Generate
            // 
            this.btn_Generate.Location = new System.Drawing.Point(303, 441);
            this.btn_Generate.Name = "btn_Generate";
            this.btn_Generate.Size = new System.Drawing.Size(132, 23);
            this.btn_Generate.TabIndex = 7;
            this.btn_Generate.Text = "Generate Rules";
            this.btn_Generate.UseVisualStyleBackColor = true;
            this.btn_Generate.Click += new System.EventHandler(this.btn_Generate_Click);
            // 
            // gv_Attributes
            // 
            this.gv_Attributes.AllowUserToAddRows = false;
            this.gv_Attributes.AllowUserToDeleteRows = false;
            this.gv_Attributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Attributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gv_Attributes.Location = new System.Drawing.Point(484, 250);
            this.gv_Attributes.Name = "gv_Attributes";
            this.gv_Attributes.RowHeadersVisible = false;
            this.gv_Attributes.Size = new System.Drawing.Size(219, 108);
            this.gv_Attributes.TabIndex = 8;
            // 
            // lbl_Classify
            // 
            this.lbl_Classify.AutoSize = true;
            this.lbl_Classify.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Classify.Location = new System.Drawing.Point(481, 230);
            this.lbl_Classify.Name = "lbl_Classify";
            this.lbl_Classify.Size = new System.Drawing.Size(154, 17);
            this.lbl_Classify.TabIndex = 10;
            this.lbl_Classify.Text = "Classify The Attributes:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(221, 404);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(413, 404);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 12;
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Location = new System.Drawing.Point(180, 407);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(33, 13);
            this.lbl_From.TabIndex = 13;
            this.lbl_From.Text = "From:";
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Location = new System.Drawing.Point(372, 407);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(23, 13);
            this.lbl_To.TabIndex = 14;
            this.lbl_To.Text = "To:";
            // 
            // lbl_Transition
            // 
            this.lbl_Transition.AutoSize = true;
            this.lbl_Transition.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Transition.Location = new System.Drawing.Point(258, 375);
            this.lbl_Transition.Name = "lbl_Transition";
            this.lbl_Transition.Size = new System.Drawing.Size(228, 17);
            this.lbl_Transition.TabIndex = 15;
            this.lbl_Transition.Text = "Select Desired Decision Transition:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 476);
            this.Controls.Add(this.lbl_Transition);
            this.Controls.Add(this.lbl_To);
            this.Controls.Add(this.lbl_From);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_Classify);
            this.Controls.Add(this.gv_Attributes);
            this.Controls.Add(this.btn_Generate);
            this.Controls.Add(this.nud_Confidence);
            this.Controls.Add(this.lbl_Confidence);
            this.Controls.Add(this.lbl_Support);
            this.Controls.Add(this.nud_Support);
            this.Controls.Add(this.gv_Data);
            this.Controls.Add(this.btn_broswe);
            this.Controls.Add(this.txt_path);
            this.Name = "Form1";
            this.Text = "Action Rule Miner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Support)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Confidence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Attributes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_broswe;
        private System.Windows.Forms.DataGridView gv_Data;
        private System.Windows.Forms.NumericUpDown nud_Support;
        private System.Windows.Forms.Label lbl_Support;
        private System.Windows.Forms.Label lbl_Confidence;
        private System.Windows.Forms.NumericUpDown nud_Confidence;
        private System.Windows.Forms.Button btn_Generate;
        private System.Windows.Forms.DataGridView gv_Attributes;
        private System.Windows.Forms.Label lbl_Classify;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.Label lbl_Transition;

    }
}

