namespace MYOB.PayRoll.UI
{
    partial class MYOBExercise
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelErrorMessage = new System.Windows.Forms.Label();
            this.buttonFileBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelErrorMessage);
            this.flowLayoutPanel1.Controls.Add(this.buttonFileBrowse);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(537, 227);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelErrorMessage
            // 
            this.labelErrorMessage.AutoSize = true;
            this.labelErrorMessage.Location = new System.Drawing.Point(5, 5);
            this.labelErrorMessage.Margin = new System.Windows.Forms.Padding(5);
            this.labelErrorMessage.MinimumSize = new System.Drawing.Size(455, 0);
            this.labelErrorMessage.Name = "labelErrorMessage";
            this.labelErrorMessage.Size = new System.Drawing.Size(455, 13);
            this.labelErrorMessage.TabIndex = 1;
            // 
            // buttonFileBrowse
            // 
            this.buttonFileBrowse.Location = new System.Drawing.Point(3, 26);
            this.buttonFileBrowse.Name = "buttonFileBrowse";
            this.buttonFileBrowse.Size = new System.Drawing.Size(162, 52);
            this.buttonFileBrowse.TabIndex = 0;
            this.buttonFileBrowse.Text = "Browse a csv or a dat file";
            this.buttonFileBrowse.UseVisualStyleBackColor = true;
            this.buttonFileBrowse.Click += new System.EventHandler(this.buttonFileBrowse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MYOBExercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 251);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MYOBExercise";
            this.Text = "MYOBExercise";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelErrorMessage;
        private System.Windows.Forms.Button buttonFileBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

