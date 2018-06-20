namespace ManageHotel.UserControls
{
    partial class UserControlRoom
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
            this.labelRoomId = new System.Windows.Forms.Label();
            this.labelGuestCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddGuest = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // labelRoomId
            // 
            this.labelRoomId.AutoSize = true;
            this.labelRoomId.Location = new System.Drawing.Point(3, 14);
            this.labelRoomId.Name = "labelRoomId";
            this.labelRoomId.Size = new System.Drawing.Size(32, 13);
            this.labelRoomId.TabIndex = 11;
            this.labelRoomId.Text = "E001";
            // 
            // labelGuestCount
            // 
            this.labelGuestCount.AutoSize = true;
            this.labelGuestCount.Location = new System.Drawing.Point(232, 14);
            this.labelGuestCount.Name = "labelGuestCount";
            this.labelGuestCount.Size = new System.Drawing.Size(24, 13);
            this.labelGuestCount.TabIndex = 10;
            this.labelGuestCount.Text = "0/4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Guest:";
            // 
            // buttonAddGuest
            // 
            this.buttonAddGuest.Location = new System.Drawing.Point(526, 4);
            this.buttonAddGuest.Name = "buttonAddGuest";
            this.buttonAddGuest.Size = new System.Drawing.Size(75, 23);
            this.buttonAddGuest.TabIndex = 8;
            this.buttonAddGuest.Text = "Add";
            this.buttonAddGuest.UseVisualStyleBackColor = true;
            this.buttonAddGuest.Click += new System.EventHandler(this.buttonAddGuest_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(371, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(628, 64);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel1_ControlAdded);
            // 
            // UserControlRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelRoomId);
            this.Controls.Add(this.labelGuestCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddGuest);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UserControlRoom";
            this.Size = new System.Drawing.Size(638, 111);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoomId;
        private System.Windows.Forms.Label labelGuestCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddGuest;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    }
}
