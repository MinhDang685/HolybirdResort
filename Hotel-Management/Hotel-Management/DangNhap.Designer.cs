namespace Hotel_Management
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtSRNM = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPWD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Location = new System.Drawing.Point(455, 388);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 28);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập";
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
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.White;
            this.labelX3.Location = new System.Drawing.Point(411, 266);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(189, 54);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = " HolyBird Resort";
            // 
            // txtSRNM
            // 
            this.txtSRNM.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSRNM.Border.Class = "TextBoxBorder";
            this.txtSRNM.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSRNM.DisabledBackColor = System.Drawing.Color.White;
            this.txtSRNM.ForeColor = System.Drawing.Color.Black;
            this.txtSRNM.Location = new System.Drawing.Point(395, 314);
            this.txtSRNM.Margin = new System.Windows.Forms.Padding(4);
            this.txtSRNM.Name = "txtSRNM";
            this.txtSRNM.PreventEnterBeep = true;
            this.txtSRNM.Size = new System.Drawing.Size(219, 22);
            this.txtSRNM.TabIndex = 0;
            this.txtSRNM.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSRNM.WatermarkText = "Tên đăng nhập";
            this.txtSRNM.TextChanged += new System.EventHandler(this.txtboxPWD_TextChanged);
            // 
            // txtPWD
            // 
            this.txtPWD.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPWD.Border.Class = "TextBoxBorder";
            this.txtPWD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPWD.DisabledBackColor = System.Drawing.Color.White;
            this.txtPWD.ForeColor = System.Drawing.Color.Black;
            this.txtPWD.Location = new System.Drawing.Point(395, 346);
            this.txtPWD.Margin = new System.Windows.Forms.Padding(4);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PreventEnterBeep = true;
            this.txtPWD.Size = new System.Drawing.Size(219, 22);
            this.txtPWD.TabIndex = 0;
            this.txtPWD.UseSystemPasswordChar = true;
            this.txtPWD.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWD.WatermarkText = "Mật khẩu";
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 464);
            this.Controls.Add(this.txtSRNM);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DangNhap";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSRNM;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPWD;
    }
}

