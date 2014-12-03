namespace KBSRules
{
    partial class ActionRulesDisplay
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
            this.tb_results = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_results
            // 
            this.tb_results.Location = new System.Drawing.Point(23, 12);
            this.tb_results.Multiline = true;
            this.tb_results.Name = "tb_results";
            this.tb_results.Size = new System.Drawing.Size(670, 433);
            this.tb_results.TabIndex = 0;
            // 
            // ActionRulesDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 476);
            this.Controls.Add(this.tb_results);
            this.Name = "ActionRulesDisplay";
            this.Text = "Association Action Rules";
            this.Load += new System.EventHandler(this.ActionRulesDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_results;
    }
}