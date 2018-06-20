namespace ManageHotel.UserControls
{
    partial class UserControlGuest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRemoveGuest = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRemoveGuest
            // 
            this.buttonRemoveGuest.Location = new System.Drawing.Point(72, 2);
            this.buttonRemoveGuest.Name = "buttonRemoveGuest";
            this.buttonRemoveGuest.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveGuest.TabIndex = 5;
            this.buttonRemoveGuest.Text = "Remove";
            this.buttonRemoveGuest.UseVisualStyleBackColor = true;
            this.buttonRemoveGuest.Click += new System.EventHandler(this.buttonRemoveGuest_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 41);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(121, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "IIG Vietnam TOEIC Test";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(3, 16);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(55, 13);
            this.labelId.TabIndex = 3;
            this.labelId.Text = "12345678";
            // 
            // UserControlGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonRemoveGuest);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelId);
            this.Name = "UserControlGuest";
            this.Size = new System.Drawing.Size(148, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemoveGuest;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelId;
    }
}
