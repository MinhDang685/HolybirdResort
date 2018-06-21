namespace Hotel_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtBoxUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtBoxPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Location = new System.Drawing.Point(341, 315);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.TextColor = System.Drawing.Color.Black;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(58, 23);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(391, 60);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = " HolyBird Resort";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBoxUserName.Border.Class = "TextBoxBorder";
            this.txtBoxUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBoxUserName.DisabledBackColor = System.Drawing.Color.White;
            this.txtBoxUserName.ForeColor = System.Drawing.Color.Black;
            this.txtBoxUserName.Location = new System.Drawing.Point(296, 255);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.PreventEnterBeep = true;
            this.txtBoxUserName.Size = new System.Drawing.Size(164, 20);
            this.txtBoxUserName.TabIndex = 0;
            this.txtBoxUserName.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUserName.WatermarkText = "Username";
            this.txtBoxUserName.TextChanged += new System.EventHandler(this.txtboxPWD_TextChanged);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBoxPassword.Border.Class = "TextBoxBorder";
            this.txtBoxPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBoxPassword.DisabledBackColor = System.Drawing.Color.White;
            this.txtBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.txtBoxPassword.Location = new System.Drawing.Point(296, 281);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PreventEnterBeep = true;
            this.txtBoxPassword.Size = new System.Drawing.Size(164, 20);
            this.txtBoxPassword.TabIndex = 0;
            this.txtBoxPassword.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword.WatermarkText = "Password ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(501, 377);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.btnLogin);
            this.Name = "Form1";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBoxUserName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBoxPassword;
    }
}

